#ifndef _TYPE_H
#define _TYPE_H
#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_syscfg.h"
typedef enum
{ 
  OFF = 0,
  ON
}Status;

#define VOLTAGE_REF 2.95
#define NUMBER_READ 100
#define SENSITIVE_CURRENT_1 105
#define VOLTAGE_CURRENT_OFFSET 2500
//---------------------- define select pin-----------------------
#define MODULE1 				1
#define ADC_MODULE1     ADC1
#define ENABLE_MODULE_1  GPIO_Pin_11
#define S0_MODULE_1  		GPIO_Pin_12
#define S1_MODULE_1  		GPIO_Pin_13
#define S2_MODULE_1  		GPIO_Pin_14
#define S3_MODULE_1  		GPIO_Pin_15

#define MODULE2         2
#define ADC_MODULE2     ADC2
#define ENABLE_MODULE_2  GPIO_Pin_0
#define S0_MODULE_2  	   GPIO_Pin_1
#define S1_MODULE_2  		 GPIO_Pin_2
#define S2_MODULE_2  		 GPIO_Pin_3
#define S3_MODULE_2  		 GPIO_Pin_4

#define PORT_MODULE1     GPIOD 
#define PORT_MODULE2     GPIOE
//---------------------- define ratio battery -----------------------
#define BATTERY1_P1  2
#define BATTERY2_P1  3
#define BATTERY3_P1  5
#define BATTERY4_P1  6

#define BATTERY1_P2  2
#define BATTERY2_P2  3
#define BATTERY3_P2  5
#define BATTERY4_P2  6

//--------------------- define ratio temperature--------------------------
#define TEM1_P1  100
#define TEM2_P1  100
#define TEM3_P1  0
#define TEM4_P1  0

#define TEM1_P2  0
#define TEM2_P2  0
#define TEM3_P2  0
#define TEM4_P2  0

#endif