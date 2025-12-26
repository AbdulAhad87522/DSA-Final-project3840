// Services/TruckServiceManager.cs - COMPLETE SINGLETON SERVICE
using System;
using System.Collections.Generic;
using System.Linq;
using SmartSupplyChainSystem.Models;

namespace SmartSupplyChainSystem.Services
{
    /// <summary>
    /// Singleton service to manage trucks across all forms in the application.
    /// Provides centralized truck management with event notifications for real-time updates.
    /// </summary>
    public class TruckServiceManager
    {
        // Singleton instance
        private static TruckServiceManager instance;

        // All trucks in the system
        private List<Truck> trucks;

        // Event to notify forms when any truck data changes
        public event EventHandler TrucksChanged;

        /// <summary>
        /// Private constructor - Singleton pattern
        /// </summary>
        private TruckServiceManager()
        {
            trucks = new List<Truck>();
            InitializeTrucks();
        }

        /// <summary>
        /// Get the singleton instance of TruckServiceManager
        /// </summary>
        public static TruckServiceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TruckServiceManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initialize default trucks
        /// </summary>
        private void InitializeTrucks()
        {
            trucks.Add(new Truck("TRK-001", "Ahmed Ali", 1000));
            trucks.Add(new Truck("TRK-002", "Hassan Khan", 1500));
            trucks.Add(new Truck("TRK-003", "Fatima Noor", 2000));
        }

        /// <summary>
        /// Get all trucks in the system
        /// </summary>
        /// <returns>List of all trucks</returns>
        public List<Truck> GetAllTrucks()
        {
            return new List<Truck>(trucks);
        }

        /// <summary>
        /// Get a specific truck by ID
        /// </summary>
        /// <param name="truckId">Truck ID to search for</param>
        /// <returns>Truck object or null if not found</returns>
        public Truck GetTruck(string truckId)
        {
            return trucks.FirstOrDefault(t => t.TruckId == truckId);
        }

        /// <summary>
        /// Get available trucks (not currently on route)
        /// </summary>
        /// <returns>List of available trucks</returns>
        public List<Truck> GetAvailableTrucks()
        {
            return trucks.Where(t => t.Status == "Available").ToList();
        }

        /// <summary>
        /// Get trucks that are currently on route
        /// </summary>
        /// <returns>List of trucks on route</returns>
        public List<Truck> GetTrucksOnRoute()
        {
            return trucks.Where(t => t.Status == "On Route").ToList();
        }

