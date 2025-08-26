"use client";
import { useState } from "react";
import { addProduct } from "@/lib/api";

export default function AddPage() {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    await addProduct({ name, price: parseFloat(price) });
    setName("");
    setPrice("");
    alert("Ürün eklendi!");
  }

  return (
    <main className="p-6">
      <h1 className="text-xl font-bold mb-4">Ürün Ekle</h1>
      <form onSubmit={handleSubmit} className="space-y-3">
        <input
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Ürün adı"
          className="border p-2 rounded w-full"
        />
        <input
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          placeholder="Fiyat"
          type="number"
          className="border p-2 rounded w-full"
        />
        <button className="bg-blue-500 text-white px-4 py-2 rounded">
          Kaydet
        </button>
      </form>
    </main>
  );
}
