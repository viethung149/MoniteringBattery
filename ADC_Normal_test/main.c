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
#include "spi.h"
#include "input_pin.h"
#define MAX_READ 40 // 20 times mean 5ms*20 = 100ms ==> result what button was pressed
float voltage_module1[SIZE_MODULE_1]={0};
float voltage_module2[SIZE_MODULE_2]={0};
float current_voltage[SIZE_CURRENT] ={0};
float current_a[SIZE_CURRENT]={0};
BYTE rx_data = 0x00;
Status IN_CHARGING =  OFF;
Status IN_DISCHARGING =  OFF;

Status FAIL_TEMPERATURE_P1 = OFF;
Status FAIL_VOLTAGE_P1 = OFF;
Status FAIL_CURRENT_P1 = OFF;

Status FAIL_TEMPERATURE_P2 = OFF;
Status FAIL_VOLTAGE_P2 = OFF;
Status FAIL_CURRENT_P2 = OFF;

Status CHANNEL_15_IO = ON;
Status CHANNEL_14_IO = ON;
Status CHANNEL_13_IO = ON;
//counter read button
int overall_cnt =0 ;
int btn_package1_cnt = 0;
int btn_package2_cnt = 0;
int btn_fan1_cnt = 0;
int btn_fan2_cnt = 0;
int counter_charge =0;
//status 
float voltage_package_1 = 0;
float voltage_package_2 = 0;
B_Voltage_status Flag_battery[SIZE_BATTERY]={NORMAL};//{MAX,NORMAL,MAX,MIN,NORMAL,MAX,NORMAL,NORMAL}; // 1011 0100
B_Voltage_status Flag_temp[SIZE_TEMPERATURE]= {NORMAL};//{MAX,MIN,MAX,MIN,NORMAL,MAX,NORMAL,NORMAL};  // 1111 0100

Status Flag_pheripheral[SIZE_PHERIPHERAL] ={OFF};

B_Voltage_status Flag_emer[SIZE_EMER] = {NORMAL};
BYTE buffer_tx_uart[SIZE_BUFFER_TX]={0};
BYTE buffer_tx_spi[SIZE_BUFFER_TX]={0};
BYTE buffer_rx[SIZE_BUFFER_RX]={0};
int index_bfrx =0;
Status Read_uart_done=OFF;
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
float battery_ratio[]={BATTERY1_P1,
										 BATTERY2_P1,
										 BATTERY3_P1,
										 BATTERY4_P1,
										 BATTERY1_P2,
										 BATTERY2_P2,
										 BATTERY3_P2,
										 BATTERY4_P2};
int temp_ratio[]={TEM1_P1,
									TEM2_P1,
									TEM3_P1,
									TEM4_P1,
									TEM1_P2,
									TEM2_P2,
									TEM3_P2,
								  TEM4_P2};

//--uart--//
char RX_buffer[1000]={0};

//--adc--//
BitAction READ_ADC_FLAG = Bit_RESET;
void update_charge(){
		printf("Reading when discharge\n");
		if(Flag_pheripheral[RELAY_1] == ON) GPIO_SetBits(GPIOC, GPIO_Pin_2);
		if(Flag_pheripheral[RELAY_2] == ON) GPIO_SetBits(GPIOC, GPIO_Pin_3);
		Dellay_us(100);
		float sum = 0;
		// update package 1
		// get voltage from battery ---------------------------------------------------------------------------------------------
		for(int i =0 ; i < 4 ; i++ )
		{
			voltage_module2[i]= ADC_get_voltage_from_channel(ADC_MODULE2,NUMBER_READ,i,MODULE2,VOLTAGE_REF)*battery_ratio[i]-sum;
			// function set flag voltage
			set_flag(Flag_battery,i,VOLTAGE,voltage_module2[i]);
			sum += voltage_module2[i];
			Dellay_us(10);
		}
		voltage_package_1 =  sum;
		sum =0;
		// update package 2
		for(int i = 4 ; i < SIZE_BATTERY ; i++ )
		{
			voltage_module2[i]= ADC_get_voltage_from_channel(ADC_MODULE2,NUMBER_READ,i,MODULE2,VOLTAGE_REF)*battery_ratio[i]-sum ;
			// function set flag voltage
			set_flag(Flag_battery,i,VOLTAGE,voltage_module2[i]);
			
			sum += voltage_module2[i];
			Dellay_us(10);
		}
		voltage_package_2 = sum;
		Dellay_ms_timer4(2000);//500ms
		if(Flag_pheripheral[RELAY_1] == ON) GPIO_ResetBits(GPIOC, GPIO_Pin_2);
		if(Flag_pheripheral[RELAY_2] == ON) GPIO_ResetBits(GPIOC, GPIO_Pin_3);
}

