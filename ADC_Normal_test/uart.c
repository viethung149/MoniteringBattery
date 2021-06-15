#include "uart.h"

void UART_init_config(void)
{
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1,ENABLE);
	USART_InitTypeDef uart;
	uart.USART_BaudRate=9600;
	uart.USART_HardwareFlowControl=USART_HardwareFlowControl_None;
	uart.USART_Mode=USART_Mode_Tx|USART_Mode_Rx;
	uart.USART_Parity=USART_Parity_No;
	uart.USART_StopBits=USART_StopBits_1;
	uart.USART_WordLength=USART_WordLength_8b;
	USART_Init(USART1,&uart);
	USART_ITConfig(USART1,USART_IT_RXNE,ENABLE);
	USART_Cmd(USART1,ENABLE);
	NVIC_InitTypeDef  nvic;
	nvic.NVIC_IRQChannel=USART1_IRQn;
	nvic.NVIC_IRQChannelCmd=ENABLE;
	nvic.NVIC_IRQChannelPreemptionPriority=0;
	nvic.NVIC_IRQChannelSubPriority=0;
	NVIC_Init(&nvic);
}
void UART_init_config_esp(void){
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART6,ENABLE);
	USART_InitTypeDef uart;
	uart.USART_BaudRate=9600;
	uart.USART_HardwareFlowControl=USART_HardwareFlowControl_None;
	uart.USART_Mode=USART_Mode_Tx|USART_Mode_Rx;
	uart.USART_Parity=USART_Parity_No;
	uart.USART_StopBits=USART_StopBits_1;
	uart.USART_WordLength=USART_WordLength_8b;
	USART_Init(USART6,&uart);
	USART_ITConfig(USART6,USART_IT_RXNE,ENABLE);
	USART_Cmd(USART6,ENABLE);
	NVIC_InitTypeDef  nvic;
	nvic.NVIC_IRQChannel=USART6_IRQn;
	nvic.NVIC_IRQChannelCmd=ENABLE;
	nvic.NVIC_IRQChannelPreemptionPriority=0;
	nvic.NVIC_IRQChannelSubPriority=0;
	NVIC_Init(&nvic);
}
// PC6 TX PC7 RX
void UART_pin_config_esp(void)
{
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC,ENABLE);
	GPIO_InitTypeDef gpio;
	gpio.GPIO_Mode=GPIO_Mode_AF;
	gpio.GPIO_OType=GPIO_OType_OD;
	gpio.GPIO_Pin=GPIO_Pin_6|GPIO_Pin_7;
	gpio.GPIO_PuPd=GPIO_PuPd_UP;
	gpio.GPIO_Speed=GPIO_Speed_100MHz;
	GPIO_Init(GPIOC,&gpio);
	GPIO_PinAFConfig (GPIOC,GPIO_PinSource6, GPIO_AF_USART6);
	GPIO_PinAFConfig (GPIOC,GPIO_PinSource7, GPIO_AF_USART6);
}
// PB6 TX PB7 RX
void UART_pin_config(void)
{
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB,ENABLE);
	GPIO_InitTypeDef gpio;
	gpio.GPIO_Mode=GPIO_Mode_AF;
	gpio.GPIO_OType=GPIO_OType_OD;
	gpio.GPIO_Pin=GPIO_Pin_6|GPIO_Pin_7;
	gpio.GPIO_PuPd=GPIO_PuPd_UP;
	gpio.GPIO_Speed=GPIO_Speed_100MHz;
	GPIO_Init(GPIOB,&gpio);
	GPIO_PinAFConfig (GPIOB,GPIO_PinSource6, GPIO_AF_USART1);
	GPIO_PinAFConfig (GPIOB,GPIO_PinSource7, GPIO_AF_USART1);
}

void UART_PutChar(BYTE c)
	{
		// check xem data dc chuyển đến thanh ghi dịch chưa nếu chưa thì bằng 0 nếu rổi thì bằng 1
		while(USART_GetFlagStatus (USART1, USART_FLAG_TXE)==0);
		USART_SendData(USART1,(uint16_t)c);
		
	}
	void UART_PutChar_esp(BYTE c)
	{
		// check xem data dc chuyển đến thanh ghi dịch chưa nếu chưa thì bằng 0 nếu rổi thì bằng 1
		while(USART_GetFlagStatus (USART6, USART_FLAG_TXE)==0);
		USART_SendData(USART6,(uint16_t)c);
		
	}
void UART_PutString(BYTE* str)
	{
		while(*str != '\n' )
		{
			UART_PutChar(*str);
			str++;
		}
	}
	void UART_PutString_esp(BYTE* str)
	{
		while(*str != '\n' )
		{
			UART_PutChar_esp(*str);
			str++;
		}
	}
uint16_t UART_GetChar(void)
{
 while(USART_GetFlagStatus(USART1,USART_FLAG_RXNE)==0);
 return USART_ReceiveData (USART1);
}