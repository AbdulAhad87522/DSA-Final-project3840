// Forms/WarehouseNavigationForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SmartSupplyChainSystem.DataStructures;
using SmartSupplyChainSystem.Services;

namespace SmartSupplyChainSystem.Forms
{
    public partial class WarehouseNavigationForm : Form
    {
        private Graph warehouseGraph;
        private PathfindingService pathfinder;
        private Dictionary<string, Point> nodePositions;

        public WarehouseNavigationForm()
        {
            InitializeComponent();
            InitializeWarehouseGraph();
            pathfinder = new PathfindingService();
            LoadLocations();
        }

        private void InitializeWarehouseGraph()
        {
            warehouseGraph = new Graph();
            nodePositions = new Dictionary<string, Point>();

            // Create warehouse layout
            string[] locations = { "Entrance", "Section-A", "Section-B", "Section-C",
                                  "Loading-Dock", "Office", "Storage-1", "Storage-2", "Exit" };

            foreach (var loc in locations)
                warehouseGraph.AddNode(loc);

            // Add connections (bidirectional edges with weights)
            warehouseGraph.AddEdge("Entrance", "Section-A", 10);
            warehouseGraph.AddEdge("Entrance", "Office", 15);
            warehouseGraph.AddEdge("Section-A", "Section-B", 8);
            warehouseGraph.AddEdge("Section-A", "Storage-1", 12);
            warehouseGraph.AddEdge("Section-B", "Section-C", 10);
            warehouseGraph.AddEdge("Section-B", "Storage-2", 7);
            warehouseGraph.AddEdge("Section-C", "Loading-Dock", 9);
            warehouseGraph.AddEdge("Section-C", "Exit", 11);
            warehouseGraph.AddEdge("Storage-1", "Storage-2", 15);
            warehouseGraph.AddEdge("Loading-Dock", "Exit", 6);
            warehouseGraph.AddEdge("Office", "Loading-Dock", 20);

            // Define positions for visualization
            nodePositions["Entrance"] = new Point(50, 200);
            nodePositions["Section-A"] = new Point(150, 100);
            nodePositions["Section-B"] = new Point(300, 100);
            nodePositions["Section-C"] = new Point(450, 100);
            nodePositions["Office"] = new Point(150, 300);
            nodePositions["Storage-1"] = new Point(250, 250);
            nodePositions["Storage-2"] = new Point(400, 250);
            nodePositions["Loading-Dock"] = new Point(550, 200);
            nodePositions["Exit"] = new Point(650, 150);
        }

        private void LoadLocations()
        {
            cmbStart.Items.Clear();
            cmbEnd.Items.Clear();

            foreach (var location in warehouseGraph.Nodes.Keys)
            {
                cmbStart.Items.Add(location);
                cmbEnd.Items.Add(location);
            }

            if (cmbStart.Items.Count > 0)
            {
                cmbStart.SelectedIndex = 0;
                cmbEnd.SelectedIndex = cmbEnd.Items.Count - 1;
            }
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            if (cmbStart.SelectedItem == null || cmbEnd.SelectedItem == null)
            {
                MessageBox.Show("Please select start and end locations!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string start = cmbStart.SelectedItem.ToString();
            string end = cmbEnd.SelectedItem.ToString();

            if (start == end)
            {
                MessageBox.Show("Start and End locations cannot be the same!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BFS for shortest path
            var path = pathfinder.BFS(warehouseGraph, start, end);

            // Dijkstra for weighted shortest path
            var dijkstraResult = pathfinder.Dijkstra(warehouseGraph, start, end);

            if (path.Count > 0)
            {
                lstPath.Items.Clear();
                lstPath.Items.Add("=== BFS PATH (Fewest Stops) ===");
                for (int i = 0; i < path.Count; i++)
                {
                    lstPath.Items.Add($"{i + 1}. {path[i]}");
                }

                lstPath.Items.Add("");
                lstPath.Items.Add("=== DIJKSTRA PATH (Shortest Distance) ===");
                for (int i = 0; i < dijkstraResult.path.Count; i++)
                {
                    lstPath.Items.Add($"{i + 1}. {dijkstraResult.path[i]}");
                }
                lstPath.Items.Add($"Total Distance: {dijkstraResult.distance} meters");

                lblResult.Text = $"✅ Path Found! Steps: {path.Count} | Distance: {dijkstraResult.distance}m";
                lblResult.ForeColor = Color.Green;

                // Visualize
                panelVisualization.Invalidate();
            }
            else
            {
                lstPath.Items.Clear();
                lstPath.Items.Add("❌ No path found!");
                lblResult.Text = "❌ No path exists between these locations";
                lblResult.ForeColor = Color.Red;
            }
        }

        private void panelVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw edges
            Pen edgePen = new Pen(Color.Gray, 2);
            foreach (var node in warehouseGraph.Nodes.Values)
            {
                if (!nodePositions.ContainsKey(node.Name)) continue;
                Point p1 = nodePositions[node.Name];

                foreach (var neighbor in node.Neighbors)
                {
                    if (!nodePositions.ContainsKey(neighbor.Key.Name)) continue;
                    Point p2 = nodePositions[neighbor.Key.Name];
                    g.DrawLine(edgePen, p1, p2);

                    // Draw weight
                    int midX = (p1.X + p2.X) / 2;
                    int midY = (p1.Y + p2.Y) / 2;
                    g.FillEllipse(Brushes.White, midX - 12, midY - 12, 24, 24);
                    g.DrawString(neighbor.Value.ToString(), new Font("Arial", 8),
                        Brushes.DarkBlue, midX - 8, midY - 8);
                }
            }

            // Draw nodes
            foreach (var kvp in nodePositions)
            {
                Point p = kvp.Value;
                g.FillEllipse(Brushes.DodgerBlue, p.X - 20, p.Y - 20, 40, 40);
                g.DrawEllipse(new Pen(Color.DarkBlue, 2), p.X - 20, p.Y - 20, 40, 40);

                // Draw label
                SizeF textSize = g.MeasureString(kvp.Key, new Font("Arial", 8));
                g.DrawString(kvp.Key, new Font("Arial", 8, FontStyle.Bold),
                    Brushes.White, p.X - textSize.Width / 2, p.Y - textSize.Height / 2);
            }

            // Highlight path if exists
            if (lstPath.Items.Count > 0)
            {
                Pen pathPen = new Pen(Color.LimeGreen, 4);
                for (int i = 0; i < lstPath.Items.Count; i++)
                {
                    string item = lstPath.Items[i].ToString();
                    if (item.Contains("."))
                    {
                        string locationName = item.Substring(item.IndexOf('.') + 2);

                        if (nodePositions.ContainsKey(locationName))
                        {
                            Point p = nodePositions[locationName];
                            g.FillEllipse(Brushes.LimeGreen, p.X - 22, p.Y - 22, 44, 44);

                            // Draw step number
                            string stepNum = item.Substring(0, item.IndexOf('.'));
                            g.DrawString(stepNum, new Font("Arial", 10, FontStyle.Bold),
                                Brushes.Yellow, p.X - 25, p.Y - 35);
                        }
                    }
                }
            }
        }

        private void cmbEnd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}