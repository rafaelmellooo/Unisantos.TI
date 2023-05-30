import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CompanyService} from "../../services/company.service";
import {Location} from "@angular/common";
import {HttpErrorResponse} from "@angular/common/http";
import {TagSection} from "@shared/interfaces/TagSection";

@Component({
  selector: 'app-new-company',
  templateUrl: './new-company.component.html',
  styleUrls: ['./new-company.component.sass']
})
export class NewCompanyComponent implements OnInit {
  companyForm: FormGroup;

  tagSections: TagSection[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly companyService: CompanyService,
    private readonly location: Location
  ) {
    this.companyForm = this.createCompanyForm();
  }

  ngOnInit() {
    this.loadTags();
  }

  async loadTags() {
    const response = await this.companyService.getTags();

    this.tagSections = response.data;
  }

  createCompanyForm() {
    return this.formBuilder.group({
      name: [null, Validators.required],
      imagePreviewUrl: [null, Validators.required],
      imageUrl: [null, Validators.required],
      description: [null, Validators.required],
      phone: [null, Validators.required],
      instagram: [null],
      facebook: [null],
      tags: [null]
    });
  }

  goBack() {
    this.location.back();
  }

  async submitForm() {
    this.companyForm.markAllAsTouched();

    if (this.companyForm.invalid) {
      return;
    }

    try {
      const response = await this.companyService.createCompany(this.companyForm.getRawValue());

      console.log(response);
    } catch (exception) {
      if (exception instanceof HttpErrorResponse) {
        if (exception.error.errors && typeof(exception.error.errors) === 'object') {
          this.companyForm.setErrors(exception.error.errors);
        }
      }
    }
  }
}
