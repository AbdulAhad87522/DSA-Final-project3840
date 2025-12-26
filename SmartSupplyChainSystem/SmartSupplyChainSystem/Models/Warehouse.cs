// Models/Warehouse.cs
using System.Collections.Generic;

namespace SmartSupplyChainSystem.Models
{
    public class Warehouse
    {
        public string WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int CurrentLoad { get; set; }
        public List<Product> Inventory { get; set; }
        public bool HasColdStorage { get; set; }

        public Warehouse(string id, string name, string location, int capacity, bool coldStorage = false)
        {
            WarehouseId = id;
            Name = name;
            Location = location;
            Capacity = capacity;
            CurrentLoad = 0;
            Inventory = new List<Product>();
            HasColdStorage = coldStorage;
        }

        public double LoadPercentage => (CurrentLoad / (double)Capacity) * 100;

        public bool CanAccommodate(int quantity)
        {
            return CurrentLoad + quantity <= Capacity;
        }

        public override string ToString()
        {
            return $"{Name} - {LoadPercentage:F1}% Full ({CurrentLoad}/{Capacity})";
        }
    }
}