void update_discharge(){
     float sum = 0;
		// update package 1
		// get voltage from battery ---------------------------------------------------------------------------------------------
		for(int i =0 ; i < 4 ; i++ )
		{
			voltage_module2[i]= ADC_get_voltage_from_channel(ADC_MODULE2,NUMBER_READ,i,MODULE2,VOLTAGE_REF)*battery_ratio[i]-sum;
			// function set flag voltage
			set_flag(Flag_battery,i,VOLTAGE,voltage_module2[i]);
			sum += voltage_module2[i];
			Dellay_us(10);
		}
		voltage_package_1 =  sum;
		sum =0;
		// update package 2
		for(int i = 4 ; i < SIZE_BATTERY ; i++ )
		{
			voltage_module2[i]= ADC_get_voltage_from_channel(ADC_MODULE2,NUMBER_READ,i,MODULE2,VOLTAGE_REF)*battery_ratio[i]-sum ;
			// function set flag voltage
			set_flag(Flag_battery,i,VOLTAGE,voltage_module2[i]);
			sum += voltage_module2[i];
			Dellay_us(10);
		}
		voltage_package_2 = sum;
}



void check_current(){
		// check package 1, 2 for turn off relay pin PC 2, PC 3
    FAIL_CURRENT_P1 = OFF;
		FAIL_CURRENT_P2 = OFF;	
		if(IN_CHARGING == ON){
				if (current_a[1] > CURRENT_MAX_CHARGE) {
					GPIO_SetBits(GPIOC, GPIO_Pin_2);
					Flag_pheripheral[RELAY_1] = OFF;
				  FAIL_CURRENT_P1 = ON;
				}					
			  if (current_a[2] > CURRENT_MAX_CHARGE) {
					GPIO_SetBits(GPIOC, GPIO_Pin_3);
					Flag_pheripheral[RELAY_2] = OFF;
					FAIL_CURRENT_P2 = ON;
				} 
		}
		else if(IN_DISCHARGING == ON){
				if ((-1)*(current_a[1]) > CURRENT_MAX_DISCHARGE){
				 GPIO_SetBits(GPIOC, GPIO_Pin_2); 
					Flag_pheripheral[RELAY_1] = OFF;
					FAIL_CURRENT_P1 = ON;
				} 
			  if ((-1)*(current_a[2]) > CURRENT_MAX_DISCHARGE){
				 GPIO_SetBits(GPIOC, GPIO_Pin_3); 
				 Flag_pheripheral[RELAY_2] = OFF;
				 FAIL_CURRENT_P2 = ON;
				}
		}
}
void check_voltage(){
		// check package 1, 2 for turn off relay pin PC 2, PC 3 
	  FAIL_VOLTAGE_P1 = OFF;
	  FAIL_VOLTAGE_P2 = OFF;
			for(int i = 0 ;i< 4 ;i++){
			  if(Flag_battery[i] != NORMAL){
					GPIO_SetBits(GPIOC, GPIO_Pin_2);
					Flag_pheripheral[RELAY_1] = OFF;
					FAIL_VOLTAGE_P1 = ON;
					break;
				}
			}
			for(int i = 4 ;i< 8 ;i++){
			  if(Flag_battery[i] != NORMAL){
					GPIO_SetBits(GPIOC, GPIO_Pin_3);
					Flag_pheripheral[RELAY_2] = OFF;
					FAIL_VOLTAGE_P2 = ON;
					break;
				}
			}
}
Status check_temperature(){
		// check package 1, 2 for turn off relay pin PC 2, PC 3 
	  FAIL_TEMPERATURE_P1 = OFF;
	  FAIL_TEMPERATURE_P2 = OFF;
			for(int i = 0 ;i< 4 ;i++){
			  if(Flag_temp[i] != NORMAL){
					GPIO_SetBits(GPIOC, GPIO_Pin_2);
					Flag_pheripheral[RELAY_1] = OFF;
					// turn on fan1
					GPIO_ResetBits(GPIOC, GPIO_Pin_4);
					Flag_pheripheral[FAN_1] = ON;
					FAIL_TEMPERATURE_P1 = ON;
					break;
				}
			}
			for(int i = 4 ;i< 8 ;i++){
			  if(Flag_temp[i] != NORMAL){
					GPIO_SetBits(GPIOC, GPIO_Pin_3);
					Flag_pheripheral[RELAY_2] = OFF;
					//turn on fan2
					GPIO_ResetBits(GPIOC, GPIO_Pin_5);
					Flag_pheripheral[FAN_2] = ON;
					FAIL_TEMPERATURE_P2 = ON;
					break;
				}
			}
}
void process_package1(void);
void process_package2(void);
void process_fan1(void);
void process_fan2(void);
void check_buffer_rx(BYTE buffer_rx[], int size);
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
    printf("IN TIMER READ ADC \n");
		//TIM_Cmd(TIM2,DISABLE);	
		if(READ_ADC_FLAG == Bit_RESET )
		{	
			// get temperature ------------------------------------------------------------------------------------------------
			for(int i =0 ; i < SIZE_TEMPERATURE ; i++ )
			{
				voltage_module1[i]= ADC_get_voltage_from_channel(ADC_MODULE1,NUMBER_READ,i,MODULE1,VOLTAGE_REF)*temp_ratio[i];
				//function set flag temperature
				set_flag(Flag_temp,i,TEMPERATURE,voltage_module1[i]);
			}
			// get current from module 1 
			get_current(current_voltage,current_a);
			voltage_module1[8] = current_a[0];
			voltage_module1[9] = current_a[1];
			voltage_module1[10] = current_a[2];
			
			// if either current package1 or current package 2 is greater than zero -> in charge mod
			if(current_a[1] > 0 || current_a[2] > 0){
				IN_CHARGING = ON;
				IN_DISCHARGING = OFF;
			}
			else if(current_a[1] < 0 || current_a[2] < 0){
				IN_DISCHARGING = ON;
				IN_CHARGING = OFF;
			}
			else
			{
				IN_CHARGING = OFF;
				IN_DISCHARGING = OFF;
			}
			counter_charge++;
			// for read when charging
			if(counter_charge == 2 && IN_CHARGING == ON ){
				update_charge();
			}
			// read when dischare
			else if(counter_charge == 2 && IN_DISCHARGING == ON ){
				update_discharge();
			}
			else {
				update_discharge();
			}
		}
		//TIM_Cmd(TIM2,ENABLE);
		READ_ADC_FLAG=Bit_SET;
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);//xoa co  ngat nho thanh  ghi pending bit
		}
}
////--------------------------------------------------------------------------------------------
void TIM5_IRQHandler(void) {
	if (TIM_GetITStatus(TIM5, TIM_IT_Update) != RESET)// kiem tra xem co ngat cua tim 2 bat chua
	{	
		overall_cnt++;
		if(GPIO_ReadInputDataBit(GPIOD,GPIO_Pin_2) == Bit_SET) btn_package1_cnt++;
		if(GPIO_ReadInputDataBit(GPIOD,GPIO_Pin_3) == Bit_SET) btn_package2_cnt++;
		if(GPIO_ReadInputDataBit(GPIOD,GPIO_Pin_4) == Bit_SET) btn_fan1_cnt++;
		if(GPIO_ReadInputDataBit(GPIOD,GPIO_Pin_7) == Bit_SET) btn_fan2_cnt++;
		if(overall_cnt == MAX_READ){
			if(btn_package1_cnt > 10){
				process_package1();
				package_human();
			}
			else if(btn_package2_cnt > 10){
				process_package2();
				package_human();
			}
			else if(btn_fan1_cnt >10){
			  process_fan1();
				package_human();
			}
			else if(btn_fan2_cnt >10){
				process_fan2();
				package_human();
			}
			btn_package1_cnt =0;
			btn_package2_cnt = 0;
			btn_fan1_cnt = 0;
			btn_fan2_cnt = 0;
			overall_cnt =0;
		}
		TIM_ClearITPendingBit(TIM5, TIM_IT_Update);//xoa co  ngat nho thanh  ghi pending bit
	}
}
void reset_buffer_rx(BYTE buffer_rx[],int size){
	for(int i =0;i<size;i++){
		buffer_rx[i] = 0x00;
	}
}
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
	INPUT_Pin_config();
	//init_data_test(voltage_module1,SIZE_MODULE_1,voltage_module2,SIZE_MODULE_2,Flag_battery,SIZE_BATTERY,Flag_temp, SIZE_TEMPERATURE);
	STATUS_pin_peripheral_config();
	STATUS_off_all_peripheral();
	TIMER_interupt_config();
	TIMER_read_button(5);
	SPI_pin_config();
	SPI_init();
	SPI_pin_nss();
	while(1)
	{
	  if(READ_ADC_FLAG == Bit_SET)
		{
			 printf("IN CHECK INFOR SEND UPDATE \n");
			//TIM_Cmd(TIM2,DISABLE);
			//TIM_Cmd(TIM5,DISABLE);
			//when read successfully ADC send packet Uart about the information of the sensor (voltage, current_voltage, temperature)
			check_current();
			check_voltage();
			check_temperature();
			package_human();
			if(counter_charge == 2){
				set_emer_flag(voltage_module2, SIZE_BATTERY, voltage_module1, SIZE_TEMPERATURE, Flag_emer, SIZE_EMER);
				//GPIO_ToggleBits(GPIOA, NSS);
        //package_emer();
				package_infor();
				counter_charge = 0;
			}
			//TIM_Cmd(TIM2,ENABLE);
			//TIM_Cmd(TIM5,ENABLE);
			READ_ADC_FLAG = Bit_RESET;
		}
		if(Read_uart_done == ON){
			 printf("IN UPDATE RELAY FROM SOLFWARE \n");
			Read_uart_done = OFF;
			check_buffer_rx(buffer_rx,SIZE_BUFFER_RX);
			//reset_buffer_rx(buffer_rx,SIZE_BUFFER_RX);
		}
	}
	return 0;
}
//// handler external 5 PD7
//// control Fan2 
//// Led PC 4
void EXTI9_5_IRQHandler(void){
//  if(EXTI_GetITStatus(EXTI_Line7) != RESET)
//  {
//		if(Flag_pheripheral[FAN_2] == OFF)
//		{
//			if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_5) == Bit_SET){
//			  Dellay_us(10000);
//				GPIO_ResetBits(GPIOC, GPIO_Pin_5);
//				Flag_pheripheral[FAN_2] = ON;
//			}
//		}
//			else if (FAIL_TEMPERATURE_P2 == OFF)
//		{
//			if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_5) == Bit_RESET){
//				Dellay_us(10000);
//				GPIO_SetBits(GPIOC, GPIO_Pin_5);
//				Flag_pheripheral[FAN_2] = OFF;
//			}
//		}
//		package_human();
//		//send the packet
//		printf("press button Fan2 \n");
//    EXTI_ClearITPendingBit(EXTI_Line7);
//  }
	if(EXTI_GetITStatus(EXTI_Line6) != RESET)
  {
		Dellay_us(1000);
		// send frame SPI 
		package_infor_spi();
    EXTI_ClearITPendingBit(EXTI_Line6);
  }
}
//----------------------------------------------------------------------------------------------------

