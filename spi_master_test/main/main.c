#include <stdio.h>
#include <stdint.h>
#include <stddef.h>
#include <string.h>

#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "freertos/semphr.h"
#include "freertos/queue.h"

#include "lwip/sockets.h"
#include "lwip/dns.h"
#include "lwip/netdb.h"
#include "lwip/igmp.h"

#include "esp_wifi.h"
#include "esp_system.h"
#include "esp_event.h"
#include "esp_event_loop.h"
#include "nvs_flash.h"
#include "soc/rtc_periph.h"
#include "esp32/rom/cache.h"
#include "driver/spi_master.h"
#include "esp_log.h"
#include "esp_spi_flash.h"
#include "driver/spi_slave.h"
#include "driver/gpio.h"
#include "esp_intr_alloc.h"
#define GPIO_HANDSHAKE 2
#define GPIO_MOSI_HSPI 13
#define GPIO_MISO_HSPI 12
#define GPIO_SCLK_HSPI 14
#define GPIO_CS_HSPI 15
#define GPIO_MOSI_VSPI 23
#define GPIO_MISO_VSPI 19
#define GPIO_SCLK_VSPI 18
#define GPIO_CS_VSPI 5
#define tag "SPI MASTER"
WORD_ALIGNED_ATTR uint8_t spi_rx_static_buf[10]={0};
//Called after a transaction is queued and ready for pickup by master. We use this to set the handshake line high.
void my_post_setup_cb(spi_slave_transaction_t *trans) {
    WRITE_PERI_REG(GPIO_OUT_W1TS_REG, (1<<GPIO_HANDSHAKE));
}

//Called after transaction is sent/received. We use this to set the handshake line low.
void my_post_trans_cb(spi_slave_transaction_t *trans) {
    WRITE_PERI_REG(GPIO_OUT_W1TC_REG, (1<<GPIO_HANDSHAKE));
}
void app_main(void *ignore)
{
    esp_log_level_set(tag,ESP_LOG_DEBUG);
    ESP_LOGI(tag, ">> test_spi_task");
    spi_bus_config_t buscfg1 = {
        .mosi_io_num = GPIO_MOSI_HSPI,
        .miso_io_num = GPIO_MISO_HSPI,
        .sclk_io_num = GPIO_SCLK_HSPI,
        .quadwp_io_num = -1,
        .quadhd_io_num = -1};
    ESP_LOGI(tag, "... Initializing bus.");
    int ret = spi_bus_initialize(HSPI_HOST, &buscfg1, 1);
    assert(ret == ESP_OK);
    spi_bus_config_t buscfg2 = {
        .mosi_io_num = GPIO_MOSI_VSPI,
        .miso_io_num = GPIO_MISO_VSPI,
        .sclk_io_num = GPIO_SCLK_VSPI,
        .quadwp_io_num = -1,
        .quadhd_io_num = -1};

    spi_device_handle_t handle1;
    spi_device_interface_config_t dev_config1 = {
        .address_bits = 0,
        .command_bits = 0,
        .dummy_bits = 0,
        .mode = 0,
        .duty_cycle_pos = 0,
        .cs_ena_posttrans = 0,
        .cs_ena_pretrans = 0,
        .clock_speed_hz = 10000,
        .spics_io_num = GPIO_CS_HSPI,
        .flags = 0,
        .queue_size = 1,
        .pre_cb = NULL,
        .post_cb = NULL,
    };
    ESP_LOGI(tag, "... Adding device bus.");
    ESP_ERROR_CHECK(spi_bus_add_device(HSPI_HOST, &dev_config1, &handle1));
    spi_slave_interface_config_t slave_config={
        .mode=0,
        .spics_io_num=GPIO_CS_VSPI,
        .queue_size=1,
        .flags=0,
        .post_setup_cb=my_post_setup_cb,
        .post_trans_cb=my_post_trans_cb
    };
    ret = spi_slave_initialize(VSPI_HOST, &buscfg2, &slave_config, 2);
    assert(ret==ESP_OK);
    //Configuration for the handshake line
    gpio_config_t io_conf={
        .intr_type=GPIO_INTR_DISABLE,
        .mode=GPIO_MODE_OUTPUT,
        .pin_bit_mask=(1<<GPIO_HANDSHAKE)
    };
    //Configure handshake line as output
    gpio_config(&io_conf);
    gpio_set_pull_mode(GPIO_MOSI_VSPI, GPIO_PULLUP_ONLY);
    gpio_set_pull_mode(GPIO_SCLK_VSPI, GPIO_PULLUP_ONLY);
    gpio_set_pull_mode(GPIO_CS_VSPI, GPIO_PULLUP_ONLY);
    char data_tx[3];
    spi_transaction_t trans_desc;
    trans_desc.addr = 0;
    trans_desc.cmd = 0;
    trans_desc.flags = 0;
    trans_desc.length = 3 * 8;
    trans_desc.rxlength = 0;
    trans_desc.tx_buffer = data_tx;
    trans_desc.rx_buffer = NULL;
    data_tx[0] = 0x12;
    data_tx[1] = 0x34;
    data_tx[2] = 0x56;
    spi_slave_transaction_t rcv;
    memset(&rcv, 0, sizeof(rcv));
    rcv.rx_buffer = spi_rx_static_buf;
    rcv.tx_buffer = spi_rx_static_buf;
    //rcv.trans_len = 10*8;
    rcv.length = 10 *8;
    for (int i = 0; i < 10; i++)
    {
        for(int i = 0; i<3;i++)
        printf("data number %d is %x \n",i, data_tx[i]);
        ESP_LOGI(tag, "... Transmitting in time %d \n", i);
        ESP_ERROR_CHECK(spi_device_transmit(handle1, &trans_desc));
        ESP_LOGI(tag, "... Receiving in time %d \n", i);
        ESP_ERROR_CHECK(spi_slave_transmit(VSPI_HOST, &rcv,portMAX_DELAY));
        printf("Received: %s\n", spi_rx_static_buf);
        vTaskDelay(400 / portTICK_PERIOD_MS);
    }
    ESP_LOGI(tag, "... Removing device.");
    ESP_ERROR_CHECK(spi_bus_remove_device(handle1));
    ESP_LOGI(tag, "... Freeing bus.");
    ESP_ERROR_CHECK(spi_bus_free(HSPI_HOST));
    ESP_LOGD(tag, "<< test_spi_task");
    vTaskDelete(NULL);
}