import {AddressResponse} from "./AddressResponse";

export interface CompanyResponse {
  id: string;
  name: string;
  latitude: number;
  longitude: number;
  imagePreviewUrl: string;
  rating?: number;
  address: AddressResponse;
  tags: string[];
}
