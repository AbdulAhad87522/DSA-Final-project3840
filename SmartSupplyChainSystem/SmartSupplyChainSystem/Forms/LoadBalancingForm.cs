// Forms/LoadBalancingForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartSupplyChainSystem.Models;

namespace SmartSupplyChainSystem.Forms
{
    public partial class LoadBalancingForm : Form
    {
        private List<Warehouse> warehouses;
        private Random random;

        public LoadBalancingForm()
        {
            InitializeComponent();
            random = new Random();
            InitializeWarehouses();
            LoadWarehouses();
            UpdateVisualization();
        }

        private void InitializeWarehouses()
        {
            warehouses = new List<Warehouse>
            {
                new Warehouse("WH-001", "North Warehouse", "Lahore", 5000, true),
                new Warehouse("WH-002", "South Warehouse", "Karachi", 7000, false),
                new Warehouse("WH-003", "East Warehouse", "Islamabad", 4000, true),
                new Warehouse("WH-004", "West Warehouse", "Peshawar", 6000, false),
                new Warehouse("WH-005", "Central Warehouse", "Multan", 8000, true)
            };

            // Add some initial load
            warehouses[0].CurrentLoad = 3200;
            warehouses[1].CurrentLoad = 5500;
            warehouses[2].CurrentLoad = 1800;
            warehouses[3].CurrentLoad = 4200;
            warehouses[4].CurrentLoad = 6400;

            // Add some sample products
            foreach (var wh in warehouses)
            {
                int productCount = random.Next(50, 150);
                for (int i = 0; i < productCount; i++)
                {
                    var product = new Product(
                        $"P-{wh.WarehouseId}-{i:D3}",
                        $"Product {i}",
                        "Electronics",
                        random.Next(10, 100),
                        wh.Name,
                        wh.HasColdStorage && random.Next(0, 2) == 0
                    );
                    wh.Inventory.Add(product);
                }
            }
        }

