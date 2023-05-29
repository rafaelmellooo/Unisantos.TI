import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {TagsSectionResponse} from "../../shared/interfaces/TagsSectionResponse";
import {NewCompanyService} from "./new-company.service";
import {Location} from "@angular/common";

@Component({
  selector: 'app-new-company',
  templateUrl: './new-company.component.html',
  styleUrls: ['./new-company.component.sass']
})
export class NewCompanyComponent implements OnInit {
  formGroup: FormGroup;

  tagsSections: TagsSectionResponse[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly newCompanyService: NewCompanyService,
    private readonly location: Location
  ) {
    this.formGroup = this.getFormGroup();
  }

  get addressFormGroup() {
    return this.formGroup.get('address') as FormGroup;
  }

  ngOnInit() {
    this.loadTags();
  }

  loadTags() {
    this.newCompanyService.getTags().subscribe(response => {
      this.tagsSections = response.data;
    });
  }

  getFormGroup() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      imagePreviewUrl: [null],
      imageUrl: [null],
      description: [null, Validators.required],
      phone: [null],
      instagram: [null],
      facebook: [null],
      tags: [null],

      address: this.formBuilder.group({
        latitude: [null, Validators.required],
        longitude: [null, Validators.required],
        zipCode: [null, Validators.required],
        city: [null, Validators.required],
        neighborhood: [null, Validators.required],
        street: [null, [Validators.required, Validators.pattern(/[0-9]+/)]],
        number: [null, Validators.required],
        complement: [null],
      })
    });
  }

  goBack() {
    this.location.back();
  }

  submitForm() {
    this.formGroup.markAllAsTouched();

    console.log(this.formGroup.getRawValue());
  }
}
