using System.Text.Json;
using clothes_app.Models;

namespace clothes_app.Service
{
    class ProductService
    {
        private string path = "Data/product_data.json";
        private List<Product> ProductList = new List<Product>();
        private int addId = 1;

        public ProductService()
        {
            LoadFromFile();
        }

        // GET BY ID
        public Product? GetById(int id)
        {
            return ProductList.FirstOrDefault(p => p.Id == id);
        }

        private void LoadFromFile()
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            string json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
            {
                ProductList = new List<Product>();
                return;
            }

            ProductList = JsonSerializer.Deserialize<List<Product>>(json)!;

            if (ProductList.Count > 0)
            {
                // Supaya ID selanjutnya tidak duplikat
                addId = ProductList.Max(p => p.Id) + 1;
            }
        }

        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(
                ProductList,
                new JsonSerializerOptions { WriteIndented = true }
            );
            File.WriteAllText(path, json);
        }

        // CREATE
        public void AddProduct(string name, string category, int price, int stock)
        {
            Product p = new Product
            {
                Id = addId++,
                NameProduct = name,
                CategoryProduct = category,
                PriceProduct = price,
                StockProduct = stock,
            };

            ProductList.Add(p);
            SaveToFile();
        }

        // READ
        public List<Product> GetAll()
        {
            return ProductList;
        }

        // UPDATE
        public bool UpdateProduct(int id, string name, string category, int price, int stock)
        {
            var product = ProductList.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return false;

            product.NameProduct = name;
            product.CategoryProduct = category;
            product.PriceProduct = price;
            product.StockProduct = stock;

            SaveToFile();
            return true;
        }

        // DELETE
        public bool DeleteProduct(int id)
        {
            var product = ProductList.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return false;

            ProductList.Remove(product);
            SaveToFile();

            return true;
        }

        // SEARCH
        public List<Product> SearchAll(string keyword)
        {
            keyword = keyword.ToLower();

            return ProductList.Where(p => p.NameProduct.ToLower().Contains(keyword)).ToList();
        }

        // FILTER
        public List<Product> FilterByCat(string category)
        {
            return ProductList
                .Where(p => p.CategoryProduct.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
