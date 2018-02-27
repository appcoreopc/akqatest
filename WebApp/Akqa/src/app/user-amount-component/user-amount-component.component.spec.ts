import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAmountComponentComponent } from './user-amount-component.component';

describe('UserAmountComponentComponent', () => {
  let component: UserAmountComponentComponent;
  let fixture: ComponentFixture<UserAmountComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserAmountComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAmountComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
