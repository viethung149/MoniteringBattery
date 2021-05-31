
#include "json_data.h"

#define TAG_CREATE_DATA "DATA"
#include "type.h"
/*
{
        "name": "Cell battery voltage",
        "voltages":     {
                "Battery 1":    3.8878240585327148,
                "Battery 2":    4.0023012161254883,
                "Battery 3":    3.9071445465087891,
                "Battery 4":    3.9990081787109375,
                "Battery 5":    3.8568706512451172,
                "Battery 6":    3.9523115158081055,
                "Battery 7":    3.911590576171875,
                "Battery 8":    3.9424238204956055
        }
}
*/
char *create_battery_voltage(float *voltage_value, int size)
{
    cJSON *battery_voltage = cJSON_CreateObject();
    char *string = NULL;
    if (battery_voltage == NULL)
        goto end;
    //ESP_LOGI"JSON", "create name for battery voltage");
    cJSON *name = cJSON_CreateString("CellBatteryVoltage");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(battery_voltage, "name", name);
    //ESP_LOGI"JSON", "create voltages for battery current");
    cJSON *voltages = cJSON_CreateObject();
    if (voltages == NULL)
        goto end;
    cJSON_AddItemToObject(battery_voltage, "voltages", voltages);
    for (int i = 0; i < size; i++)
    {
        char battery_template[] = "Battery";
        char number[10] = {0};
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        cJSON *voltage = NULL;
        voltage = cJSON_CreateNumber((double)voltage_value[i]);
        if (temperature == NULL)
            goto end;
        //add element to json
        cJSON_AddItemToObject(voltages, battery_template, voltage);
    }
    string = cJSON_Print((const cJSON *)battery_voltage);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print voltage cells.\n");
    }
end:
    cJSON_Delete(battery_voltage);
    return string;
}

int lenght_of_json(char *string_json)
{
    int cnt = 0;
    while (*(string_json++) != NULL)
    {
        cnt++;
    }
    return cnt;
}
/*
{
        "name": "Cell battery Temperature",
        "temperatures": {
                "Battery 1":    32.3812255859375,
                "Battery 2":    69.2977981567383,
                "Battery 3":    75.586441040039062,
                "Battery 4":    75.376434326171875,
                "Battery 5":    66.477668762207031,
                "Battery 6":    73.5580368041992,
                "Battery 7":    56.514942169189453,
                "Battery 8":    76.4821014404297
        }
}
*/
char *create_battery_temperature(float *temperature_value, int size)
{
    cJSON *battery_temperature = cJSON_CreateObject();
    char *string = NULL;
    if (battery_temperature == NULL)
        goto end;
    //ESP_LOGI"JSON", "create name for battery temperature");
    cJSON *name = cJSON_CreateString("CellBatteryTemperature");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(battery_temperature, "name", name);
    //ESP_LOGI"JSON", "create temperatures for battery temperature");
    cJSON *temperatures = cJSON_CreateObject();
    if (temperatures == NULL)
        goto end;
    cJSON_AddItemToObject(battery_temperature, "temperatures", temperatures);
    for (int i = 0; i < size; i++)
    {
        char battery_template[] = "Battery";
        char number[10] = {0};
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        cJSON *temperature = NULL;
        temperature = cJSON_CreateNumber((double)temperature_value[i]);
        if (temperature == NULL)
            goto end;
        //add element to json
        cJSON_AddItemToObject(temperatures, battery_template, temperature);
    }
    string = cJSON_Print((const cJSON *)battery_temperature);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print temperature cells.\n");
    }
