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

void get_all();
#endif