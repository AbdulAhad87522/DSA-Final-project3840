// Forms/TruckRoutingForm.cs - CLEAN VISUALIZATION (ONLY ASSIGNED ADDRESSES)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartSupplyChainSystem.DataStructures;
using SmartSupplyChainSystem.Models;
using SmartSupplyChainSystem.Services;

namespace SmartSupplyChainSystem.Forms
{
    public partial class TruckRoutingForm : Form
    {
        private Graph cityGraph;
        private RouteOptimizationService routeOptimizer;
        private TruckServiceManager truckManager;
        private Dictionary<string, Point> cityPositions;

        public TruckRoutingForm()
        {
            InitializeComponent();
            cityGraph = new Graph();
            routeOptimizer = new RouteOptimizationService();
            truckManager = TruckServiceManager.Instance;
            cityPositions = new Dictionary<string, Point>();

            InitializeCityGraph();
            LoadTrucks();

            truckManager.TrucksChanged += TruckManager_TrucksChanged;
        }

        private void TruckManager_TrucksChanged(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedItem != null)
            {
                var selectedTruck = (Truck)cmbTruck.SelectedItem;
                int selectedIndex = cmbTruck.SelectedIndex;
                LoadTrucks();
                if (selectedIndex < cmbTruck.Items.Count)
                {
                    cmbTruck.SelectedIndex = selectedIndex;
                }
                LoadDestinationsForTruck(selectedTruck);
                panelVisualization.Invalidate();
            }
        }

        private void InitializeCityGraph()
        {
            // Warehouse is the starting point - ALWAYS visible
            cityGraph.AddNode("Warehouse");
            cityPositions["Warehouse"] = new Point(100, 250);

            // Default cities - for manual mode only
            string[] defaultCities = { "City-A", "City-B", "City-C", "City-D", "City-E", "City-F" };
            Point[] positions = {
                new Point(250, 100),
                new Point(250, 300),
                new Point(400, 150),
                new Point(550, 100),
                new Point(550, 300),
                new Point(700, 200)
            };

            for (int i = 0; i < defaultCities.Length; i++)
            {
                cityGraph.AddNode(defaultCities[i]);
                cityPositions[defaultCities[i]] = positions[i];
            }

            cityGraph.AddEdge("Warehouse", "City-A", 15);
            cityGraph.AddEdge("Warehouse", "City-B", 25);
            cityGraph.AddEdge("City-A", "City-C", 20);
            cityGraph.AddEdge("City-A", "City-D", 30);
            cityGraph.AddEdge("City-B", "City-C", 18);
            cityGraph.AddEdge("City-B", "City-E", 22);
            cityGraph.AddEdge("City-C", "City-D", 12);
            cityGraph.AddEdge("City-C", "City-F", 28);
            cityGraph.AddEdge("City-D", "City-E", 15);
            cityGraph.AddEdge("City-E", "City-F", 10);
        }

        private void LoadTrucks()
        {
            cmbTruck.Items.Clear();
            var trucks = truckManager.GetAllTrucks();

            foreach (var truck in trucks)
            {
                cmbTruck.Items.Add(truck);
            }

            if (cmbTruck.Items.Count > 0)
                cmbTruck.SelectedIndex = 0;
        }

