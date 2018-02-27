import { TestBed, async } from '@angular/core/testing';
import { UserAmountComponentComponent } from './user-amount-component/user-amount-component.component';
import { AppComponent } from './app.component';
import { FormControl, FormsModule, FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { Store } from '@ngrx/store';

const akqatestTitle : string =  'Akqa test app';

let userServiceStub = { 
  subscribe : function() {
  },
  dispatch : function() {
  }
};

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports : [ReactiveFormsModule, FormsModule],
      declarations: [
        AppComponent, UserAmountComponentComponent
      ], 
      providers: [ {provide: Store, useValue: userServiceStub } ] 
    }).compileComponents();
  }));
  
  it(`should have as title 'akqa test'`, async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual(akqatestTitle);
  }));
  
  it('should render title in a app-user-amount-component tag', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    const targetComponent = compiled.querySelector('app-user-amount-component');
    expect(targetComponent).not.toBeNull();
  }));
});
