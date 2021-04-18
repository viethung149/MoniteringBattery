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