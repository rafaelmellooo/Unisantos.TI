import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsSectionsComponent } from './products-sections.component';

describe('ProductsSectionsComponent', () => {
  let component: ProductsSectionsComponent;
  let fixture: ComponentFixture<ProductsSectionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsSectionsComponent]
    });
    fixture = TestBed.createComponent(ProductsSectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