        private void LoadDestinationsForTruck(Truck truck)
        {
            lstDestinations.Items.Clear();

            if (truck.DeliveryAddresses.Count > 0)
            {
                lblDestinationMode.Text = $"🚚 Assigned Delivery Addresses ({truck.DeliveryAddresses.Count}):";
                lblDestinationMode.ForeColor = Color.Green;

                foreach (var address in truck.DeliveryAddresses)
                {
                    lstDestinations.Items.Add(address);

                    if (!cityGraph.Nodes.ContainsKey(address))
                    {
                        cityGraph.AddNode(address);
                        Random rand = new Random(address.GetHashCode());
                        int distance = rand.Next(20, 50);
                        cityGraph.AddEdge("Warehouse", address, distance);

                        // Dynamic positioning for assigned addresses
                        int x = 200 + (lstDestinations.Items.Count * 150);
                        int y = 100 + (rand.Next(0, 3) * 100);
                        cityPositions[address] = new Point(x, y);
                    }
                }

                for (int i = 0; i < lstDestinations.Items.Count; i++)
                {
                    lstDestinations.SetItemChecked(i, true);
                }

                lblTruckInfo.Text = $"Driver: {truck.DriverName} | Capacity: {truck.Capacity} kg | " +
                                   $"Status: {truck.Status} | 📦 Deliveries: {truck.DeliveryAddresses.Count}";
                lblTruckInfo.ForeColor = Color.Green;

                lblRouteInfo.Text = $"✅ {truck.DeliveryAddresses.Count} delivery addresses loaded. Click 'Optimize Route' to plan delivery.";
                lblRouteInfo.ForeColor = Color.Green;
            }
            else
            {
                lblDestinationMode.Text = "🎯 No Deliveries Assigned - Select Cities Manually:";
                lblDestinationMode.ForeColor = Color.Gray;

                string[] defaultCities = { "City-A", "City-B", "City-C", "City-D", "City-E", "City-F" };
                foreach (var city in defaultCities)
                {
                    lstDestinations.Items.Add(city);
                }

                lblTruckInfo.Text = $"Driver: {truck.DriverName} | Capacity: {truck.Capacity} kg | Status: {truck.Status}";
                lblTruckInfo.ForeColor = Color.Black;

                lblRouteInfo.Text = "No deliveries assigned. Select cities manually or assign orders in Product Manager.";
                lblRouteInfo.ForeColor = Color.Orange;
            }
        }

