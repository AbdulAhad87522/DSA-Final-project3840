// Models/Truck.cs - ENHANCED VERSION
using System;
using System.Collections.Generic;

namespace SmartSupplyChainSystem.Models
{
    public class Truck
    {
        public string TruckId { get; set; }
        public string DriverName { get; set; }
        public int Capacity { get; set; }
        public int CurrentLoad { get; set; }
        public string CurrentLocation { get; set; }
        public List<Order> AssignedOrders { get; set; }
        public List<string> Route { get; set; }

        // NEW: Delivery addresses for assigned orders
        public List<string> DeliveryAddresses { get; set; }

        public string Status { get; set; } // "Available", "On Route", "Delivering", "Returning"
        public DateTime LastUpdated { get; set; }

        public Truck(string truckId, string driverName, int capacity)
        {
            TruckId = truckId;
            DriverName = driverName;
            Capacity = capacity;
            CurrentLoad = 0;
            CurrentLocation = "Warehouse";
            AssignedOrders = new List<Order>();
            Route = new List<string>();
            DeliveryAddresses = new List<string>();
            Status = "Available";
            LastUpdated = DateTime.Now;
        }

        public double LoadPercentage => (CurrentLoad / (double)Capacity) * 100;

        public bool CanAccommodate(int weight)
        {
            return CurrentLoad + weight <= Capacity;
        }

        public override string ToString()
        {
            return $"{TruckId} - {DriverName} [{Status}] - {LoadPercentage:F1}% Full";
        }
    }
}