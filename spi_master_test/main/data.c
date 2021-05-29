#include "data.h"
// get voltage from cell 1 to cell 8
void get_voltage(uint8_t spi_rx_static_buf[], float voltage[],int size){
    ESP_LOGI(TAG,"... in get voltage \n");
    int start_index = SPI_ESP_VOLTAGE;
    for(int i = 0; i<size;i++){
        union floatToByte temp;
        for(int j=start_index; j<start_index+4;j++){
            temp.variableByte[j-start_index] = spi_rx_static_buf[j];
        }
        voltage[i] = temp.variableFloat;
        start_index +=4;
    }
} 

// get temperature from cell 1 to cell 8
void get_temperature(uint8_t spi_rx_static_buf[], float temperature[],int size){
     ESP_LOGI(TAG,"... in get temperature \n");
    int start_index = SPI_ESP_TEMPERATURE;
    for(int i = 0; i<size;i++){
        union floatToByte temp;
        for(int j=start_index; j<start_index+4;j++){
            temp.variableByte[j-start_index] = spi_rx_static_buf[j];
        }
        temperature[i] = temp.variableFloat;
        printf("temperature %d is %f \n",i,temperature[i]);
        start_index +=4;
    }
}
// get current from sensor system, sensor package 1, sensor package 2
void get_current(uint8_t spi_rx_static_buf[], float current[],int size){
     ESP_LOGI(TAG,"... in get  current \n");
    int start_index = SPI_ESP_CURRENT;
    for(int i = 0; i<size;i++){
        union floatToByte temp;
        for(int j=start_index; j<start_index+4;j++){
            temp.variableByte[j-start_index] = spi_rx_static_buf[j];
        }
        current[i] = temp.variableFloat;
        start_index +=4;
    }
}
// get status voltage 
void get_status_voltage(uint8_t spi_rx_static_buf[],bool status_voltage[],int size){
     ESP_LOGI(TAG,"... in get_status_voltage \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_VOLTAGE];
    for(int i = 0 ;i<size ;i++){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_voltage[i] = (status & 0x01) == 0x01? true:false;
        status >>=1;
    }
}
void get_status_temperature(uint8_t spi_rx_static_buf[],bool status_temperature[],int size){
    ESP_LOGI(TAG,"... in get_status_temperature \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_TEMPERATURE];
    for(int i = 0 ;i < size ;i++){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_temperature[i] = (status & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
// current byte 0: package 1, byte 1: package 2, byte 2: all
void get_status_current(uint8_t spi_rx_static_buf[],bool status_current[],int size){
    ESP_LOGI(TAG,"... in get_status_current \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_CURRENT];
    for(int i = 0 ;i < size;i++){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_current[i] = (status & 0x01) ==0x01? true:false;
        printf("current status %d is %s \n",i,status_current[i] ==  true?"True":"False");
        status >>=1;
    }
}
void get_status_pheripheral(uint8_t spi_rx_static_buf[],bool status_pheripheral[],int size){
    ESP_LOGI(TAG,"... in get_status_pheripheral \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_PHERIPHERAL];
    for(int i = 0 ;i < size;i++){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_pheripheral[i] = ( status & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
void get_status_blance(uint8_t spi_rx_static_buf[],bool status_blance[],int size){
    ESP_LOGI(TAG,"... in get_status_blance \n");
     BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_BLANCE];
    for(int i = 0 ;i < size;i ++){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_blance[i] = (status & 0x01) ==0x01? true:false;
        status >>=1;
    }
}

void get_all(){
    get_voltage( spi_rx_static_buf,  voltage, NUMBER_CELLS);
    get_temperature( spi_rx_static_buf,  temperature, NUMBER_CELLS);
    get_current( spi_rx_static_buf,  current, NUMBER_CURRENT);
    get_status_voltage( spi_rx_static_buf, status_voltage, NUMBER_CELLS);
    get_status_temperature( spi_rx_static_buf, status_temperature, NUMBER_CELLS);
    get_status_current( spi_rx_static_buf, status_current, NUMBER_CELLS);
    get_status_pheripheral( spi_rx_static_buf, status_pheripheral, NUMBER_CELLS);
    get_status_blance( spi_rx_static_buf, status_blance, NUMBER_CELLS);
}
void print_voltage(float voltage[], int size){
    printf("Battery \n");
    for(int i =0 ;i<size;i++){
        printf("Battery %d : %f V \n",i,voltage[i]);
    }
}
void print_temperature(float temperature[], int size){
    printf("Temperature \n");
    for(int i =0 ;i<size;i++){
        printf("Temperature %d : %f oC \n",i,temperature[i]);
    }
}
void print_current(float current[], int size){
    printf("Current \n");
    for(int i =0 ;i<size;i++){
        printf("Current  %d : %f A \n",i,current[i]);
    }
}
void print_status_voltage(bool status_voltage[], int size){
     printf("status voltage \n");
    for(int i =0 ;i<size;i++){
        printf("Voltage %d : %s  \n", i, 
                        (status_voltage[i]==true)?"Emer":"Normal");
    }
}
void print_status_temperature(bool status_temperature[], int size){
     printf("status Temperature \n");
    for(int i =0 ;i<size;i++){
        printf("Temperature %d : %s  \n", i, 
                        (status_temperature[i]==true)?"Emer":"Normal");
    }
}
void print_status_current(bool status_current[], int size){
     printf("status Current \n");
    for(int i =0 ;i<size;i++){
        printf("Current %d : %s  \n", i, 
                        (status_current[i]==true)?"Emer":"Normal");
    }
}
void print_status_pheripheral(bool status_pheripheral[], int size){
     printf("status Pheripheral \n");
    for(int i =0 ;i<size;i++){
        printf("Pheripheral %d : %s  \n", i, 
                        (status_pheripheral[i]==true)?"ON":"OFF");
    }
}
void print_status_blance(bool status_blance[], int size){
     printf("status Battery \n");
    for(int i =0 ;i<size;i++){
        printf("Battery %d : %s  \n", i, 
                        (status_blance[i]==true)?"Blancing":"Normal");
    }
}
void print_all_infor(){
    //  for(int i = 0;i<SIZE_BUFFER;i++){
    //      printf("Byte %d is %x \n",i,spi_rx_static_buf[i]);
    //  }
     print_voltage( voltage,  NUMBER_CELLS);
     print_temperature( temperature,  NUMBER_CELLS);
     print_current( current, NUMBER_CURRENT);
     print_status_voltage( status_voltage,  NUMBER_CELLS);
     print_status_temperature( status_temperature,  NUMBER_CELLS);
     print_status_current( status_current,  NUMBER_CELLS);
     print_status_pheripheral( status_pheripheral,  NUMBER_PHERIPHERAL);
     print_status_blance( status_blance,  NUMBER_CELLS);
}

bool check_infor(uint8_t spi_rx_static_buf[]){
    if(spi_rx_static_buf[SPI_ESP_HEADER] != 'U' ||spi_rx_static_buf[SPI_ESP_END] !='\r' ) 
        return false;
    else{
        BYTE crc_check = 0x00;
        for(int i =0;i < SPI_ESP_CRC;i++)crc_check += spi_rx_static_buf[i];
        ESP_LOGI(TAG,"byte check %x and byte crc %x",crc_check,spi_rx_static_buf[SPI_ESP_END]);
        if(crc_check != spi_rx_static_buf[SPI_ESP_CRC]) return false;
    }
    return true;
}

float get_voltage_package1(float voltage[]){
    float voltage_float =0;
    for(int i =0 ;i < 4 ; i++){
        voltage_float += voltage[i];
    }
    return voltage_float;
}

float get_voltage_package2(float voltage[]){
    float voltage_float =0;
    for(int i = 4 ;i < 8 ; i++)
        voltage_float += voltage[i];
    return voltage_float;
}

float get_voltage_all_system(float voltage[]){
    float v1 = get_voltage_package1(voltage);
    float v2 = get_voltage_package2(voltage);
    return (v1 + v2)/2;
}

float get_temperature_package1(float temperature[]){
    float max = -1;
    for(int i = 0;i<4;i++){
        max = (max < temperature[i])? temperature[i]:max;
    }
    return max;
}
float get_temperature_package2(float temperature[]){
    float max = -1;
    for(int i = 4; i<8; i++){
        max = (max < temperature[i])? temperature[i]:max;
    }
    return max;
}
float get_temperature_all_system(float temperature[]){
    float t1 = get_temperature_package1(temperature);
    float t2 = get_temperature_package2(temperature);
    return (t1 > t2)? t1:t2;
}
// true means package 1 is blancing
// false menas package 1 is normal
bool get_blancing_package1(bool blance[]){
    bool temp = false; 
    for(int i = 0; i<4; i++){
        temp |= blance[i];
    }
    return temp;
}

// true means package 2 is blancing
// false menas package 2 is normal
bool get_blancing_package2(bool blance[]){
    bool temp = false; 
    for(int i = 4; i<8; i++){
        temp |= blance[i];
    }
    return temp;
}

bool get_blancing_all_system(bool blance[]){
    bool b1 = get_blancing_package2(blance);
    bool b2 = get_blancing_package2(blance);
    return b1 | b2;
}

CONNECT_STATUS get_connect_status_package1(bool status_pheripheral_relay1, float current_package1 ){
    if(status_pheripheral_relay1 == false) return DISCONNECT;
    if(status_pheripheral_relay1 == true ){
        if(current_package1  == 0) return CONNECT;
        else if(current_package1 > 0) return CHARGE;
        else return DISCHARGE;
    }
    return DISCONNECT;
}

CONNECT_STATUS get_connect_status_package2(bool status_pheripheral_relay2, float current_package2 ){
    if(status_pheripheral_relay2 == false) return DISCONNECT;
    if(status_pheripheral_relay2 == true ){
        if(current_package2  == 0) return CONNECT;
        else if(current_package2 > 0) return CHARGE;
        else return DISCHARGE;
    }
    return DISCONNECT;
}

CONNECT_STATUS get_connect_status_all_system(bool status_pheripheral_relay1, 
                                             float current_package1 ,
                                             bool status_pheripheral_relay2,
                                             float current_package2,
                                             float current_all_system){
    CONNECT_STATUS status_p1 = get_connect_status_package1(status_pheripheral_relay1,current_package1);
    CONNECT_STATUS status_p2 = get_connect_status_package2(status_pheripheral_relay2,current_package2);
    if(status_p1 == DISCONNECT && status_p2 == DISCONNECT) return DISCONNECT;
    else if(status_p1 == CONNECT && status_p2 == CONNECT) return CONNECT;
    else if (status_p1 == DISCHARGE || status_p2 == DISCHARGE) return DISCHARGE;
    else if (status_p1 == CHARGE || status_p2 == CHARGE) return CHARGE;
    else return DISCONNECT;
}

bool Warning_package1(float voltage[], float temperature[], float current){
    float voltage_p1 = get_voltage_package1(voltage);
    float temperature_p1 = get_temperature_package1(temperature);
    if( voltage_p1 > 16.8 || (temperature_p1 < 0 || temperature_p1 >100) || current > MAX_CURRENT){
        return false;
    }
    else
        return true;
}

bool Warning_package2(float voltage[], float temperature[], float current){
    float voltage_p2 = get_voltage_package2(voltage);
    float temperature_p2 = get_temperature_package2(temperature);
    if( voltage_p2 > 16.8 || (temperature_p2 < 0 || temperature_p2 >100) || current > MAX_CURRENT){
        return false;
    }
    else
        return true;
}

 bool Warning_all_system(float voltage[] , float temperature[], float current){
     bool package1 = Warning_package1(voltage, temperature, current);
     bool package2 = Warning_package1(voltage, temperature, current);
     return package1 & package2;
 }

 void update_table_package(float voltage[], float temperature[], float current[],
                                     bool blance[], bool status_pheripheral[])
{
    capacity_package[PACKAGE1] = get_voltage_package1( voltage);
    capacity_package[PACKAGE2] = get_voltage_package2( voltage);
    capacity_package[ALL_SYSTEM] = get_voltage_all_system( voltage);
  
    temperature_package[PACKAGE1] = get_temperature_package1( temperature);
    temperature_package[PACKAGE2]  = get_temperature_package2( temperature);
    temperature_package[ALL_SYSTEM]  = get_temperature_all_system( temperature);

    current_package[PACKAGE1] = current[PACKAGE1];
    current_package[PACKAGE2] = current[PACKAGE2];
    current_package[ALL_SYSTEM] = current[ALL_SYSTEM];

    blancing_package[PACKAGE1] = get_blancing_package1( blance);
    blancing_package[PACKAGE2] = get_blancing_package2( blance);
    blancing_package[ALL_SYSTEM] = get_blancing_all_system( blance);

    connect_package[PACKAGE1] = get_connect_status_package1(status_pheripheral[RELAY1_PACKAGE1],  current_package[PACKAGE1]  );
    connect_package[PACKAGE2] = get_connect_status_package2(status_pheripheral[RELAY2_PACKAGE2], current_package[PACKAGE2]);
    connect_package[ALL_SYSTEM] = get_connect_status_all_system(status_pheripheral[RELAY1_PACKAGE1],
                                                                current_package[PACKAGE1],
                                                                status_pheripheral[RELAY2_PACKAGE2], current_package[PACKAGE2],
                                                                current_package[ALL_SYSTEM]);
    
    warning_package[PACKAGE1] = Warning_package1(voltage, temperature, current_package[PACKAGE1]);
    warning_package[PACKAGE1] = Warning_package2(voltage, temperature, current_package[PACKAGE2]);
    warning_package[PACKAGE1] = Warning_all_system(voltage, temperature, current_package[ALL_SYSTEM]);
}

void print_infor_table_package(){
    ESP_LOGI("COLUMN 1 ","------------------------------CAPACITY--------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Voltage package %d : %f \n",i+1,capacity_package[i]);
    }
    ESP_LOGI("COLUMN 2 ","----------------------------TEMPERATURE-------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Temperature package %d : %f \n",i+1,temperature_package[i]);
    }
    ESP_LOGI("COLUMN 3 ","-------------------------------CURRENT--------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Current package %d : %f \n",i+1,current_package[i]);
    }
    ESP_LOGI("COLUMN 4 ","------------------------------BLANCING--------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Blancing package %d : %s \n",i+1,blancing_package[i] == true ?"Blancing":"Normal");
    }
    ESP_LOGI("COLUMN 5 ","------------------------------CONNECT--------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Connect Package package %d : %s \n",i+1,connect_package[i] == DISCONNECT ?"DISCONNECT":"CONNECT");
    }
    ESP_LOGI("COLUMN 6 ","------------------------------WARNING--------------------------" );
    for(int i = 0; i<NUMBER_PACKAGE;i++){
        printf("Warning Package package %d : %s \n",i+1,warning_package[i] == true ?"EMERGENCY":"NORMAL");
    }
}