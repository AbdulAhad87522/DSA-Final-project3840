// Services/PathfindingService.cs
using System.Collections.Generic;
using System.Linq;
using SmartSupplyChainSystem.DataStructures;

namespace SmartSupplyChainSystem.Services
{
    public class PathfindingService
    {
        // BFS - Shortest path in unweighted graph
        public List<string> BFS(Graph graph, string start, string end)
        {
            if (!graph.Nodes.ContainsKey(start) || !graph.Nodes.ContainsKey(end))
                return new List<string>();

            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var parent = new Dictionary<string, string>();

            queue.Enqueue(start);
            visited.Add(start);
            parent[start] = null;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == end)
                    return ReconstructPath(parent, start, end);

                foreach (var neighbor in graph.Nodes[current].Neighbors.Keys)
                {
                    if (!visited.Contains(neighbor.Name))
                    {
                        visited.Add(neighbor.Name);
                        parent[neighbor.Name] = current;
                        queue.Enqueue(neighbor.Name);
                    }
                }
            }

            return new List<string>();
        }

        // Dijkstra - Shortest path in weighted graph
        public (List<string> path, int distance) Dijkstra(Graph graph, string start, string end)
        {
            if (!graph.Nodes.ContainsKey(start) || !graph.Nodes.ContainsKey(end))
                return (new List<string>(), int.MaxValue);

            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var unvisited = new HashSet<string>();

            foreach (var node in graph.Nodes.Keys)
            {
                distances[node] = int.MaxValue;
                unvisited.Add(node);
            }

            distances[start] = 0;

            while (unvisited.Count > 0)
            {
                var current = unvisited.OrderBy(n => distances[n]).First();
                unvisited.Remove(current);

                if (current == end)
                    break;

                if (distances[current] == int.MaxValue)
                    break;

                foreach (var neighbor in graph.Nodes[current].Neighbors)
                {
                    var alt = distances[current] + neighbor.Value;
                    if (alt < distances[neighbor.Key.Name])
                    {
                        distances[neighbor.Key.Name] = alt;
                        previous[neighbor.Key.Name] = current;
                    }
                }
            }

            return (ReconstructPath(previous, start, end), distances[end]);
        }

        private List<string> ReconstructPath(Dictionary<string, string> parent, string start, string end)
        {
            var path = new List<string>();
            var current = end;

            while (current != null)
            {
                path.Add(current);
                current = parent.ContainsKey(current) ? parent[current] : null;
            }

            path.Reverse();
            return path[0] == start ? path : new List<string>();
        }
    }
}