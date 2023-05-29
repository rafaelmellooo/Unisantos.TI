import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {TagsSectionResponse} from "../../shared/interfaces/TagsSectionResponse";
import {NewCompanyService} from "./new-company.service";
import {Location} from "@angular/common";
import {HttpErrorResponse} from "@angular/common/http";

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
      tags: [null]
    });
  }

  goBack() {
    this.location.back();
  }

  submitForm() {
    this.formGroup.markAllAsTouched();

    if (this.formGroup.invalid) {
      return;
    }

    this.newCompanyService.createCompany(this.formGroup.getRawValue()).subscribe({
      next: response => {
        console.log(response);
      },
      error: (httpErrorResponse: HttpErrorResponse) => {
        if (httpErrorResponse.error.errors && typeof(httpErrorResponse.error.errors) === 'object') {
          this.formGroup.setErrors(httpErrorResponse.error.errors);
        }
      }
    });

    console.log(this.formGroup.getRawValue());
  }
}
