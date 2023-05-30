import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessHoursComponent } from './business-hours.component';

describe('BusinessHoursComponent', () => {
  let component: BusinessHoursComponent;
  let fixture: ComponentFixture<BusinessHoursComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BusinessHoursComponent]
    });
    fixture = TestBed.createComponent(BusinessHoursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
