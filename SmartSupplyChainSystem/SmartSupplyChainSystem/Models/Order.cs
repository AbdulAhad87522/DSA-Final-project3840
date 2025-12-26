// Models/Order.cs
using System;
using System.Collections.Generic;

namespace SmartSupplyChainSystem.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // "Pending", "Processing", "Dispatched", "Delivered"
        public int Priority { get; set; } // 1=Emergency, 2=High, 3=Normal
        public string AssignedWarehouse { get; set; }

        public Order(string orderId, string customerName, string deliveryAddress, int priority = 3)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Products = new List<Product>();
            DeliveryAddress = deliveryAddress;
            OrderDate = DateTime.Now;
            Status = "Pending";
            Priority = priority;
        }

        public override string ToString()
        {
            string priorityText = Priority == 1 ? "🚨 EMERGENCY" : Priority == 2 ? "⚡ HIGH" : "📦 NORMAL";
            return $"{OrderId} - {CustomerName} [{priorityText}] - {Status}";
        }
    }
}