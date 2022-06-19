#include "Sensors.h"
#include "Motors.h"

extern ADC_HandleTypeDef hadc1;

sSENSOR sSEN_FRONT;
sSENSOR* pSENSOR_FRONT = &sSEN_FRONT;
sSENSOR sSEN_LEFT;
sSENSOR* pSENSOR_LEFT = &sSEN_LEFT;
sSENSOR sSEN_RIGHT;
sSENSOR* pSENSOR_RIGHT = &sSEN_RIGHT;

uint32_t 	ADC_buff[3],
					ADC_sum[3],
					ADC_mean[3];
					
float ADC_conv_V[3];
uint16_t mean_ctr = 0;

void HAL_ADC_ConvCpltCallback(ADC_HandleTypeDef* hadc){							
	
		 
	
		for (int i = 0; i < 3; i++)
		{
			ADC_sum[i] += ADC_buff[i];
		}
		
		mean_ctr++;
		
		if(mean_ctr > 1000)			// srednia z 1000 pomiarow
		{
			for (int i = 0; i < 3; i++)
			{
				ADC_mean[i] = ADC_sum[i] / mean_ctr;
				ADC_conv_V[i] = roundf(((float)ADC_mean[i] * (3.3f/4096.0f)) * 100.0f) / 100.0f;			// przeliczanie na Volty (napiecie stm32 adc / 12-bit ADC) ( * 100 / 100 ) dla dwoch miejsc po przecinku dla float
				ADC_sum[i] = 0;
			}
			mean_ctr = 0;
		
			CALCULATE_TO_DISTANCE_MM();
		}
	}

void CALCULATE_TO_DISTANCE_MM(void){
	
		pSENSOR_LEFT->distance_mm = roundf(((7.1675*(pow(ADC_conv_V[0],6))) - (78.82f*(pow(ADC_conv_V[0],5))) + (356.76f*(pow(ADC_conv_V[0],4))) - (857.37f*(pow(ADC_conv_V[0],3)))
		+ (1174.1f*(pow(ADC_conv_V[0],2))) - (910.83f*ADC_conv_V[0]) + 358.02f) * 100.0f) / 100.0f;
	
		pSENSOR_RIGHT->distance_mm = roundf(((11.449f*(pow(ADC_conv_V[1],6))) - (115.39f*(pow(ADC_conv_V[1],5))) + (477.71f*(pow(ADC_conv_V[1],4))) - (1055.1f*(pow(ADC_conv_V[1],3)))
		+ (1348.2f*(pow(ADC_conv_V[1],2))) - (1000.5f*ADC_conv_V[1]) + 384.37f) * 100.0f) / 100.0f;
	
		pSENSOR_FRONT->distance_mm = roundf(((14.791f*(powf(ADC_conv_V[2],6))) - (147.36f*(powf(ADC_conv_V[2],5))) + (607.99f*(powf(ADC_conv_V[2],4))) - (1351.1f*(powf(ADC_conv_V[2],3)))
		+ (1760.2f*(powf(ADC_conv_V[2],2)))	- (1368.7f*ADC_conv_V[2]) + 602.46f) * 100.0f) / 100.0f;
	
}

float GET_FRONT_SENSOR_MM(void){
	return pSENSOR_FRONT->distance_mm;
}

float GET_LEFT_SENSOR_MM(void){
	return pSENSOR_LEFT->distance_mm;
}

float GET_RIGHT_SENSOR_MM(void){
	return pSENSOR_RIGHT->distance_mm;
}

bool IS_WALL_FRONT(void){
	if(pSENSOR_FRONT->distance_mm < 100.0f) pSENSOR_FRONT->wall = true;
		else pSENSOR_FRONT->wall = false;
	
	return pSENSOR_FRONT->wall;
}
bool IS_WALL_LEFT(void){
	if(pSENSOR_LEFT->distance_mm < 100.0f) pSENSOR_LEFT->wall = true;
		else pSENSOR_LEFT->wall = false;
	
	return pSENSOR_LEFT->wall;
}
bool IS_WALL_RIGHT(void){
	if(pSENSOR_RIGHT->distance_mm < 100.0f) pSENSOR_RIGHT->wall = true;
		else pSENSOR_RIGHT->wall = false;
	
	return pSENSOR_RIGHT->wall;
}
