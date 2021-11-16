import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAdvanceComponent } from './my-advance.component';

describe('MyAdvanceComponent', () => {
  let component: MyAdvanceComponent;
  let fixture: ComponentFixture<MyAdvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyAdvanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAdvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
