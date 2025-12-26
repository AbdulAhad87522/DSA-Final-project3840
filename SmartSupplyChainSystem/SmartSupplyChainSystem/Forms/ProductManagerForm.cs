// Forms/ProductManagerForm.cs - COMPLETELY FIXED VERSION
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
    public partial class ProductManagerForm : Form
    {
        private OrderManagerService orderManager;
        private InventoryService inventoryService;
        private TruckServiceManager truckManager;
        private Graph warehouseGraph;
        private RouteOptimizationService routeOptimizer;
        private PathfindingService pathfinder;

        public ProductManagerForm()
        {
            InitializeComponent();

            try
            {
                orderManager = OrderManagerService.Instance;
                inventoryService = new InventoryService();
                truckManager = TruckServiceManager.Instance;
                warehouseGraph = new Graph();
                routeOptimizer = new RouteOptimizationService();
                pathfinder = new PathfindingService();

                InitializeWarehouseGraph();
                LoadTrucks();
                LoadOrders();

                // Subscribe to events
                orderManager.OrdersChanged += OrderManager_OrdersChanged;

                lblStatus.Text = "✅ System Ready - Select orders and assign to truck";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Product Manager:\n{ex.Message}",
                    "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderManager_OrdersChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadTrucks()
        {
            try
            {
                cmbTruck.Items.Clear();
                var trucks = truckManager.GetAllTrucks();

                if (trucks == null || trucks.Count == 0)
                {
                    lblStatus.Text = "⚠️ No trucks available in the system";
                    lblStatus.ForeColor = Color.Orange;
                    return;
                }

                foreach (var truck in trucks)
                {
                    cmbTruck.Items.Add(truck);
                }

                if (cmbTruck.Items.Count > 0)
                    cmbTruck.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trucks:\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeWarehouseGraph()
        {
            try
            {
                string[] locations = { "Entrance", "Section-A", "Section-B", "Section-C",
                                      "Loading-Dock", "Office", "Storage-1", "Storage-2", "Exit" };

                foreach (var loc in locations)
                    warehouseGraph.AddNode(loc);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing warehouse graph:\n{ex.Message}",
                    "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                lstOrders.Items.Clear();

                var pendingOrders = orderManager.GetOrdersByStatus("Pending");

                if (pendingOrders == null || pendingOrders.Count == 0)
                {
                    lblTotalOrders.Text = "Total Orders Ready: 0";
                    lblStatus.Text = "📋 No orders ready for dispatch. Create orders in Order Processing.";
                    lblStatus.ForeColor = Color.Orange;
                    return;
                }

                foreach (var order in pendingOrders)
                {
                    lstOrders.Items.Add(order, false);
                }

                lblTotalOrders.Text = $"Total Orders Ready: {pendingOrders.Count}";
                lblStatus.Text = $"✅ {pendingOrders.Count} orders ready for dispatch - Check orders to select";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders:\n{ex.Message}",
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstOrders.SelectedItem != null)
                {
                    var order = (Order)lstOrders.SelectedItem;
                    DisplayOrderDetails(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying order details:\n{ex.Message}",
                    "Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrderDetails(Order order)
        {
            try
            {
                txtOrderDetails.Clear();
                txtOrderDetails.AppendText("═══════════════════════════════════════════\n");
                txtOrderDetails.AppendText($"         ORDER DETAILS\n");
                txtOrderDetails.AppendText("═══════════════════════════════════════════\n\n");

                txtOrderDetails.AppendText($"Order ID: {order.OrderId}\n");
                txtOrderDetails.AppendText($"Customer: {order.CustomerName}\n");
                txtOrderDetails.AppendText($"Delivery Address: {order.DeliveryAddress}\n");
                txtOrderDetails.AppendText($"Priority: {GetPriorityText(order.Priority)}\n");
                txtOrderDetails.AppendText($"Status: {order.Status}\n");
                txtOrderDetails.AppendText($"Order Date: {order.OrderDate:dd/MM/yyyy HH:mm}\n\n");

                txtOrderDetails.AppendText("───────────────────────────────────────────\n");
                txtOrderDetails.AppendText("         PRODUCTS ORDERED\n");
                txtOrderDetails.AppendText("───────────────────────────────────────────\n\n");

                if (order.Products != null && order.Products.Count > 0)
                {
                    foreach (var product in order.Products)
                    {
                        txtOrderDetails.AppendText($"📦 Product: {product.Name}\n");
                        txtOrderDetails.AppendText($"   ID: {product.ProductId}\n");
                        txtOrderDetails.AppendText($"   Category: {product.Category}\n");
                        txtOrderDetails.AppendText($"   Available Stock: {product.Quantity} units\n");
                        txtOrderDetails.AppendText($"   Warehouse Location: {product.Warehouse}\n");
                        txtOrderDetails.AppendText($"   Cold Storage: {(product.IsColdStorage ? "✅ Required" : "❌ Not Required")}\n\n");
                    }
                }
                else
                {
                    txtOrderDetails.AppendText("⚠️ No products in this order\n");
                }
            }
            catch (Exception ex)
            {
                txtOrderDetails.Clear();
                txtOrderDetails.AppendText($"Error displaying order details:\n{ex.Message}");
            }
        }

        private string GetPriorityText(int priority)
        {
            return priority == 1 ? "🚨 EMERGENCY" : priority == 2 ? "⚡ HIGH" : "📦 NORMAL";
        }

        private void btnTrackProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstOrders.SelectedItem == null)
                {
                    MessageBox.Show("Please select an order first!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var order = (Order)lstOrders.SelectedItem;

                if (order.Products == null || order.Products.Count == 0)
                {
                    MessageBox.Show("This order has no products!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = order.Products[0];

                lstTrackingLog.Items.Clear();
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("         📦 PRODUCT TRACKING");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add($"🔍 Tracking Product: {product.Name}");
                lstTrackingLog.Items.Add($"📋 Order ID: {order.OrderId}");
                lstTrackingLog.Items.Add($"👤 Customer: {order.CustomerName}");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("         WAREHOUSE LOCATION");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add($"📍 Product Location: {product.Warehouse}");
                lstTrackingLog.Items.Add($"🏢 Warehouse: Main Warehouse");
                lstTrackingLog.Items.Add($"📦 Stock Available: {product.Quantity} units");

                if (product.IsColdStorage)
                {
                    lstTrackingLog.Items.Add($"❄️ Storage Type: Cold Storage Required");
                    lstTrackingLog.Items.Add($"🌡️ Temperature: -5°C to 0°C");
                }
                else
                {
                    lstTrackingLog.Items.Add($"📦 Storage Type: Regular Storage");
                }

                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("    🗺️ SHORTEST ROUTE TO PRODUCT");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("");

                var path = pathfinder.Dijkstra(warehouseGraph, "Entrance", product.Warehouse);

                if (path.path != null && path.path.Count > 0)
                {
                    lstTrackingLog.Items.Add("✅ Route Found! (Using Dijkstra Algorithm)");
                    lstTrackingLog.Items.Add("");
                    for (int i = 0; i < path.path.Count; i++)
                    {
                        string arrow = i < path.path.Count - 1 ? "→" : "🎯";
                        lstTrackingLog.Items.Add($"   {i + 1}. {path.path[i]} {arrow}");
                    }
                    lstTrackingLog.Items.Add("");
                    lstTrackingLog.Items.Add($"📏 Total Distance: {path.distance} meters");
                    lstTrackingLog.Items.Add($"⏱️ Estimated Walking Time: {Math.Round(path.distance / 60.0, 1)} minutes");
                }
                else
                {
                    lstTrackingLog.Items.Add("❌ No route found!");
                }

                lblStatus.Text = $"✅ Product tracked: {product.Name} located in {product.Warehouse}";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error tracking product:\n{ex.Message}",
                    "Tracking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssignTruck_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATION 1: Check for checked items
                if (lstOrders.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please CHECK orders to assign!\n\n" +
                                  "Use the checkboxes (✓) next to orders to select multiple orders for assignment.",
                        "No Orders Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VALIDATION 2: Check truck selection
                if (cmbTruck.SelectedItem == null)
                {
                    MessageBox.Show("Please select a truck!", "No Truck Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedTruck = (Truck)cmbTruck.SelectedItem;

                // VALIDATION 3: Verify truck exists in manager
                var truckFromManager = truckManager.GetTruck(selectedTruck.TruckId);
                if (truckFromManager == null)
                {
                    MessageBox.Show("Selected truck not found in system!", "Truck Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedOrders = new List<Order>();

                // CRITICAL FIX: Create a copy to avoid collection modification error
                var checkedOrdersCopy = new List<Order>();
                foreach (Order order in lstOrders.CheckedItems)
                {
                    // VALIDATION 4: Verify order has products
                    if (order.Products == null || order.Products.Count == 0)
                    {
                        MessageBox.Show($"Order {order.OrderId} has no products!\n\n" +
                                      "Please ensure all orders have products before assigning.",
                            "Invalid Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // VALIDATION 5: Verify delivery address
                    if (string.IsNullOrWhiteSpace(order.DeliveryAddress))
                    {
                        MessageBox.Show($"Order {order.OrderId} has no delivery address!\n\n" +
                                      "Please ensure all orders have delivery addresses.",
                            "Invalid Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    checkedOrdersCopy.Add(order);
                }

                lstTrackingLog.Items.Clear();
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("    🚛 TRUCK ASSIGNMENT & ROUTE OPTIMIZATION");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add($"🚛 Truck: {selectedTruck.TruckId}");
                lstTrackingLog.Items.Add($"👨‍✈️ Driver: {selectedTruck.DriverName}");
                lstTrackingLog.Items.Add($"📦 Capacity: {selectedTruck.Capacity} kg");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add($"         VALIDATING ORDERS ({checkedOrdersCopy.Count})");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("");

                // CRITICAL: Collect ALL products from ALL checked orders
                var allProducts = new List<Product>();

                foreach (Order order in checkedOrdersCopy)
                {
                    try
                    {
                        selectedOrders.Add(order);

                        lstTrackingLog.Items.Add($"✅ Order: {order.OrderId}");
                        lstTrackingLog.Items.Add($"   👤 Customer: {order.CustomerName}");

                        // Show ALL products in this order with NULL check
                        if (order.Products != null && order.Products.Count > 0)
                        {
                            lstTrackingLog.Items.Add($"   📦 Products ({order.Products.Count}):");
                            foreach (var product in order.Products)
                            {
                                if (product != null)
                                {
                                    lstTrackingLog.Items.Add($"      • {product.Name ?? "Unknown"} (from {product.Warehouse ?? "Unknown"})");
                                    allProducts.Add(product);
                                }
                            }
                        }

                        lstTrackingLog.Items.Add($"   📍 Delivery: {order.DeliveryAddress}");
                        lstTrackingLog.Items.Add($"   ⚡ Priority: {GetPriorityText(order.Priority)}");
                        lstTrackingLog.Items.Add("");
                    }
                    catch (Exception orderEx)
                    {
                        lstTrackingLog.Items.Add($"❌ Error processing order {order.OrderId}: {orderEx.Message}");
                        lstTrackingLog.Items.Add("");
                    }
                }

                // VALIDATION 6: Check if any products were collected
                if (allProducts.Count == 0)
                {
                    MessageBox.Show("No valid products found in selected orders!",
                        "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add($"✅ All {selectedOrders.Count} orders validated successfully!");
                lstTrackingLog.Items.Add("───────────────────────────────────────────");
                lstTrackingLog.Items.Add("");

                // Update order status BEFORE assigning to truck
                foreach (var order in selectedOrders)
                {
                    try
                    {
                        orderManager.UpdateOrderStatus(order.OrderId, "Dispatched");
                    }
                    catch (Exception statusEx)
                    {
                        lstTrackingLog.Items.Add($"⚠️ Warning: Could not update status for {order.OrderId}: {statusEx.Message}");
                    }
                }

                // CRITICAL: Assign orders to truck using TruckServiceManager with error handling
                try
                {
                    truckManager.AssignOrdersToTruck(selectedTruck.TruckId, selectedOrders);
                    lstTrackingLog.Items.Add("✅ Orders successfully assigned to truck!");
                    lstTrackingLog.Items.Add("");
                }
                catch (Exception assignEx)
                {
                    MessageBox.Show($"Failed to assign orders to truck:\n{assignEx.Message}\n\n" +
                                  "Orders have been marked as dispatched but truck assignment failed.",
                        "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Rollback order status
                    foreach (var order in selectedOrders)
                    {
                        orderManager.UpdateOrderStatus(order.OrderId, "Pending");
                    }
                    return;
                }

                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("    📦 WAREHOUSE COLLECTION ROUTE");
                lstTrackingLog.Items.Add("    (Using TSP Algorithm for Optimization)");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("");

                // FIXED: Get unique warehouse locations from ALL products
                var uniqueLocations = allProducts
                    .Select(p => p.Warehouse)
                    .Distinct()
                    .ToList();

                if (uniqueLocations.Count > 0)
                {
                    lstTrackingLog.Items.Add($"📦 Total Products to collect: {allProducts.Count}");
                    lstTrackingLog.Items.Add($"📍 From {uniqueLocations.Count} warehouse location(s):");
                    lstTrackingLog.Items.Add("");

                    foreach (var location in uniqueLocations)
                    {
                        var productsAtLocation = allProducts
                            .Where(p => p.Warehouse == location)
                            .ToList();

                        lstTrackingLog.Items.Add($"   📍 {location} ({productsAtLocation.Count} products):");
                        foreach (var prod in productsAtLocation)
                        {
                            // Find which order this product belongs to
                            var orderForProduct = selectedOrders.FirstOrDefault(o =>
                                o.Products != null && o.Products.Contains(prod));
                            string orderInfo = orderForProduct != null ? $" [Order: {orderForProduct.OrderId}]" : "";
                            lstTrackingLog.Items.Add($"      → {prod.Name}{orderInfo}");
                        }
                        lstTrackingLog.Items.Add("");
                    }

                    var warehouseRoute = routeOptimizer.OptimizeRoute(warehouseGraph, "Entrance", uniqueLocations);

                    lstTrackingLog.Items.Add("✅ Optimized Collection Route:");
                    lstTrackingLog.Items.Add("");

                    if (warehouseRoute.route != null && warehouseRoute.route.Count > 0)
                    {
                        for (int i = 0; i < warehouseRoute.route.Count; i++)
                        {
                            string icon = i == 0 ? "🚪" : i == warehouseRoute.route.Count - 1 ? "📦" : "📍";
                            lstTrackingLog.Items.Add($"   {i + 1}. {icon} {warehouseRoute.route[i]}");
                        }
                        lstTrackingLog.Items.Add($"   {warehouseRoute.route.Count + 1}. 🚚 Loading-Dock (Load all products)");
                        lstTrackingLog.Items.Add($"   {warehouseRoute.route.Count + 2}. 🚪 Exit (Depart for delivery)");
                        lstTrackingLog.Items.Add("");
                        lstTrackingLog.Items.Add($"📏 Collection Distance: {warehouseRoute.totalDistance} meters");
                        lstTrackingLog.Items.Add($"⏱️ Collection Time: {Math.Round(warehouseRoute.totalDistance / 60.0, 1)} minutes");
                    }
                }

                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("    🗺️ DELIVERY ADDRESSES ASSIGNED");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add($"✅ Driver {selectedTruck.DriverName} must deliver to {selectedOrders.Count} location(s):");
                lstTrackingLog.Items.Add("");

                for (int i = 0; i < selectedOrders.Count; i++)
                {
                    lstTrackingLog.Items.Add($"   Stop {i + 1}: 📍 {selectedOrders[i].DeliveryAddress}");

                    // FIXED: Show ALL products for this delivery
                    if (selectedOrders[i].Products != null && selectedOrders[i].Products.Count > 0)
                    {
                        lstTrackingLog.Items.Add($"           📦 Deliver ({selectedOrders[i].Products.Count} items):");
                        foreach (var product in selectedOrders[i].Products)
                        {
                            lstTrackingLog.Items.Add($"              • {product.Name}");
                        }
                    }

                    lstTrackingLog.Items.Add($"           👤 Customer: {selectedOrders[i].CustomerName}");
                    lstTrackingLog.Items.Add($"           📋 Order: {selectedOrders[i].OrderId}");
                    lstTrackingLog.Items.Add("");
                }

                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("    ✅ DISPATCH SUMMARY");
                lstTrackingLog.Items.Add("═══════════════════════════════════════════");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add($"📊 Total Orders: {selectedOrders.Count}");
                lstTrackingLog.Items.Add($"📦 Total Products: {allProducts.Count}");
                lstTrackingLog.Items.Add($"📍 Warehouse Stops: {uniqueLocations.Count}");
                lstTrackingLog.Items.Add($"🏠 Delivery Addresses: {selectedOrders.Count}");
                lstTrackingLog.Items.Add($"🚛 Truck: {selectedTruck.TruckId}");
                lstTrackingLog.Items.Add($"👨‍✈️ Driver: {selectedTruck.DriverName}");
                lstTrackingLog.Items.Add($"📦 Status: Dispatched");
                lstTrackingLog.Items.Add("");
                lstTrackingLog.Items.Add("✅ All delivery addresses assigned to driver!");
                lstTrackingLog.Items.Add("📱 Driver can now view these in Truck Routing.");

                lblStatus.Text = $"✅ {selectedOrders.Count} orders ({allProducts.Count} products) dispatched to {selectedTruck.DriverName}";
                lblStatus.ForeColor = Color.Green;

                LoadOrders(); // Refresh order list

                // Build detailed product list for message box
                string productList = "";
                foreach (var order in selectedOrders)
                {
                    productList += $"\n  Order {order.OrderId}:\n";
                    if (order.Products != null)
                    {
                        foreach (var product in order.Products)
                        {
                            productList += $"    • {product.Name} (from {product.Warehouse})\n";
                        }
                    }
                }

                MessageBox.Show($"✅ DISPATCH SUCCESSFUL!\n\n" +
                              $"🚛 Truck: {selectedTruck.TruckId}\n" +
                              $"👨‍✈️ Driver: {selectedTruck.DriverName}\n" +
                              $"📦 Orders: {selectedOrders.Count}\n" +
                              $"📦 Total Products: {allProducts.Count}\n" +
                              $"📍 Warehouse Stops: {uniqueLocations.Count}\n" +
                              $"🏠 Delivery Addresses: {selectedOrders.Count}\n\n" +
                              $"Products to collect:{productList}\n" +
                              $"Delivery addresses:\n" +
                              string.Join("\n", selectedOrders.Select(o => $"  • {o.DeliveryAddress} ({o.CustomerName})")) + "\n\n" +
                              $"✅ Driver can now optimize route in Truck Routing Form!",
                              "Dispatch Complete",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning truck:\n{ex.Message}\n\n" +
                              $"Error Type: {ex.GetType().Name}\n" +
                              $"Stack Trace:\n{ex.StackTrace}",
                    "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOrders();
                LoadTrucks();
                lstTrackingLog.Items.Clear();
                txtOrderDetails.Clear();

                // Uncheck all items
                for (int i = 0; i < lstOrders.Items.Count; i++)
                {
                    lstOrders.SetItemChecked(i, false);
                }

                lblStatus.Text = "🔄 Refreshed successfully - All data reloaded";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data:\n{ex.Message}",
                    "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                orderManager.OrdersChanged -= OrderManager_OrdersChanged;
            }
            catch
            {
                // Ignore errors during cleanup
            }
            base.OnFormClosing(e);
        }

        private void txtOrderDetails_TextChanged(object sender, EventArgs e)
        {
        }
    }
}