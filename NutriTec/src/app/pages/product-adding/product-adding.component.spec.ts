import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAddingComponent } from './product-adding.component';

describe('ProductAddingComponent', () => {
  let component: ProductAddingComponent;
  let fixture: ComponentFixture<ProductAddingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductAddingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductAddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
