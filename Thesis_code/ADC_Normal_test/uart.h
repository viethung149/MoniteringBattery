#ifndef  _UART_H
#define _UART_H
#include "stm32f4xx.h"
#include "stm32f4xx_usart.h"
void UART_init_config(void);
void UART_pin_config(void);
void UART_PutChar(char c);
void UART_PutString(char* str);
uint16_t UART_GetChar(void);

#endif