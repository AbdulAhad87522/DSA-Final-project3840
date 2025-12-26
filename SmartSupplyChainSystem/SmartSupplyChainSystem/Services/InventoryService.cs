// Services/InventoryService.cs - ENHANCED WITH PRODUCTS
using System;
using System.Collections.Generic;
using SmartSupplyChainSystem.DataStructures;
using SmartSupplyChainSystem.Models;

namespace SmartSupplyChainSystem.Services
{
    public class InventoryService
    {
        private InventoryTree tree;
        private Dictionary<string, Product> products;

        public InventoryService()
        {
            tree = new InventoryTree();
            products = new Dictionary<string, Product>();
            InitializeDefaultCategories();
            InitializeDefaultProducts();
        }

        private void InitializeDefaultCategories()
        {
            // Level 1 Categories
            var electronics = tree.AddCategory("Electronics");
            var food = tree.AddCategory("Food");
            var clothing = tree.AddCategory("Clothing");
            var furniture = tree.AddCategory("Furniture");

            // Level 2 Sub-categories
            tree.AddCategory("Laptops", electronics);
            tree.AddCategory("Mobile Phones", electronics);
            tree.AddCategory("Tablets", electronics);
            tree.AddCategory("Frozen Food", food);
            tree.AddCategory("Fresh Produce", food);
            tree.AddCategory("Dairy Products", food);
            tree.AddCategory("Men's Wear", clothing);
            tree.AddCategory("Women's Wear", clothing);
            tree.AddCategory("Office Furniture", furniture);
            tree.AddCategory("Home Furniture", furniture);
        }

