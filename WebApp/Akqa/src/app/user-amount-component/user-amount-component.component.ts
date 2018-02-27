import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription'
import * as messageUtil from "../sharedObjects/storeMessageUtil";
import {FormUtil} from "../sharedObjects/formUtil";
import {UserAmountModel} from '../models/UserAmountModel';
import { Store } from '@ngrx/store';

import {
  USERAMOUNT_SAVE, USERAMOUNT_SAVE_SUCCESS,
  USERAMOUNT_SAVE_ERR,  
  USERAMOUNT_GET, USERAMOUNT_GET_ERR,
  PROGRESS_WAIT_SHOW, PROGRESS_WAIT_HIDE,
  USERAMOUNT_GET_OK, AppState, headersJson
} from '../sharedObjects/sharedMessages';
import { last } from 'rxjs/operators/last';

@Component({
  selector: 'app-user-amount-component',
  templateUrl: './user-amount-component.component.html',
  styleUrls: ['./user-amount-component.component.css']
})
export class UserAmountComponentComponent implements OnInit {
  
  private userAmountModel : UserAmountModel = new UserAmountModel();
  private userAmountForm : FormGroup;
  userSubscription: Subscription;
  
  formErrors = {
    'username': '',
    'amount': ''
  };
  
  validationMessages = {
    'username': {
      'required': 'Name is required.'
    },
    'amount': {
      'required': 'Amount is required'
    }
  };
  
  constructor(private store: Store<AppState>, private fb: FormBuilder) { }
  
  ngOnInit() {
    
    this.userSubscription = this.store.subscribe(appData => {
      
      this.componentMessageHandle(messageUtil.getMultiMessage(appData,
        [USERAMOUNT_GET_OK, USERAMOUNT_SAVE_SUCCESS]));
      });
      
      this.configureEditForm();  
    }
    
    ngAfterViewInit() { 
      this.dispatchIntent(USERAMOUNT_GET);
    }  
    private configureEditForm() {
      
      this.userAmountModel = new UserAmountModel();
      this.userAmountModel.username = '';
      this.userAmountModel.amount = 0;   
      
      this.userAmountForm = this.fb.group({
        username: [this.userAmountModel.username, Validators.required ],
        amount: [this.userAmountModel.amount, Validators.required]     
      });            
      this.userAmountForm.valueChanges.debounceTime(200).subscribe(data => 
        this.onValueChanged(data)       
      );
    }
    
    onValueChanged(data?: UserAmountModel) {
      
      if (!this.userAmountForm) { return; }
      
      const form = this.userAmountForm;
      
      for (const field in this.formErrors) {
        // clear previous error message (if any)
        this.formErrors[field] = '';
        const control = form.get(field);
        
        if (control && control.dirty && !control.valid) {
          const messages = this.validationMessages[field];
          for (const key in control.errors) {
            this.formErrors[field] += messages[key] + ' ';
          }
        }
      }
    }
        
    componentMessageHandle(messageAll: Array<any>) {      
      messageAll.map(message => {        
        if (message && message.type == USERAMOUNT_GET_OK) {          
          console.log(message);          
        }
        
        if (message && message.type == USERAMOUNT_SAVE_SUCCESS) {          
        }        
      });      
    }
        
    dispatchIntent(messageType: string, data?: any) {
      messageUtil.dispatchIntent(this.store, messageType, data);
    }
    
  }
  