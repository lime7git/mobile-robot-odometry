#include "Motors.h"
#include "Sensors.h"
#include "Uart.h"

sMOT sMOT_LEFT;
sMOT* pMOT_LEFT = &sMOT_LEFT;
sMOT sMOT_RIGHT;
sMOT* pMOT_RIGHT = &sMOT_RIGHT;

sMOUSE MOUSE;
sMOUSE* pMOUSE = &MOUSE;

uint8_t run = 0;

float debug_right_speed = 0.0f;
float debug_left_speed = 0.0f;

void PID_INIT(float kp, float ki, float kd, sMOT *ptrMOTOR){
	
	ptrMOTOR->kp = kp;
	ptrMOTOR->ki = ki;
	ptrMOTOR->kd = kd;
	
}
void MOUSE_INIT(void){
	
	TIM3->CNT = 0;
	TIM4->CNT = 0;
	
	pMOT_LEFT->set_rpm 		= 0.0f;
	pMOT_LEFT->totalDist 	= 0.0f;
	pMOT_LEFT->e 					= 0.0f;
	pMOT_LEFT->e_total 		= 0.0f;
	pMOT_LEFT->e_prev 		= 0.0f;
	pMOT_LEFT->enc 				= 0.0f;
	
	pMOT_RIGHT->set_rpm 	= 0.0f;
	pMOT_RIGHT->totalDist = 0.0f;
	pMOT_RIGHT->e 				= 0.0f;
	pMOT_RIGHT->e_total 	= 0.0f;
	pMOT_RIGHT->e_prev 		= 0.0f;
	pMOT_RIGHT->enc 			= 0.0f;
	
	pMOUSE->pos_x 		= 0.0f;
	pMOUSE->pos_y 		= 0.0f;
	pMOUSE->new_pos_x = 0.0f;
	pMOUSE->new_pos_y = 0.0f;
	pMOUSE->new_ang 	= 0.0f;
	
}
void READ_POS(void){
	
	pMOT_LEFT->encPrev = pMOT_LEFT->enc;
	pMOT_LEFT->enc = TIM3->CNT;
	pMOT_LEFT->encDiff = pMOT_LEFT->enc - pMOT_LEFT->encPrev;
	
	if(pMOT_LEFT->encDiff > 32768)
		pMOT_LEFT->encDiff = pMOT_LEFT->encDiff - 65536;
	if(pMOT_LEFT->encDiff < -32768)
		pMOT_LEFT->encDiff = 65536 - abs(pMOT_LEFT->encDiff);
	
	pMOT_LEFT->dist = (float)pMOT_LEFT->encDiff / ENC_IMP_PER_ROTATE * CIRCUMFERENCE_OF_WHEEL;
	pMOT_LEFT->totalDist += pMOT_LEFT->dist;
	
	
	pMOT_RIGHT->encPrev = pMOT_RIGHT->enc;
	pMOT_RIGHT->enc = TIM4->CNT;
	pMOT_RIGHT->encDiff = pMOT_RIGHT->enc - pMOT_RIGHT->encPrev;
	
	if(pMOT_RIGHT->encDiff > 32768)
		pMOT_RIGHT->encDiff = pMOT_RIGHT->encDiff - 65536;
	if(pMOT_RIGHT->encDiff < -32768)
		pMOT_RIGHT->encDiff = 65536 - abs(pMOT_RIGHT->encDiff);
	
	pMOT_RIGHT->dist = (float)pMOT_RIGHT->encDiff / ENC_IMP_PER_ROTATE * CIRCUMFERENCE_OF_WHEEL;
	pMOT_RIGHT->totalDist += pMOT_RIGHT->dist;
	
	float tempAng = ((pMOT_LEFT->totalDist - pMOT_RIGHT->totalDist) * ROTATE_CALIB) / DISTANCE_BETWEEN_WHEELS * RAD_TO_DEG;
	
	pMOUSE->ang = fmod(tempAng, 360.0f);
	
	if(pMOUSE->ang < -180.0f)
	{
		pMOUSE->ang += 360.0f;
	}
	else if(pMOUSE->ang > 180.0f)
	{
		pMOUSE->ang -= 360.0f;
	}

	pMOUSE->distance = (pMOT_LEFT->dist + pMOT_RIGHT->dist) / 2.0f;
	
	pMOUSE->pos_x += pMOUSE->distance * sin(pMOUSE->ang * DEG_TO_RAD);
	pMOUSE->pos_y += pMOUSE->distance * cos(pMOUSE->ang * DEG_TO_RAD);
}
void MOT_LEFT_GET_SPEED(void){

	pMOT_LEFT->pulse_per_sec = TIM3->CNT - pMOT_LEFT->prev_pulse;
			if(pMOT_LEFT->pulse_per_sec > 32768)
					pMOT_LEFT->pulse_per_sec = pMOT_LEFT->pulse_per_sec - 65535;
			if(pMOT_LEFT->pulse_per_sec < -32768)
				pMOT_LEFT->pulse_per_sec = 65535 - abs(pMOT_LEFT->pulse_per_sec);
				
	pMOT_LEFT->prev_pulse = TIM3->CNT;
	pMOT_LEFT->act_rpm = (float)pMOT_LEFT->pulse_per_sec / ENC_IMP_PER_ROTATE * 6000.0f;	
	
}
void MOT_RIGHT_GET_SPEED(void){
	
	pMOT_RIGHT->pulse_per_sec = TIM4->CNT - pMOT_RIGHT->prev_pulse;
			if(pMOT_RIGHT->pulse_per_sec > 32768)
					pMOT_RIGHT->pulse_per_sec = pMOT_RIGHT->pulse_per_sec - 65535;
			if(pMOT_RIGHT->pulse_per_sec < -32768)
				pMOT_RIGHT->pulse_per_sec = 65535 - abs(pMOT_RIGHT->pulse_per_sec);
				
	pMOT_RIGHT->prev_pulse = TIM4->CNT;
	pMOT_RIGHT->act_rpm = (float)pMOT_RIGHT->pulse_per_sec / ENC_IMP_PER_ROTATE * 6000.0f;	
	
}
void MOT_LEFT_REGULATOR(void){
	
	pMOT_LEFT->e_prev = pMOT_LEFT->e;
	
  pMOT_LEFT->e = pMOT_LEFT->set_rpm - pMOT_LEFT->act_rpm;
	
	pMOT_LEFT->e_total += pMOT_LEFT->e;
	
	if(pMOT_LEFT->e_total > 10000.0f)		
		pMOT_LEFT->e_total = 10000.0f;
	else if(pMOT_LEFT->e_total < -10000.0f)	
		pMOT_LEFT->e_total = -10000.0f;
	
	pMOT_LEFT->out = pMOT_LEFT->kp * pMOT_LEFT->e + pMOT_LEFT->ki * pMOT_LEFT->e_total * TIME_STAMP + pMOT_LEFT->kd * (pMOT_LEFT->e - pMOT_LEFT->e_prev) / TIME_STAMP;

	if(pMOT_LEFT->out > 100.0f)		
		pMOT_LEFT->out = 100.0f;
	else if(pMOT_LEFT->out < -100.0f)	
		pMOT_LEFT->out = -100.0f;

	MOT_LEFT_SET_SPEED(pMOT_LEFT->out);

}

