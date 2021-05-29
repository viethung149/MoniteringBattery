
#include "json_data.h"

#define TAG_CREATE_DATA "DATA"
#include "type.h"

char *create_battery_voltage(float *voltage_value, int length)
{
    cJSON *battery_voltage = cJSON_CreateObject();
    char *string = NULL;
    if (battery_voltage == NULL)
    {
        goto end;
    }
    for (int i = 0; i < length; i++)
    {
        char battery_template[] = "Voltage battery ";
        char number[10] = {0};
        char voltage[10] = {0};
        char template[100] = {0};
        // convert int to string
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        strcpy(template, battery_template);
        printf("%s \n", battery_template);
        // convert float to string
        sprintf(voltage, "%0.4f", voltage_value[i]);

        cJSON *battery = NULL;
        battery = cJSON_CreateString((const char *)voltage);
        if (battery == NULL)
        {
            goto end;
        }
        //add element to json
        cJSON_AddItemToObject(battery_voltage, template, battery);
        // char* test = cJSON_Print(battery_voltage);
        // printf("%s \n",test);
    }
    string = cJSON_Print((const cJSON *)battery_voltage);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print monitor.\n");
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

char *create_battery_temperature(float *temperature_value, int length)
{
    cJSON *battery_temperature = cJSON_CreateObject();
    char *string = NULL;
    if (battery_temperature == NULL)
    {
        goto end;
    }
    for (int i = 0; i < length; i++)
    {
        char battery_template[] = "temperature battery ";
        char number[10] = {0};
        char temperature[10] = {0};
        char template[100] = {0};
        // convert int to string
        sprintf(number, "%d", (i + 1));
        strcat(battery_template, number);
        strcpy(template, battery_template);
        // convert float to string
        sprintf(temperature, "%0.4f", temperature_value[i]);

        cJSON *battery = NULL;
        battery = cJSON_CreateString((const char *)temperature);
        if (battery == NULL)
        {
            goto end;
        }
        //add element to json
        cJSON_AddItemToObject(battery_temperature, template, battery);

    }
    string = cJSON_Print((const cJSON *)battery_temperature);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print monitor.\n");
    }
end:
    cJSON_Delete(battery_temperature);
    return string;
}

char* create_battery_infor(float* voltage,
                           float* temperature,
                           bool* status_blancing,
                           bool* status_voltage,
                           bool* status_temperature,
                           int size)
{
    cJSON *battery_table = cJSON_CreateObject();
    char* string = NULL;
    // adding name of the json form
    ESP_LOGI("JSON","create name for infor");
    cJSON *name = cJSON_CreateString("Cell Battery Voltage");
    if(name == NULL) goto end;
    cJSON_AddItemToObject(battery_table,"name",name);
    // adding array information
    cJSON *cell_informations = cJSON_CreateArray();
    if(cell_informations == NULL) goto end;
    ESP_LOGI("JSON","create array cells information");
    cJSON_AddItemToObject(battery_table,"cells information",cell_informations);
    for(int i = 0 ; i < size ;i++){
        ESP_LOGI("JSON","add the element of cells information");
        cJSON *cell_information =  cJSON_CreateObject();
        if(cell_information == NULL) goto end;
        cJSON_AddItemToArray(cell_informations,cell_information);
        // VOLTAGE
        ESP_LOGI("JSON","create voltage infor");
        cJSON * cell_voltage = cJSON_CreateNumber((double)voltage[i]);
        if(cell_voltage == NULL) goto end;
        // TEMPERATURE
        ESP_LOGI("JSON","create temperature infor");
        cJSON * cell_temperature = cJSON_CreateNumber((double)temperature[i]);
        if(cell_temperature == NULL) goto end;
        // BLANCING STATUS
        ESP_LOGI("JSON","create blancing infor");
        char* string_blancing = (status_blance[i] == true)? "Blancing":"Normal";
        cJSON * cell_status_blancing = cJSON_CreateString(string_blancing);
        if(cell_status_blancing == NULL) goto end;
        // VOLTAGE_STATUS
        ESP_LOGI("JSON","create status voltage infor");
        char* string_status_voltage = (status_voltage[i] == true)? "Emergency":"Normal";
        cJSON * cell_status_voltage = cJSON_CreateString(string_status_voltage);
        if(cell_status_voltage == NULL) goto end;
        // TEMPERATURE STATUS
        ESP_LOGI("JSON","create temperature status infor");
        char* string_status_temperature = (status_temperature[i] == true)? "Emergency":"Normal";
        cJSON * cell_status_temperature = cJSON_CreateString(string_status_temperature);
        if(cell_status_temperature == NULL) goto end;
        // add to array
        cJSON_AddItemToObject(cell_information,"voltage",cell_voltage);
        cJSON_AddItemToObject(cell_information,"temperature",cell_temperature);
        cJSON_AddItemToObject(cell_information,"Blance",cell_status_blancing);
        cJSON_AddItemToObject(cell_information,"Warning Voltage",cell_status_voltage);
        cJSON_AddItemToObject(cell_information,"Warning Temperature",cell_status_temperature);

    }
    string = cJSON_Print((const cJSON *)battery_table);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print monitor.\n");
    }

