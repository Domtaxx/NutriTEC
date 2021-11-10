import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductApprovingComponent } from './product-approving.component';

describe('ProductApprovingComponent', () => {
  let component: ProductApprovingComponent;
  let fixture: ComponentFixture<ProductApprovingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductApprovingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductApprovingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
