export const API_URL = process.env.NEXT_PUBLIC_API_URL;

export async function fetchProducts() {
  const res = await fetch(`${API_URL}/product`);
  return res.json();
}

export async function addProduct(product: { name: string; price: number }) {
  const res = await fetch(`${API_URL}/product`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(product),
  });
  return res.json();
}
