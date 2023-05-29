import {Address} from "./Address";

export interface Company {
  id: string;
  name: string;
  latitude: number;
  longitude: number;
  imagePreviewUrl: string;
  rating?: number;
  address: Address;
  tags: string[];
}
