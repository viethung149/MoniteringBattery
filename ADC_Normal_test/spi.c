#include "spi.h"
void SPI_pin_config(void){
	// config SPI 1
	// mosi : PA7
	// MISO : PA6
	// SCK : PA5
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA,ENABLE);
	GPIO_InitTypeDef gpio_spi1;
	gpio_spi1.GPIO_Mode=GPIO_Mode_AF;
	gpio_spi1.GPIO_OType=GPIO_OType_PP;
	gpio_spi1.GPIO_Pin=CLK|MISO|MOSI;
	gpio_spi1.GPIO_Speed=GPIO_Speed_50MHz;
	GPIO_Init(GPIOA,&gpio_spi1);
	GPIO_PinAFConfig(GPIOA,GPIO_PinSource5,GPIO_AF_SPI1);
	GPIO_PinAFConfig(GPIOA,GPIO_PinSource6,GPIO_AF_SPI1);	
	GPIO_PinAFConfig(GPIOA,GPIO_PinSource7,GPIO_AF_SPI1);	
}
void SPI_init(){
	SPI_pin_config();
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_SPI1,ENABLE);
	SPI_InitTypeDef spi_config;
	spi_config.SPI_BaudRatePrescaler= SPI_BaudRatePrescaler_256;
	spi_config.SPI_CPHA=SPI_CPHA_1Edge;
	spi_config.SPI_CPOL=SPI_CPOL_Low;
	spi_config.SPI_CRCPolynomial=0x0007;
	spi_config.SPI_DataSize=SPI_DataSize_8b;
	spi_config.SPI_Direction=SPI_Direction_2Lines_FullDuplex;
	spi_config.SPI_FirstBit=SPI_FirstBit_MSB;
	spi_config.SPI_Mode=SPI_Mode_Master;
	spi_config.SPI_NSS=SPI_NSS_Soft;
	SPI_Init(SPI1,&spi_config);
	SPI_Cmd(SPI1,ENABLE);
}
// NSS pin is PA9
void SPI_pin_nss(void){
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA,ENABLE);
	GPIO_InitTypeDef gpio_config;
	gpio_config.GPIO_Mode = GPIO_Mode_OUT;
	gpio_config.GPIO_OType = GPIO_OType_PP;
	gpio_config.GPIO_Pin = NSS;
	gpio_config.GPIO_PuPd = GPIO_PuPd_UP;
	gpio_config.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA,&gpio_config);	
}
void SPI_exti_pin_handshark(void)
{
	/* Configure PA8 */ 
	GPIO_InitTypeDef gpio_init;
	RCC_AHB1PeriphClockCmd (RCC_AHB1Periph_GPIOA,ENABLE );
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
	gpio_init.GPIO_Mode=GPIO_Mode_IN;
	gpio_init.GPIO_OType=GPIO_OType_OD;
	gpio_init.GPIO_Pin=Handshark;
	gpio_init.GPIO_PuPd=GPIO_PuPd_DOWN;
	gpio_init.GPIO_Speed=GPIO_Speed_100MHz;
	GPIO_Init(GPIOA,&gpio_init);
	SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOA,EXTI_PinSource8);
	/* Configure EXTI Line8 */ 
	EXTI_InitTypeDef   EXTI_InitStructure;
  EXTI_InitStructure.EXTI_Line = EXTI_Line8;
  EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
  EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
  EXTI_InitStructure.EXTI_LineCmd = ENABLE;
  EXTI_Init(&EXTI_InitStructure);
	/* Enable and set EXTI Line6 Interrupt to the lowest priority */
	NVIC_InitTypeDef   NVIC_InitStructure;
  NVIC_InitStructure.NVIC_IRQChannel = EXTI9_5_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x01;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}
void SPI_send_data(BYTE* tx_buffer){
	while(*tx_buffer != '\n'){
			SPI_I2S_SendData(SPI1,*(tx_buffer));
		  while(SPI_I2S_GetFlagStatus(SPI1,SPI_I2S_FLAG_BSY)==SET);
		  tx_buffer++;
	}
}
