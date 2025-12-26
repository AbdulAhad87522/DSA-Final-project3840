// Services/OrderManagerService.cs - NEW SHARED SERVICE
using System;
using System.Collections.Generic;
using SmartSupplyChainSystem.Models;

namespace SmartSupplyChainSystem.Services
{
    // Singleton pattern to share orders between forms
    public class OrderManagerService
    {
        private static OrderManagerService instance;
        private List<Order> allOrders;

        // Events to notify forms when orders change
        public event EventHandler OrdersChanged;

        private OrderManagerService()
        {
            allOrders = new List<Order>();
        }

        public static OrderManagerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManagerService();
                }
                return instance;
            }
        }

        public void AddOrder(Order order)
        {
            allOrders.Add(order);
            OnOrdersChanged();
        }

        public void UpdateOrderStatus(string orderId, string newStatus)
        {
            var order = allOrders.Find(o => o.OrderId == orderId);
            if (order != null)
            {
                order.Status = newStatus;
                OnOrdersChanged();
            }
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>(allOrders);
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            return allOrders.FindAll(o => o.Status == status);
        }

        public Order GetOrder(string orderId)
        {
            return allOrders.Find(o => o.OrderId == orderId);
        }

        private void OnOrdersChanged()
        {
            OrdersChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ClearAllOrders()
        {
            allOrders.Clear();
            OnOrdersChanged();
        }
    }
}