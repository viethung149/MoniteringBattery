#include "uart.h"
void UART_init_config(void)
{
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1,ENABLE);
	USART_InitTypeDef uart;
	uart.USART_BaudRate=19200;
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

void UART_PutChar(char c)
	{
		// check xem data dc chuyển đến thanh ghi dịch chưa nếu chưa thì bằng 0 nếu rổi thì bằng 1
		//while(USART_GetFlagStatus (USART1, USART_FLAG_TXE)==0);
		USART_SendData(USART1,(uint16_t)c);
		
	}
void UART_PutString(char* str)
	{
		while(*str )
		{
			UART_PutChar(*str);
			str++;
		}
	}
uint16_t UART_GetChar(void)
{
 while(USART_GetFlagStatus(USART1,USART_FLAG_RXNE)==0);
 return USART_ReceiveData (USART1);
}