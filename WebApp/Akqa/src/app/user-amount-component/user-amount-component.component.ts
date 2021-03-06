import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription'
import * as messageUtil from "../sharedObjects/storeMessageUtil";
import {FormUtil} from "../sharedObjects/formUtil";
import {UserAmountModel} from '../models/UserAmountModel';
import { Store } from '@ngrx/store';
import "rxjs/add/operator/map";
import "rxjs/add/operator/debounceTime";

import * as numUtil from "../sharedObjects/numToWord";
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
  private userSubscription: Subscription;

  private amountInWords : string = '';
  private statusMessage : string = '';
  
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
        [USERAMOUNT_SAVE_ERR, USERAMOUNT_SAVE_SUCCESS]));
      });
      
      this.configureEditForm();  
    }
    
    ngAfterViewInit() { 
      
    }  
    private configureEditForm() {
      
      this.userAmountModel = new UserAmountModel();
      this.userAmountModel.username = '';
      this.userAmountModel.amount = 0;   
      
      this.userAmountForm = this.fb.group({
        username: [this.userAmountModel.username, Validators.required ],
        amount: [this.userAmountModel.amount, [Validators.required, Validators.maxLength(9)]]     
      });            
      this.userAmountForm.valueChanges.debounceTime(200).subscribe(data => 
        this.onValueChanged(data)       
      );
    }
    
    onValueChanged(data?: UserAmountModel) {
      
      this.amountInWords = '';
      if (!this.userAmountForm) { return; }
      
      const form = this.userAmountForm;

      this.userAmountModel.username = data.username;
      this.userAmountModel.amount = data.amount;

      this.amountInWords = numUtil.number2words(this.userAmountModel.amount);
      
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
        
        if (message && message.type == USERAMOUNT_SAVE_ERR) {          
           this.statusMessage = "Ops! Problem saving user amount to database.";
        }
        
        if (message && message.type == USERAMOUNT_SAVE_SUCCESS) {   
          this.statusMessage = "User and amount has been successfully saved.";
        }        
      });      
    }

    save()
    {      
      let data = this.userAmountForm.value as UserAmountModel;
      this.dispatchIntent(USERAMOUNT_SAVE, data);
    }
        
    dispatchIntent(messageType: string, data?: any) {
      messageUtil.dispatchIntent(this.store, messageType, data);
    }
  }
  