import { Product } from "../models/product.model";
import { Category } from "../models/category.enum";
import { CartItem } from "../models/cart-item.model";

export class ECommerceService {
    private products: Product[] = [
        { id: 1, name: "Laptop", price: 45000, stock: 3, category: Category.Electronics },
        { id: 2, name: "Jeans", price: 1500, stock: 10, category: Category.Clothing },
        { id: 3, name: "Rice Bag", price: 700, stock: 5, category: Category.Grocery }
    ];

    private cart: CartItem[] = [];

    viewProducts(): void {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
        console.log();
    }

    addToCart(productId: number, quantity: number): void {
        const product = this.products.find(p => p.id === productId);
        if (!product) {
            console.log("Product not found.");
            return;
        }

        if (product.stock < quantity) {
            console.log(`Cannot add ${quantity} x ${product.name}. Only ${product.stock} left.`);
            return;
        }

        const cartItem = this.cart.find(ci => ci.product.id === productId);
        if (cartItem) {
            cartItem.quantity += quantity;
        } else {
            this.cart.push({ product, quantity });
        }

        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.\n`);
    }

    removeFromCart(productId: number): void {
        const index = this.cart.findIndex(ci => ci.product.id === productId);
        if (index !== -1) {
            const item = this.cart[index];
            item.product.stock += item.quantity; // return stock
            this.cart.splice(index, 1);
            console.log(`${item.product.name} removed from cart.\n`);
        } else {
            console.log("Product not found in cart.\n");
        }
    }

    showCart(): void {
        if (this.cart.length === 0) {
            console.log("Cart is empty.");
            return;
        }

        console.log("Cart Summary:");
        let total = 0;

        for (const item of this.cart) {
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
            total += item.product.price * item.quantity;
        }

        console.log(`Total: ₹${total}`);

        let discount = 0;
        if (total >= 10000) {
            discount = total * 0.15;
        } else if (total >= 5000) {
            discount = total * 0.10;
        }

        if (discount > 0) {
            console.log(`Discounted Total: ₹${total - discount}`);
        }

        console.log();
    }

    getProducts(): Product[] {
        return this.products;
    }
}
