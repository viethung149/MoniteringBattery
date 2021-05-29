#ifndef _JSON_DATA_
#define _JSON_DATA_
#include "type.h"
#include "slave.h"
#include "json_data.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "esp_log.h"
#include "cJson.h"
#include "math.h"
extern float voltage[] ;
extern float temperature[];
extern float current[] ;
extern bool status_voltage[] ;
extern bool status_temperature[] ;
extern bool status_current[] ;
extern bool status_pheripheral[] ;
extern bool status_blance[] ;
//table package
extern float capacity_package[];
extern float temperature_package[];
extern float current_package[];
extern bool blancing_package[];
extern CONNECT_STATUS connect_package[];
extern bool warning_package[];
char *create_battery_voltage(float* voltage_value, int length);
char *create_battery_temperature(float* temperature_value, int length);
char *create_battery_status(bool* status,int lenght);
int lenght_of_json(char* string_json);
// create JSON for battery table
char* create_battery_infor(float* voltage,
                                   float* temperature,
                                   bool* status_blancing,
                                   bool* status_voltage,
                                   bool* status_temperature,
                                   int size);
char* create_package_infor(float* capacity,
                           float* temperature,
                           float* current,
                           bool* status_blancing,
                           CONNECT_STATUS* status_connect,
                           bool* status_warning,
                           int size);
#endif