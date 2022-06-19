#ifndef _SENSORS_H
#define _SENSORS_H

#include "main.h"


typedef struct{
	
	float distance_mm;
	
	bool wall;
	
} sSENSOR;

extern uint32_t ADC_buff[3];

void CALCULATE_TO_DISTANCE_MM(void);

float GET_FRONT_SENSOR_MM(void);
float GET_LEFT_SENSOR_MM(void);
float GET_RIGHT_SENSOR_MM(void);

bool IS_WALL_FRONT(void);
bool IS_WALL_LEFT(void);
bool IS_WALL_RIGHT(void);

#endif
