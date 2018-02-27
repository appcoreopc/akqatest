import { ActionReducer, Action } from '@ngrx/store';

import {USERAMOUNT_SAVE, USERAMOUNT_SAVE_SUCCESS, 
		  USERAMOUNT_SAVE_ERR, USERAMOUNT_GET, USERAMOUNT_GET_ERR,
	  USERAMOUNT_GET_OK } from '../sharedObjects/sharedMessages';

		export function UserAmountReducer(status: number, action: Action) {
	switch (action.type) {
		case USERAMOUNT_GET_OK: 
		  return  { status : 1, data : action, type: USERAMOUNT_GET_OK };
		case USERAMOUNT_SAVE:			 
		  return  { status : 2, data : action, type: USERAMOUNT_SAVE_SUCCESS };		
		case USERAMOUNT_SAVE_SUCCESS:
			console.log(USERAMOUNT_SAVE_SUCCESS);
			return { status : 4, data : action, type: USERAMOUNT_SAVE_SUCCESS }
		case USERAMOUNT_SAVE_ERR:
			console.log(USERAMOUNT_SAVE_ERR);
			return  { status : 5, data : action, type: USERAMOUNT_SAVE_ERR };	
		default:
			return status;						
		}					
	} 