end:
    cJSON_Delete(battery_table);
    return string;
}

char* create_package_infor(float* capacity,
                           float* temperature,
                           float* current,
                           bool* status_blancing,
                           CONNECT_STATUS* status_connect,
                           bool* status_warning,
                           int size)
{
    cJSON *package_table = cJSON_CreateObject();
    char* string = NULL;
    // adding name of the json form
    ESP_LOGI("JSON","create name for packages");
    cJSON *name = cJSON_CreateString("Package Battery");
    if(name == NULL) goto end;
    cJSON_AddItemToObject(package_table,"name",name);
    // adding array information
    cJSON *packages_information = cJSON_CreateArray();
    if(packages_information == NULL) goto end;
    ESP_LOGI("JSON","create array packages information");
    cJSON_AddItemToObject(package_table,"packages information",packages_information);

    for(int i = 0 ; i < size ;i++){
        ESP_LOGI("JSON","add the element of packages information");
        cJSON *package_information =  cJSON_CreateObject();
        if(package_information == NULL) goto end;
        cJSON_AddItemToArray(packages_information,package_information);
        // CAPACITY
        ESP_LOGI("JSON","create capacity infor");
        cJSON * package_capacity_infor = cJSON_CreateNumber((double)capacity[i]);
        if(package_capacity_infor == NULL) goto end;
        // TEMPERATURE
        ESP_LOGI("JSON","create temperature infor");
        cJSON * package_temperature_infor = cJSON_CreateNumber((double)temperature[i]);
        if(package_temperature_infor == NULL) goto end;
        // CURRENT
        ESP_LOGI("JSON","create current infor");
        cJSON * package_current_infor = cJSON_CreateNumber((double)current[i]);
        if(package_current_infor  == NULL) goto end;
        // BLANCING STATUS
        ESP_LOGI("JSON","create blancing infor");
        char* string_blancing = (status_blance[i] == true)? "Blancing":"Normal";
        cJSON * package_status_blancing_infor = cJSON_CreateString(string_blancing);
        if(package_status_blancing_infor == NULL) goto end;
        // CONNECT STATUS
        ESP_LOGI("JSON","create status voltage infor");
        char* string_status_connect = NULL;
        if(status_connect[i] == DISCONNECT) string_status_connect ="DISCONNECT";
        else if(status_connect[i] == CONNECT) string_status_connect ="CONNECT";
        else if(status_connect[i] == CHARGE) string_status_connect ="CHARGE";
        else  string_status_connect ="DISCONNECT";
         cJSON * package_status_connect_infor = cJSON_CreateString(string_status_connect);
        if(package_status_connect_infor == NULL) goto end;
        // WARNING STATUS
        ESP_LOGI("JSON","create warning status infor");
        char* string_status_warning = (status_warning[i] == true)? "Emergency":"Normal";
        cJSON * package_status_warning_infor = cJSON_CreateString(string_status_warning);
        if(package_status_warning_infor == NULL) goto end;
        // add to array
        cJSON_AddItemToObject(package_information,"Voltage",package_capacity_infor);
        cJSON_AddItemToObject(package_information,"Temperature",package_temperature_infor);
        cJSON_AddItemToObject(package_information,"Current",package_current_infor);
        cJSON_AddItemToObject(package_information,"Balance",package_status_blancing_infor);
        cJSON_AddItemToObject(package_information,"Connect",package_status_connect_infor);
        cJSON_AddItemToObject(package_information,"Warning",package_status_warning_infor);
    }
    string = cJSON_Print((const cJSON *)package_table);
    if (string == NULL)
    {
        fprintf(stderr, "Failed to print monitor.\n");
    }

end:
    cJSON_Delete(package_table);
    return string;
}