        private void LoadWarehouses()
        {
            cmbWarehouse.Items.Clear();
            lstWarehouses.Items.Clear();

            foreach (var wh in warehouses)
            {
                cmbWarehouse.Items.Add(wh);
                lstWarehouses.Items.Add(wh);
            }

            if (cmbWarehouse.Items.Count > 0)
                cmbWarehouse.SelectedIndex = 0;

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            int totalCapacity = warehouses.Sum(w => w.Capacity);
            int totalLoad = warehouses.Sum(w => w.CurrentLoad);
            double avgLoad = warehouses.Average(w => w.LoadPercentage);

            lblTotalCapacity.Text = $"Total Capacity: {totalCapacity:N0} kg";
            lblTotalLoad.Text = $"Total Load: {totalLoad:N0} kg";
            lblAvgLoad.Text = $"Average Load: {avgLoad:F1}%";

            // Find most and least loaded
            var mostLoaded = warehouses.OrderByDescending(w => w.LoadPercentage).First();
            var leastLoaded = warehouses.OrderBy(w => w.LoadPercentage).First();

            lblMostLoaded.Text = $"Most Loaded: {mostLoaded.Name} ({mostLoaded.LoadPercentage:F1}%)";
            lblMostLoaded.ForeColor = mostLoaded.LoadPercentage > 80 ? Color.Red : Color.Black;

            lblLeastLoaded.Text = $"Least Loaded: {leastLoaded.Name} ({leastLoaded.LoadPercentage:F1}%)";
            lblLeastLoaded.ForeColor = Color.Green;
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            if (cmbWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Please select a warehouse!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var warehouse = (Warehouse)cmbWarehouse.SelectedItem;
            int loadToAdd = (int)numLoadAmount.Value;

            if (warehouse.CanAccommodate(loadToAdd))
            {
                warehouse.CurrentLoad += loadToAdd;
                LoadWarehouses();
                UpdateVisualization();

                MessageBox.Show($"✅ {loadToAdd} kg added to {warehouse.Name}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"❌ Cannot add {loadToAdd} kg. Warehouse capacity exceeded!\nAvailable space: {warehouse.Capacity - warehouse.CurrentLoad} kg",
                    "Capacity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveLoad_Click(object sender, EventArgs e)
        {
            if (cmbWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Please select a warehouse!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var warehouse = (Warehouse)cmbWarehouse.SelectedItem;
            int loadToRemove = (int)numLoadAmount.Value;

            if (warehouse.CurrentLoad >= loadToRemove)
            {
                warehouse.CurrentLoad -= loadToRemove;
                LoadWarehouses();
                UpdateVisualization();

                MessageBox.Show($"✅ {loadToRemove} kg removed from {warehouse.Name}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"❌ Cannot remove {loadToRemove} kg. Current load is only {warehouse.CurrentLoad} kg",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutoBalance_Click(object sender, EventArgs e)
        {
            // Simple load balancing algorithm
            int totalLoad = warehouses.Sum(w => w.CurrentLoad);
            int totalCapacity = warehouses.Sum(w => w.Capacity);

            if (totalLoad > totalCapacity)
            {
                MessageBox.Show("Total load exceeds total capacity! Cannot balance.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate target load percentage
            double targetPercentage = (totalLoad / (double)totalCapacity) * 100;

            // Redistribute load
            var sortedWarehouses = warehouses.OrderByDescending(w => w.LoadPercentage).ToList();

            lstBalanceLog.Items.Clear();
            lstBalanceLog.Items.Add("=== LOAD BALANCING LOG ===");
            lstBalanceLog.Items.Add($"Target Load: {targetPercentage:F1}%");
            lstBalanceLog.Items.Add("");

            foreach (var wh in sortedWarehouses)
            {
                int targetLoad = (int)(wh.Capacity * targetPercentage / 100);
                int difference = wh.CurrentLoad - targetLoad;

                if (Math.Abs(difference) > 100) // Only balance if difference is significant
                {
                    wh.CurrentLoad = targetLoad;
                    string action = difference > 0 ? "Reduced" : "Increased";
                    lstBalanceLog.Items.Add($"{wh.Name}: {action} by {Math.Abs(difference)} kg");
                }
            }

            lstBalanceLog.Items.Add("");
            lstBalanceLog.Items.Add("✅ Load balancing completed!");

            LoadWarehouses();
            UpdateVisualization();

            MessageBox.Show("Load balanced successfully across all warehouses!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindBestWarehouse_Click(object sender, EventArgs e)
        {
            int requiredLoad = (int)numLoadAmount.Value;

            var suitableWarehouses = warehouses
                .Where(w => w.CanAccommodate(requiredLoad))
                .OrderBy(w => w.LoadPercentage)
                .ToList();

            lstBalanceLog.Items.Clear();
            lstBalanceLog.Items.Add($"=== FINDING BEST WAREHOUSE FOR {requiredLoad} kg ===");
            lstBalanceLog.Items.Add("");

            if (suitableWarehouses.Count > 0)
            {
                lstBalanceLog.Items.Add("✅ Suitable Warehouses (sorted by available space):");
                lstBalanceLog.Items.Add("");

                for (int i = 0; i < suitableWarehouses.Count; i++)
                {
                    var wh = suitableWarehouses[i];
                    int availableSpace = wh.Capacity - wh.CurrentLoad;
                    lstBalanceLog.Items.Add($"{i + 1}. {wh.Name}");
                    lstBalanceLog.Items.Add($"   Location: {wh.Location}");
                    lstBalanceLog.Items.Add($"   Current Load: {wh.LoadPercentage:F1}%");
                    lstBalanceLog.Items.Add($"   Available: {availableSpace} kg");
                    lstBalanceLog.Items.Add($"   Cold Storage: {(wh.HasColdStorage ? "✅ Yes" : "❌ No")}");
                    lstBalanceLog.Items.Add("");
                }

                lstBalanceLog.Items.Add($"🎯 RECOMMENDED: {suitableWarehouses[0].Name}");
            }
            else
            {
                lstBalanceLog.Items.Add("❌ No warehouse can accommodate this load!");
                lstBalanceLog.Items.Add("");
                lstBalanceLog.Items.Add("Suggestions:");
                lstBalanceLog.Items.Add("1. Reduce load amount");
                lstBalanceLog.Items.Add("2. Balance existing warehouses");
                lstBalanceLog.Items.Add("3. Remove items from warehouses");
            }
        }

        private void UpdateVisualization()
        {
            panelVisualization.Invalidate();
        }

        private void panelVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int barWidth = 120;
            int barMaxHeight = 300;
            int spacing = 20;
            int startX = 30;
            int startY = 350;

            for (int i = 0; i < warehouses.Count; i++)
            {
                var wh = warehouses[i];
                int x = startX + (barWidth + spacing) * i;

                // Calculate bar height based on load percentage
                int barHeight = (int)(barMaxHeight * (wh.LoadPercentage / 100.0));

                // Determine color based on load
                Color barColor;
                if (wh.LoadPercentage > 80)
                    barColor = Color.FromArgb(231, 76, 60); // Red
                else if (wh.LoadPercentage > 60)
                    barColor = Color.FromArgb(241, 196, 15); // Yellow
                else
                    barColor = Color.FromArgb(46, 204, 113); // Green

                // Draw capacity outline
                g.DrawRectangle(new Pen(Color.Gray, 2), x, startY - barMaxHeight, barWidth, barMaxHeight);

                // Draw load bar
                g.FillRectangle(new SolidBrush(barColor), x, startY - barHeight, barWidth, barHeight);

                // Draw warehouse icon
                string icon = wh.HasColdStorage ? "❄️" : "📦";
                g.DrawString(icon, new Font("Segoe UI", 20), Brushes.Black, x + 40, startY - barMaxHeight - 40);

                // Draw warehouse name
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                g.DrawString(wh.Name, new Font("Arial", 8, FontStyle.Bold), Brushes.Black,
                    x + barWidth / 2, startY + 10, sf);

                // Draw percentage
                g.DrawString($"{wh.LoadPercentage:F1}%", new Font("Arial", 10, FontStyle.Bold),
                    Brushes.White, x + barWidth / 2 - 25, startY - barHeight / 2);

                // Draw load info
                g.DrawString($"{wh.CurrentLoad}/{wh.Capacity} kg", new Font("Arial", 7),
                    Brushes.Black, x + 5, startY + 30);
            }

            // Draw legend
            int legendX = startX;
            int legendY = 400;

            g.FillRectangle(new SolidBrush(Color.FromArgb(46, 204, 113)), legendX, legendY, 20, 20);
            g.DrawString("< 60% (Good)", new Font("Arial", 8), Brushes.Black, legendX + 25, legendY + 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(241, 196, 15)), legendX + 150, legendY, 20, 20);
            g.DrawString("60-80% (Moderate)", new Font("Arial", 8), Brushes.Black, legendX + 175, legendY + 3);

            g.FillRectangle(new SolidBrush(Color.FromArgb(231, 76, 60)), legendX + 350, legendY, 20, 20);
            g.DrawString("> 80% (Critical)", new Font("Arial", 8), Brushes.Black, legendX + 375, legendY + 3);
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWarehouse.SelectedItem != null)
            {
                var warehouse = (Warehouse)cmbWarehouse.SelectedItem;
                lblWarehouseInfo.Text = $"📍 {warehouse.Location} | Capacity: {warehouse.Capacity} kg | " +
                    $"Current: {warehouse.CurrentLoad} kg ({warehouse.LoadPercentage:F1}%) | " +
                    $"Available: {warehouse.Capacity - warehouse.CurrentLoad} kg | " +
                    $"Cold Storage: {(warehouse.HasColdStorage ? "✅" : "❌")} | " +
                    $"Products: {warehouse.Inventory.Count}";
            }
        }
    }
}