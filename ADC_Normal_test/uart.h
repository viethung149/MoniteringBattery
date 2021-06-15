#ifndef  _UART_H
#define _UART_H
#include "stm32f4xx.h"
#include "stm32f4xx_usart.h"
#include "type.h"
void UART_init_config(void);
void UART_init_config_esp(void);
void UART_pin_config_esp(void);
void UART_pin_config(void);
void UART_PutChar(BYTE c);
void UART_PutChar_esp(BYTE c);
void UART_PutString(BYTE* str);
void UART_PutString_esp(BYTE* str);
uint16_t UART_GetChar(void);

#endif