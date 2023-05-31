import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CompanyService} from "../../services/company.service";
import {Location} from "@angular/common";
import {HttpErrorResponse} from "@angular/common/http";
import {TagSection} from "@shared/interfaces/Company/TagSection";
import {ActivatedRoute, Router} from "@angular/router";
import {BusinessHoursComponent} from "../../components/business-hours/business-hours.component";
import {ProductSectionsComponent} from "../../components/product-sections/product-sections.component";
import {AddressComponent} from "../../components/address/address.component";
import {CompanyData} from "@shared/interfaces/Company/CompanyData";
import {CreateCompanyData} from "@shared/interfaces/Company/CreateCompanyData";
import {UpdateCompanyData} from "@shared/interfaces/Company/UpdateCompanyData";

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

  id: string;

  updateMode = false;

  companyForm: FormGroup;

  tagSections = new Array<TagSection>();

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly companyService: CompanyService,
    private readonly location: Location,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router
  ) {
    this.companyForm = this.createCompanyForm();
  }

  ngOnInit() {
    this.loadTags();
  }

  ngAfterViewInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id) {
      this.id = id;

      this.loadCompanyData(id).then(() => {
        if (this.activatedRoute.snapshot.data['viewMode']) {
          this.companyForm.disable({
            emitEvent: false
          });
        }
      });
    }

    this.updateMode = this.activatedRoute.snapshot.data['updateMode'];
  }

  async loadCompanyData(id: string) {
    const response = await this.companyService.getCompanyDetails(id);

    response.data.businessHours.forEach(() => {
      this.businessHoursComponent.addBusinessHoursForm();
    });

    response.data.productSections.forEach((productSection, index) => {
      this.productSectionsComponent.addProductSectionForm();

      productSection.products.forEach(() => {
        this.productSectionsComponent.addProductForm(index);
      });
    });

    await this.addressComponent.loadCities(response.data.address.state.id);

    this.companyForm.patchValue({
      name: response.data.name,
      description: response.data.description,
      imagePreviewUrl: response.data.imagePreviewUrl,
      imageUrl: response.data.imageUrl,
      phone: response.data.phone,
      instagram: response.data.instagram,
      facebook: response.data.facebook,
      tags: response.data.tags.map(tag => tag.id),
      address: {
        id: response.data.address.id,
        cep: response.data.address.cep,
        latitude: response.data.address.latitude,
        longitude: response.data.address.longitude,
        state: response.data.address.state.id,
        city: response.data.address.city.id,
        street: response.data.address.street,
        neighborhood: response.data.address.neighborhood,
        number: response.data.address.number,
        complement: response.data.address.complement
      },
      businessHours: response.data.businessHours,
      productSections: response.data.productSections
    }, {
      emitEvent: false
    });
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

    const createCompanyData = this.companyForm.getRawValue() as CreateCompanyData;

    try {
      if (this.updateMode) {
        const updateCompanyData: UpdateCompanyData = {
          ...createCompanyData,
          removedBusinessHours: this.businessHoursComponent.businessHoursToRemove,
          removedProductSections: this.productSectionsComponent.productSectionsToRemove,
          removedProducts: this.productSectionsComponent.productsToRemove,
        };

        await this.companyService.updateCompany(this.id, updateCompanyData);
      } else {
        await this.companyService.createCompany(createCompanyData);
      }

      this.router.navigateByUrl('/home');
    } catch (exception) {
      if (exception instanceof HttpErrorResponse) {
        if (exception.error.errors && typeof (exception.error.errors) === 'object') {
          this.companyForm.setErrors(exception.error.errors);
        }
      }
    }
  }
}
