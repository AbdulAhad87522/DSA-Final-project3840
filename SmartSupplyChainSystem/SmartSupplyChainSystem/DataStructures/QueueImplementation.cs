// DataStructures/QueueImplementation.cs
using System.Collections.Generic;

namespace SmartSupplyChainSystem.DataStructures
{
    public class OrderQueue<T>
    {
        private Queue<T> queue;

        public OrderQueue()
        {
            queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        public T Dequeue()
        {
            if (queue.Count > 0)
                return queue.Dequeue();
            return default(T);
        }

        public T Peek()
        {
            if (queue.Count > 0)
                return queue.Peek();
            return default(T);
        }

        public int Count => queue.Count;

        public List<T> GetAllOrders()
        {
            return new List<T>(queue);
        }
    }
}