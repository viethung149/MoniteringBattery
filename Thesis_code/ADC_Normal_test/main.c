#include "stm32f4xx.h"                  // Device header
#include "stdio.h"
#include "delay.h"
#include "misc.h"
#include "uart.h"
float voltage_module1[16]={0};
int ratio_R[]={2,3,5,6};
float R1_current = 9.7;
float R2_current = 20.7;
int sensitive_current =105;
int CurrenOffset = 2500;
char buffer[1000]={0};
int index_buff=0;//bien chay buffer
BitAction READ_ADC_FLAG = Bit_RESET;
typedef enum
{ 
  OFF = 0,
  ON
}Status;
Status s_start_stop = OFF;
Status s_load_charge = OFF;
Status s_package1 =OFF;
Status s_package2 =OFF;
Status s_Fan1=OFF;
Status s_Fan2= OFF;
///* USER CODE BEGIN PFP */
///* Private function prototypes -----------------------------------------------*/
//struct __FILE
//{
//  int handle;
//  /* Whatever you require here. If the only file you are using is */
//  /* standard output using printf() for debugging, no file handling */
//  /* is required. */
//};
///* USER CODE END PFP */
///* USER CODE BEGIN 4 */
///*send text over SWV*/
//int fputc(int ch, FILE *f) {
//    ITM_SendChar(ch);//send method for SWV
//    return(ch);
//}
///* USER CODE END 4 */
//----------------------------------------------------------------------------------------------------
void Init_GPIO_select()
{
		//Pin PD12, PD13, PD14, PD15 select channel
		//Pin 11 enable modedule adc
		//Pin PD0 -> 5 button 
	 
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD,ENABLE);
	  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC,ENABLE);
	  RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
		GPIO_InitTypeDef GPIO_config;
		GPIO_config.GPIO_Mode=GPIO_Mode_OUT;
		GPIO_config.GPIO_OType=GPIO_OType_PP;
		GPIO_config.GPIO_Pin=GPIO_Pin_12|GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15|GPIO_Pin_11;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_NOPULL;
		GPIO_config.GPIO_Speed=GPIO_Speed_50MHz;
		GPIO_Init(GPIOD,&GPIO_config);
    //set pin for external interrup
	  GPIO_config.GPIO_Mode=GPIO_Mode_IN;
		GPIO_config.GPIO_Pin=GPIO_Pin_0|GPIO_Pin_1|GPIO_Pin_2|GPIO_Pin_3|GPIO_Pin_4|GPIO_Pin_5;
	  GPIO_config.GPIO_OType=GPIO_OType_OD;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_DOWN;
		GPIO_config.GPIO_Speed=GPIO_Speed_100MHz;
		GPIO_Init(GPIOD,&GPIO_config);
	  SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource0);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource1);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource2);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource3);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource4);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD,EXTI_PinSource5);
		EXTI_InitTypeDef   EXTI_InitStructure;
		EXTI_InitStructure.EXTI_Line = EXTI_Line0;
		EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
		EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
		EXTI_InitStructure.EXTI_LineCmd = ENABLE;
    EXTI_Init(&EXTI_InitStructure);
	/* Enable and set EXTI Line0 Interrupt to the lowest priority */
		NVIC_InitTypeDef   NVIC_InitStructure;
		NVIC_InitStructure.NVIC_IRQChannel = EXTI0_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);
		// PC0 start/stop
		// PC1 package 1
		// PC2 package 2
	  // PC3 Fan 1
		// PC4 Fan 2
		// PC5 timer interrupt read adc
		// PC6 RX uart
		GPIO_config.GPIO_Mode=GPIO_Mode_OUT;
		GPIO_config.GPIO_OType=GPIO_OType_PP;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_NOPULL;
		GPIO_config.GPIO_Speed=GPIO_Speed_50MHz;
		GPIO_config.GPIO_Pin=GPIO_Pin_0| GPIO_Pin_1 | GPIO_Pin_2 | GPIO_Pin_3 | GPIO_Pin_4 | GPIO_Pin_5 | GPIO_Pin_6;
		GPIO_Init (GPIOC,&GPIO_config);
}
//----------------------------------------------------------------------------------------------------
//config external interrupt
void external_line_config(){
		EXTI_InitTypeDef   EXTI_InitStructure;
		EXTI_InitStructure.EXTI_Line = EXTI_Line0;
		EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
		EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
		EXTI_InitStructure.EXTI_LineCmd = ENABLE;
    EXTI_Init(&EXTI_InitStructure);
	/* Enable and set EXTI Line0 Interrupt to the lowest priority */
		NVIC_InitTypeDef   NVIC_InitStructure;
		NVIC_InitStructure.NVIC_IRQChannel = EXTI0_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);
	
		EXTI_InitStructure.EXTI_Line = EXTI_Line1;
    EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI1_IRQn;
		NVIC_Init(&NVIC_InitStructure);
		
		EXTI_InitStructure.EXTI_Line = EXTI_Line2;
    EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI2_IRQn;
		NVIC_Init(&NVIC_InitStructure);
		
		EXTI_InitStructure.EXTI_Line = EXTI_Line3;
    EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI3_IRQn;
		NVIC_Init(&NVIC_InitStructure);
		
		EXTI_InitStructure.EXTI_Line = EXTI_Line4;
    EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI4_IRQn;
		NVIC_Init(&NVIC_InitStructure);
		
		EXTI_InitStructure.EXTI_Line = EXTI_Line5;
    EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
		NVIC_Init(&NVIC_InitStructure);
}
	
