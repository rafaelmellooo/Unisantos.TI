import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl, FormArray, FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-product-sections',
  templateUrl: './product-sections.component.html',
  styleUrls: ['./product-sections.component.sass']
})
export class ProductSectionsComponent implements OnInit {
  @Input({
    required: true
  })
  formGroup: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder
  ) {
  }

  ngOnInit() {
    this.formGroup.addControl('productSections', this.formBuilder.array([]));
  }

  get productSections() {
    return this.formGroup.get('productSections') as FormArray;
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
    return this.productSections.controls[section].get('products') as FormArray;
  }

  getInfoProductSection(productSection: AbstractControl) {
    const title = productSection.get('title')?.value || 'Título da seção';

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

  addProductSection() {
    this.productSections.push(this.getFormGroup());
  }

  addProduct(section: number) {
    this.products(section).push(this.getProductFormGroup());
  }

  removeProductSection(index: number) {
    this.productSections.removeAt(index);
  }

  removeProduct(section: number, index: number) {
    this.products(section).removeAt(index);
  }
}
