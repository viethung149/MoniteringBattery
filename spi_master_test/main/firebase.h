#ifndef _FIREBASE_H_
#define _FIREBASE_H_
#define TAG_HTTP "HTTP_CLIENT"
#include "json_data.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "esp_http_client.h"
#include "esp_log.h"
#include "json_data.h"
extern char* buffer_read;
extern int buffer_read_index;
#define URL_BATTERY_CELLS "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/battery_cells.json"
#define URL_BATTERY_PACKAGES "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/battery_packages.json"
#define URL_PHERIPHERALS "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/pheripherals.json"
#define URL_TEMPERATURE_CELLS "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/temperature_cells.json"
#define URL_VOLTAGE_CELLS "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/voltage_cells.json"
#define URL_CURRENT_PACKAGE "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/current_packages.json"
#define URL_WARNING_VOLTAGE "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/warning_voltage_cells.json"
#define URL_WARNING_TEMPERATURE "https://monitoringbattery-5496a-default-rtdb.asia-southeast1.firebasedatabase.app/warning_temperature_cells.json"
void http_get(char* url);
void http_post(char* url);
void http_delete(char* url);
void http_put(char *url, const char* data);

#endif