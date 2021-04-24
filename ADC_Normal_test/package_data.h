#ifndef _PACKAGE_DATA_H
#define _PACKAGE_DATA_H
#include "stm32f4xx.h"
#include "type.h"
extern BYTE buffer_tx[];
extern float voltage_module1[];
extern float voltage_module2[];
extern Status Flag_battery[];
extern Status Flag_temp[];
#define START_HEADER_INFO  0
#define START_DATA_INFO    1
#define START_STATUS_INFO  129
#define START_CRC_INFO     133
#define START_END_INFOR    134
void reset_buffer_tx(BYTE buffer_tx[],int size_buffer_tx);
void init_data_test(float voltage_module1[],
										int size_module1,
										float voltage_module2[],
										int size_module2,
										Status Flag_battery[],
										int size_battery,
										Status Flag_temp[],
										int size_temp);
										
void package_infor();
										
void package_header( TX_types types, BYTE buffer_tx[], int startIndex );

void package_data_infor(float voltage_module1[],
												int size_module1,
												float voltage_module2[],
												int size_module2,
												BYTE buffer_tx[],
												int size_buffer_tx,
												int startIndex);
												
void package_status_infor(Status Flag_battery[],
													int size_battery,
													Status Flag_temp[],
													int size_temp,
													BYTE buffer_tx[],
													int size_buffer_tx,
													int startIndex);
													
void package_crc_infor(BYTE buffer_tx[],
									     int size_buffer_tx,
									     int startIndex);
void package_end (BYTE buffer_tx[],
									int size_buffer,
									int startIndex);



#endif