/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2021 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdbool.h>
#include <math.h>
#include <stdlib.h>
#include <stdio.h>
/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

void HAL_TIM_MspPostInit(TIM_HandleTypeDef *htim);

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
#define USER_LED_Pin GPIO_PIN_13
#define USER_LED_GPIO_Port GPIOC
#define USER_BUTTON_Pin GPIO_PIN_0
#define USER_BUTTON_GPIO_Port GPIOA
#define USER_BUTTON_EXTI_IRQn EXTI0_IRQn
#define USER_BUTTON_TOP_Pin GPIO_PIN_1
#define USER_BUTTON_TOP_GPIO_Port GPIOA
#define USER_BUTTON_TOP_EXTI_IRQn EXTI1_IRQn
#define SENSOR_SIDE_LEFT_Pin GPIO_PIN_3
#define SENSOR_SIDE_LEFT_GPIO_Port GPIOA
#define SENSOR_SIDE_RIGHT_Pin GPIO_PIN_4
#define SENSOR_SIDE_RIGHT_GPIO_Port GPIOA
#define SENSOR_FRONT_Pin GPIO_PIN_5
#define SENSOR_FRONT_GPIO_Port GPIOA
#define MOTL_ENC_CH1_Pin GPIO_PIN_6
#define MOTL_ENC_CH1_GPIO_Port GPIOA
#define MOTL_ENC_CH2_Pin GPIO_PIN_7
#define MOTL_ENC_CH2_GPIO_Port GPIOA
#define MOTL_IN4_Pin GPIO_PIN_12
#define MOTL_IN4_GPIO_Port GPIOB
#define MOTL_IN3_Pin GPIO_PIN_13
#define MOTL_IN3_GPIO_Port GPIOB
#define MOTR_IN2_Pin GPIO_PIN_14
#define MOTR_IN2_GPIO_Port GPIOB
#define MOTR_IN1_Pin GPIO_PIN_15
#define MOTR_IN1_GPIO_Port GPIOB
#define MOTL_PWM_Pin GPIO_PIN_8
#define MOTL_PWM_GPIO_Port GPIOA
#define BT_TX_Pin GPIO_PIN_11
#define BT_TX_GPIO_Port GPIOA
#define BT_RX_Pin GPIO_PIN_12
#define BT_RX_GPIO_Port GPIOA
#define MOTR_PWM_Pin GPIO_PIN_3
#define MOTR_PWM_GPIO_Port GPIOB
#define MOTL_ENC_CH1B6_Pin GPIO_PIN_6
#define MOTL_ENC_CH1B6_GPIO_Port GPIOB
#define MOTR_ENC_CH2_Pin GPIO_PIN_7
#define MOTR_ENC_CH2_GPIO_Port GPIOB
/* USER CODE BEGIN Private defines */

/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