end:
    cJSON_Delete(battery_temperature);
    return string;
}
/*
       {
        "name": "Cell battery current",
        "currents":     {
                "Package 1":    0,
                "Package 2":    0,
                "Package 3":    -24.950000762939453
        }
}
*/
char *create_battery_current(float *current_value, int size)
{
    cJSON *package_current = cJSON_CreateObject();
    char *string = NULL;
    if (package_current == NULL)
        goto end;
    //ESP_LOGI"JSON", "create name for battery current");
    cJSON *name = cJSON_CreateString("CellBatteryCurrent");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(package_current, "name", name);
    //ESP_LOGI"JSON", "create currents for battery current");
    cJSON *currents = cJSON_CreateObject();
    if (currents == NULL)
        goto end;
    cJSON_AddItemToObject(package_current, "currents", currents);

    for (int i = 0; i < size; i++)
    {
        char package_template[] = "Package ";
        char number[10] = {0};
        sprintf(number, "%d", (i + 1));
        strcat(package_template, number);
        cJSON *current = NULL;
        current = cJSON_CreateNumber((double)current_value[i]);
        if (temperature == NULL)
            goto end;
        //add element to json
        cJSON_AddItemToObject(currents, package_template, current);
    }
    string = cJSON_Print((const cJSON *)package_current);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print current package.\n");
    }
end:
    cJSON_Delete(package_current);
    return string;
}
/*
    {
        "name": "Battery Cells",
        "cells information":    [{
                        "voltage":      3.8878240585327148,
                        "temperature":  32.3812255859375,
                        "Blance":       "Normal",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      4.0023012161254883,
                        "temperature":  69.2977981567383,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.9071445465087891,
                        "temperature":  75.586441040039062,
                        "Blance":       "Normal",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.9990081787109375,
                        "temperature":  75.376434326171875,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.8568706512451172,
                        "temperature":  66.477668762207031,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.9523115158081055,
                        "temperature":  73.5580368041992,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.911590576171875,
                        "temperature":  56.514942169189453,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }, {
                        "voltage":      3.9424238204956055,
                        "temperature":  76.4821014404297,
                        "Blance":       "Blancing",
                        "Warning Voltage":      "Normal",
                        "Warning Temperature":  "Normal"
                }]
}
*/
char *create_battery_infor(float *voltage,
                           float *temperature,
                           bool *status_blancing,
                           bool *status_voltage,
                           bool *status_temperature,
                           int size)
{
    cJSON *battery_table = cJSON_CreateObject();
    char *string = NULL;
    // adding name of the json form
    //ESP_LOGI"JSON", "create name for infor");
    cJSON *name = cJSON_CreateString("BatteryCells");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(battery_table, "name", name);
    // adding array information
    cJSON *cell_informations = cJSON_CreateArray();
    if (cell_informations == NULL)
        goto end;
    //ESP_LOGI"JSON", "create array cells information");
    cJSON_AddItemToObject(battery_table, "CellsInformation", cell_informations);
    for (int i = 0; i < size; i++)
    {
        //ESP_LOGI"JSON", "add the element of cells information");
        cJSON *cell_information = cJSON_CreateObject();
        if (cell_information == NULL)
            goto end;
        cJSON_AddItemToArray(cell_informations, cell_information);
        // VOLTAGE
        //ESP_LOGI"JSON", "create voltage infor");
        cJSON *cell_voltage = cJSON_CreateNumber((double)voltage[i]);
        if (cell_voltage == NULL)
            goto end;
        // TEMPERATURE
        //ESP_LOGI"JSON", "create temperature infor");
        cJSON *cell_temperature = cJSON_CreateNumber((double)temperature[i]);
        if (cell_temperature == NULL)
            goto end;
        // BLANCING STATUS
        //ESP_LOGI"JSON", "create blancing infor");
        char *string_blancing = (status_blance[i] == true) ? "Blancing" : "Normal";
        cJSON *cell_status_blancing = cJSON_CreateString(string_blancing);
        if (cell_status_blancing == NULL)
            goto end;
        // VOLTAGE_STATUS
        //ESP_LOGI"JSON", "create status voltage infor");
        char *string_status_voltage = (status_voltage[i] == true) ? "Emergency" : "Normal";
        cJSON *cell_status_voltage = cJSON_CreateString(string_status_voltage);
        if (cell_status_voltage == NULL)
            goto end;
        // TEMPERATURE STATUS
        //ESP_LOGI"JSON", "create temperature status infor");
        char *string_status_temperature = (status_temperature[i] == true) ? "Emergency" : "Normal";
        cJSON *cell_status_temperature = cJSON_CreateString(string_status_temperature);
        if (cell_status_temperature == NULL)
            goto end;
        // add to array
        cJSON_AddItemToObject(cell_information, "Voltage", cell_voltage);
        cJSON_AddItemToObject(cell_information, "Temperature", cell_temperature);
        cJSON_AddItemToObject(cell_information, "Balance", cell_status_blancing);
        cJSON_AddItemToObject(cell_information, "WarningVoltage", cell_status_voltage);
        cJSON_AddItemToObject(cell_information, "WarningTemperature", cell_status_temperature);
    }
    string = cJSON_Print((const cJSON *)battery_table);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print battery table.\n");
    }

