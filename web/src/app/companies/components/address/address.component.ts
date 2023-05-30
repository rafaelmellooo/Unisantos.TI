import {Component, Input, OnInit} from '@angular/core';
import {AddressService} from "./address.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {State} from "@shared/interfaces/State";
import {City} from "@shared/interfaces/City";
import {BrasilService} from "@shared/services/brasil.service";
import {HttpErrorResponse} from "@angular/common/http";
import {MatDialog} from "@angular/material/dialog";
import {WarningDialogComponent} from "@shared/components/warning-dialog/warning-dialog.component";

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

  states: State[] = [];
  cities: City[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly addressService: AddressService,
    private readonly brasilService: BrasilService,
    private readonly dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.formGroup.addControl('address', this.createAddressForm());

    this.loadStates();
  }

  get addressForm() {
    return this.formGroup.get('address') as FormGroup;
  }

  createAddressForm() {
    return this.formBuilder.group({
      latitude: [null, Validators.required],
      longitude: [null, Validators.required],
      cep: [null, Validators.required],
      state: [null, Validators.required],
      city: [null, Validators.required],
      neighborhood: [null, Validators.required],
      street: [null, Validators.required],
      number: [null, Validators.required],
      complement: [null]
    });
  }

  async loadStates() {
    const response = await this.addressService.getStates();

    this.states = response.data;
  }

  async loadCities(state: string) {
    const response = await this.addressService.getCities(state);

    this.cities = response.data;
  }

  async fetchCep() {
    const cep = this.addressForm.get('cep');

    if (!cep || cep.invalid) {
      return;
    }

    try {
      const response = await this.brasilService.fetchCep(cep.value);

      await this.loadCities(response.state);

      this.addressForm.patchValue({
        state: response.state,
        neighborhood: response.neighborhood,
        street: response.street,
        latitude: response.location.coordinates.latitude,
        longitude: response.location.coordinates.longitude
      });

      const city = this.cities.find(
        city => city.name === response.city
      );

      this.addressForm.get('city')?.setValue(city?.id);
    } catch (exception) {
      if (exception instanceof HttpErrorResponse) {
        this.dialog.open(WarningDialogComponent, {
          data: {
            warning: "CEP está inválido ou não foi encontrado"
          }
        });
      }
    }
  }
}
