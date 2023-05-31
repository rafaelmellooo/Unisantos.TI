import {City} from "@shared/interfaces/Address/City";
import {State} from "@shared/interfaces/Address/State";

export interface Address {
  id: string;
  cep: string;
  latitude: number;
  longitude: number;
  state: State;
  city: City;
  neighborhood: string;
  street: string;
  number: number;
  complement?: string;
}