end:
    cJSON_Delete(battery_table);
    return string;
}
/*
     {
        "name": "Package Battery",
        "packages information": [{
                        "Voltage":      15.79627799987793,
                        "Temperature":  75.586441040039062,
                        "Current":      0,
                        "Balance":      "Normal",
                        "Connect":      "CONNECT",
                        "Warning":      "Emergency"
                }, {
                        "Voltage":      15.663196563720703,
                        "Temperature":  76.4821014404297,
                        "Current":      0,
                        "Balance":      "Blancing",
                        "Connect":      "CONNECT",
                        "Warning":      "Normal"
                }, {
                        "Voltage":      15.729737281799316,
                        "Temperature":  76.4821014404297,
                        "Current":      -24.950000762939453,
                        "Balance":      "Normal",
                        "Connect":      "CONNECT",
                        "Warning":      "Normal"
                }]
}
*/
char *create_package_infor(float *capacity,
                           float *temperature,
                           float *current,
                           bool *status_blancing,
                           CONNECT_STATUS *status_connect,
                           bool *status_warning,
                           int size)
{
    cJSON *package_table = cJSON_CreateObject();
    char *string = NULL;
    // adding name of the json form
    //ESP_LOGI"JSON", "create name for packages");
    cJSON *name = cJSON_CreateString("PackageBattery");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(package_table, "name", name);
    // adding array information
    cJSON *packages_information = cJSON_CreateArray();
    if (packages_information == NULL)
        goto end;
    //ESP_LOGI"JSON", "create array packages information");
    cJSON_AddItemToObject(package_table, "PackagesInformation", packages_information);

    for (int i = 0; i < size; i++)
    {
        //ESP_LOGI"JSON", "add the element of packages information");
        cJSON *package_information = cJSON_CreateObject();
        if (package_information == NULL)
            goto end;
        cJSON_AddItemToArray(packages_information, package_information);
        // CAPACITY
        //ESP_LOGI"JSON", "create capacity infor");
        cJSON *package_capacity_infor = cJSON_CreateNumber((double)capacity[i]);
        if (package_capacity_infor == NULL)
            goto end;
        // TEMPERATURE
        //ESP_LOGI"JSON", "create temperature infor");
        cJSON *package_temperature_infor = cJSON_CreateNumber((double)temperature[i]);
        if (package_temperature_infor == NULL)
            goto end;
        // CURRENT
        //ESP_LOGI"JSON", "create current infor");
        cJSON *package_current_infor = cJSON_CreateNumber((double)current[i]);
        if (package_current_infor == NULL)
            goto end;
        // BLANCING STATUS
        //ESP_LOGI"JSON", "create blancing infor");
        char *string_blancing = (status_blance[i] == true) ? "Blancing" : "Normal";
        cJSON *package_status_blancing_infor = cJSON_CreateString(string_blancing);
        if (package_status_blancing_infor == NULL)
            goto end;
        // CONNECT STATUS
        //ESP_LOGI"JSON", "create status voltage infor");
        char *string_status_connect = NULL;
        if (status_connect[i] == DISCONNECT)
            string_status_connect = "DISCONNECT";
        else if (status_connect[i] == CONNECT)
            string_status_connect = "CONNECT";
        else if (status_connect[i] == CHARGE)
            string_status_connect = "CHARGE";
        else
            string_status_connect = "DISCHARGE";
        cJSON *package_status_connect_infor = cJSON_CreateString(string_status_connect);
        if (package_status_connect_infor == NULL)
            goto end;
        // WARNING STATUS
        //ESP_LOGI"JSON", "create warning status infor");
        char *string_status_warning = (status_warning[i] == true) ? "Emergency" : "Normal";
        cJSON *package_status_warning_infor = cJSON_CreateString(string_status_warning);
        if (package_status_warning_infor == NULL)
            goto end;
        // add to array
        cJSON_AddItemToObject(package_information, "Voltage", package_capacity_infor);
        cJSON_AddItemToObject(package_information, "Temperature", package_temperature_infor);
        cJSON_AddItemToObject(package_information, "Current", package_current_infor);
        cJSON_AddItemToObject(package_information, "Balance", package_status_blancing_infor);
        cJSON_AddItemToObject(package_information, "Connect", package_status_connect_infor);
        cJSON_AddItemToObject(package_information, "Warning", package_status_warning_infor);
    }
    string = cJSON_Print((const cJSON *)package_table);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print package table.\n");
    }

