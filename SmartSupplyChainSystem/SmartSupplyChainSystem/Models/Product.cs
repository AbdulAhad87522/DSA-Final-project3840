// Models/Product.cs
using System;

namespace SmartSupplyChainSystem.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Warehouse { get; set; }
        public bool IsColdStorage { get; set; }
        public DateTime LastUpdated { get; set; }

        public Product(string id, string name, string category, int quantity, string warehouse, bool coldStorage = false)
        {
            ProductId = id;
            Name = name;
            Category = category;
            Quantity = quantity;
            Warehouse = warehouse;
            IsColdStorage = coldStorage;
            LastUpdated = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ProductId} - {Name} ({Quantity} units)";
        }
    }

    public class ProductAction
    {
        public string ActionType { get; set; } // "ADD", "UPDATE", "DELETE"
        public Product Product { get; set; }
        public Product PreviousState { get; set; }
        public DateTime Timestamp { get; set; }

        public ProductAction(string actionType, Product product, Product previousState = null)
        {
            ActionType = actionType;
            Product = product;
            PreviousState = previousState;
            Timestamp = DateTime.Now;
        }
    }
}