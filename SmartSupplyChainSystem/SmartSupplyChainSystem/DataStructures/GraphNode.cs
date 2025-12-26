// DataStructures/GraphNode.cs
using System.Collections.Generic;

namespace SmartSupplyChainSystem.DataStructures
{
    public class GraphNode
    {
        public string Name { get; set; }
        public Dictionary<GraphNode, int> Neighbors { get; set; }

        public GraphNode(string name)
        {
            Name = name;
            Neighbors = new Dictionary<GraphNode, int>();
        }

        public void AddNeighbor(GraphNode neighbor, int weight)
        {
            Neighbors[neighbor] = weight;
        }
    }

    public class Graph
    {
        public Dictionary<string, GraphNode> Nodes { get; set; }

        public Graph()
        {
            Nodes = new Dictionary<string, GraphNode>();
        }

        public void AddNode(string name)
        {
            if (!Nodes.ContainsKey(name))
                Nodes[name] = new GraphNode(name);
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!Nodes.ContainsKey(from))
                AddNode(from);
            if (!Nodes.ContainsKey(to))
                AddNode(to);

            Nodes[from].AddNeighbor(Nodes[to], weight);
            Nodes[to].AddNeighbor(Nodes[from], weight); // Bidirectional
        }
    }
}