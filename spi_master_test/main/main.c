#include"slave.h"
#include"type.h"
#include"data.h"
WORD_ALIGNED_ATTR uint8_t spi_rx_static_buf[SIZE_BUFFER]={0};
//Called after a transaction is queued and ready for pickup by master. We use this to set the handshake line high.
float voltage[NUMBER_VOLTAGE] ={0};
float temperature[NUMBER_TEMPERATURE] ={0};
float current[NUMBER_CURRENT] ={0};
bool status_voltage[NUMBER_VOLTAGE] ={false};
bool status_temperature[NUMBER_TEMPERATURE] ={false};
bool status_current[NUMBER_CURRENT] ={false};
bool status_pheripheral[NUMBER_PHERIPHERAL] ={false};
bool status_blance[NUMBER_VOLTAGE] ={false};

void my_post_setup_cb(spi_slave_transaction_t *trans) {
    WRITE_PERI_REG(GPIO_OUT_W1TS_REG, (1<<GPIO_HANDSHAKE));
}

//Called after transaction is sent/received. We use this to set the handshake line low.
void my_post_trans_cb(spi_slave_transaction_t *trans) {
    WRITE_PERI_REG(GPIO_OUT_W1TC_REG, (1<<GPIO_HANDSHAKE));
}
void app_main(void *ignore)
{
    esp_log_level_set(TAG,ESP_LOG_DEBUG);
    ESP_LOGI(TAG, ">> test_spi_task");
    spi_slave_transaction_t rcv = slave_config();
    // for (int i = 0; i < 100; i++)
    // {
        slave_read(spi_rx_static_buf,rcv,1);
        get_all();
        print_all_infor();
        vTaskDelay(1000 / portTICK_PERIOD_MS);
    //}
    ESP_LOGI(TAG, "... Removing device.");
    //ESP_ERROR_CHECK(spi_bus_remove_device(handle1));
    ESP_LOGI(TAG, "... Freeing bus.");
    //ESP_ERROR_CHECK(spi_bus_free(VSPI_HOST));
    ESP_LOGD(TAG, "<< test_spi_task");
    vTaskDelete(NULL);
}