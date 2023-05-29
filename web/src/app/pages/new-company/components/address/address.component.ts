import {Component, Input, OnInit} from '@angular/core';
import {StateResponse} from "../../../../shared/interfaces/StateResponse";
import {CityResponse} from "../../../../shared/interfaces/CityResponse";
import {AddressService} from "./address.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.sass']
})
export class AddressComponent implements OnInit {
  @Input({
    required: true
  })
  formGroup: FormGroup;

  states: StateResponse[] = [];
  cities: CityResponse[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly addressService: AddressService
  ) {
  }

  ngOnInit() {
    this.formGroup.addControl('address', this.getFormGroup());

    this.loadStates();
  }

  get address() {
    return this.formGroup.get('address') as FormGroup;
  }

  getFormGroup() {
    return this.formBuilder.group({
      latitude: [null, Validators.required],
      longitude: [null, Validators.required],
      zipCode: [null, Validators.required],
      city: [null, Validators.required],
      neighborhood: [null, Validators.required],
      street: [null, Validators.required],
      number: [null, Validators.required],
      complement: [null],
    });
  }

  loadStates() {
    this.addressService.getStates().subscribe(response => {
      this.states = response.data;
    });
  }

  loadCities(stateId: number) {
    this.addressService.getCities(stateId).subscribe(response => {
      this.cities = response.data;
    });
  }
}
