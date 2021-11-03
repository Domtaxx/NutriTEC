import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeAddingComponent } from './recipe-adding.component';

describe('RecipeAddingComponent', () => {
  let component: RecipeAddingComponent;
  let fixture: ComponentFixture<RecipeAddingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeAddingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeAddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
