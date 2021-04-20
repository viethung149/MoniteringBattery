#include <stdio.h>
#include <stdlib.h>
int buffer[1000]={0};
union floatToByte
{
	float variableFloat;
	char varialbeByte[4];
};
typedef unsigned char BYTE;
void package_header( int types, BYTE buffer_tx[], int startIndex ){
if(types == 1){
	buffer_tx[startIndex] = 'I';
	//printf("buffer %d = %c \n",startIndex,buffer_tx[startIndex]);
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

void package_status_infor(int Flag_battery[],int size_battery,int Flag_temp[],int size_temp,BYTE buffer_tx[],int size_buffer_tx,int startIndex){
		for(int i =0 ;i < (size_battery / 8);i++){
				BYTE temp_byte = 0x00 ;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_battery[j] == 1 ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
                    //printf("temp status %x and temp byte is %x \n",temp_status,temp_byte);
				}
				buffer_tx[startIndex++]=temp_byte;
				//printf("battery status \n");
				//printf("buffer %d is %x \n",startIndex-1,buffer_tx[startIndex]);
		}
		for(int i =0 ;i < (size_temp / 8);i++){
				BYTE temp_byte = 0x00;
				for(int j = i*8;j< i*8+8;j++){
					BYTE temp_status = Flag_temp[j] == 1 ? 0x01 : 0x00;
					temp_byte |= (temp_status<<(j%8));
				}
				buffer_tx[startIndex++]=temp_byte;
				//printf("temp status \n");
				//printf("buffer %d is %x \n",startIndex-1,buffer_tx[startIndex]);
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
int main()
{
    unsigned char buffer_tx[200]={0};
    float voltage_module1[]={3.1, 3.2, 4.5, 6.8, 8, 9, 8, 6.8, 4, 5, 6,4, 3.3, 4.5, 7.8, 1.2};
    float voltage_module2[]={2.1,3.2,2.5,3.8,8.5,9.9,8.0,6.8,4.7,5.7,6.0,4.8,3.3,4.5,7.8,1.2};
    int Flag_battery[] ={1,1,1,1, 0,0,0,0, 1,0,0,1, 0,0,1,1};
    int Flag_temp[] ={1,1,1,1, 0,0,0,0, 1,0,0,1, 0,0,1,1};
    package_header(1,buffer_tx,0);
    package_data_infor(voltage_module1,16,voltage_module2,16,buffer_tx,200,1);
    package_status_infor(Flag_battery,16,Flag_temp,16,buffer_tx,200,129);
    package_crc_infor(buffer_tx,200,133);
    package_end(buffer_tx,200,134);
    for(int i =0 ;i<150; i++)
    {
        printf("byte %d is %x \n",i,buffer_tx[i]);
    }
}