end:
    cJSON_Delete(package_table);
    return string;
}
/*
{
        "name": "Pheripheral",
        "packages information": {
                "Relay1 - Package1":    "ON",
                "Relay2 - Package2":    "ON",
                "Relay3 - Fan1":        "OFF",
                "Relay4 - Fan2":        "ON"
        }
}
*/
char *create_pheripheral_infor(bool *status_pheripheral)
{
    cJSON *pheripheral_table = cJSON_CreateObject();
    char *string = NULL;
    // adding name of the json form
    cJSON *name = cJSON_CreateString("Pheripheral");
    if (name == NULL)
        goto end;
    //ESP_LOGI"JSON", "Create the name for pheripheral table");
    cJSON_AddItemToObject(pheripheral_table, "name", name);
    //adding Value object
    //ESP_LOGI"JSON", "Create the values for pheripheral table");
    cJSON *pheripheral_values = cJSON_CreateObject();
    if (pheripheral_table == NULL)
        goto end;
    cJSON_AddItemToObject(pheripheral_table, "PackagesInformation", pheripheral_values);
    //ESP_LOGI"JSON", "Create the value status relay 1");
    char *str_relay1_status = (status_pheripheral[RELAY1_PACKAGE1] == true) ? "ON" : "OFF";
    cJSON *relay1_package1 = cJSON_CreateString(str_relay1_status);
    if (relay1_package1 == NULL)
        goto end;

    //ESP_LOGI"JSON", "Create the value status relay 2");
    char *str_relay2_status = (status_pheripheral[RELAY2_PACKAGE2] == true) ? "ON" : "OFF";
    cJSON *relay2_package2 = cJSON_CreateString(str_relay2_status);
    if (relay2_package2 == NULL)
        goto end;

    //ESP_LOGI"JSON", "Create the value status relay 3");
    char *str_relay3_status = (status_pheripheral[RELAY3_FAN1] == true) ? "ON" : "OFF";
    cJSON *relay3_fan1 = cJSON_CreateString(str_relay3_status);
    if (relay3_fan1 == NULL)
        goto end;

    //ESP_LOGI"JSON", "Create the value status relay 4");
    char *str_relay4_status = (status_pheripheral[RELAY4_FAN2] == true) ? "ON" : "OFF";
    cJSON *relay4_fan2 = cJSON_CreateString(str_relay4_status);
    if (relay4_fan2 == NULL)
        goto end;

    // add to value
    cJSON_AddItemToObject(pheripheral_values, "Relay1-Package1", relay1_package1);
    cJSON_AddItemToObject(pheripheral_values, "Relay2-Package2", relay2_package2);
    cJSON_AddItemToObject(pheripheral_values, "Relay3-Fan1", relay3_fan1);
    cJSON_AddItemToObject(pheripheral_values, "Relay4-Fan2", relay4_fan2);
    string = cJSON_Print((const cJSON *)pheripheral_table);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print pheripheral table.\n");
    }