void MOT_RIGHT_REGULATOR(void){
	
	pMOT_RIGHT->e_prev = pMOT_RIGHT->e;
	
  pMOT_RIGHT->e = pMOT_RIGHT->set_rpm - pMOT_RIGHT->act_rpm;
	
	pMOT_RIGHT->e_total += pMOT_RIGHT->e;
	
	if(pMOT_RIGHT->e_total > 10000.0f)		
		pMOT_RIGHT->e_total = 10000.0f;
	else if(pMOT_RIGHT->e_total < -10000.0f)	
		pMOT_RIGHT->e_total = -10000.0f;
	
	pMOT_RIGHT->out = pMOT_RIGHT->kp * pMOT_RIGHT->e + pMOT_RIGHT->ki * pMOT_RIGHT->e_total * TIME_STAMP + pMOT_RIGHT->kd * (pMOT_RIGHT->e - pMOT_RIGHT->e_prev) / TIME_STAMP;

	
	if(pMOT_RIGHT->out > 100.0f) 	
		pMOT_RIGHT->out = 100.0f;
	else if(pMOT_RIGHT->out < -100.0f)	
		pMOT_RIGHT->out = -100.0f;
	
	MOT_RIGHT_SET_SPEED(pMOT_RIGHT->out);

}

static void MOT_LEFT_SET_SPEED(float speed){

	
	if(speed > 0.0f)		// jezeli ustawiona predkosc jest wieksza od 0 krec w prawo
	{
			__HAL_TIM_SET_COMPARE(&htim1, TIM_CHANNEL_1, fabs(speed * 9.99f));
			MOTL_FORWARD;
	}
	
	if(speed < 0.0f)	// jezeli ustawiona predkosc jest mniejsza od 0 krec w lewo
	{
			__HAL_TIM_SET_COMPARE(&htim1, TIM_CHANNEL_1, fabs(speed * 9.99f));
			MOTL_BACKWARDS;
	}
			 if (speed > -0.1f && speed < 0.1f)	// w przeciwnym razie stop
			{
				__HAL_TIM_SET_COMPARE(&htim1, TIM_CHANNEL_1, 0);
				MOTL_STOP;
			}
	
}
static void MOT_RIGHT_SET_SPEED(float speed){
	
	if(speed > 0.0f)		// jezeli ustawiona predkosc jest wieksza od 0 krec w prawo
	{
			__HAL_TIM_SET_COMPARE(&htim2, TIM_CHANNEL_2, fabs(speed * 9.99f));
			MOTR_FORWARD;
	}
	
	if(speed < 0.0f)	// jezeli ustawiona predkosc jest mniejsza od 0 krec w lewo
	{
			__HAL_TIM_SET_COMPARE(&htim2, TIM_CHANNEL_2, fabs(speed * 9.99f));
			MOTR_BACKWARDS;
	}
			 if (speed > -0.1f && speed < 0.1f)		// w przeciwnym razie stop
			{
				__HAL_TIM_SET_COMPARE(&htim2, TIM_CHANNEL_2, 0);
				MOTR_STOP;
			}	
	
}
void MOVE_SET(float new_pos_x, float new_pos_y, float new_ang, eMODE mode){
	
		pMOUSE->new_pos_x = new_pos_x;
		pMOUSE->new_pos_y = new_pos_y;
		pMOUSE->new_ang 	= new_ang;
		pMOUSE->act_motion_mode = mode;
		
}
void MOVE(float new_pos_x, float new_pos_y, float new_ang, eMODE mode){
	
	 static float prev_distance_to_travel, out;
	 static float prev_ang_to_achieve, out_ang;
	 
	
	prev_distance_to_travel = pMOUSE->distance_to_travel;
	prev_ang_to_achieve = pMOUSE->ang_to_achieve;
	
	pMOUSE->distance_to_travel = sqrt(pow((new_pos_x - pMOUSE->pos_x),2) + pow((new_pos_y - pMOUSE->pos_y),2));

	if			(mode == XY_MODE)
		pMOUSE->ang_to_achieve = fmod((atan2f((new_pos_x - pMOUSE->pos_x),(new_pos_y - pMOUSE->pos_y)) * RAD_TO_DEG) - pMOUSE->ang, 360.0f);
	
	else if	(mode == ANG_MODE)
		pMOUSE->ang_to_achieve = fmod( (new_ang - pMOUSE->ang) , 360.0f );
	
	if(pMOUSE->ang_to_achieve < -180.0f)
	{
		pMOUSE->ang_to_achieve += 360.0f;
	}
	else if(pMOUSE->ang_to_achieve > 180.0f)
	{
		pMOUSE->ang_to_achieve -= 360.0f;
	}

	out 		= 0.2f * pMOUSE->distance_to_travel 	 	+ 0.1f 	* (pMOUSE->distance_to_travel - prev_distance_to_travel) / TIME_STAMP;
	out_ang = 0.8f 	* pMOUSE->ang_to_achieve + 0.51f * (pMOUSE->ang_to_achieve - prev_ang_to_achieve) / TIME_STAMP;
	
	if(out > 50.0f)
			out = 50.0f;
	else if(out < -50.0f)
			out = -50.0f;
	
	if(out_ang > 40.0f)
			out_ang = 40.0f;
	else if(out_ang < -40.0f)
			out_ang = -40.0f;
	
	
	if(pMOUSE->act_motion_mode == XY_MODE)
	{
	
		if(pMOUSE->distance_to_travel > 2.8f)
		{
			pMOUSE->Front = out;
		}
		else
		{
			pMOUSE->Front = 0.0f;
			//MOT_STOP;
		}

	}
	
	if(pMOUSE->ang_to_achieve  > -5.0f && pMOUSE->ang_to_achieve  < 5.0f)
	{
		pMOUSE->Dir = out_ang;
	}
	else 
	{
		pMOUSE->Dir = out_ang;
		pMOUSE->Front = 0.0f;
	}
	
}
void MOUSE_MAIN(void){
			
			READ_POS();

			MOT_LEFT_GET_SPEED();
			MOT_RIGHT_GET_SPEED();

		if(run == 1){
			MOVE(pMOUSE->new_pos_x, pMOUSE->new_pos_y, pMOUSE->new_ang, pMOUSE->act_motion_mode);
			
		pMOT_LEFT->set_rpm 	= pMOUSE->Front + pMOUSE->Dir;
		pMOT_RIGHT->set_rpm = pMOUSE->Front - pMOUSE->Dir;
		
		MOT_RIGHT_REGULATOR();			
		MOT_LEFT_REGULATOR();
		}
		
		if(run == 7)
		{
			pMOT_LEFT->set_rpm = debug_left_speed;
			pMOT_RIGHT->set_rpm = debug_right_speed;
			
			MOT_RIGHT_REGULATOR();			
			MOT_LEFT_REGULATOR();
		}
		else{
			pMOUSE->Front = 0.0f;
			pMOUSE->Dir		= 0.0f;
		}
		
		
	
}
