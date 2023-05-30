export interface Cep {
  cep: string;
  state: string;
  city: string;
  neighborhood: string;
  street: string;

  location: {
    coordinates: {
      latitude: string;
      longitude: string;
    }
  }
}