end:
    cJSON_Delete(pheripheral_table);
    return string;
}
/*
 {
        "name": "Cell status voltage battery",
        "status_voltages":      {
                "Battery 1":    "Emergency",
                "Battery 2":    "Emergency",
                "Battery 3":    "Emergency",
                "Battery 4":    "Emergency",
                "Battery 5":    "Normal",
                "Battery 6":    "Normal",
                "Battery 7":    "Normal",
                "Battery 8":    "Normal"
        }
}
*/
char *create_voltage_warning(bool* status_voltage,int size){
    cJSON *battery_voltage_status = cJSON_CreateObject();
    char *string = NULL;
    if (battery_voltage_status == NULL)
        goto end;
    //ESP_LOGI"JSON", "create name for battery voltage status");
    cJSON *name = cJSON_CreateString("CellStatusVoltage");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(battery_voltage_status, "name", name);
    //ESP_LOGI"JSON", "create statuses for battery voltage status");
    cJSON *statuses = cJSON_CreateObject();
    if (statuses == NULL)
        goto end;
    cJSON_AddItemToObject(battery_voltage_status, "statusVoltages", statuses);
    for (int i = 0; i < size; i++)
    {
        char battery_template[] = "Battery";
        char number[10] = {0};
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        cJSON *status = NULL;
        char* str_voltage_status = (status_voltage[i] == true)?"Emergency":"Normal";
        status = cJSON_CreateString(str_voltage_status);
        if (status == NULL)
            goto end;
        //add element to json
        cJSON_AddItemToObject(statuses, battery_template, status);
    }
    string = cJSON_Print((const cJSON *)battery_voltage_status);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print voltage status cells.\n");
    }
end:
    cJSON_Delete(battery_voltage_status);
    return string;
}
/*
 {
        "name": "Cell status temperature battery",
        "status temperatures":  {
                "Battery 1":    "Emergency",
                "Battery 2":    "Normal",
                "Battery 3":    "Normal",
                "Battery 4":    "Normal",
                "Battery 5":    "Normal",
                "Battery 6":    "Normal",
                "Battery 7":    "Normal",
                "Battery 8":    "Normal"
        }
}
*/
char *create_temperature_warning(bool* status_temperature,int size){
    cJSON *battery_temperature_status = cJSON_CreateObject();
    char *string = NULL;
    if (battery_temperature_status == NULL)
        goto end;
    //ESP_LOGI"JSON", "create name for battery temperature status");
    cJSON *name = cJSON_CreateString("CellStatusTemperature");
    if (name == NULL)
        goto end;
    cJSON_AddItemToObject(battery_temperature_status, "name", name);
    //ESP_LOGI"JSON", "create statuses for battery temperature status");
    cJSON *statuses = cJSON_CreateObject();
    if (statuses == NULL)
        goto end;
    cJSON_AddItemToObject(battery_temperature_status, "StatusTemperatures", statuses);
    for (int i = 0; i < size; i++)
    {
        char battery_template[] = "Battery";
        char number[10] = {0};
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        cJSON *status = NULL;
        char* str_temperature_status = (status_temperature[i] == true)?"Emergency":"Normal";
        status = cJSON_CreateString(str_temperature_status);
        if (status == NULL)
            goto end;
        //add element to json
        cJSON_AddItemToObject(statuses, battery_template, status);
    }
    string = cJSON_Print((const cJSON *)battery_temperature_status);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print temperature status cells.\n");
    }
end:
    cJSON_Delete(battery_temperature_status);
    return string;
}
char *create_pheripheral_connect(CONNECT_STATUS* status_connect,int size);