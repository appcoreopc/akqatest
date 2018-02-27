import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { AppComponent } from './app.component';
import { UserAmountComponentComponent } from './user-amount-component/user-amount-component.component';
import { UserAmountEffects } from './user-amount-component/userAmountEffects';
import { UserAmountReducer } from './user-amount-component/userAmountReducer';

import { HttpClientModule }  from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    UserAmountComponentComponent
  ],
  imports: [
    BrowserModule, ReactiveFormsModule, HttpClientModule, FormsModule,
    StoreModule.forRoot([UserAmountReducer]),
    EffectsModule.forRoot([UserAmountEffects])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
