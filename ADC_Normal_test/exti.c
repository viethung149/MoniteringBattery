#include "exti.h"

void EXTI_Pin_config(void)
{
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD,ENABLE);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
	GPIO_InitTypeDef GPIO_config;
  //set pin for external interrup Pin PD2 -> 5 button 
	// pin 6 handshark stm32f103
	// pin 7 handshark esp32
	GPIO_config.GPIO_Mode=GPIO_Mode_IN;
	GPIO_config.GPIO_Pin=GPIO_Pin_8|GPIO_Pin_6;
	GPIO_config.GPIO_OType=GPIO_OType_PP;
	GPIO_config.GPIO_PuPd=GPIO_PuPd_DOWN;
	GPIO_config.GPIO_Speed=GPIO_Speed_100MHz;
	GPIO_Init(GPIOD,&GPIO_config);

	SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource6);//handshark stm32f1
	SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource8);//handshark esp32
}
void EXTI_line_config(void)
{
	EXTI_InitTypeDef   EXTI_InitStructure;
	EXTI_InitStructure.EXTI_Line = EXTI_Line6;
	EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
	EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
	EXTI_InitStructure.EXTI_LineCmd = ENABLE;
	EXTI_Init(&EXTI_InitStructure);

	NVIC_InitTypeDef   NVIC_InitStructure;
	NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
	
	EXTI_InitStructure.EXTI_Line = EXTI_Line8;
	EXTI_Init(&EXTI_InitStructure);
	NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
	EXTI_Init(&EXTI_InitStructure);
//	EXTI_InitStructure.EXTI_Line = EXTI_Line1;
//	EXTI_Init(&EXTI_InitStructure);

//	NVIC_InitStructure.NVIC_IRQChannel = EXTI1_IRQn;
//	NVIC_Init(&NVIC_InitStructure);
//	
//	EXTI_InitStructure.EXTI_Line = EXTI_Line2;
//	EXTI_Init(&EXTI_InitStructure);

//	NVIC_InitStructure.NVIC_IRQChannel = EXTI2_IRQn;
//	NVIC_Init(&NVIC_InitStructure);
//	
//	EXTI_InitStructure.EXTI_Line = EXTI_Line3;
//	EXTI_Init(&EXTI_InitStructure);

//	NVIC_InitStructure.NVIC_IRQChannel = EXTI3_IRQn;
//	NVIC_Init(&NVIC_InitStructure);
//	

//	

//	
//	EXTI_InitStructure.EXTI_Line = EXTI_Line6;
//	EXTI_Init(&EXTI_InitStructure);
//	
//	NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
//	NVIC_Init(&NVIC_InitStructure);
//	
//	EXTI_ClearITPendingBit(EXTI_Line2);
//	EXTI_ClearITPendingBit(EXTI_Line3);
//	EXTI_ClearITPendingBit(EXTI_Line4);
//	EXTI_ClearITPendingBit(EXTI_Line5);
//	EXTI_ClearITPendingBit(EXTI_Line6);
}