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
#define NUMBER_VOLTAGE     8
#define NUMBER_TEMPERATURE 8
#define NUMBER_CURRENT     3// actually is 3 but use 8 for byte package
#define NUMBER_PHERIPHERAL 8 // actually is 4 but use 8 for bytes package
//-------------------------------- union extract float to byte --------------
union floatToByte
{
	float variableFloat;
	char variableByte[4];
};
//----------------- BYTE
typedef unsigned char   BYTE;
#endif