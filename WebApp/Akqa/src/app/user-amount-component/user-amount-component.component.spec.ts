import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UserAmountComponentComponent } from './user-amount-component.component';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { FormControl, FormsModule, FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { Store } from '@ngrx/store';

let userServiceStub = { 
  subscribe : function() {
  },
  dispatch : function() {
  }
};


describe('UserAmountComponentComponent', () => {
  let component: UserAmountComponentComponent;
  let fixture: ComponentFixture<UserAmountComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports : [ReactiveFormsModule, FormsModule],
      declarations: [ UserAmountComponentComponent ],
      providers: [ {provide: Store, useValue: userServiceStub } ]
      
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAmountComponentComponent);
    component = fixture.componentInstance;
    component.ngOnInit();
    fixture.detectChanges();
  });

  it('should have input username', () => {
    const targetComponent : DebugElement = fixture.debugElement;
    const debugElem = targetComponent.query(By.css("label[for=username]"));
    expect(debugElem).not.toBeNull();
  });

  it('should have input amount', () => {
    const targetComponent : DebugElement = fixture.debugElement;
    const debugElem = targetComponent.query(By.css("label[for=amount]"));
    expect(debugElem).not.toBeNull();
  });

  it('should have save button', () => {
    const targetComponent : DebugElement = fixture.debugElement;
    const debugElem = targetComponent.query(By.css("#saveBtn"));
    console.log(debugElem);
    expect(debugElem).not.toBeNull();
  });
});
