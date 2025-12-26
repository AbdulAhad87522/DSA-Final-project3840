// Services/TemperatureMonitoringService.cs
using System;
using System.Collections.Generic;

namespace SmartSupplyChainSystem.Services
{
    public class TemperatureReading
    {
        public string SensorId { get; set; }
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } // "Normal", "Warning", "Critical"

        public TemperatureReading(string sensorId, double temperature)
        {
            SensorId = sensorId;
            Temperature = temperature;
            Timestamp = DateTime.Now;

            // Determine status based on temperature
            if (temperature > 3 || temperature < -8)
                Status = "Critical";
            else if (temperature > 0 || temperature < -5)
                Status = "Warning";
            else
                Status = "Normal";
        }

        public override string ToString()
        {
            return $"{SensorId}: {Temperature}°C [{Status}] - {Timestamp:HH:mm:ss}";
        }
    }

    // NEW: Alert class for Priority Queue
    public class TemperatureAlert
    {
        public string SensorId { get; set; }
        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }
        public int Priority { get; set; } // 1=Critical, 2=Warning
        public string Status { get; set; }

        public TemperatureAlert(string sensorId, double temperature, string status)
        {
            SensorId = sensorId;
            Temperature = temperature;
            Timestamp = DateTime.Now;
            Status = status;

            // Set priority based on status
            Priority = status == "Critical" ? 1 : 2;
        }

        public override string ToString()
        {
            string icon = Priority == 1 ? "🚨 CRITICAL" : "⚠️ WARNING";
            return $"{icon}: {SensorId} at {Temperature}°C - {Timestamp:HH:mm:ss}";
        }
    }

    public class TemperatureMonitoringService
    {
        // FIXED: Circular Queue with fixed size
        private Queue<TemperatureReading> readingsQueue;
        private const int MAX_QUEUE_SIZE = 100;

        // NEW: Priority Queue for alerts
        private DataStructures.PriorityQueue<TemperatureAlert> alertQueue;

        private List<TemperatureReading> history;
        private Random random;

        public TemperatureMonitoringService()
        {
            readingsQueue = new Queue<TemperatureReading>();
            alertQueue = new DataStructures.PriorityQueue<TemperatureAlert>();
            history = new List<TemperatureReading>();
            random = new Random();
        }

        public void SimulateSensorReading(string sensorId)
        {
            // Simulate temperature between -10°C to 8°C
            double temperature = -10 + (random.NextDouble() * 18);
            temperature = Math.Round(temperature, 1);

            var reading = new TemperatureReading(sensorId, temperature);

            // FIXED: Circular Queue - remove oldest if full
            if (readingsQueue.Count >= MAX_QUEUE_SIZE)
            {
                readingsQueue.Dequeue(); // Remove oldest
            }
            readingsQueue.Enqueue(reading);

            // Add to history (unlimited)
            history.Add(reading);

            // NEW: Add to Alert Priority Queue if not normal
            if (reading.Status == "Critical" || reading.Status == "Warning")
            {
                var alert = new TemperatureAlert(
                    reading.SensorId,
                    reading.Temperature,
                    reading.Status
                );
                alertQueue.Enqueue(alert, alert.Priority);
            }
        }

        public TemperatureReading ProcessNextReading()
        {
            if (readingsQueue.Count > 0)
                return readingsQueue.Dequeue();
            return null;
        }

        // NEW: Process next alert (highest priority first)
        public TemperatureAlert ProcessNextAlert()
        {
            if (alertQueue.Count > 0)
                return alertQueue.Dequeue();
            return null;
        }

        // NEW: Get all pending alerts
        public List<TemperatureAlert> GetAllAlerts()
        {
            var alerts = new List<TemperatureAlert>();
            foreach (var item in alertQueue.GetAllOrders())
            {
                alerts.Add(item.item);
            }
            return alerts;
        }

        public int PendingReadings => readingsQueue.Count;
        public int PendingAlerts => alertQueue.Count;

        public List<TemperatureReading> GetHistory()
        {
            // Return last 50 readings for visualization
            int startIndex = Math.Max(0, history.Count - 50);
            return history.GetRange(startIndex, history.Count - startIndex);
        }

        public List<TemperatureReading> GetCriticalAlerts()
        {
            var alerts = new List<TemperatureReading>();
            foreach (var reading in history)
            {
                if (reading.Status == "Critical")
                    alerts.Add(reading);
            }
            return alerts;
        }
    }
}