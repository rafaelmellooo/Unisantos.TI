import {Address} from "../Address/Address";
import {Tag} from "@shared/interfaces/Company/Tag";

export interface Company {
  id: string;
  name: string;
  imagePreviewUrl: string;
  rating?: number;
  address: Address;
  tags: Tag[];
}
