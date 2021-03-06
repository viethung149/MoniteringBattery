#include "delay.h"
/* use timer 6 to delay micro second 
   use time-tick to delay mili second */
void Delay_ms(__IO uint32_t nTime)
{
  TimingDelay = nTime;

  while(TimingDelay != 0);
}
void timetick_configure()
	{
		 if (SysTick_Config(SystemCoreClock / 1000))
		{
			while (1);
		}
	}
void SysTick_Handler(void)
{
  if (TimingDelay != 0x00)
  {
    TimingDelay--;
  }
}
void Dellay_us(uint16_t period){

  	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM6, ENABLE);
  	TIM6->PSC = 83;		// clk = SystemCoreClock /2/(PSC+1) = 1MHz
  	TIM6->ARR = period-1;
  	TIM6->CNT = 0;
  	TIM6->EGR = 1;		// update registers;

  	TIM6->SR  = 0;		// clear overflow flag
  	TIM6->CR1 = 1;		// enable Timer6

  	while (!TIM6->SR);
    
  	TIM6->CR1 = 0;		// stop Timer6
  	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM6, DISABLE);
}