        private void InitializeDefaultProducts()
        {
            // LAPTOPS
            AddProduct(new Product("LAP-001", "Dell Inspiron 15", "Laptops", 25, "Section-A", false));
            AddProduct(new Product("LAP-002", "HP Pavilion", "Laptops", 30, "Section-A", false));
            AddProduct(new Product("LAP-003", "Lenovo ThinkPad", "Laptops", 20, "Section-A", false));
            AddProduct(new Product("LAP-004", "MacBook Air M2", "Laptops", 15, "Section-A", false));
            AddProduct(new Product("LAP-005", "ASUS ROG Gaming", "Laptops", 12, "Section-A", false));
            AddProduct(new Product("LAP-006", "Acer Aspire", "Laptops", 28, "Section-A", false));

            // MOBILE PHONES
            AddProduct(new Product("MOB-001", "iPhone 15 Pro", "Mobile Phones", 40, "Section-A", false));
            AddProduct(new Product("MOB-002", "Samsung Galaxy S24", "Mobile Phones", 45, "Section-A", false));
            AddProduct(new Product("MOB-003", "Google Pixel 8", "Mobile Phones", 30, "Section-A", false));
            AddProduct(new Product("MOB-004", "OnePlus 12", "Mobile Phones", 35, "Section-A", false));
            AddProduct(new Product("MOB-005", "Xiaomi 14 Pro", "Mobile Phones", 38, "Section-A", false));

            // TABLETS
            AddProduct(new Product("TAB-001", "iPad Pro 12.9", "Tablets", 22, "Section-B", false));
            AddProduct(new Product("TAB-002", "Samsung Galaxy Tab S9", "Tablets", 25, "Section-B", false));
            AddProduct(new Product("TAB-003", "Microsoft Surface Pro", "Tablets", 18, "Section-B", false));

            // FROZEN FOOD (Cold Storage Required)
            AddProduct(new Product("FFD-001", "Frozen Pizza Pack", "Frozen Food", 100, "Storage-1", true));
            AddProduct(new Product("FFD-002", "Ice Cream Variety", "Frozen Food", 150, "Storage-1", true));
            AddProduct(new Product("FFD-003", "Frozen Vegetables", "Frozen Food", 200, "Storage-1", true));
            AddProduct(new Product("FFD-004", "Frozen Meat Pack", "Frozen Food", 80, "Storage-1", true));
            AddProduct(new Product("FFD-005", "Frozen Fish", "Frozen Food", 90, "Storage-1", true));

            // FRESH PRODUCE (Cold Storage Required)
            AddProduct(new Product("PRD-001", "Fresh Fruits Pack", "Fresh Produce", 120, "Storage-2", true));
            AddProduct(new Product("PRD-002", "Organic Vegetables", "Fresh Produce", 150, "Storage-2", true));
            AddProduct(new Product("PRD-003", "Salad Mix", "Fresh Produce", 100, "Storage-2", true));

            // DAIRY PRODUCTS (Cold Storage Required)
            AddProduct(new Product("DAI-001", "Milk Bottles (12 Pack)", "Dairy Products", 200, "Storage-2", true));
            AddProduct(new Product("DAI-002", "Cheese Variety", "Dairy Products", 80, "Storage-2", true));
            AddProduct(new Product("DAI-003", "Yogurt Multipack", "Dairy Products", 150, "Storage-2", true));

            // MEN'S WEAR
            AddProduct(new Product("MEN-001", "Formal Shirts", "Men's Wear", 60, "Section-C", false));
            AddProduct(new Product("MEN-002", "Casual T-Shirts", "Men's Wear", 100, "Section-C", false));
            AddProduct(new Product("MEN-003", "Denim Jeans", "Men's Wear", 75, "Section-C", false));
            AddProduct(new Product("MEN-004", "Formal Pants", "Men's Wear", 50, "Section-C", false));

            // WOMEN'S WEAR
            AddProduct(new Product("WOM-001", "Summer Dresses", "Women's Wear", 70, "Section-C", false));
            AddProduct(new Product("WOM-002", "Formal Wear", "Women's Wear", 55, "Section-C", false));
            AddProduct(new Product("WOM-003", "Casual Tops", "Women's Wear", 90, "Section-C", false));

            // OFFICE FURNITURE
            AddProduct(new Product("OFF-001", "Executive Desk", "Office Furniture", 15, "Loading-Dock", false));
            AddProduct(new Product("OFF-002", "Office Chairs", "Office Furniture", 40, "Loading-Dock", false));
            AddProduct(new Product("OFF-003", "Filing Cabinets", "Office Furniture", 25, "Loading-Dock", false));

            // HOME FURNITURE
            AddProduct(new Product("HOM-001", "Sofa Set 3-Seater", "Home Furniture", 12, "Loading-Dock", false));
            AddProduct(new Product("HOM-002", "Dining Table Set", "Home Furniture", 10, "Loading-Dock", false));
            AddProduct(new Product("HOM-003", "Bed Frame Queen Size", "Home Furniture", 18, "Loading-Dock", false));
        }

        public InventoryTree GetTree()
        {
            return tree;
        }

        public void AddProduct(Product product)
        {
            products[product.ProductId] = product;
        }

        public void RemoveProduct(string productId)
        {
            if (products.ContainsKey(productId))
                products.Remove(productId);
        }

        public Product GetProduct(string productId)
        {
            return products.ContainsKey(productId) ? products[productId] : null;
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(products.Values);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            var result = new List<Product>();
            foreach (var product in products.Values)
            {
                if (product.Category == category)
                    result.Add(product);
            }
            return result;
        }

        public List<Product> GetProductsByWarehouse(string warehouse)
        {
            var result = new List<Product>();
            foreach (var product in products.Values)
            {
                if (product.Warehouse == warehouse)
                    result.Add(product);
            }
            return result;
        }

        public List<string> GetAllCategories()
        {
            var categories = new List<string>();
            CollectCategories(tree.Root, categories);
            return categories;
        }

        private void CollectCategories(TreeNode<string> node, List<string> categories)
        {
            if (node.Data != "Warehouse")
                categories.Add(node.Data);
            foreach (var child in node.Children)
                CollectCategories(child, categories);
        }
    }
}