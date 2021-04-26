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
#include "package_data.h"
float voltage_module1[SIZE_MODULE_1]={0};
float voltage_module2[SIZE_MODULE_2]={0};
Status Flag_battery[SIZE_BATTERY]={OFF};
Status Flag_temp[SIZE_TEMPERATURE]= {OFF};
Status Flag_pheripheral[SIZE_PHERIPHERAL] ={OFF};
Status Flag_emer[SIZE_EMER] = {OFF};
BYTE buffer_tx[SIZE_BUFFER_TX]={0};
BYTE buffer_rx[SIZE_BUFFER_RX]={0};

uint16_t PIN_SELECT_MODULE1[]={ENABLE_MODULE_1, 
															 S0_MODULE_1,
															 S1_MODULE_1,
															 S2_MODULE_1,
															 S3_MODULE_1};

uint16_t PIN_SELECT_MODULE2[]={ENABLE_MODULE_2,
															 S0_MODULE_2,
															 S1_MODULE_2,
															 S2_MODULE_2,
															 S3_MODULE_2};
int cnt=1;
int battery_ratio[]={BATTERY1_P1,
										 BATTERY2_P1,
										 BATTERY3_P1,
										 BATTERY4_P1,
										 BATTERY1_P2,
										 BATTERY2_P2,
										 BATTERY3_P2,
										 BATTERY4_P2,
										 0,0,0,0,0,0,0,0};
int temp_ratio[]={TEM1_P1,
									TEM2_P1,
									TEM3_P1,
									TEM4_P1,
									TEM1_P2,
									TEM2_P2,
									TEM3_P2,
								  TEM4_P2,
									0,0,0,0,0,0,0,0};

int temperature_ratio[]={};
//--uart--//
char RX_buffer[1000]={0};
int index_rx_buffer=0;

//--adc--//
BitAction READ_ADC_FLAG = Bit_RESET;




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
//void USART1_IRQHandler(void)
//{
//	while(USART_GetITStatus(USART1,USART_IT_RXNE)==1)
//	{
//			GPIO_SetBits(GPIOC,GPIO_Pin_6);
//			printf("read from  uart \n");
//			RX_buffer[index_rx_buffer++]=USART1->DR;
//			if(index_rx_buffer==100)index_rx_buffer=0;
//			GPIO_ResetBits(GPIOC, GPIO_Pin_6);
//	}
//}
//----------------------------------------------------------------------------------------------------
// interrup timer 2
void TIM2_IRQHandler(void) {
	if (TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET)// kiem tra xem co ngat cua tim 2 bat chua
	{	
		GPIO_ToggleBits(GPIOC,GPIO_Pin_5);
//		TIM_Cmd(TIM2,DISABLE);	
//		if(READ_ADC_FLAG == Bit_RESET )
//		{	
//			for(int i =0 ; i < 8 ; i++ )
//			{
//				voltage_module1[i]= ADC_get_voltage_from_channel(ADC_MODULE1,NUMBER_READ,i,MODULE1,VOLTAGE_REF);
//				Dellay_us(10);
//			}
//			ADC_Cmd(ADC1,DISABLE);
//			for(int i =0 ; i < 4 ; i++ )
//			{
//				voltage_module2[i]= ADC_get_voltage_from_channel(ADC_MODULE2,NUMBER_READ,i,MODULE2,VOLTAGE_REF);
//				Dellay_us(10);
//			}
//			ADC_Cmd(ADC2,DISABLE);
//		}

//		TIM_Cmd(TIM2,ENABLE);
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
		if(Flag_pheripheral[START_STOP] == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_0);
			Flag_pheripheral[START_STOP] = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_0);
			Flag_pheripheral[START_STOP] = OFF;
		}
		package_human();
		printf("press button start/stop \n");
		//send the packet
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
		if(Flag_pheripheral[LOAD_CHARGE] == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_1);
			Flag_pheripheral[LOAD_CHARGE] = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_1);
			Flag_pheripheral[LOAD_CHARGE] = OFF;
		}
		package_human();
		//send the packet
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
		if(Flag_pheripheral[RELAY_1] == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_2);
			Flag_pheripheral[RELAY_1] = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_2);
			Flag_pheripheral[RELAY_1] = OFF;
		}
		package_human();
		//send the packet
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
		if(Flag_pheripheral[RELAY_2] == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_3);
			Flag_pheripheral[RELAY_2]  = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_3);
			Flag_pheripheral[RELAY_2] = OFF;
		}
		package_human();
		//send the packet
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
		if(Flag_pheripheral[FAN_1]  == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_4);
			Flag_pheripheral[FAN_1]  = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_4);
			Flag_pheripheral[FAN_1]  = OFF;
		}
		package_human();
		//send the packet
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
		if(Flag_pheripheral[FAN_2] == OFF)
		{
			GPIO_SetBits(GPIOC, GPIO_Pin_5);
			Flag_pheripheral[FAN_2] = ON;
		}
		else
		{
			GPIO_ResetBits(GPIOC, GPIO_Pin_5);
			Flag_pheripheral[FAN_2] = OFF;
		}
		package_human();
		//send the packet
		printf("press button Fan2 \n");
    EXTI_ClearITPendingBit(EXTI_Line5);
  }
}
//----------------------------------------------------------------------------------------------------
int main()
{
	printf("Test ADC /n");
	SystemInit();
	ADC_pin_select_config();
	ADC_pin_config();
	timetick_configure();
	UART_pin_config();
	UART_init_config();
	EXTI_Pin_config();
	EXTI_line_config();
	init_data_test(voltage_module1,SIZE_MODULE_1,voltage_module2,SIZE_MODULE_2,Flag_battery,SIZE_BATTERY,Flag_temp, SIZE_TEMPERATURE);
	STATUS_pin_peripheral_config();
	TIMER_interupt_config();
	while(1)
	{
	  if(READ_ADC_FLAG == Bit_SET)
		{
			TIM_Cmd(TIM2,DISABLE);
			for(int i = 0 ;i< SIZE_MODULE_1 ;i++)
			{
				Flag_emer[i] = voltage_module1[i]> 4.2 ? ON:OFF; 
			}
			for(int i = 0 ;i< SIZE_MODULE_2 ;i++)
			{
				Flag_emer[i+16] = voltage_module2[i]> 1.0 ? ON:OFF; 
			}	
			package_emer();
			Delay_ms(1000);
      //for(int i =0 ;i<16; i++){
      //printf("Voltage %d read is %1.3f \n",i+1,voltage_module1[i]*battery_temp_ratio[i]);
      //}
			//when read successfully ADC send packet Uart about the information of the sensor (voltage, current, temperature)
			//Send
			package_infor();
			TIM_Cmd(TIM2,ENABLE);
			READ_ADC_FLAG = Bit_RESET;
		}
	}
	return 0;
	
}