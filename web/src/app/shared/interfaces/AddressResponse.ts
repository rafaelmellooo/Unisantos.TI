export interface AddressResponse {
  id: string;
  zipCode: string;
  state: string;
  city: string;
  neighborhood: string;
  street: string;
  number: number;
  complement?: string;
}
