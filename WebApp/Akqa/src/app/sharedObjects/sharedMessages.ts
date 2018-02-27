import { ActionReducer, Action } from '@ngrx/store';
import { HttpHeaders } from '@angular/common/http';

export const USERAMOUNT_SAVE = 'USERAMOUNT_SAVE';
export const USERAMOUNT_SAVE_SUCCESS = 'USERAMOUNT_SAVE_SUCCESS';
export const USERAMOUNT_SAVE_ERR = 'USERAMOUNT_SAVE_ERR';
export const USERAMOUNT_GET = 'USERAMOUNT_GET';
export const USERAMOUNT_GET_ERR = 'USERAMOUNT_GET_ERR';
export const USERAMOUNT_GET_OK = 'USERAMOUNT_GET_OK';

export const PROGRESS_WAIT_SHOW = 'PROGRESS_WAIT_SHOW';
export const PROGRESS_WAIT_HIDE = "PROGRESS_WAIT_HIDE";

export interface AppState {
	status?: number;	
	type? : string; 
	data?  : any; 	
}

export interface KeyValueData {
	key: string;
	description : string
} 

export const headersJson = new HttpHeaders().set('Content-Type', 'application/json');