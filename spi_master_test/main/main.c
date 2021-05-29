#include "slave.h"
#include "type.h"
#include "data.h"
#include "cJson.h"
#include "json_data.h"
#include "string.h"
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
void my_post_setup_cb(spi_slave_transaction_t *trans)
{
    WRITE_PERI_REG(GPIO_OUT_W1TS_REG, (1 << GPIO_HANDSHAKE));
}

//Called after transaction is sent/received. We use this to set the handshake line low.
void my_post_trans_cb(spi_slave_transaction_t *trans)
{
    WRITE_PERI_REG(GPIO_OUT_W1TC_REG, (1 << GPIO_HANDSHAKE));
}
void app_main(void *ignore)
{
    esp_log_level_set(TAG, ESP_LOG_DEBUG);
    ESP_LOGI(TAG, ">> test_spi_task");
    spi_slave_transaction_t rcv = slave_config();
    for (int i = 0; i < 1; i++)
    {
        slave_read(spi_rx_static_buf, rcv, i + 1);

        if (check_infor(spi_rx_static_buf))
        {
            counter_read_success++;
            ESP_LOGI(TAG, "Received true format \n");
            get_all();
            print_all_infor();
            update_table_package(voltage, temperature, current, status_blance, status_pheripheral);
            print_infor_table_package();
            char *json_battery = create_battery_infor(voltage,
                                                    temperature,
                                                    status_blance,
                                                    status_voltage,
                                                    status_temperature,
                                                    NUMBER_CELLS);
            char* json_package = create_package_infor(capacity_package,
                                temperature_package,
                                current_package,
                                blancing_package,
                                connect_package,
                                warning_package,NUMBER_PACKAGE);
            printf("json file: %s \n",json_battery);
            printf("json file: %s \n",json_package);

        }
        else
        {
            counter_read_fail++;
            ESP_LOGI(TAG, "Received fail format \n");
        }
        vTaskDelay(1000 / portTICK_PERIOD_MS);
    }
    ESP_LOGI(TAG, "Times read success: %d, Times read fail: %d", counter_read_success, counter_read_fail);
    ESP_LOGI(TAG, "... Removing device.");
    //ESP_ERROR_CHECK(spi_bus_remove_device(handle1));
    ESP_LOGI(TAG, "... Freeing bus.");
    //ESP_ERROR_CHECK(spi_bus_free(VSPI_HOST));
    ESP_LOGD(TAG, "<< test_spi_task");
    vTaskDelete(NULL);
}