#ifndef _WIFI_H_
#define _WIFI_H_
#include <stdio.h>
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "freertos/event_groups.h"
#include "esp_event_loop.h"
#include "esp_wifi.h"
#include "esp_log.h"
#include "nvs_flash.h"
#include "type.h"
extern  esp_err_t event_handler(void *ctx, system_event_t *event);
#define CONFIG_WIFI_SSID "VIET HUNG"
#define CONFIG_WIFI_PASSWORD "anhkhoa0504"

void wifiInit(void);
#endif