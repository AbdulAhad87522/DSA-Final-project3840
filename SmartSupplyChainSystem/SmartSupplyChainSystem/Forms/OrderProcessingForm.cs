// Forms/OrderProcessingForm.cs - UPDATED VERSION
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using SmartSupplyChainSystem.DataStructures;
using SmartSupplyChainSystem.Models;
using SmartSupplyChainSystem.Services;

namespace SmartSupplyChainSystem.Forms
{
    public partial class OrderProcessingForm : Form
    {
        private OrderQueue<Order> normalQueue;
        private PriorityQueue<Order> priorityQueue;
        private InventoryService inventoryService;
        private OrderManagerService orderManager;

        public OrderProcessingForm()
        {
            InitializeComponent();
            normalQueue = new OrderQueue<Order>();
            priorityQueue = new PriorityQueue<Order>();
            inventoryService = new InventoryService();
            orderManager = OrderManagerService.Instance;
            cmbPriority.SelectedIndex = 2; // Default to Normal
            LoadProducts();
            LoadExistingOrders();

            // Subscribe to order changes
            orderManager.OrdersChanged += OrderManager_OrdersChanged;
        }

        private void LoadExistingOrders()
        {
            // Load orders that are already in the system
            var existingOrders = orderManager.GetAllOrders();

            foreach (var order in existingOrders)
            {
                if (order.Status == "Pending")
                {
                    if (order.Priority == 3)
                    {
                        lstNormalQueue.Items.Add(order);
                    }
                    else
                    {
                        // Add to priority queue display
                        RefreshPriorityQueue();
                    }
                }
                else if (order.Status == "Dispatched")
                {
                    lstProcessed.Items.Add($"[DISPATCHED] {order}");
                }
            }

            UpdateQueueCounts();
        }

        private void OrderManager_OrdersChanged(object sender, EventArgs e)
        {
            // Refresh processed list when orders are updated from Product Manager
            RefreshProcessedOrders();
        }

        private void RefreshProcessedOrders()
        {
            lstProcessed.Items.Clear();
            var dispatchedOrders = orderManager.GetOrdersByStatus("Dispatched");

            foreach (var order in dispatchedOrders)
            {
                string priorityTag = order.Priority == 1 ? "[PRIORITY-DISPATCHED]" :
                                    order.Priority == 2 ? "[PRIORITY-DISPATCHED]" :
                                    "[NORMAL-DISPATCHED]";
                lstProcessed.Items.Add($"{priorityTag} {order}");
            }

            UpdateQueueCounts();
        }

