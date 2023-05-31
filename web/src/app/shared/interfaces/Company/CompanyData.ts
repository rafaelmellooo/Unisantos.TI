import {Company} from "@shared/interfaces/Company/Company";
import {ProductSection} from "@shared/interfaces/Company/ProductSection";
import {BusinessHours} from "@shared/interfaces/Company/BusinessHours";

export interface CompanyData extends Company {
  description: string
  phone: string
  instagram: string
  facebook: string
  imageUrl: string
  businessHours: BusinessHours[];
  productSections: ProductSection[];
}
