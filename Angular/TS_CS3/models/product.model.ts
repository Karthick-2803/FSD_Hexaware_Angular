import { Category } from "./category.enum";

export interface Product {
    id: number;
    name: string;
    price: number;
    stock: number;
    category: Category;
}
