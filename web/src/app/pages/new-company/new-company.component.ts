import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {TagsSectionResponse} from "../../shared/interfaces/TagsSectionResponse";
import {NewCompanyService} from "./new-company.service";
import {StateResponse} from "../../shared/interfaces/StateResponse";
import {CityResponse} from "../../shared/interfaces/CityResponse";

@Component({
  selector: 'app-new-company',
  templateUrl: './new-company.component.html',
  styleUrls: ['./new-company.component.sass']
})
export class NewCompanyComponent implements OnInit {
  formGroup: FormGroup;

  tagsSections: TagsSectionResponse[] = [];
  states: StateResponse[] = [];
  cities: CityResponse[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly newCompanyService: NewCompanyService
  ) {
    this.formGroup = this.getFormGroup();
  }

  get addressFormGroup() {
    return this.formGroup.get('address') as FormGroup;
  }

  ngOnInit() {
    this.loadTags();
    this.loadStates();
  }

  loadTags() {
    this.newCompanyService.getTags().subscribe(response => {
      this.tagsSections = response.data;
    });
  }

  loadStates() {
    this.newCompanyService.getStates().subscribe(response => {
      this.states = response.data;
    });
  }

  loadCities(stateId: number) {
    this.newCompanyService.getCities(stateId).subscribe(response => {
      this.cities = response.data;
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

  submitForm() {
    console.log(this.formGroup.getRawValue());
  }
}
