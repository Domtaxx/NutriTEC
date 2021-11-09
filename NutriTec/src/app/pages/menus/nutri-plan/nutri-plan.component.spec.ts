import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NutriPlanComponent } from './nutri-plan.component';

describe('NutriPlanComponent', () => {
  let component: NutriPlanComponent;
  let fixture: ComponentFixture<NutriPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NutriPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NutriPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
