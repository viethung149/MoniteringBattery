#include "timer.h"

void TIMER_interupt_config(void)
{
	TIM_TimeBaseInitTypeDef tim_struct;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	tim_struct.TIM_Period = 3000000-1;
	tim_struct.TIM_Prescaler = (uint16_t)(SystemCoreClock/2/1000000)-1;
	tim_struct.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM2, &tim_struct);
	TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);
	TIM_Cmd(TIM2, ENABLE);
	TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
  //configure interrup timer 2
	NVIC_InitTypeDef nvic_struct;
	nvic_struct.NVIC_IRQChannel = TIM2_IRQn;
	nvic_struct.NVIC_IRQChannelPreemptionPriority =1;
	nvic_struct.NVIC_IRQChannelSubPriority =0;
	nvic_struct.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&nvic_struct);
}