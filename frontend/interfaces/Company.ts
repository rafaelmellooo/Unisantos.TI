import { Address } from "./Address";

export interface Company {
    id: string;
    name: string;
    latitude: number;
    longitude: number;
    imagePreviewUrl: string;
    imageUrl: string;
    rating: number;
    address: Address;
    tags: string[];
    description: string;
    phone: string;
    instagram: string;
    facebook: string;
    rates: [
        {
          id: string,
          user: string,
          comment: string,
          rate: number
        }
    ]
    productsSections: ProductsSection[];
}

export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
}

export interface ProductsSection{
    id: string;
    title: string;
    products: Product[];
}