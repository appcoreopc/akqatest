import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Actions, Effect } from '@ngrx/effects';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import * as messageUtil from "../sharedObjects/storeMessageUtil";

import {
  USERAMOUNT_SAVE, USERAMOUNT_SAVE_SUCCESS,
  USERAMOUNT_SAVE_ERR,  
  USERAMOUNT_GET, USERAMOUNT_GET_ERR,
  PROGRESS_WAIT_SHOW, PROGRESS_WAIT_HIDE,
  USERAMOUNT_GET_OK, AppState, headersJson
} from '../sharedObjects/sharedMessages';

import { APPLICATION_HOST } from '../sharedObjects/applicationSetup';
import 'rxjs/Rx';
import { subscribeOn } from 'rxjs/operator/subscribeOn';

@Injectable()
export class UserAmountEffects {

  constructor(
    private http: HttpClient,
    private actions$: Actions<AppState>, private store: Store<AppState>,
  ) { }

  @Effect() citySave$ = this.actions$
    .ofType(USERAMOUNT_SAVE)
    .map(action => {
      return JSON.stringify(action.data);
    }).switchMap(payload => {
      
      return Observable.of(payload)
        .map(action => {

          this.http.post(APPLICATION_HOST + '/employee/save', payload, { headers: headersJson })
            .subscribe(res => {
              messageUtil.dispatchIntent(this.store, USERAMOUNT_SAVE_SUCCESS, null);
              messageUtil.dispatchIntent(this.store, PROGRESS_WAIT_HIDE, null);

            },
            err => {
              if (err && err.status == 201) {
                messageUtil.dispatchIntent(this.store, USERAMOUNT_SAVE_SUCCESS, null);
                messageUtil.dispatchIntent(this.store, PROGRESS_WAIT_HIDE, null);

              }
              else {
                messageUtil.dispatchIntent(this.store, USERAMOUNT_SAVE_ERR, null);
                messageUtil.dispatchIntent(this.store, PROGRESS_WAIT_HIDE, null);
              }
            });
          
          });
             
    })
    .concatMap(res => {
      return Observable.of({ type: PROGRESS_WAIT_SHOW });
    });
 
  @Effect() cityGet$ = this.actions$
    .ofType(USERAMOUNT_GET)
    .map(action => {
      JSON.stringify(action);
    })
    .switchMap(

    payload => this.http.get(APPLICATION_HOST + '/employee/index').map(res => {
      return { type: USERAMOUNT_GET_OK, data: res };
    }).catch(() => Observable.of({ type: USERAMOUNT_GET_ERR }))

    );
}

