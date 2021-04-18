#include "adc.h"
#include "delay.h"
void ADC_pin_select_config(void)
{
		//Pin PD12, PD13, PD14, PD15 select channel
		//Pin 11 enable modedule adc 
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD,ENABLE);
		GPIO_InitTypeDef GPIO_config;
		GPIO_config.GPIO_Mode=GPIO_Mode_OUT;
		GPIO_config.GPIO_OType=GPIO_OType_PP;
		GPIO_config.GPIO_Pin=GPIO_Pin_12|GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15|GPIO_Pin_11;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_NOPULL;
		GPIO_config.GPIO_Speed=GPIO_Speed_100MHz;
		GPIO_Init(GPIOD,&GPIO_config);
}
//-------------------------------------------------------------------------------------
void ADC_pin_config(void)
{
	  RCC_AHB1PeriphClockCmd (RCC_AHB1Periph_GPIOA,ENABLE);
		// config pin using for ADC
		GPIO_InitTypeDef GPIO_config;
		GPIO_config.GPIO_Mode=GPIO_Mode_AN;
		GPIO_config.GPIO_OType=GPIO_OType_PP;
		GPIO_config.GPIO_Pin=GPIO_Pin_1;
		GPIO_config.GPIO_PuPd=GPIO_PuPd_NOPULL;
		GPIO_config.GPIO_Speed=GPIO_Speed_100MHz;
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
		ADC_RegularChannelConfig(ADC1,ADC_Channel_1,1,ADC_SampleTime_28Cycles); /* choose channel and time sampling */
}
//----------------------------------------------------------------------------------------------------
int ADC_select_channel(int channel)
{
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
		return channel;
		}
}
//----------------------------------------------------------------------------------------------------
float ADC_get_digital(ADC_TypeDef* ADCx, int numberRead)
{
	float sum_digital =0;
	for(int i=0; i<numberRead; i++)
	{
		while(!ADC_GetFlagStatus(ADCx, ADC_FLAG_EOC));//Processing the conversion
		uint16_t value_digital = ADC_GetConversionValue(ADCx);
		sum_digital += value_digital;
		Dellay_us(100);
	}
	GPIO_WriteBit(GPIOD,GPIO_Pin_11,Bit_SET);
	return sum_digital/numberRead;
}
//----------------------------------------------------------------------------------------------------
float ADC_get_value_voltage(ADC_TypeDef* ADCx, int numberRead, float voltage_ref)
{
	GPIO_ResetBits(GPIOD,GPIO_Pin_11);
	Dellay_us(2);
	float sum_voltage =0;
	for(int i=0; i<numberRead; i++)
	{
		ADC_Cmd(ADC1,ENABLE);
		ADC_SoftwareStartConv(ADC1);
		while(!ADC_GetFlagStatus(ADCx, ADC_FLAG_EOC));//Processing the conversion
		uint16_t value_digital = ADC_GetConversionValue(ADCx);
		float Voltage = value_digital*(voltage_ref/4095);
		ADC_ClearFlag(ADC1,ADC_FLAG_EOC);
		sum_voltage += Voltage;
		ADC_Cmd(ADC1,DISABLE);
	}
	GPIO_SetBits(GPIOD,GPIO_Pin_11);
	return sum_voltage/numberRead;
}
//----------------------------------------------------------------------------
float ADC_get_value_voltage_mv(ADC_TypeDef* ADCx, int numberRead, float voltage_ref)
{
	float sum_voltage =0;
	for(int i=0; i<numberRead; i++)
	{
		//while(!ADC_GetFlagStatus(ADCx, ADC_FLAG_EOC));//Processing the conversion
		uint16_t value_digital = ADC_GetConversionValue(ADCx);
		float Voltage = value_digital*(voltage_ref*1000/4095);
		sum_voltage += Voltage;
		Dellay_us(10);
	}
	GPIO_SetBits(GPIOD,GPIO_Pin_11);
	
	return sum_voltage/numberRead;
}
//----------------------------------------------------------------------------------------------------
float ADC_get_voltage_from_channel(ADC_TypeDef* ADCx, int numberRead, int channel,  float voltage_ref)
{
	ADC_select_channel(channel);
	return ADC_get_value_voltage(ADCx,numberRead,voltage_ref);
}
//----------------------------------------------------------------------------------------------------
float ADC_get_digital_from_channel(ADC_TypeDef* ADCx, int numberRead, int channel)
{
	ADC_select_channel(channel);
	return ADC_get_digital(ADCx,numberRead);
}
//-------------------------------------------------------------------------------------------
float ADC_get_voltage_from_channel_mv(ADC_TypeDef* ADCx, int numberRead, int channel,  float voltage_ref)
{
	ADC_select_channel(channel);
	return ADC_get_value_voltage_mv(ADCx,numberRead,voltage_ref);
}