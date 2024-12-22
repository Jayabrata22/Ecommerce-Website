import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupLoginComponent } from './signup-login.component';

describe('SignupLoginComponent', () => {
  let component: SignupLoginComponent;
  let fixture: ComponentFixture<SignupLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SignupLoginComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignupLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
