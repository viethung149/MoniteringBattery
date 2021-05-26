#ifndef _PACKAGE_DATA_H
#define _PACKAGE_DATA_H
#include "stm32f4xx.h"
#include "type.h"
#include "spi.h"
#include "uart.h"
#include "delay.h"
extern BYTE buffer_tx_uart[];
extern BYTE buffer_tx_spi[];
extern float voltage_module1[];
extern float voltage_module2[];
extern B_Voltage_status Flag_battery[];
extern B_Voltage_status Flag_temp[];
extern Status Flag_pheripheral[];
extern B_Voltage_status Flag_emer[];
#define START_HEADER_INFO  0
#define START_DATA_INFO    1
#define START_STATUS_INFO  129
#define START_CRC_INFO     133
#define START_END_INFOR    134

#define START_HEADER_HUMAN 0
#define START_DATA_HUMAN 1
#define START_CRC_HUMAN 3
#define START_END_HUMAN 134

#define START_HEADER_EMER 0
#define START_DATA_EMER 1
#define START_CRC_EMER 5
#define START_END_EMER 134

void reset_buffer_tx(BYTE buffer_tx[],int size_buffer_tx);
void init_data_test(float voltage_module1[],
										int size_module1,
										float voltage_module2[],
										int size_module2,
										Status Flag_battery[],
										int size_battery,
										Status Flag_temp[],
										int size_temp);
// human infor									
								
void package_header( TX_types types, BYTE buffer_tx[], int startIndex );

void package_data_infor(float voltage_module1[],
												int size_module1,
												float voltage_module2[],
												int size_module2,
												BYTE buffer_tx[],
												int size_buffer_tx,
												int startIndex);
												
void package_status_infor(B_Voltage_status Flag_battery[],
													int size_battery,
													B_Voltage_status Flag_temp[],
													int size_temp,
													BYTE buffer_tx[],
													int size_buffer_tx,
													int startIndex);
													
void package_crc(BYTE buffer_tx[],
									     int size_buffer_tx,
									     int startIndex);
void package_end (BYTE buffer_tx[],
									int size_buffer,
									int startIndex);

//-- human data

void package_data_human(Status Flag_pheripheral[],
												int size_flag_pheripheral,
												BYTE buffer_tx[],
												int size_buffer_tx,
												int startIndex);
// -- emer
void package_data_emer(B_Voltage_status Flag_emer[], 
											int size_flag_emer,
											BYTE buffer_tx[],
											int size_buffer_tx,
											int startIndex);												

//final 
void package_infor(void);
// human package have 5 byte
// HEADER, DATA, CRC, END 
void package_human(void);
// emer packet send flag that tell the status of the bin baterry
// V > 4.2 flag = MAX,  V< 0 flag = MIN , nothing wrong is NORMAL
// temp > 100 flag = MAX, temp< 0 flag = MIN, nothing wrong is NORMAL
void package_emer(void);											
void set_emer_flag(float* battery_voltage,
									 int size_battery,
									 float* temp_voltage,
									 int size_temp,
									 B_Voltage_status* Flag_emer,
									 int size_emer_flag);
void package_infor_spi();
void package_human_spi();
void package_emer_spi();
#endif