import { fetchProducts } from "@/lib/api";

export default async function HomePage() {
  const products = await fetchProducts();

  return (
    <main className="p-6">
      <h1 className="text-xl font-bold">Ürünler</h1>
      <ul className="mt-4 space-y-2">
        {products.map((p: any) => (
          <li key={p.id} className="border p-2 rounded">
            {p.name} - {p.price} ₺
          </li>
        ))}
      </ul>
    </main>
  );
}
