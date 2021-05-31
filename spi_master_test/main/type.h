#ifndef _TYPE_H
#define _TYPE_H
#define GPIO_HANDSHAKE 2
#define GPIO_MOSI_VSPI 23
#define GPIO_MISO_VSPI 19
#define GPIO_SCLK_VSPI 18
#define GPIO_CS_VSPI 5
#define SIZE_BUFFER 92
#define TAG "SPI SLAVE"
//---------------------------define frame spi -----------------------
#define SPI_ESP_HEADER             0
#define SPI_ESP_VOLTAGE            1
#define SPI_ESP_TEMPERATURE        33
#define SPI_ESP_CURRENT            65
#define SPI_ESP_STATUS_VOLTAGE     77
#define SPI_ESP_STATUS_TEMPERATURE 78
#define SPI_ESP_STATUS_CURRENT     79
#define SPI_ESP_STATUS_PHERIPHERAL 80
#define SPI_ESP_STATUS_BLANCE      81
#define SPI_ESP_ADDING             82
#define SPI_ESP_CRC                90
#define SPI_ESP_END                91
#define NUMBER_CURRENT     3// actually is 3 but use 8 for byte package
#define NUMBER_PHERIPHERAL 4 // actually is 4 but use 8 for bytes package
#define NUMBER_CELLS       8
//-------------------------------- union extract float to byte --------------
union floatToByte
{
	float variableFloat;
	char variableByte[4];
};
typedef enum{
	DISCONNECT =0,
	CONNECT,
	CHARGE,
	DISCHARGE
}CONNECT_STATUS;
//-------------------current -------------------
#define MAX_CURRENT 3
#define CURRENT_ALL_SYSTEM 0
#define CURRENT_PACKAGE1   1
#define CURRENT_PACKAGE2   2

//----------------- BYTE
typedef unsigned char   BYTE;
// ----------------TABLE PACKAGE -----------------
#define NUMBER_PACKAGE 3
#define PACKAGE1 0
#define PACKAGE2 1
#define ALL_SYSTEM 2

//--------------------- pheripheral ------------------
#define RELAY1_PACKAGE1 0
#define RELAY2_PACKAGE2 1
#define RELAY3_FAN1 2
#define RELAY4_FAN2 3
// ---------------------BATTERRY --------------------------
#define BATTERY_1 0
#define BATTERY_2 1
#define BATTERY_3 2
#define BATTERY_4 3
#define BATTERY_5 4
#define BATTERY_6 5
#define BATTERY_7 6
#define BATTERY_8 7

//--------------------- RECEIVE -------------------
#define TAG_STM "REQUEST TO STM"
#define TAG_WIFI "WIFI CONNECTION"
#define TAG_FIREBASE "SEND TO FIREBASE"
#endif