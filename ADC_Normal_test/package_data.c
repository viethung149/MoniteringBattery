#include "package_data.h"
#include "uart.h"
void package_infor(){
	package_header( INFO, buffer_tx, START_HEADER_INFO);	
	package_data_infor(voltage_module1,SIZE_MODULE_1,voltage_module2,SIZE_MODULE_2, buffer_tx,SIZE_BUFFER_TX,START_DATA_INFO);	
	package_status_infor(Flag_battery, SIZE_BATTERY, Flag_temp,SIZE_TEMPERATURE,buffer_tx,SIZE_BUFFER_TX,START_STATUS_INFO);
	package_crc(buffer_tx,SIZE_BUFFER_TX,START_CRC_INFO);
	package_end (buffer_tx,SIZE_BUFFER_TX,START_END_INFOR);
	UART_PutString(buffer_tx);
	reset_buffer_tx(buffer_tx,SIZE_BUFFER_TX);
}
void package_human(){
	package_header( HUMAN_TOUCH, buffer_tx, START_HEADER_HUMAN);
	package_data_human(Flag_pheripheral,SIZE_PHERIPHERAL,buffer_tx, SIZE_BUFFER_TX,START_DATA_HUMAN);
	package_crc(buffer_tx,SIZE_BUFFER_TX,START_CRC_HUMAN);
	package_end(buffer_tx,SIZE_BUFFER_TX,START_END_HUMAN);
	UART_PutString(buffer_tx);
	reset_buffer_tx(buffer_tx,SIZE_BUFFER_TX);
}
void package_emer(){
	package_header( EMER, buffer_tx, START_HEADER_EMER);
	package_data_emer(Flag_emer,SIZE_EMER,buffer_tx, SIZE_BUFFER_TX,START_DATA_EMER);
	package_crc(buffer_tx,SIZE_BUFFER_TX,START_CRC_EMER);
	package_end(buffer_tx,SIZE_BUFFER_TX,START_END_EMER);
	UART_PutString(buffer_tx);
	reset_buffer_tx(buffer_tx,SIZE_BUFFER_TX);
}
void reset_buffer_tx(BYTE buffer_tx[],int size_buffer_tx)
{
	for(int i =0 ;i<size_buffer_tx; i++){
	buffer_tx[i] = 0x00;
	}
}

void init_data_test(float voltage_module1[],int size_module1,float voltage_module2[],int size_module2,Status Flag_battery[],int size_battery,Status Flag_temp[],int size_temp){
	for(int i =0 ;i< size_module1;i++)
	{
		voltage_module1[i]=3.2;
	}
	for(int i =0 ;i< size_module2;i++)
	{
		voltage_module2[i]=1.1;
	}
	for(int i =0 ;i< size_battery;i++)
	{
		Flag_battery[i]=OFF;
	}
	for(int i =0 ;i< size_temp;i++)
	{
		Flag_temp[i]=ON;
	}
}
void package_header( TX_types types, BYTE buffer_tx[], int startIndex ){
if(types == INFO){
	buffer_tx[startIndex] = 'I';
}
else if (types ==  HUMAN_TOUCH){
	buffer_tx[startIndex] = 'H';
}
else if (types ==  EMER){
	buffer_tx[startIndex] = 'E';
}
else{

}
}

void package_data_infor(float voltage_module1[],int size_module1,float voltage_module2[],int size_module2,BYTE buffer_tx[],int size_buffer_tx,int startIndex){
	union floatToByte temp;												
	for(int i =0 ;i<size_module1;i++){
		temp.variableFloat = voltage_module1[i];
		for(int index = 0 ; index < 4; index ++){
			buffer_tx[startIndex++] = temp.varialbeByte[index];
		}
	}
	for(int i =0 ;i<size_module2;i++){
		temp.variableFloat = voltage_module2[i];
		for(int index = 0 ; index < 4; index ++){
			buffer_tx[startIndex++] = temp.varialbeByte[index];
		}
	}
}
												
void package_status_infor(Status Flag_battery[],int size_battery,Status Flag_temp[],int size_temp,BYTE buffer_tx[],int size_buffer_tx,int startIndex){
		for(int i =0 ;i < (size_battery / 8);i++){
				BYTE temp_byte = 0x00 ;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_battery[j] == ON ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
				}
				buffer_tx[startIndex++]=temp_byte;
		}
		for(int i =0 ;i < (size_temp / 8);i++){
				BYTE temp_byte = 0x00;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_temp[j] == ON ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
				}
				buffer_tx[startIndex++]=temp_byte;
		}
}
													
void package_crc(BYTE buffer_tx[],int size_buffer_tx,int startIndex){
		BYTE crc = 0x00;
		for(int i = 0; i< startIndex;i++)
		{
			crc += buffer_tx[i];
		}
		buffer_tx[startIndex]=crc;
}
void package_end (BYTE buffer_tx[],int size_buffer,int startIndex){
	buffer_tx[startIndex++] = '\r';
	buffer_tx[startIndex++] = '\n';
}


// data human
void package_data_human(Status Flag_pheripheral[],int size_flag_pheripheral,BYTE buffer_tx[],int size_buffer_tx,int startIndex){
	for(int i =0 ;i < (size_flag_pheripheral / 8);i++){
				BYTE temp_byte = 0x00 ;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_pheripheral[j] == ON ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
				}
				buffer_tx[startIndex++]=temp_byte;
		}
}
// data_emer
void package_data_emer(Status Flag_emer[], int size_flag_emer,BYTE buffer_tx[],int size_buffer_tx,int startIndex){
		for(int i =0 ;i < (size_flag_emer / 8);i++){
				BYTE temp_byte = 0x00 ;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_emer[j] == ON ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
				}
				buffer_tx[startIndex++]=temp_byte;
		}
}	