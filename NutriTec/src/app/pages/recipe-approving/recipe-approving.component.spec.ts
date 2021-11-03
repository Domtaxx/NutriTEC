import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeApprovingComponent } from './recipe-approving.component';

describe('RecipeApprovingComponent', () => {
  let component: RecipeApprovingComponent;
  let fixture: ComponentFixture<RecipeApprovingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeApprovingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeApprovingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
