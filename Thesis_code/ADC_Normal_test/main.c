#include "stm32f4xx.h"                  // Device header
#include "stdio.h"
#include "delay.h"
#include "misc.h"
#include "uart.h"
#include "timer.h"
#include "adc.h"
#include "exti.h"
#include "status.h"
#include "type.h"
float voltage_module1[16]={0};
int cnt=1;
int battery_temp_ratio[]={BATTERY1_P1,
													BATTERY2_P1,
													BATTERY3_P1,
													BATTERY4_P1,
													BATTERY1_P2,
													BATTERY2_P2,
													BATTERY3_P2,
													BATTERY4_P2,
													TEM1_P1,
													TEM2_P1,
													TEM3_P1,
													TEM4_P1,
													TEM1_P2,
													TEM2_P2,
													TEM3_P2,
													TEM4_P2};

int temperature_ratio[]={};
//--uart--//
char RX_buffer[1000]={0};
int index_rx_buffer=0;

//--adc--//
BitAction READ_ADC_FLAG = Bit_RESET;

//--status--//
Status s_start_stop = OFF;
Status s_load_charge = OFF;
Status s_package1 =OFF;
Status s_package2 =OFF;
Status s_Fan1=OFF;
Status s_Fan2= OFF;


///* USER CODE BEGIN PFP */
///* Private function prototypes -----------------------------------------------*/
struct __FILE
{
  int handle;
  /* Whatever you require here. If the only file you are using is */
  /* standard output using printf() for debugging, no file handling */
  /* is required. */
};
/* USER CODE END PFP */
/* USER CODE BEGIN 4 */
/*send text over SWV*/
int fputc(int ch, FILE *f) {
    ITM_SendChar(ch);//send method for SWV
    return(ch);
}
///* USER CODE END 4 */
//----------------------------------------------------------------------------------------------------


//----------------------------------------------------------------------------------------------------
//interrup uart 
void USART1_IRQHandler(void)
{
	while(USART_GetITStatus(USART1,USART_IT_RXNE)==1)
	{
			GPIO_SetBits(GPIOC,GPIO_Pin_6);
			printf("read from  uart \n");
			RX_buffer[index_rx_buffer++]=USART1->DR;
			if(index_rx_buffer==100)index_rx_buffer=0;
			GPIO_ResetBits(GPIOC, GPIO_Pin_6);
	}
}
//----------------------------------------------------------------------------------------------------
// interrup timer 2
void TIM2_IRQHandler(void) {
	if (TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET)// kiem tra xem co ngat cua tim 2 bat chua
	{
		TIM_Cmd(TIM2,DISABLE);	
		if(READ_ADC_FLAG == Bit_RESET )
		{	
			for(int i =0 ; i < 16 ; i++ )
			{
				voltage_module1[i]= ADC_get_voltage_from_channel(ADC1,NUMBER_READ,i,VOLTAGE_REF);
				Dellay_us(10);
			}
		
		}
		TIM_Cmd(TIM2,ENABLE);
		READ_ADC_FLAG=Bit_SET;
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);//xoa co  ngat nho thanh  ghi pending bit
	}
}
//----------------------------------------------------------------------------------------------------
// handler external 0 PCD0
// control Relay start stop 
// Led PC 0
void EXTI0_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line0) != RESET)
  {
		if(s_start_stop == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_0);
			s_start_stop = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_0);
			s_start_stop = OFF;
		}
		printf("press button start/stop \n");
    EXTI_ClearITPendingBit(EXTI_Line0);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 1 PCD1
// control Relay load charge 
// Led PC 1
void EXTI1_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line1) != RESET)
  {
		if(s_load_charge == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_1);
			s_load_charge = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_1);
			s_load_charge = OFF;
		}
		printf("press button load/ charge \n");
    EXTI_ClearITPendingBit(EXTI_Line1);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 2 PCD2
// control Package 1 
// Led PC 2
void EXTI2_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line2) != RESET)
  {
		if(s_package1 == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_2);
			s_package1 = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_2);
			s_package1 = OFF;
		}
		printf("press button package 1 \n");
    EXTI_ClearITPendingBit(EXTI_Line2);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 3 PCD3
// control Package 2 
// Led PC 2
void EXTI3_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line3) != RESET)
  {
		if(s_package2 == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_3);
			s_package2 = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_3);
			s_package2 = OFF;
		}
		printf("press button package 2 \n");
    EXTI_ClearITPendingBit(EXTI_Line3);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 4 PCD4
// control Fan1 
// Led PC 3
void EXTI4_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line4) != RESET)
  {
		if(s_Fan1 == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_4);
			s_Fan1 = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_4);
			s_Fan1 = OFF;
		}
		printf("press button Fan1 \n");
    EXTI_ClearITPendingBit(EXTI_Line4);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 5 PCD5
// control Fan2 
// Led PC 4
void EXTI9_5_IRQHandler(void){
  if(EXTI_GetITStatus(EXTI_Line5) != RESET)
  {
		if(s_Fan2 == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_5);
			s_Fan2 = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_5);
			s_Fan2 = OFF;
		}
		printf("press button Fan2 \n");
    EXTI_ClearITPendingBit(EXTI_Line5);
  }
}
//----------------------------------------------------------------------------------------------------
int main()
{
	//printf("Test ADC /n");
	SystemInit();
	ADC_pin_select_config();
	ADC_pin_config();
	timetick_configure();
	UART_pin_config();
	UART_init_config();
	//EXTI_Pin_config();
	//EXTI_line_config();
	TIMER_interupt_config();
	STATUS_pin_peripheral_config();
	while(1)
	{
	  if(READ_ADC_FLAG == Bit_SET)
		{
			for(int i =0 ;i<16; i++){
				//printf("Voltage %d read is %1.3f \n",i+1,voltage_module1[i]*battery_temp_ratio[i]);
			}
			READ_ADC_FLAG = Bit_RESET;
		}
	}
	return 0;
}