void process_package1(void){
	if(Flag_pheripheral[RELAY_1] == OFF && FAIL_VOLTAGE_P1 == OFF && FAIL_CURRENT_P1 == OFF && FAIL_TEMPERATURE_P1 == OFF )
		{
			if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_2) == Bit_SET){
				GPIO_ResetBits(GPIOC, GPIO_Pin_2);
				Flag_pheripheral[RELAY_1] = ON;
			}
		}
		else
		{
			if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_2) == Bit_RESET){
				GPIO_SetBits(GPIOC, GPIO_Pin_2);
				Flag_pheripheral[RELAY_1] = OFF;
			}
		}
		printf("press button package 1 \n");
}
void process_package2(void){
if(Flag_pheripheral[RELAY_2] == OFF && FAIL_VOLTAGE_P2 == OFF && FAIL_CURRENT_P2 == OFF && FAIL_TEMPERATURE_P2 == OFF )
				{
					if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_3) == Bit_SET){
						GPIO_ResetBits(GPIOC, GPIO_Pin_3);
						Flag_pheripheral[RELAY_2] = ON;
					}
				}
				else
				{
					if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_3) == Bit_RESET){
						GPIO_SetBits(GPIOC, GPIO_Pin_3);
						Flag_pheripheral[RELAY_2] = OFF;
					}
				}
				printf("press button package 2 \n");
}
void process_fan1(void){
		if(Flag_pheripheral[FAN_1] == OFF )
			{
				if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_4) == Bit_SET){
						GPIO_ResetBits(GPIOC, GPIO_Pin_4);
						Flag_pheripheral[FAN_1] = ON;
					}
			}
			else if(FAIL_TEMPERATURE_P1 == OFF)
			{
				if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_4) == Bit_RESET){
					GPIO_SetBits(GPIOC, GPIO_Pin_4);
					Flag_pheripheral[FAN_1] = OFF;
				}
			}
			printf("press button Fan1 \n");
}
void process_fan2(void){
	if(Flag_pheripheral[FAN_2] == OFF)
	{
		if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_5) == Bit_SET){
			GPIO_ResetBits(GPIOC, GPIO_Pin_5);
			Flag_pheripheral[FAN_2] = ON;
		}
	}
	else if (FAIL_TEMPERATURE_P2 == OFF){
		if(GPIO_ReadOutputDataBit(GPIOC,GPIO_Pin_5) == Bit_RESET){
			GPIO_SetBits(GPIOC, GPIO_Pin_5);
			Flag_pheripheral[FAN_2] = OFF;
	  }
  }
	printf("press button Fan2 \n");
}
// read uart
void USART1_IRQHandler(void)
{
	while(USART_GetITStatus(USART1,USART_IT_RXNE)==1)
	{
			rx_data = USART_ReceiveData(USART1);
		  if(rx_data >= 0x01 && rx_data <= 0x04){
			Read_uart_done=ON;
			}
	}
}
void check_buffer_rx(BYTE buffer_rx[], int size){
//	if(buffer_rx[0] != 'R' && buffer_rx[0] != 'F') return;
//	if(buffer_rx[4] != '\r' || buffer_rx[5] != '\n') return;
//	BYTE _crc_test = buffer_rx[0] + buffer_rx[1] + buffer_rx[2];
//	if(_crc_test != buffer_rx[3]) return;
//	if(buffer_rx[1] == '1'){
//		buffer_rx[2] == 0x01? GPIO_ResetBits(GPIOC,GPIO_Pin_2): GPIO_SetBits(GPIOC,GPIO_Pin_2);
//		Flag_pheripheral[RELAY_1] = buffer_rx[2] == 0x01?ON:OFF;
//		printf("attemp relay 1 \n");
//	}
//	else if(buffer_rx[1] == '2'){
//		buffer_rx[2] == 0x01? GPIO_ResetBits(GPIOC,GPIO_Pin_3): GPIO_SetBits(GPIOC,GPIO_Pin_3);
//		Flag_pheripheral[RELAY_2] = buffer_rx[2] == 0x01?ON:OFF;
//		printf("attemp relay 2 \n");
//	}
//	else if(buffer_rx[1] == '3'){
//		buffer_rx[2] == 0x01? GPIO_ResetBits(GPIOC,GPIO_Pin_4): GPIO_SetBits(GPIOC,GPIO_Pin_4);
//		Flag_pheripheral[FAN_1] = buffer_rx[2] == 0x01?ON:OFF;
//		printf("attemp relay 3 \n");
//	}
//	else if(buffer_rx[1] == '4'){
//		buffer_rx[2] == 0x01? GPIO_ResetBits(GPIOC,GPIO_Pin_5): GPIO_SetBits(GPIOC,GPIO_Pin_5);
//		Flag_pheripheral[FAN_2] = buffer_rx[2] == 0x01?ON:OFF;
//		printf("attemp relay 4 \n");
//	}
//	package_human();
//	
	if(rx_data == 0x01){
		if(Flag_pheripheral[RELAY_1] == OFF && FAIL_CURRENT_P1 == OFF && FAIL_TEMPERATURE_P1 == OFF && FAIL_TEMPERATURE_P1 ==OFF){
			GPIO_ResetBits(GPIOC,GPIO_Pin_2);
			Flag_pheripheral[RELAY_1] =ON;
		}
		else if(Flag_pheripheral[RELAY_1] == ON){
			GPIO_SetBits(GPIOC,GPIO_Pin_2);
			Flag_pheripheral[RELAY_1] =OFF;
		}
		printf("attemp relay 1 \n");
	}
	else if(rx_data == 0x02 ){
		if(Flag_pheripheral[RELAY_2] == OFF && FAIL_CURRENT_P2 == OFF && FAIL_TEMPERATURE_P2 == OFF && FAIL_TEMPERATURE_P2 ==OFF){
			GPIO_ResetBits(GPIOC,GPIO_Pin_3);
			Flag_pheripheral[RELAY_2] =ON;
		}
		else if(Flag_pheripheral[RELAY_2] == ON){
			GPIO_SetBits(GPIOC,GPIO_Pin_3);
			Flag_pheripheral[RELAY_2] =OFF;
		}
		printf("attemp relay 2 \n");
	}
	else if(rx_data == 0x03){
	 if(Flag_pheripheral[FAN_1] == OFF ){
			GPIO_ResetBits(GPIOC,GPIO_Pin_4);
			Flag_pheripheral[FAN_1] =ON;
		}
		else if(Flag_pheripheral[FAN_1] == ON && FAIL_TEMPERATURE_P1 == OFF){
			GPIO_SetBits(GPIOC,GPIO_Pin_4);
			Flag_pheripheral[FAN_1] =OFF;
		}
		printf("attemp relay 3 \n");
	}
	else if(rx_data == 0x04){
		 if(Flag_pheripheral[FAN_2] == OFF ){
			GPIO_ResetBits(GPIOC,GPIO_Pin_5);
			Flag_pheripheral[FAN_2] =ON;
		}
		else if(Flag_pheripheral[FAN_2] == ON && FAIL_TEMPERATURE_P2 == OFF){
			GPIO_SetBits(GPIOC,GPIO_Pin_5);
			Flag_pheripheral[FAN_2] =OFF;
		}
		printf("attemp relay 4 \n");
	}
	package_human();
}