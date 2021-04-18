#ifndef  _UART_H
#define _UART_H
#include "stm32f4xx.h"
#include "stm32f4xx_usart.h"
void INIT_UART(void);
void INIT_GPIOUART(void);
void INIT_IT_UART(void);
void USART_PutChar(char c);
void USART_PutString(char* str);
uint16_t USART_GetChar(void);

#endif