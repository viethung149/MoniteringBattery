#include "package_data.h"
void reset_buffer_tx(BYTE buffer_tx[],int size_buffer_tx)
{
	for(int i =0 ;i<size_buffer_tx; i++){
	buffer_tx[i] = 0x00;
	}
}

void init_data_test(float voltage_module1[],int size_module1,float voltage_module2[],int size_module2,Status Flag_battery[],int size_battery,Status Flag_temp[],int size_temp){
	for(int i =0 ;i< size_module1;i++)
	{
		voltage_module1[i]=1.1;
	}
	for(int i =0 ;i< size_module2;i++)
	{
		voltage_module2[i]=5.1;
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
													
void package_crc_infor(BYTE buffer_tx[],int size_buffer_tx,int startIndex){
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

void package_infor(){
		package_header( INFO, buffer_tx, START_HEADER_INFO);	
		package_data_infor(voltage_module1,SIZE_MODULE_1,voltage_module2,SIZE_MODULE_2, buffer_tx,SIZE_BUFFER_TX,START_DATA_INFO);	
		package_status_infor(Flag_battery, SIZE_BATTERY, Flag_temp,SIZE_TEMPERATURE,buffer_tx,SIZE_BUFFER_TX,START_STATUS_INFO);
		package_crc_infor(buffer_tx,SIZE_BUFFER_TX,START_CRC_INFO);
		package_end (buffer_tx,SIZE_BUFFER_TX,START_END_INFOR);
}