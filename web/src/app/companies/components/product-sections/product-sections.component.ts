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

  get productSectionsForm() {
    return this.formGroup.get('productSections') as FormArray;
  }

  createProductSectionsForm() {
    return this.formBuilder.group({
      title: [null, Validators.required],
      products: this.formBuilder.array([]),
    });
  }

  createProductForm() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      price: [null, Validators.required]
    });
  }

  productsForm(section: number) {
    return this.productSectionsForm.controls[section].get('products') as FormArray;
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

  addProductSectionForm() {
    this.productSectionsForm.push(this.createProductSectionsForm());
  }

  addProductForm(section: number) {
    this.productsForm(section).push(this.createProductForm());
  }

  removeProductSectionForm(index: number) {
    this.productSectionsForm.removeAt(index);
  }

  removeProductForm(section: number, index: number) {
    this.productsForm(section).removeAt(index);
  }
}