//----------------------------------------------------------------------------------------------------
//init ADC
void Init_ADC(void)
{
		RCC_AHB1PeriphClockCmd (RCC_AHB1Periph_GPIOA,ENABLE);
		// config pin using for ADC
		GPIO_InitTypeDef GPIO_config;
		GPIO_config.GPIO_Mode=GPIO_Mode_AN;
		GPIO_config.GPIO_OType=GPIO_OType_PP;
		GPIO_config.GPIO_Pin=GPIO_Pin_1;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_NOPULL;
		GPIO_config.GPIO_Speed=GPIO_Speed_50MHz;
		GPIO_Init(GPIOA,&GPIO_config);
	  // config overview ADC
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1,ENABLE);  					       // enable APB2
		ADC_DeInit();
		ADC_InitTypeDef ADC_config;
		ADC_config.ADC_ContinuousConvMode=ENABLE;                            // read continuous
		ADC_config.ADC_DataAlign=ADC_DataAlign_Right;                         // data align left
	  ADC_config.ADC_ExternalTrigConv=ADC_ExternalTrigConvEdge_None;
		ADC_config.ADC_ExternalTrigConvEdge=ADC_ExternalTrigConvEdge_None;    
		ADC_config.ADC_NbrOfConversion=1;                                    //Read one channel
	  ADC_config.ADC_Resolution=ADC_Resolution_12b;                          // Resolution: 12b
		ADC_config.ADC_ScanConvMode=DISABLE;                                 //conversion one channel
		ADC_Init(ADC1,&ADC_config);
		ADC_RegularChannelConfig(ADC1,ADC_Channel_1,1,ADC_SampleTime_84Cycles); /* choose channel and time sampling */
		
}
// ----------------------------------------------------------------------------------
//timer config TIM2 
void INTTIM_Config(void)
{
	TIM_TimeBaseInitTypeDef tim_struct;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	tim_struct.TIM_Period = 5000000-1;
	tim_struct.TIM_Prescaler = (uint16_t)(SystemCoreClock/2/1000000)-1;
	//tim_struct.TIM_ClockDivision = 0;
	tim_struct.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM2, &tim_struct);
	TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);
  //nvic timer 2
	NVIC_InitTypeDef nvic_struct;
	nvic_struct.NVIC_IRQChannel = TIM2_IRQn;
	nvic_struct.NVIC_IRQChannelPreemptionPriority =1;
	nvic_struct.NVIC_IRQChannelSubPriority =2;
	nvic_struct.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&nvic_struct);
	TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
	TIM_Cmd(TIM2, ENABLE);
}
// ----------------------------------------------------------------------------------
//select channel 
int select_channel(int channel)
{
	GPIO_WriteBit(GPIOD,GPIO_Pin_11,Bit_SET);
	if(channel >15) return -1;
	else{
		uint16_t starting = GPIO_Pin_12;
		for(int i =0 ;i< 4;i++)
		{
			BitAction Action;
			int remain = channel%2;
			channel/= 2;
			if(remain ==1) Action = Bit_SET;
			else Action = Bit_RESET;
			GPIO_WriteBit(GPIOD,starting,Action);
			starting = starting << 1;
		}
		GPIO_WriteBit(GPIOD,GPIO_Pin_11,Bit_RESET);
		return channel;
	}
}
//----------------------------------------------------------------------------------------------------
//get raw ADC 12bit
float get_raw_analog(ADC_TypeDef* ADCx, int numberRead)
{
	float sum_raw_analog =0;
	for(int i=0; i<numberRead; i++)
	{
		while(!ADC_GetFlagStatus(ADCx, ADC_FLAG_EOC));//Processing the conversion
		uint16_t value_digital = ADC_GetConversionValue(ADCx);
		sum_raw_analog += value_digital;
		Delay_ms(2);
	}
	GPIO_WriteBit(GPIOD,GPIO_Pin_11,Bit_SET);
	return sum_raw_analog/numberRead;
}
//----------------------------------------------------------------------------------------------------
// get voltage ref 3.0 Vol
float get_value_voltage(ADC_TypeDef* ADCx, int numberRead)
{
	float sum_voltage =0;
	for(int i=0; i<numberRead; i++)
	{
		while(!ADC_GetFlagStatus(ADCx, ADC_FLAG_EOC));//Processing the conversion
		uint16_t value_digital = ADC_GetConversionValue(ADCx);
		float Voltage = value_digital*(3.0/4095);
		sum_voltage += Voltage;
	}
	GPIO_WriteBit(GPIOD,GPIO_Pin_11,Bit_SET);
	Dellay_us1(1000);
	return sum_voltage/numberRead;
}
//----------------------------------------------------------------------------------------------------
// get voltage from channel
float get_voltage_from_channel(ADC_TypeDef* ADCx, int numberRead, int channel)
{
	select_channel(channel);
	return get_value_voltage(ADCx,numberRead);
}
float get_raw_analog_from_channel(ADC_TypeDef* ADCx, int numberRead, int channel)
{
	select_channel(channel);
	return get_raw_analog(ADCx,numberRead);
}
//----------------------------------------------------------------------------------------------------
//interrup uart 
void USART1_IRQHandler(void)
{

	while(USART_GetITStatus(USART1,USART_IT_RXNE)==1)
	{
			GPIO_SetBits(GPIOC,GPIO_Pin_6);
			buffer[index_buff++]=USART1->DR;
			GPIO_ResetBits(GPIOC, GPIO_Pin_6);
	}
}
//----------------------------------------------------------------------------------------------------
// interrup timer 2
void TIM2_IRQHandler(void) 
{
	if (TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET)// kiem tra xem co ngat cua tim 2 bat chua
	{
		
		GPIO_ToggleBits(GPIOC,GPIO_Pin_5);
		TIM_Cmd(TIM2,DISABLE);

		ADC_Cmd(ADC1,ENABLE);
		ADC_SoftwareStartConv(ADC1);//Start the conversion
		for(int i =0 ; i < 16 ; i++ )
		{
			voltage_module1[i]= get_voltage_from_channel(ADC1,100,i);
		}
		TIM_Cmd(TIM2,ENABLE);
		READ_ADC_FLAG=Bit_SET;
    ADC_Cmd(ADC1,DISABLE);
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);//xoa co  ngat nho thanh  ghi pending bit
	}
}
//----------------------------------------------------------------------------------------------------
// handler external 0 PCD0
// control Relay start stop 
// Led PC 0
void EXTI0_IRQHandler(void)
{
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
    EXTI_ClearITPendingBit(EXTI_Line0);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 1 PCD1
// control Relay load charge 
// Led PC 1
void EXTI1_IRQHandler(void)
{
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
    EXTI_ClearITPendingBit(EXTI_Line1);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 2 PCD2
// control Package 1 
// Led PC 2
void EXTI2_IRQHandler(void)
{
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
	
    EXTI_ClearITPendingBit(EXTI_Line2);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 3 PCD3
// control Package 2 
// Led PC 2
void EXTI3_IRQHandler(void)
{
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
	
    EXTI_ClearITPendingBit(EXTI_Line3);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 4 PCD4
// control Fan1 
// Led PC 3
void EXTI4_IRQHandler(void)
{
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
	
    EXTI_ClearITPendingBit(EXTI_Line4);
  }
}
//----------------------------------------------------------------------------------------------------
// handler external 5 PCD5
// control Fan2 
// Led PC 4
void EXTI9_5_IRQHandler(void)
{
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
    EXTI_ClearITPendingBit(EXTI_Line5);
  }
}
//----------------------------------------------------------------------------------------------------
int main()
{
	//printf("Test ADC /n");
	SystemInit();
	Init_ADC();
	timetick_configure();
	Init_GPIO_select();
	external_line_config();
	INIT_GPIOUART();
	INIT_UART();
	INIT_IT_UART();
	INTTIM_Config();

	while(1)
	{
	  if(READ_ADC_FLAG == Bit_SET)
		{
			for(int i =0 ;i<16; i++);
			//printf("Voltage %d read is %1.3f \n",i+1,voltage_module1[i]);
		}
//		else
//		{
//			printf("fail \n");
//		}
//		printf("Voltage of LM35:1 is %1.3f and the temperature is %1.3f \n",voltage,voltage*100);
//		Delay_ms(1000);
//	  voltage = get_voltage_from_channel(ADC1,100,1);
//		printf("Voltage of LM35:2 is %1.3f and the temperature is %1.3f \n",voltage,voltage*100);
//		Delay_ms(1000);
//	  float raw_current = get_raw_analog_from_channel(ADC1,100,2);
//		float voltage_current =	raw_current*3000/4095*3.28;//3.28 là ty le tro
//		float current =(voltage_current - CurrenOffset)/sensitive_current;
//		printf("Voltage Current is %1.3f and now the current is %1.3f\n",voltage_current,current);
//	  Delay_ms(1000);
//		float voltage_offset =0;
//		for(int i=3;i<=6;i++)
//		{
//			float voltage = get_voltage_from_channel(ADC1,100,i);
//			voltage = voltage*ratio_R[i-3]-voltage_offset;
//			printf("Voltage of Battery %d is %1.3f \n",i-2,voltage);
//			voltage_offset+=voltage;
//			Delay_ms(1000);
//		}
	}
	return 0;
}