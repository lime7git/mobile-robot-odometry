#include "Uart.h"
#include "Motors.h"
#include <stdio.h>
#include <string.h>

extern sMOUSE* pMOUSE;
extern sMOT* pMOT_RIGHT;
extern sMOT* pMOT_LEFT;
extern bool logger_flag;
extern uint8_t run;

extern float debug_right_speed;
extern float debug_left_speed;

uint8_t Received[6];

float new_x,new_y,new_ang_uart;

void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart) {
 
	static char Data[40]; // Tablica przechowujaca wysylana wiadomosc.

	HAL_UART_Receive_DMA(&huart6, Received, 6); // Ponowne wlaczenie nasluchiwania
	
	if		 (Received[0] == 'R' && Received[1] == 'S' && Received[2] == 'T'){
					if(logger_flag == false)HAL_UART_Transmit_DMA(&huart6,(uint8_t *)Data,sprintf(Data,"RESET\r\n"));
					//memset(Received,'-',6);		
					NVIC_SystemReset();			
				}
	else if		 (Received[0] == 'T' && Received[1] == 'E' && Received[2] == 'S' && Received[3] == 'T'){
					if(logger_flag == false)HAL_UART_Transmit_DMA(&huart6,(uint8_t *)Data,sprintf(Data,"TEST!\r\n"));
					memset(Received,'-',6);			
				}
	else if		 (Received[0] == 'L' && Received[1] == 'O' && Received[2] == 'G' && Received[3] == 'O' && Received[4] == 'N'){
					if(logger_flag == false)HAL_UART_Transmit_DMA(&huart6,(uint8_t *)Data,sprintf(Data,"LOGGER ON!\r\n"));
					memset(Received,'-',6);	
					logger_flag = true;	
				}
	else if		 (Received[0] == 'L' && Received[1] == 'O' && Received[2] == 'G' && Received[3] == 'O' && Received[4] == 'F' && Received[5] == 'F'){
					memset(Received,'-',6);			
					logger_flag = false;
					if(logger_flag == false) HAL_UART_Transmit_DMA(&huart6,(uint8_t *)Data,sprintf(Data,"LOGGER OFF!\r\n"));
				}
	else if		 (Received[0] == 'P' && Received[1] == 'O' && Received[2] == 'I' && Received[3] == 'N' && Received[4] == 'T' && Received[5] == '1'){
					memset(Received,'-',6);			
	
		static uint8_t next_point = 0;
			
					next_point++;
					pMOUSE->act_motion_mode = XY_MODE;
					run = 1;
					
					if(next_point == 1){
						pMOUSE->new_pos_x = 300.0f;
						pMOUSE->new_pos_y = 300.0f;
					}
					else if(next_point == 2){
						pMOUSE->new_pos_x = 300.0f;
						pMOUSE->new_pos_y = 1300.0f;						
					}
					else if(next_point == 3){
						pMOUSE->new_pos_x = 1300.0f;
						pMOUSE->new_pos_y = 1300.0f;						
					}
					else if(next_point == 4){
						pMOUSE->new_pos_x = 1300.0f;
						pMOUSE->new_pos_y = 300.0f;				
					}					
					else if(next_point == 5){
						pMOUSE->new_pos_x = 300.0f;
						pMOUSE->new_pos_y = 300.0f;				
						next_point = 1;
					}
				}			
	else if		 (Received[0] == 'N' && Received[1] == 'X'){
						
		static int x;
		static char tmp[4];
					tmp[0] = Received[2];
					tmp[1] = Received[3];
					tmp[2] = Received[4];
					tmp[3] = Received[5];
		
					x = atoi(tmp);
					
					new_x = (float)x;
		
				//	memset(Received,'-',6);		
				}	
	else if		 (Received[0] == 'N' && Received[1] == 'Y'){
				
		static int y;
		static char tmp[4];
					tmp[0] = Received[2];
					tmp[1] = Received[3];
					tmp[2] = Received[4];
					tmp[3] = Received[5];
		
					y = atoi(tmp);
					
					new_y = (float)y;
		
					if(new_x >= 0.0f && new_y >= 0.0f)
					{
						pMOUSE->new_pos_x = new_x;
						pMOUSE->new_pos_y = new_y;
						
						pMOUSE->act_motion_mode = XY_MODE;
						run = 1;
					}
					
				//	memset(Received,'-',6);	
					new_x = 0.0f;
					new_y = 0.0f;
				}	
	else if		 (Received[0] == 'A' && Received[1] == 'N' && Received[2] == 'G' && Received[3] == 'Z' && Received[4] == 'E' && Received[5] == 'R'){
				//		memset(Received,'-',6);	
	
						pMOUSE->new_ang = 0.0f;
						pMOUSE->act_motion_mode = ANG_MODE;
						run = 1;
				}	
	else if		 (Received[0] == 'A' && Received[1] == 'N' && Received[2] == 'G'){
				
		static int ang;
		static char tmp[3];
					tmp[0] = Received[3];
					tmp[1] = Received[4];
					tmp[2] = Received[5];
		
					ang = atoi(tmp);
					
					new_ang_uart = (float)ang;
		
					if(new_ang_uart <= 180.0f && new_ang_uart > 0.0f)
					{
						pMOUSE->new_ang = new_ang_uart;
						
						pMOUSE->act_motion_mode = ANG_MODE;
						run = 1;
					}
					
				//	memset(Received,'-',6);	
				}	
	else if		 (Received[0] == 'A' && Received[1] == 'G'){
				
		static int ang;
		static char tmp[4];
					tmp[0] = Received[2];
					tmp[1] = Received[3];
					tmp[2] = Received[4];
					tmp[3] = Received[5];
		
					ang = atoi(tmp);
					
					new_ang_uart = (float)ang;
		
					if(new_ang_uart < 0.0f && new_ang_uart >= -180.0f)
					{
						pMOUSE->new_ang = new_ang_uart;
						
						pMOUSE->act_motion_mode = ANG_MODE;
						run = 1;
					}
					
				//	memset(Received,'-',6);	
				}	
		else if		 (Received[0] == 'R' && Received[1] == 'F'){
				//		memset(Received,'-',6);	
	
						debug_right_speed = 10.f;
						run = 7;
				}	
		else if		 (Received[0] == 'R' && Received[1] == 'B'){
				//		memset(Received,'-',6);	
	
						debug_right_speed = -10.f;
						run = 7;
				}	
		else if		 (Received[0] == 'L' && Received[1] == 'F'){
				//		memset(Received,'-',6);	
	
						debug_left_speed = 10.f;
						run = 7;
				}	
		else if		 (Received[0] == 'L' && Received[1] == 'B'){
				//		memset(Received,'-',6);	
	
						debug_left_speed = -10.f;
						run = 7;
				}	
	else{
		HAL_UART_Transmit_DMA(&huart6,(uint8_t *)Data,sprintf(Data,"NIEZNANA KOMENDA\r\n"));
				//	memset(Received,'-',6);		
	}
}

void DATA_LOGGER_POS(void){
	
	static char Data_transmit[16];
	static int x1, y1, x2, y2, ang;
	
	x1 = x2;
	y1 = y2;
	
	x2 = (int)pMOUSE->pos_x;
	y2 = (int)pMOUSE->pos_y;
	
	ang = (int)pMOUSE->ang;
	
	
	HAL_UART_Transmit_DMA(&huart6, (uint8_t*)Data_transmit, sprintf(Data_transmit, "\nX%iY%iX%iY%iA%i",x1,y1,x2,y2,ang));
	
}


