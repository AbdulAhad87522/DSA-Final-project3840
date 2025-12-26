// Services/RouteOptimizationService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using SmartSupplyChainSystem.DataStructures;

namespace SmartSupplyChainSystem.Services
{
    public class RouteOptimizationService
    {
        private PathfindingService pathfinder = new PathfindingService();

        // Nearest Neighbor TSP Approximation
        public (List<string> route, int totalDistance) OptimizeRoute(Graph graph, string start, List<string> destinations)
        {
            var route = new List<string> { start };
            var unvisited = new List<string>(destinations);
            var totalDistance = 0;
            var current = start;

            while (unvisited.Count > 0)
            {
                string nearest = null;
                int minDistance = int.MaxValue;

                foreach (var dest in unvisited)
                {
                    var result = pathfinder.Dijkstra(graph, current, dest);
                    if (result.distance < minDistance)
                    {
                        minDistance = result.distance;
                        nearest = dest;
                    }
                }

                if (nearest != null)
                {
                    route.Add(nearest);
                    totalDistance += minDistance;
                    unvisited.Remove(nearest);
                    current = nearest;
                }
                else
                {
                    break;
                }
            }

            return (route, totalDistance);
        }

        // Calculate total distance for a given route
        public int CalculateRouteDistance(Graph graph, List<string> route)
        {
            int total = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                var result = pathfinder.Dijkstra(graph, route[i], route[i + 1]);
                total += result.distance;
            }
            return total;
        }
    }
}