        private void btnOptimizeRoute_Click(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedItem == null)
            {
                MessageBox.Show("Please select a truck!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstDestinations.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one destination!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTruck = (Truck)cmbTruck.SelectedItem;
            var destinations = new List<string>();

            foreach (var item in lstDestinations.CheckedItems)
            {
                destinations.Add(item.ToString());
            }

            var result = routeOptimizer.OptimizeRoute(cityGraph, "Warehouse", destinations);

            if (result.route.Count > 0)
            {
                lstOptimizedRoute.Items.Clear();
                lstOptimizedRoute.Items.Add("═══════════════════════════════════════");

                if (selectedTruck.DeliveryAddresses.Count > 0)
                {
                    lstOptimizedRoute.Items.Add("  📦 OPTIMIZED DELIVERY ROUTE");
                }
                else
                {
                    lstOptimizedRoute.Items.Add("  🚛 OPTIMIZED ROUTE");
                }

                lstOptimizedRoute.Items.Add("═══════════════════════════════════════");
                lstOptimizedRoute.Items.Add("");

                if (selectedTruck.DeliveryAddresses.Count > 0)
                {
                    lstOptimizedRoute.Items.Add("🏭 Starting from Warehouse...");
                    lstOptimizedRoute.Items.Add("");

                    int stopNumber = 1;
                    for (int i = 0; i < result.route.Count; i++)
                    {
                        if (result.route[i] == "Warehouse")
                        {
                            continue;
                        }

                        lstOptimizedRoute.Items.Add($"Stop {stopNumber}: 📍 {result.route[i]}");

                        var order = selectedTruck.AssignedOrders.FirstOrDefault(o => o.DeliveryAddress == result.route[i]);
                        if (order != null)
                        {
                            lstOptimizedRoute.Items.Add($"  📦 Deliver: {order.Products[0].Name}");
                            lstOptimizedRoute.Items.Add($"  👤 Customer: {order.CustomerName}");
                            lstOptimizedRoute.Items.Add($"  📋 Order: {order.OrderId}");
                        }

                        lstOptimizedRoute.Items.Add("");
                        stopNumber++;
                    }
                }
                else
                {
                    for (int i = 0; i < result.route.Count; i++)
                    {
                        string icon = result.route[i] == "Warehouse" ? "🏭" : "🏙️";
                        lstOptimizedRoute.Items.Add($"{i + 1}. {icon} {result.route[i]}");
                    }
                    lstOptimizedRoute.Items.Add("");
                }

                lstOptimizedRoute.Items.Add("═══════════════════════════════════════");
                lstOptimizedRoute.Items.Add($"📏 Total Distance: {result.totalDistance} km");
                lstOptimizedRoute.Items.Add($"⏱️ Estimated Time: {CalculateTime(result.totalDistance)} hrs");
                lstOptimizedRoute.Items.Add("═══════════════════════════════════════");

                selectedTruck.Route = result.route;
                selectedTruck.Status = "On Route";
                truckManager.UpdateTruck(selectedTruck);

                if (selectedTruck.DeliveryAddresses.Count > 0)
                {
                    lblRouteInfo.Text = $"✅ Delivery route optimized! Distance: {result.totalDistance} km | Stops: {destinations.Count}";
                }
                else
                {
                    lblRouteInfo.Text = $"✅ Route optimized! Distance: {result.totalDistance} km";
                }

                lblRouteInfo.ForeColor = Color.Green;

                panelVisualization.Invalidate();
            }
            else
            {
                MessageBox.Show("Unable to optimize route!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateTime(int distance)
        {
            return Math.Round(distance / 60.0, 2);
        }

        private void btnResetRoute_Click(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedItem != null)
            {
                var truck = (Truck)cmbTruck.SelectedItem;

                truck.Route.Clear();
                truck.Status = "Available";
                truckManager.UpdateTruck(truck);

                for (int i = 0; i < lstDestinations.Items.Count; i++)
                {
                    lstDestinations.SetItemChecked(i, false);
                }

                lstOptimizedRoute.Items.Clear();

                if (truck.DeliveryAddresses.Count > 0)
                {
                    for (int i = 0; i < lstDestinations.Items.Count; i++)
                    {
                        lstDestinations.SetItemChecked(i, true);
                    }

                    lblRouteInfo.Text = "Route cleared. Addresses still assigned. Click 'Optimize Route' to re-plan.";
                    lblRouteInfo.ForeColor = Color.Orange;
                }
                else
                {
                    lblRouteInfo.Text = "Route reset. Select destinations and click 'Optimize Route'.";
                    lblRouteInfo.ForeColor = Color.Black;
                }
            }

            panelVisualization.Invalidate();
        }

        private void panelVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (cmbTruck.SelectedItem == null)
                return;

            var selectedTruck = (Truck)cmbTruck.SelectedItem;

            // CRITICAL: Determine which locations to show
            HashSet<string> visibleLocations = new HashSet<string>();
            visibleLocations.Add("Warehouse"); // Warehouse always visible

            if (selectedTruck.DeliveryAddresses.Count > 0)
            {
                // ONLY SHOW ASSIGNED ADDRESSES
                foreach (var address in selectedTruck.DeliveryAddresses)
                {
                    visibleLocations.Add(address);
                }
            }
            else
            {
                // Show default cities in manual mode
                visibleLocations.Add("City-A");
                visibleLocations.Add("City-B");
                visibleLocations.Add("City-C");
                visibleLocations.Add("City-D");
                visibleLocations.Add("City-E");
                visibleLocations.Add("City-F");
            }

            // Draw edges ONLY between visible locations
            Pen edgePen = new Pen(Color.LightGray, 2);
            foreach (var node in cityGraph.Nodes.Values)
            {
                if (!visibleLocations.Contains(node.Name)) continue;
                if (!cityPositions.ContainsKey(node.Name)) continue;

                Point p1 = cityPositions[node.Name];

                foreach (var neighbor in node.Neighbors)
                {
                    if (!visibleLocations.Contains(neighbor.Key.Name)) continue;
                    if (!cityPositions.ContainsKey(neighbor.Key.Name)) continue;

                    Point p2 = cityPositions[neighbor.Key.Name];
                    g.DrawLine(edgePen, p1, p2);

                    // Draw distance
                    int midX = (p1.X + p2.X) / 2;
                    int midY = (p1.Y + p2.Y) / 2;
                    g.FillEllipse(Brushes.White, midX - 12, midY - 12, 24, 24);
                    g.DrawString(neighbor.Value.ToString(), new Font("Arial", 8),
                        Brushes.DarkBlue, midX - 8, midY - 8);
                }
            }

            // Draw optimized route if exists
            if (selectedTruck.Route.Count > 1)
            {
                Pen routePen = new Pen(Color.Red, 4);
                for (int i = 0; i < selectedTruck.Route.Count - 1; i++)
                {
                    if (cityPositions.ContainsKey(selectedTruck.Route[i]) &&
                        cityPositions.ContainsKey(selectedTruck.Route[i + 1]))
                    {
                        Point p1 = cityPositions[selectedTruck.Route[i]];
                        Point p2 = cityPositions[selectedTruck.Route[i + 1]];
                        g.DrawLine(routePen, p1, p2);
                        DrawArrow(g, routePen, p1, p2);
                    }
                }
            }

            // Draw ONLY visible locations
            foreach (var kvp in cityPositions)
            {
                if (!visibleLocations.Contains(kvp.Key)) continue;

                Point p = kvp.Value;
                Color nodeColor = kvp.Key == "Warehouse" ? Color.Green : Color.DodgerBlue;

                if (selectedTruck.DeliveryAddresses.Contains(kvp.Key))
                {
                    nodeColor = Color.Orange;
                }

                g.FillEllipse(new SolidBrush(nodeColor), p.X - 25, p.Y - 25, 50, 50);
                g.DrawEllipse(new Pen(Color.DarkBlue, 2), p.X - 25, p.Y - 25, 50, 50);

                string icon = kvp.Key == "Warehouse" ? "🏭" : "📍";
                g.DrawString(icon, new Font("Segoe UI", 16), Brushes.White, p.X - 15, p.Y - 18);

                string displayName = kvp.Key.Length > 20 ? kvp.Key.Substring(0, 17) + "..." : kvp.Key;
                SizeF textSize = g.MeasureString(displayName, new Font("Arial", 8, FontStyle.Bold));
                g.DrawString(displayName, new Font("Arial", 8, FontStyle.Bold),
                    Brushes.Black, p.X - textSize.Width / 2, p.Y + 30);
            }
        }

        private void DrawArrow(Graphics g, Pen pen, Point start, Point end)
        {
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);
            int arrowLength = 15;
            double arrowAngle = Math.PI / 6;

            Point arrowPoint1 = new Point(
                (int)(end.X - arrowLength * Math.Cos(angle - arrowAngle)),
                (int)(end.Y - arrowLength * Math.Sin(angle - arrowAngle))
            );

            Point arrowPoint2 = new Point(
                (int)(end.X - arrowLength * Math.Cos(angle + arrowAngle)),
                (int)(end.Y - arrowLength * Math.Sin(angle + arrowAngle))
            );

            g.DrawLine(pen, end, arrowPoint1);
            g.DrawLine(pen, end, arrowPoint2);
        }

        private void cmbTruck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedItem != null)
            {
                var truck = (Truck)cmbTruck.SelectedItem;
                LoadDestinationsForTruck(truck);
                panelVisualization.Invalidate();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            truckManager.TrucksChanged -= TruckManager_TrucksChanged;
            base.OnFormClosing(e);
        }

        private void lblTruckInfo_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblSelectTruck_Click(object sender, EventArgs e) { }
        private void grpDestinations_Enter(object sender, EventArgs e) { }
        private void lblDestinationMode_Click(object sender, EventArgs e) { }
        private void lstDestinations_SelectedIndexChanged(object sender, EventArgs e) { }
        private void grpRouteDetails_Enter(object sender, EventArgs e) { }
        private void lstOptimizedRoute_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblRouteInfo_Click(object sender, EventArgs e) { }
    }
}