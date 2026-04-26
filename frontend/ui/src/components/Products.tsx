import { useEffect, useState } from "react";

type Products = {
  id: number;
  name: string;
  category: string;
  price: number;
  quantity: number;
};

const fetchProducts = async () => {
  const result = await fetch(
    "http://localhost:8080/api/controller/GetProducts",
  );
  const data = (await result.json()) as Promise<Products[]>;
  return data;
};

const Products = () => {
  const [products, setProducts] = useState<Products[]>([]);

  useEffect(() => {
    const loadData = async () => {
      const data = await fetchProducts();
      setProducts(data);
    };
    loadData();
  }, []);

  return (
    <div>
      <h3>Products</h3>
      <ul>
        {products?.map((p) => (
          <li key={p.id}>
            {p.name} - {p.category} - {p.price} - {p.quantity}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Products;
