#ifndef _SLAVE_H
#define _SLAVE_H
#include "type.h"
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
#include "type.h"
extern void my_post_setup_cb(spi_slave_transaction_t *trans);
extern void my_post_trans_cb(spi_slave_transaction_t *trans);
extern WORD_ALIGNED_ATTR uint8_t spi_rx_static_buf[];

spi_slave_transaction_t slave_config();
void slave_read (uint8_t spi_rx_static_buf[], spi_slave_transaction_t rcv, int times_read);
#endif