// DataStructures/PriorityQueue.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartSupplyChainSystem.DataStructures
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> items;

        public PriorityQueue()
        {
            items = new List<(T, int)>();
        }

        public void Enqueue(T item, int priority)
        {
            items.Add((item, priority));
            items = items.OrderByDescending(x => x.priority).ToList();
        }

        public T Dequeue()
        {
            if (items.Count > 0)
            {
                var item = items[0];
                items.RemoveAt(0);
                return item.item;
            }
            return default(T);
        }

        public T Peek()
        {
            if (items.Count > 0)
                return items[0].item;
            return default(T);
        }

        public int Count => items.Count;

        public List<(T item, int priority)> GetAllOrders()
        {
            return new List<(T, int)>(items);
        }
    }
}