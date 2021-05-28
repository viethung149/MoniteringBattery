#include "slave.h"
spi_slave_transaction_t slave_config(){
    spi_bus_config_t buscfg2 = {
        .mosi_io_num = GPIO_MOSI_VSPI,
        .miso_io_num = GPIO_MISO_VSPI,
        .sclk_io_num = GPIO_SCLK_VSPI,
        .quadwp_io_num = -1,
        .quadhd_io_num = -1};
    ESP_LOGI(TAG, "... Initializing bus slave");
    ESP_LOGI(TAG, "... Adding device bus.");
    spi_slave_interface_config_t slave_config={
        .mode=0,
        .spics_io_num=GPIO_CS_VSPI,
        .queue_size=1,
        .flags=0,
        .post_setup_cb=my_post_setup_cb,
        .post_trans_cb=my_post_trans_cb
    };
    int ret = spi_slave_initialize(VSPI_HOST, &buscfg2, &slave_config, 2);
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
    spi_slave_transaction_t rcv;
    memset(&rcv, 0, sizeof(rcv));
    rcv.rx_buffer = spi_rx_static_buf;
    rcv.tx_buffer = spi_rx_static_buf;
    rcv.trans_len = SIZE_BUFFER*8;
    rcv.length = SIZE_BUFFER*8;
    return rcv;
}

void slave_read (uint8_t spi_rx_static_buf[], spi_slave_transaction_t rcv,int times_read){
    memset(&rcv, 0, sizeof(rcv));
    rcv.rx_buffer = spi_rx_static_buf;
    rcv.tx_buffer = NULL;
    rcv.trans_len = SIZE_BUFFER * 8;
    rcv.length = SIZE_BUFFER * 8;
    ESP_LOGI(TAG, "... Receiving in time %d \n",times_read);
    ESP_ERROR_CHECK(spi_slave_transmit(VSPI_HOST, &rcv,portMAX_DELAY));
    for(int i =0;i<SIZE_BUFFER;i++ ){
        printf("Byte %d is: %X \n",i,spi_rx_static_buf[i]&0xFF);
    }
    printf("lenght is : %d \n",rcv.trans_len);
}