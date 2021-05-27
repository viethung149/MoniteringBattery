#ifndef _SPI_H
#define _SPI_H
#include "stm32f4xx.h"
#include "stm32f4xx_spi.h"
#include "spi.h"
#include "stdio.h"
#include "type.h"
#define MOSI  GPIO_Pin_7
#define MISO  GPIO_Pin_6
#define CLK   GPIO_Pin_5
#define NSS   GPIO_Pin_10
#define Handshark  GPIO_Pin_8
void SPI_pin_config(void);
void SPI_init(void);
// NSS pin is PA9
void SPI_pin_nss(void);
void SPI_exti_pin_handshark(void);
void SPI_send_data(BYTE* tx_buffer);
#endif