#ifndef _DATA_H
#define _DATA_H
#include "type.h"
#include "slave.h"
extern WORD_ALIGNED_ATTR uint8_t spi_rx_static_buf[];
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

void get_voltage(uint8_t spi_rx_static_buf[], float voltage[],int size);
void get_temperature(uint8_t spi_rx_static_buf[], float temperature[],int size);
void get_current(uint8_t spi_rx_static_buf[], float current[],int size);
void get_status_voltage(uint8_t spi_rx_static_buf[],bool status_voltage[],int size);
void get_status_temperature(uint8_t spi_rx_static_buf[],bool status_temperature[],int size);
void get_status_current(uint8_t spi_rx_static_buf[],bool status_current[],int size);
void get_status_pheripheral(uint8_t spi_rx_static_buf[],bool status_pheripheral[],int size);
void get_status_blance(uint8_t spi_rx_static_buf[],bool status_blance[],int size);

void print_voltage(float voltage[], int size);
void print_temperature(float temperature[], int size);
void print_current(float current[], int size);
void print_status_voltage(bool status_voltage[], int size);
void print_status_temperature(bool status_temperature[], int size);
void print_status_current(bool status_current[], int size);
void print_status_pheripheral(bool status_pheripheral[], int size);
void print_status_blance(bool status_blance[], int size);
void print_all_infor(void);
bool check_infor(uint8_t spi_rx_static_buf[]);
void get_all();
// get information
float get_voltage_package1(float voltage[]);
float get_voltage_package2(float voltage[]);
float get_voltage_all_system(float voltage[]);
float get_temperature_package1(float temperature[]);
float get_temperature_package2(float temperature[]);
float get_temperature_all_system(float temperature[]);
// true means package 1 is blancing
// false menas package 1 is normal
bool get_blancing_package1(bool blance[]);

// true means package 2 is blancing
// false menas package 2 is normal
bool get_blancing_package2(bool blance[]);
bool get_blancing_all_system(bool blance[]);
CONNECT_STATUS get_connect_status_package1(bool status_pheripheral_relay1, float current_package1 );
CONNECT_STATUS get_connect_status_package2(bool status_pheripheral_relay2, float current_package2 );
CONNECT_STATUS get_connect_status_all_system(bool status_pheripheral_relay1, 
                                             float current_package1 ,
                                             bool status_pheripheral_relay2,
                                             float current_package2,
                                             float current_all_system);
bool Warning_package1(float voltage[], float temperature[], float current);
bool Warning_package2(float voltage[], float temperature[], float current);
bool Warning_all_system(float voltage[] , float temperature[], float current);

void update_table_package(float voltage[], float temperature[], float current[],
                                     bool blance[], bool status_pheripheral[]);
void print_infor_table_package();                                     
#endif