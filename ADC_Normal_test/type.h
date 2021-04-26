#ifndef _TYPE_H
#define _TYPE_H
#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_syscfg.h"
typedef unsigned char   BYTE;
//-- define status Pin gpio ----
typedef enum
{ 
  OFF = 0,
  ON
}Status;
//--------------------- define types send uart ----------------------------------
typedef enum
{
	INFO = 0, // send data sensor   (Header I)
	HUMAN_TOUCH,// send when people pressbutton on the PCB board (Header H)
	EMER,       // send when emergency     (Header E)
}TX_types;
//-------------------- define for Extract frame -----------------------------
union floatToByte
{
	float variableFloat;
	char varialbeByte[4];
};
//------------------- constant value ----------------------
#define VOLTAGE_REF 2.95
#define NUMBER_READ 100
#define SENSITIVE_CURRENT_1 105
#define VOLTAGE_CURRENT_OFFSET 2500
//---------------------- define select pin-----------------------
#define MODULE1 				1
#define PORT_MODULE1     GPIOD 
#define ADC_MODULE1     ADC1
#define ENABLE_MODULE_1  GPIO_Pin_11
#define S0_MODULE_1  		GPIO_Pin_12
#define S1_MODULE_1  		GPIO_Pin_13
#define S2_MODULE_1  		GPIO_Pin_14
#define S3_MODULE_1  		GPIO_Pin_15
#define SIZE_MODULE_1   16
#define SIZE_BATTERY    16


#define MODULE2         2
#define PORT_MODULE2     GPIOE
#define ADC_MODULE2      ADC2
#define ENABLE_MODULE_2  GPIO_Pin_0
#define S0_MODULE_2  	   GPIO_Pin_1
#define S1_MODULE_2  		 GPIO_Pin_2
#define S2_MODULE_2  		 GPIO_Pin_3
#define S3_MODULE_2  		 GPIO_Pin_4
#define SIZE_MODULE_2   16
#define SIZE_TEMPERATURE 16

//---------------------- define ratio battery -----------------------
#define BATTERY1_P1  2
#define BATTERY2_P1  3
#define BATTERY3_P1  5
#define BATTERY4_P1  6

#define BATTERY1_P2  2
#define BATTERY2_P2  3
#define BATTERY3_P2  5
#define BATTERY4_P2  6

//--------------------- status battery ---------------------------------
#define  STATUS_B1 0
#define  STATUS_B2 1
#define  STATUS_B3 2
#define  STATUS_B4 3
#define  STATUS_B5 4
#define  STATUS_B6 5
#define  STATUS_B7 6
#define  STATUS_B8 7

//--------------------- status temperature -----------------------------
#define STATUS_T1  0
#define STATUS_T2  1
#define STATUS_T3  2
#define STATUS_T4  3
#define STATUS_T5  4
#define STATUS_T6  5
#define STATUS_T7  6
#define STATUS_T8  7
//--------------------- define ratio temperature--------------------------
#define TEM1_P1  100
#define TEM2_P1  100
#define TEM3_P1  0
#define TEM4_P1  0

#define TEM1_P2  0
#define TEM2_P2  0
#define TEM3_P2  0
#define TEM4_P2  0
//-------------------- define UART TX --------------------------------------
#define SIZE_BUFFER_TX     150
//-------------------- define UART RX --------------------------------------
#define SIZE_BUFFER_RX     1000
//---------------------- pheripheral --------------------------------
#define SIZE_PHERIPHERAL 16
#define START_STOP  0
#define LOAD_CHARGE 1
#define RELAY_1     2
#define RELAY_2     3
#define FAN_1       5
#define FAN_2       6
//---------------------- error ---------------------------------------
#define SIZE_EMER 32 
#define EMER_VOLTAGE_B1 0
#define EMER_VOLTAGE_B2 1
#define EMER_VOLTAGE_B3 2
#define EMER_VOLTAGE_B4 3
#define EMER_VOLTAGE_B5 4
#define EMER_VOLTAGE_B6 5
#define EMER_VOLTAGE_B7 6
#define EMER_VOLTAGE_B8 7

#define EMER_TEMP_B1 8
#define EMER_TEMP_B2 9
#define EMER_TEMP_B3 10
#define EMER_TEMP_B4 11
#define EMER_TEMP_B5 12
#define EMER_TEMP_B6 13
#define EMER_TEMP_B7 14
#define EMER_TEMP_B8 15

#define EMER_TEMP_CURRENT_1 16
#define EMER_TEMP_CURRENT_2 17
#define EMER_TEMP_CURRENT_3 18
#endif