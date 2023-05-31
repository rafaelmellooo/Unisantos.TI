import {ProductSection} from "@shared/interfaces/Company/ProductSection";
import {BusinessHours} from "@shared/interfaces/Company/BusinessHours";
import {Address} from "@shared/interfaces/Address/Address";
import {Tag} from "@shared/interfaces/Company/Tag";

export interface CompanyData {
  name: string;
  imagePreviewUrl: string;
  rating?: number;
  address: Address;
  tags: Tag[];
  description: string
  phone: string
  instagram: string
  facebook: string
  imageUrl: string
  businessHours: BusinessHours[];
  productSections: ProductSection[];
}
