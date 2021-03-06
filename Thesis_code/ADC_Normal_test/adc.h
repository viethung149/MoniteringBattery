#ifndef _ADC_H
#define _ADC_H
#include "stm32f4xx.h"
#include "stm32f4xx_adc.h"
void ADC_pin_select_config(void);
void ADC_pin_config(void);
int ADC_select_channel(int module, int channel);
//get digital value
float ADC_get_digital(ADC_TypeDef* ADCx, int numberRead);
//get analog voltage
float ADC_get_value_voltage(ADC_TypeDef* ADCx, int numberRead, float voltage_ref);
float ADC_get_value_voltage_mv(ADC_TypeDef* ADCx, int numberRead, float voltage_ref);
float ADC_get_voltage_from_channel(ADC_TypeDef* ADCx, int numberRead, int channel,int module, float voltage_ref);
float ADC_get_voltage_from_channel_mv(ADC_TypeDef* ADCx, int numberRead, int channel,int module, float voltage_ref);
float ADC_get_digital_from_channel(ADC_TypeDef* ADCx, int numberRead,int module, int channel);
#endif