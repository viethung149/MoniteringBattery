#include "data.h"
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
void get_temperature(uint8_t spi_rx_static_buf[], float temperature[],int size){
     ESP_LOGI(TAG,"... in get temperature \n");
    int start_index = SPI_ESP_TEMPERATURE;
    for(int i = 0; i<size;i++){
        union floatToByte temp;
        for(int j=start_index; j<start_index+4;j++){
            temp.variableByte[j-start_index] = spi_rx_static_buf[j];
        }
        temperature[i] = temp.variableFloat;
        start_index +=4;
    }
}
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
void get_status_voltage(uint8_t spi_rx_static_buf[],bool status_voltage[],int size){
     ESP_LOGI(TAG,"... in get_status_voltage \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_VOLTAGE];
    for(int i = size-1 ;i>=0;i--){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_voltage[i] = ((status>>1) & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
void get_status_temperature(uint8_t spi_rx_static_buf[],bool status_temperature[],int size){
    ESP_LOGI(TAG,"... in get_status_temperature \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_TEMPERATURE];
    for(int i = size-1 ;i>=0;i--){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_temperature[i] = ((status>>1) & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
void get_status_current(uint8_t spi_rx_static_buf[],bool status_current[],int size){
    ESP_LOGI(TAG,"... in get_status_current \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_CURRENT];
    for(int i = size-1 ;i>=0;i--){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_current[i] = ((status>>1) & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
void get_status_pheripheral(uint8_t spi_rx_static_buf[],bool status_pheripheral[],int size){
    ESP_LOGI(TAG,"... in get_status_pheripheral \n");
    BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_PHERIPHERAL];
    for(int i = size-1 ;i>=0;i--){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_pheripheral[i] = ((status>>1) & 0x01) ==0x01? true:false;
        status >>=1;
    }
}
void get_status_blance(uint8_t spi_rx_static_buf[],bool status_blance[],int size){
    ESP_LOGI(TAG,"... in get_status_blance \n");

     BYTE status = spi_rx_static_buf[SPI_ESP_STATUS_BLANCE];
    for(int i = size-1 ;i>=0;i--){
        // true mean wrong voltage
        // flase mean this is the accepted voltege
        status_blance[i] = ((status>>1) & 0x01) ==0x01? true:false;
        status >>=1;
    }
}

void get_all(){
    get_voltage( spi_rx_static_buf,  voltage, NUMBER_VOLTAGE);
    get_temperature( spi_rx_static_buf,  temperature, NUMBER_TEMPERATURE);
    get_current( spi_rx_static_buf,  current, NUMBER_CURRENT);
    get_status_voltage( spi_rx_static_buf, status_voltage, NUMBER_VOLTAGE);
    get_status_temperature( spi_rx_static_buf, status_temperature, NUMBER_TEMPERATURE);
    get_status_current( spi_rx_static_buf, status_current, NUMBER_VOLTAGE);
    get_status_pheripheral( spi_rx_static_buf, status_pheripheral, NUMBER_PHERIPHERAL);
    get_status_blance( spi_rx_static_buf, status_blance, NUMBER_VOLTAGE);
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
     print_voltage( voltage,  NUMBER_VOLTAGE);
     print_temperature( temperature,  NUMBER_TEMPERATURE);
     print_current( current, NUMBER_CURRENT);
     print_status_voltage( status_voltage,  NUMBER_VOLTAGE);
     print_status_temperature( status_temperature,  NUMBER_TEMPERATURE);
     print_status_current( status_current,  NUMBER_VOLTAGE);
     print_status_pheripheral( status_pheripheral,  NUMBER_PHERIPHERAL);
     print_status_blance( status_blance,  NUMBER_VOLTAGE);
}