import {City} from "@shared/interfaces/Address/City";

export interface Address {
  id: string;
  cep: string;
  latitude: number;
  longitude: number;
  state: string;
  city: City;
  neighborhood: string;
  street: string;
  number: number;
  complement?: string;
}
