import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CompanyService} from "../../services/company.service";
import {Location} from "@angular/common";
import {HttpErrorResponse} from "@angular/common/http";
import {TagSection} from "@shared/interfaces/TagSection";
import {ActivatedRoute} from "@angular/router";
import {BusinessHoursComponent} from "../../components/business-hours/business-hours.component";
import {ProductSectionsComponent} from "../../components/product-sections/product-sections.component";
import {AddressComponent} from "../../components/address/address.component";

@Component({
  selector: 'app-new-company',
  templateUrl: './new-company.component.html',
  styleUrls: ['./new-company.component.sass']
})
export class NewCompanyComponent implements OnInit, AfterViewInit {
  @ViewChild('businessHoursComponent', {static: true})
  businessHoursComponent: BusinessHoursComponent;

  @ViewChild('productSectionsComponent', {static: true})
  productSectionsComponent: ProductSectionsComponent;

  @ViewChild('addressComponent', {static: true})
  addressComponent: AddressComponent;

  companyForm: FormGroup;

  tagSections: TagSection[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly companyService: CompanyService,
    private readonly location: Location,
    private readonly activatedRoute: ActivatedRoute
  ) {
    this.companyForm = this.createCompanyForm();
  }

  ngOnInit() {
    this.loadTags();
  }

  ngAfterViewInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id) {
      this.companyService.getCompanyDetails(id).then(response => {
        response.data.businessHours.forEach(() => {
          this.businessHoursComponent.addBusinessHoursForm();
        });

        response.data.productSections.forEach((productSection: any, section: number) => {
          this.productSectionsComponent.addProductSectionForm();

          productSection.products.forEach(() => {
            this.productSectionsComponent.addProductForm(section);
          });
        });

        this.addressComponent.loadCities(response.data.address.state).then(() => {
          this.companyForm.patchValue(response.data, {
            emitEvent: false
          });

          this.companyForm.disable({
            emitEvent: false
          });
        });
      });
    }
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
        if (exception.error.errors && typeof (exception.error.errors) === 'object') {
          this.companyForm.setErrors(exception.error.errors);
        }
      }
    }
  }
}
