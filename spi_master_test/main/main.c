#include "slave.h"
#include "type.h"
#include "data.h"
#include "cJson.h"
#include "json_data.h"
#include "string.h"
#include "wifi.h"
#include "firebase.h"
WORD_ALIGNED_ATTR uint8_t spi_rx_static_buf[SIZE_BUFFER] = {0};
//Called after a transaction is queued and ready for pickup by master. We use this to set the handshake line high.
float voltage[NUMBER_CELLS] = {0};
float temperature[NUMBER_CELLS] = {0};
float current[NUMBER_CURRENT] = {0};
bool status_voltage[NUMBER_CELLS] = {false};
bool status_temperature[NUMBER_CELLS] = {false};
bool status_current[NUMBER_CELLS] = {false};
bool status_pheripheral[NUMBER_CELLS] = {false};
bool status_blance[NUMBER_CELLS] = {false};
// table package
float capacity_package[NUMBER_PACKAGE] = {0};
float temperature_package[NUMBER_PACKAGE] = {0};
float current_package[NUMBER_PACKAGE] = {0};
bool blancing_package[NUMBER_PACKAGE] = {false};

CONNECT_STATUS connect_package[NUMBER_PACKAGE] = {DISCONNECT};
bool warning_package[NUMBER_PACKAGE] = {false};
//
int counter_read_success = 0;
int counter_read_fail = 0;
float voltage_package_1 = 0;
float voltage_package_2 = 0;
// -----for http client-----
char *buffer_read;
int buffer_read_index = 0;
// -----for  manage task ----
xSemaphoreHandle connectionSemaphore;
//----for config slave spi ----
spi_slave_transaction_t rcv;
TaskHandle_t *task_wifi;
TaskHandle_t *task_firebase;
void my_post_setup_cb(spi_slave_transaction_t *trans)
{
    WRITE_PERI_REG(GPIO_OUT_W1TS_REG, (1 << GPIO_HANDSHAKE));
}

//Called after transaction is sent/received. We use this to set the handshake line low.
void my_post_trans_cb(spi_slave_transaction_t *trans)
{
    WRITE_PERI_REG(GPIO_OUT_W1TC_REG, (1 << GPIO_HANDSHAKE));
}
// event handler for wifi
esp_err_t event_handler(void *ctx, system_event_t *event)
{
    switch (event->event_id)
    {
    case SYSTEM_EVENT_STA_START:
        esp_wifi_connect();
        ESP_LOGI(TAG_WIFI, "connecting...\n");
        break;

    case SYSTEM_EVENT_STA_CONNECTED:
        ESP_LOGI(TAG_WIFI, "connected\n");
        break;

    case SYSTEM_EVENT_STA_GOT_IP:
        ESP_LOGI(TAG_WIFI, "got ip\n");
        xSemaphoreGive(connectionSemaphore);
        break;

    case SYSTEM_EVENT_STA_DISCONNECTED:
        ESP_LOGI(TAG_WIFI, "disconnected\n");
        break;

    default:
        break;
    }
    return ESP_OK;
}
// task after wifi connect
void request_receive_toSTM(void *para)
{
    while (true)
        {
        ESP_LOGI(TAG_WIFI,"GO TO WIFI TASK");
        // take semphore when connnected
        if (xSemaphoreTake(connectionSemaphore, 10000 / portTICK_RATE_MS)){
            ESP_LOGI(TAG_STM, "Processing");
            slave_read(spi_rx_static_buf, rcv, 1);
            if (check_infor(spi_rx_static_buf))
            {
                counter_read_success++;
                ESP_LOGW(TAG_STM, "Received true format %d\n", counter_read_success);
                ESP_LOGI(TAG_FIREBASE, "Start send to firebase");
                ESP_LOGW(TAG_FIREBASE, "Send to server firebase in time [%d] \n", xTaskGetTickCount());
                get_all();
                update_table_package(voltage, temperature, current, status_blance, status_pheripheral);
                char *json_battery = create_battery_infor(voltage,
                                                          temperature,
                                                          status_blance,
                                                          status_voltage,
                                                          status_temperature,
                                                          NUMBER_CELLS);
                char *json_package = create_package_infor(capacity_package,
                                                          temperature_package,
                                                          current_package,
                                                          blancing_package,
                                                          connect_package,
                                                          warning_package, NUMBER_PACKAGE);
                char *json_pheripheral = create_pheripheral_infor(status_pheripheral);
                char *json_temperature = create_battery_temperature(temperature, NUMBER_CELLS);
                char *json_voltage = create_battery_voltage(voltage, NUMBER_CELLS);
                char *json_current = create_battery_current(current_package, NUMBER_CURRENT);
                char *json_voltage_warning = create_voltage_warning(status_voltage, NUMBER_CELLS);
                char *json_temperature_warning = create_temperature_warning(status_temperature, NUMBER_CELLS);
                http_put(URL_BATTERY_CELLS, json_battery);
                http_put(URL_BATTERY_PACKAGES, json_package);
                http_put(URL_PHERIPHERALS, json_pheripheral);
                // http_put(URL_VOLTAGE_CELLS, json_voltage);
                // http_put(URL_TEMPERATURE_CELLS, json_temperature);
                // http_put(URL_CURRENT_PACKAGE, json_current);
                // http_put(URL_WARNING_VOLTAGE, json_voltage_warning);
                // http_put(URL_WARNING_TEMPERATURE, json_temperature_warning);
               
            }
            else
            {
                counter_read_fail++;
                ESP_LOGE(TAG_STM, "Received fail format %d\n", counter_read_fail);
            }
            ESP_LOGI(TAG_STM, "Done!");
        }
        else
        {
            ESP_LOGE(TAG_WIFI, "Failed to connect. Retry in");
            for (int i = 0; i < 2; i++)
            {
                ESP_LOGE(TAG_WIFI, "...%d", i);
                vTaskDelay(1000 / portTICK_RATE_MS);
            }
            ESP_LOGE(TAG_WIFI, "Can not connect to wifi");
            esp_restart();
        }
         vTaskDelay(3000 / portTICK_RATE_MS);
                 xSemaphoreGive(connectionSemaphore);
    }
}
void send_to_firebase()
{
    while (true)
    {
        ESP_LOGI(TAG_FIREBASE,"GO TO FIREBASE TASK");
        if (xSemaphoreTake(connectionSemaphore, 10000 / portTICK_RATE_MS))
        {
            vTaskSuspend(task_wifi);
           
            //xSemaphoreGive(connectionSemaphore);
        }
    }
}
void app_main(void *ignore)
{
    esp_log_level_set(TAG, ESP_LOG_DEBUG);
    connectionSemaphore = xSemaphoreCreateBinary();
    ESP_LOGI("START ESP", "test_spi_task");
    spi_slave_transaction_t rcv = slave_config();

    wifiInit();
    xTaskCreate(&request_receive_toSTM, "handle receive", 1024 * 10, NULL, 10,task_wifi );
    //xTaskCreate(&send_to_firebase, "handle firebase", 1024 * 10, NULL, 5, task_firebase);
}