        /// <summary>
        /// Update an existing truck's information
        /// </summary>
        /// <param name="truck">Updated truck object</param>
        public void UpdateTruck(Truck truck)
        {
            var existingTruck = GetTruck(truck.TruckId);
            if (existingTruck != null)
            {
                // Update the existing truck in the list
                int index = trucks.IndexOf(existingTruck);
                trucks[index] = truck;
                truck.LastUpdated = DateTime.Now;

                // Notify all subscribed forms
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Assign orders to a truck and extract delivery addresses
        /// </summary>
        /// <param name="truckId">ID of the truck to assign orders to</param>
        /// <param name="orders">List of orders to assign</param>
        public void AssignOrdersToTruck(string truckId, List<Order> orders)
        {
            var truck = GetTruck(truckId);
            if (truck != null)
            {
                // Clear existing assignments
                truck.AssignedOrders.Clear();
                truck.DeliveryAddresses.Clear();
                truck.Route.Clear();

                // Add new orders
                foreach (var order in orders)
                {
                    truck.AssignedOrders.Add(order);

                    // Add delivery address if not already present
                    if (!truck.DeliveryAddresses.Contains(order.DeliveryAddress))
                    {
                        truck.DeliveryAddresses.Add(order.DeliveryAddress);
                    }
                }

                // Update truck status
                truck.Status = "On Route";
                truck.CurrentLocation = "Warehouse";
                truck.LastUpdated = DateTime.Now;

                // Notify all subscribed forms
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Add a new delivery address to a truck
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="address">Delivery address to add</param>
        public void AddDeliveryAddress(string truckId, string address)
        {
            var truck = GetTruck(truckId);
            if (truck != null && !truck.DeliveryAddresses.Contains(address))
            {
                truck.DeliveryAddresses.Add(address);
                truck.LastUpdated = DateTime.Now;
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Remove a delivery address from a truck
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="address">Delivery address to remove</param>
        public void RemoveDeliveryAddress(string truckId, string address)
        {
            var truck = GetTruck(truckId);
            if (truck != null && truck.DeliveryAddresses.Contains(address))
            {
                truck.DeliveryAddresses.Remove(address);
                truck.LastUpdated = DateTime.Now;
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Clear all assignments from a truck (make it available)
        /// </summary>
        /// <param name="truckId">Truck ID to clear</param>
        public void ClearTruckAssignments(string truckId)
        {
            var truck = GetTruck(truckId);
            if (truck != null)
            {
                truck.AssignedOrders.Clear();
                truck.DeliveryAddresses.Clear();
                truck.Route.Clear();
                truck.Status = "Available";
                truck.CurrentLoad = 0;
                truck.CurrentLocation = "Warehouse";
                truck.LastUpdated = DateTime.Now;

                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Clear all assignments from all trucks
        /// </summary>
        public void ClearAllTruckAssignments()
        {
            foreach (var truck in trucks)
            {
                truck.AssignedOrders.Clear();
                truck.DeliveryAddresses.Clear();
                truck.Route.Clear();
                truck.Status = "Available";
                truck.CurrentLoad = 0;
                truck.CurrentLocation = "Warehouse";
                truck.LastUpdated = DateTime.Now;
            }

            OnTrucksChanged();
        }

        /// <summary>
        /// Update truck status
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="newStatus">New status (Available, On Route, Delivering, Returning)</param>
        public void UpdateTruckStatus(string truckId, string newStatus)
        {
            var truck = GetTruck(truckId);
            if (truck != null)
            {
                truck.Status = newStatus;
                truck.LastUpdated = DateTime.Now;
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Update truck location
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="newLocation">New location</param>
        public void UpdateTruckLocation(string truckId, string newLocation)
        {
            var truck = GetTruck(truckId);
            if (truck != null)
            {
                truck.CurrentLocation = newLocation;
                truck.LastUpdated = DateTime.Now;
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Update truck route
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="route">New route list</param>
        public void UpdateTruckRoute(string truckId, List<string> route)
        {
            var truck = GetTruck(truckId);
            if (truck != null)
            {
                truck.Route = new List<string>(route);
                truck.LastUpdated = DateTime.Now;
                OnTrucksChanged();
            }
        }

        /// <summary>
        /// Get total number of deliveries across all trucks
        /// </summary>
        /// <returns>Total delivery count</returns>
        public int GetTotalDeliveryCount()
        {
            return trucks.Sum(t => t.DeliveryAddresses.Count);
        }

        /// <summary>
        /// Get total number of assigned orders across all trucks
        /// </summary>
        /// <returns>Total assigned orders</returns>
        public int GetTotalAssignedOrders()
        {
            return trucks.Sum(t => t.AssignedOrders.Count);
        }

        /// <summary>
        /// Check if a truck can accommodate more orders
        /// </summary>
        /// <param name="truckId">Truck ID</param>
        /// <param name="additionalWeight">Additional weight to check</param>
        /// <returns>True if truck can accommodate, false otherwise</returns>
        public bool CanAccommodateOrder(string truckId, int additionalWeight)
        {
            var truck = GetTruck(truckId);
            return truck != null && truck.CanAccommodate(additionalWeight);
        }

        /// <summary>
        /// Get summary of all trucks
        /// </summary>
        /// <returns>Dictionary with truck statistics</returns>
        public Dictionary<string, int> GetTruckSummary()
        {
            return new Dictionary<string, int>
            {
                { "Total Trucks", trucks.Count },
                { "Available", trucks.Count(t => t.Status == "Available") },
                { "On Route", trucks.Count(t => t.Status == "On Route") },
                { "Delivering", trucks.Count(t => t.Status == "Delivering") },
                { "Returning", trucks.Count(t => t.Status == "Returning") },
                { "Total Deliveries", GetTotalDeliveryCount() },
                { "Total Orders", GetTotalAssignedOrders() }
            };
        }

        /// <summary>
        /// Raise the TrucksChanged event to notify all subscribed forms
        /// </summary>
        private void OnTrucksChanged()
        {
            TrucksChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Reset the service (useful for testing or starting fresh)
        /// </summary>
        public void Reset()
        {
            trucks.Clear();
            InitializeTrucks();
            OnTrucksChanged();
        }
    }
}