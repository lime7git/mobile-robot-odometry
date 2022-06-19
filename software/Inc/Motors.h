#ifndef _MOTORS_H
#define _MOTORS_H

#include "main.h"

#define MOTR_IN1_ON			GPIOB->ODR |= GPIO_ODR_OD15;
#define MOTR_IN1_OFF		GPIOB->ODR &= ~GPIO_ODR_OD15;
#define MOTR_IN2_ON			GPIOB->ODR |= GPIO_ODR_OD14;
#define MOTR_IN2_OFF		GPIOB->ODR &= ~GPIO_ODR_OD14;
#define MOTL_IN3_ON			GPIOB->ODR |= GPIO_ODR_OD13;
#define MOTL_IN3_OFF		GPIOB->ODR &= ~GPIO_ODR_OD13;
#define MOTL_IN4_ON			GPIOB->ODR |= GPIO_ODR_OD12;
#define MOTL_IN4_OFF		GPIOB->ODR &= ~GPIO_ODR_OD12;

//#define MOTR_FORWARD		{MOTR_IN1_ON 		MOTR_IN2_OFF}
//#define MOTR_BACKWARDS	{MOTR_IN1_OFF		MOTR_IN2_ON}

#define MOTR_BACKWARDS	{MOTR_IN1_ON 		MOTR_IN2_OFF}
#define MOTR_FORWARD		{MOTR_IN1_OFF		MOTR_IN2_ON}

#define MOTL_FORWARD		{MOTL_IN3_ON		MOTL_IN4_OFF}
#define MOTL_BACKWARDS	{MOTL_IN3_OFF		MOTL_IN4_ON}

#define MOT_FORWARD			{MOTR_FORWARD		MOTL_FORWARD}
#define MOT_BACKWARDS		{MOTR_BACKWARDS	MOTL_BACKWARDS}

#define MOTR_STOP		{MOTR_IN1_OFF	MOTR_IN2_OFF}
#define MOTL_STOP 	{MOTL_IN3_OFF MOTL_IN4_OFF}
#define MOT_STOP		{MOTR_STOP MOTL_STOP}

#define TIME_STAMP 0.01f		// 10 ms

#define CIRCUMFERENCE_OF_WHEEL 204.1f					 	// d * pi // 65 mm * 3.14 	wheel cir
#define DISTANCE_BETWEEN_WHEELS 116.5f 	// 115.0 mm between two wheels
#define ENC_IMP_PER_ROTATE 3840.0f			// 32.0 * 120.0
#define ROTATE_CALIB 0.930232f 		// kalibracja obrotu

#define DEG_TO_RAD 0.0174532925f
#define RAD_TO_DEG 57.295779513f

typedef enum
{
	XY_MODE 	= 0,
	ANG_MODE 	= 1
} eMODE;

typedef struct{
	
	float set_rpm;
	float act_rpm;
	
	float e;
	float e_prev;
	float e_total;
	
	float out;
	
	float kp;
	float ki;
	float kd;
	
	int32_t enc;
	int32_t encPrev;
	int32_t encDiff;
	
	int32_t pulse_per_sec;
	int32_t prev_pulse;

	float totalDist;
	float dist;
	
} sMOT;

typedef struct{
	
	float Front;
	float Dir;
	
	float pos_x;
	float pos_y;
	float ang;
	float distance;

	float new_pos_x;
	float new_pos_y;
	float new_ang;
	
	float distance_to_travel;
	float ang_to_achieve;
	
	eMODE act_motion_mode;

} sMOUSE;


extern TIM_HandleTypeDef htim1;
extern TIM_HandleTypeDef htim2;
extern TIM_HandleTypeDef htim3;
extern TIM_HandleTypeDef htim4;

void PID_INIT(float kp, float ki, float kd, sMOT *ptrMOTOR);
void MOUSE_INIT(void);

void READ_POS(void);

void MOT_LEFT_GET_SPEED(void);
void MOT_RIGHT_GET_SPEED(void);

void MOT_LEFT_REGULATOR(void);
void MOT_RIGHT_REGULATOR(void);

static void MOT_LEFT_SET_SPEED(float speed);
static void MOT_RIGHT_SET_SPEED(float speed);

void MOVE_SET(float new_pos_x, float new_pos_y, float new_ang, eMODE mode);
void MOVE(float new_pos_x, float new_pos_y, float new_ang, eMODE mode);

void MOUSE_MAIN(void);



#endif
