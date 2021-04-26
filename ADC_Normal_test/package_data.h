#ifndef _PACKAGE_DATA_H
#define _PACKAGE_DATA_H
#include "stm32f4xx.h"
#include "type.h"
extern BYTE buffer_tx[];
extern float voltage_module1[];
extern float voltage_module2[];
extern Status Flag_battery[];
extern Status Flag_temp[];
extern Status Flag_pheripheral[];
extern Status Flag_emer[];
#define START_HEADER_INFO  0
#define START_DATA_INFO    1
#define START_STATUS_INFO  129
#define START_CRC_INFO     133
#define START_END_INFOR    134

#define START_HEADER_HUMAN 0
#define START_DATA_HUMAN 1
#define START_CRC_HUMAN 3
#define START_END_HUMAN 4

#define START_HEADER_EMER 0
#define START_DATA_EMER 1
#define START_CRC_EMER 5
#define START_END_EMER 6

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
												
void package_status_infor(Status Flag_battery[],
													int size_battery,
													Status Flag_temp[],
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
void package_data_emer(Status Flag_emer[], 
											int size_flag_emer,
											BYTE buffer_tx[],
											int size_buffer_tx,
											int startIndex);												

//final 
void package_infor(void);
void package_human(void);
void package_emer(void);											


#endif