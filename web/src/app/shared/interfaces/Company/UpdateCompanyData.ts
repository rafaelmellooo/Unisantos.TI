import {CreateCompanyData} from "@shared/interfaces/Company/CreateCompanyData";

export interface UpdateCompanyData extends CreateCompanyData {
  removedBusinessHours: string[];
  removedProductSections: string[];
  removedProducts: string[];
}
