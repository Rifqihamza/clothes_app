using clothes_app.Models;
using clothes_app.Service;

namespace clothes_app
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("         CLOTHES MANAGEMENT APP       ");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Filter by Category");
                Console.WriteLine("0. Exit");
                Console.WriteLine("======================================");
                Console.Write("Choose menu (0–6): ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddProduct(service);
                        break;
                    case "2":
                        ShowAll(service, pause: true);
                        break;
                    case "3":
                        UpdateProduct(service);
                        break;
                    case "4":
                        DeleteProduct(service);
                        break;
                    case "5":
                        SearchProduct(service);
                        break;
                    case "6":
                        FilterCategory(service);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Unknown menu option!");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        // ----------------------------------------------
        // SHOW ALL (option to pause or not)
        // ----------------------------------------------
        static void ShowAll(ProductService service, bool pause = false)
        {
            var list = service.GetAll();

            Console.WriteLine("======================================");
            Console.WriteLine("                PRODUCTS              ");
            Console.WriteLine("======================================");

            if (list.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                Console.WriteLine("ID | Name                | Category      | Price    | Stock");
                Console.WriteLine(
                    "---------------------------------------------------------------"
                );

                foreach (var p in list)
                {
                    Console.WriteLine(
                        $"{p.Id, -3}| {p.NameProduct, -19}| {p.CategoryProduct, -13}| Rp {p.PriceProduct, -7}| {p.StockProduct}"
                    );
                }
            }

            if (pause)
                Pause();
        }

        // ----------------------------------------------
        // ADD PRODUCT
        // ----------------------------------------------
        static void AddProduct(ProductService service)
        {
            Console.WriteLine("=== Add New Product ===");

            Console.Write("Product Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Category (T-Shirt/Jacket/Pants): ");
            string category = Console.ReadLine() ?? "";

            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine() ?? "0");

            service.AddProduct(name, category, price, stock);

            Console.WriteLine("\nProduct added successfully!");
            Pause();
        }

        // ----------------------------------------------
        // UPDATE PRODUCT (now much easier)
        // ----------------------------------------------
        static void UpdateProduct(ProductService service)
        {
            Console.WriteLine("=== Update Product ===");
            ShowAll(service); // No pause

            Console.Write("\nEnter Product ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var existing = service.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Product not found!");
                Pause();
                return;
            }

            Console.WriteLine("\nPress ENTER to keep current value.");
            Console.WriteLine("-----------------------------------");

            Console.Write($"New Name ({existing.NameProduct}): ");
            string name = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(name))
                name = existing.NameProduct;

            Console.Write($"New Category ({existing.CategoryProduct}): ");
            string category = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(category))
                category = existing.CategoryProduct;

            Console.Write($"New Price ({existing.PriceProduct}): ");
            string priceInput = Console.ReadLine()!;
            int price = string.IsNullOrWhiteSpace(priceInput)
                ? existing.PriceProduct
                : int.Parse(priceInput);

            Console.Write($"New Stock ({existing.StockProduct}): ");
            string stockInput = Console.ReadLine()!;
            int stock = string.IsNullOrWhiteSpace(stockInput)
                ? existing.StockProduct
                : int.Parse(stockInput);

            service.UpdateProduct(id, name, category, price, stock);

            Console.WriteLine("\nProduct updated successfully!");
            Pause();
        }

        // ----------------------------------------------
        // DELETE PRODUCT
        // ----------------------------------------------
        static void DeleteProduct(ProductService service)
        {
            Console.WriteLine("=== Delete Product ===");
            ShowAll(service); // No pause

            Console.Write("\nEnter Product ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            if (service.DeleteProduct(id))
            {
                Console.WriteLine("Product deleted!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Pause();
        }

        // ----------------------------------------------
        // SEARCH
        // ----------------------------------------------
        static void SearchProduct(ProductService service)
        {
            Console.WriteLine("=== Search Product ===");
            ShowAll(service); // No pause

            Console.Write("\nEnter keyword: ");
            string keyword = Console.ReadLine() ?? "";

            var result = service.SearchAll(keyword);

            Console.WriteLine("\n=== Search Results ===");

            if (result.Count == 0)
            {
                Console.WriteLine("No product matched.");
            }
            else
            {
                foreach (var p in result)
                {
                    Console.WriteLine(
                        $"[{p.Id}] {p.NameProduct} | {p.CategoryProduct} | Rp {p.PriceProduct}"
                    );
                }
            }

            Pause();
        }

        // ----------------------------------------------
        // FILTER CATEGORY
        // ----------------------------------------------
        static void FilterCategory(ProductService service)
        {
            Console.WriteLine("=== Filter by Category ===");
            ShowAll(service); // No pause

            Console.Write("\nEnter category: ");
            string category = Console.ReadLine() ?? "";

            var result = service.FilterByCat(category);

            Console.WriteLine("\n=== Filter Results ===");

            if (result.Count == 0)
            {
                Console.WriteLine("No products found in this category.");
            }
            else
            {
                foreach (var p in result)
                {
                    Console.WriteLine($"[{p.Id}] {p.NameProduct} | Rp {p.PriceProduct}");
                }
            }

            Pause();
        }
    }
}
