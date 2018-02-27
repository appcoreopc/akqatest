import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { FormControl, FormsModule, FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { Store } from '@ngrx/store';
import * as numUtil from "../sharedObjects/numToWord";

describe('numToWords test', () => {
       
    it('number 90 without fractions', () => {    
    const result = numUtil.number2words(90);   
    expect(result).toBe("NINETY AND ZERO CENTS");  
  
  });
       
  it('number 1990.90 fractions', () => {    
    const result = numUtil.number2words(1990.90);   
    expect(result).toBe("ONE THOUSAND NINE HUNDRED NINETY AND NINETY CENTS");
  });

  it('number 1990.90090 extra leading fractions', () => {    
    const result = numUtil.number2words(1990.90090);   
    expect(result).toBe("ONE THOUSAND NINE HUNDRED NINETY AND NINETY CENTS");
  });

});