        private void LoadProducts()
        {
            cmbProduct.Items.Clear();
            var products = inventoryService.GetAllProducts();
            foreach (var product in products)
            {
                cmbProduct.Items.Add(product);
            }

            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtDeliveryAddress.Text) ||
                cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields including product selection!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if order ID already exists
            if (orderManager.GetOrder(txtOrderId.Text) != null)
            {
                MessageBox.Show("Order ID already exists! Please use a different ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int priority = cmbPriority.SelectedIndex + 1; // 1=Emergency, 2=High, 3=Normal
            var selectedProduct = (Product)cmbProduct.SelectedItem;

            // Check product availability
            if (selectedProduct.Quantity <= 0)
            {
                MessageBox.Show($"Product '{selectedProduct.Name}' is out of stock!", "Stock Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var order = new Order(
                txtOrderId.Text,
                txtCustomerName.Text,
                txtDeliveryAddress.Text,
                priority
            );

            // Add selected product to order
            order.Products.Add(selectedProduct);
            order.AssignedWarehouse = selectedProduct.Warehouse;
            order.Status = "Pending"; // Initial status

            // Add to shared order manager
            orderManager.AddOrder(order);

            // Add to local queues for display
            if (priority == 3) // Normal
            {
                normalQueue.Enqueue(order);
                lstNormalQueue.Items.Add(order);
            }
            else // Emergency or High
            {
                priorityQueue.Enqueue(order, priority);
                RefreshPriorityQueue();
            }

            UpdateQueueCounts();
            ClearInputs();

            MessageBox.Show($"✅ Order '{order.OrderId}' added successfully!\n" +
                          $"Product: {selectedProduct.Name}\n" +
                          $"Warehouse: {selectedProduct.Warehouse}\n" +
                          $"Status: {order.Status}\n\n" +
                          $"Order is now ready for dispatch in Product Manager!",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProcessNormal_Click(object sender, EventArgs e)
        {
            if (normalQueue.Count == 0)
            {
                MessageBox.Show("Normal queue is empty!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var order = normalQueue.Dequeue();
            order.Status = "Processing";
            orderManager.UpdateOrderStatus(order.OrderId, "Processing");

            lstProcessed.Items.Add($"[NORMAL] {order}");
            lstNormalQueue.Items.RemoveAt(0);

            UpdateQueueCounts();
            lblLastProcessed.Text = $"✅ Last Processed: {order.OrderId} - {order.CustomerName} - {order.Products[0].Name}";
            lblLastProcessed.ForeColor = Color.Green;
        }

        private void btnProcessPriority_Click(object sender, EventArgs e)
        {
            if (priorityQueue.Count == 0)
            {
                MessageBox.Show("Priority queue is empty!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var order = priorityQueue.Dequeue();
            order.Status = "Processing";
            orderManager.UpdateOrderStatus(order.OrderId, "Processing");

            lstProcessed.Items.Add($"[PRIORITY] {order}");
            RefreshPriorityQueue();

            UpdateQueueCounts();
            lblLastProcessed.Text = $"⚡ Last Processed: {order.OrderId} - {order.CustomerName} - {order.Products[0].Name}";
            lblLastProcessed.ForeColor = Color.OrangeRed;
        }

        private void RefreshPriorityQueue()
        {
            lstPriorityQueue.Items.Clear();
            var orders = priorityQueue.GetAllOrders();
            foreach (var item in orders)
            {
                lstPriorityQueue.Items.Add(item.item);
            }
        }

        private void UpdateQueueCounts()
        {
            lblNormalCount.Text = $"📦 Normal Orders: {normalQueue.Count}";
            lblPriorityCount.Text = $"⚡ Priority Orders: {priorityQueue.Count}";
            lblProcessedCount.Text = $"✅ Processed: {lstProcessed.Items.Count}";
        }

        private void ClearInputs()
        {
            txtOrderId.Clear();
            txtCustomerName.Clear();
            txtDeliveryAddress.Clear();
            cmbPriority.SelectedIndex = 2; // Default to Normal
            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Clear all queues? This will NOT delete orders from Product Manager.",
                "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                normalQueue = new OrderQueue<Order>();
                priorityQueue = new PriorityQueue<Order>();
                lstNormalQueue.Items.Clear();
                lstPriorityQueue.Items.Clear();
                lstProcessed.Items.Clear();
                UpdateQueueCounts();
                lblLastProcessed.Text = "Ready to process orders";
                lblLastProcessed.ForeColor = Color.Black;
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem != null)
            {
                var product = (Product)cmbProduct.SelectedItem;
                lblProductInfo.Text = $"📦 {product.Name} | Category: {product.Category} | " +
                                    $"Stock: {product.Quantity} | Warehouse: {product.Warehouse} | " +
                                    $"Cold Storage: {(product.IsColdStorage ? "✅" : "❌")}";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unsubscribe from events
            orderManager.OrdersChanged -= OrderManager_OrdersChanged;
            base.OnFormClosing(e);
        }

        private void grpOrderInput_Enter(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblProductInfo_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderId_Click(object sender, EventArgs e)
        {

        }

        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProduct_Click(object sender, EventArgs e)
        {

        }

        private void lblDeliveryAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtDeliveryAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPriority_Click(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpNormalQueue_Enter(object sender, EventArgs e)
        {

        }

        private void lstNormalQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNormalCount_Click(object sender, EventArgs e)
        {

        }

        private void grpPriorityQueue_Enter(object sender, EventArgs e)
        {

        }

        private void lstPriorityQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPriorityCount_Click(object sender, EventArgs e)
        {

        }

        private void grpProcessed_Enter(object sender, EventArgs e)
        {

        }

        private void lstProcessed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblProcessedCount_Click(object sender, EventArgs e)
        {

        }

        private void lblLastProcessed_Click(object sender, EventArgs e)
        {

        }
    }
}