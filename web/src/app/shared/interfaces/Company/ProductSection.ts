import {Product} from "@shared/interfaces/Company/Product";

export interface ProductSection {
  id: string;
  title: string;
  products: Product[];
}
