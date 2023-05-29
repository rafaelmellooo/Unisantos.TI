import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl, FormArray, FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-products-sections',
  templateUrl: './products-sections.component.html',
  styleUrls: ['./products-sections.component.sass']
})
export class ProductsSectionsComponent implements OnInit {
  @Input({
    required: true
  })
  formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder
  ) {
  }

  ngOnInit() {
    this.formGroup.addControl('productsSections', this.formBuilder.array([]));
  }

  get productsSections() {
    return this.formGroup.get('productsSections') as FormArray;
  }

  getFormGroup() {
    return this.formBuilder.group({
      title: [null, Validators.required],
      products: this.formBuilder.array([]),
    });
  }

  getProductFormGroup() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      price: [null, Validators.required]
    });
  }

  products(section: number) {
    return this.productsSections.controls[section].get('products') as FormArray;
  }

  getInfoProductsSection(productsSection: AbstractControl) {
    const title = productsSection.get('title')?.value || 'Título da seção';

    return `${title}`;
  }

  getInfoProduct(product: AbstractControl) {
    const name = product.get('name')?.value || 'Nome do produto';

    const price = new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(product.get('price')?.value);

    return `${name} - ${price}`;
  }

  addProductsSection() {
    this.productsSections.push(this.getFormGroup());
  }

  addProduct(section: number) {
    this.products(section).push(this.getProductFormGroup());
  }

  removeProductsSection(index: number) {
    this.productsSections.removeAt(index);
  }

  removeProduct(section: number, index: number) {
    this.products(section).removeAt(index);
  }
}
