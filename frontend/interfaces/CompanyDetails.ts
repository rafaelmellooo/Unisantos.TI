import {Address} from "./Address";
import {ProductsSection} from "./ProductsSection";
import {Rate} from "./Rate";

export interface CompanyDetails {
    name: string;
    latitude: number;
    longitude: number;
    imageUrl: string;
    rating: number;
    address: Address;
    tags: string[];
    description: string;
    phone: string;
    instagram: string;
    facebook: string;
    rates: Rate[];
    productsSections: ProductsSection[];
}