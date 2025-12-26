// Forms/ProductTrackingForm.cs - WITH WAREHOUSE SECTIONS & PRODUCTS IN TREE
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
    public partial class ProductTrackingForm : Form
    {
        private InventoryService inventoryService;
        private UndoRedoStack<ProductAction> undoRedoStack;
        private List<Product> products;

        public ProductTrackingForm()
        {
            InitializeComponent();
            inventoryService = new InventoryService();
            undoRedoStack = new UndoRedoStack<ProductAction>();
            products = new List<Product>();

            // Load all products from inventory service
            products = inventoryService.GetAllProducts();

            LoadInventoryTree();
            LoadCategories();
            RefreshProductList();
            UpdateUndoRedoButtons();
        }

        private void LoadInventoryTree()
        {
            treeInventory.Nodes.Clear();
            TreeNode rootNode = new TreeNode("🏭 Warehouse Inventory");
            rootNode.Tag = "ROOT";

            // Get all warehouse locations
            var warehouseLocations = new Dictionary<string, List<Product>>();

            foreach (var product in products)
            {
                if (!warehouseLocations.ContainsKey(product.Warehouse))
                {
                    warehouseLocations[product.Warehouse] = new List<Product>();
                }
                warehouseLocations[product.Warehouse].Add(product);
            }

            // Build tree by warehouse location
            foreach (var location in warehouseLocations.Keys.OrderBy(k => k))
            {
                TreeNode locationNode = new TreeNode($"📍 {location} ({warehouseLocations[location].Count} products)");
                locationNode.Tag = $"LOCATION:{location}";
                locationNode.ForeColor = Color.DarkBlue;

                // Group products by category within this location
                var categoriesInLocation = warehouseLocations[location]
                    .GroupBy(p => p.Category)
                    .OrderBy(g => g.Key);

                foreach (var categoryGroup in categoriesInLocation)
                {
                    TreeNode categoryNode = new TreeNode($"📂 {categoryGroup.Key} ({categoryGroup.Count()})");
                    categoryNode.Tag = $"CATEGORY:{categoryGroup.Key}";
                    categoryNode.ForeColor = Color.DarkGreen;

                    // Add individual products
                    foreach (var product in categoryGroup.OrderBy(p => p.Name))
                    {
                        string coldIcon = product.IsColdStorage ? "❄️" : "📦";
                        TreeNode productNode = new TreeNode(
                            $"{coldIcon} {product.Name} ({product.Quantity} units)"
                        );
                        productNode.Tag = product;
                        productNode.ForeColor = product.IsColdStorage ? Color.Blue : Color.Black;

                        categoryNode.Nodes.Add(productNode);
                    }

                    locationNode.Nodes.Add(categoryNode);
                }

                rootNode.Nodes.Add(locationNode);
            }

            treeInventory.Nodes.Add(rootNode);
            rootNode.Expand();

            // Expand all warehouse sections
            foreach (TreeNode locationNode in rootNode.Nodes)
            {
                locationNode.Expand();
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            var categories = inventoryService.GetAllCategories();
            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category);
            }
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if product ID already exists
            if (products.Any(p => p.ProductId == txtProductId.Text))
            {
                MessageBox.Show("Product ID already exists! Please use a unique ID.",
                    "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine warehouse based on category
            string warehouse = DetermineWarehouse(cmbCategory.SelectedItem.ToString());

            var product = new Product(
                txtProductId.Text,
                txtProductName.Text,
                cmbCategory.SelectedItem.ToString(),
                (int)numQuantity.Value,
                warehouse,
                chkColdStorage.Checked
            );

            inventoryService.AddProduct(product);
            products.Add(product);

            // Add to undo stack
            var action = new ProductAction("ADD", product);
            undoRedoStack.Push(action);

            LoadInventoryTree(); // Refresh tree
            RefreshProductList();
            ClearInputs();
            UpdateUndoRedoButtons();

            MessageBox.Show($"✅ Product '{product.Name}' added successfully!\n\n" +
                          $"📍 Warehouse Location: {warehouse}\n" +
                          $"📂 Category: {product.Category}\n" +
                          $"📦 Quantity: {product.Quantity} units",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string DetermineWarehouse(string category)
        {
            // Determine warehouse section based on category
            var categoryWarehouseMap = new Dictionary<string, string>
            {
                { "Laptops", "Section-A" },
                { "Mobile Phones", "Section-A" },
                { "Tablets", "Section-B" },
                { "Frozen Food", "Storage-1" },
                { "Fresh Produce", "Storage-2" },
                { "Dairy Products", "Storage-2" },
                { "Men's Wear", "Section-C" },
                { "Women's Wear", "Section-C" },
                { "Office Furniture", "Loading-Dock" },
                { "Home Furniture", "Loading-Dock" }
            };

            return categoryWarehouseMap.ContainsKey(category)
                ? categoryWarehouseMap[category]
                : "Section-A";
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to update!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (Product)lstProducts.SelectedItem;
            var previousState = new Product(
                selectedProduct.ProductId,
                selectedProduct.Name,
                selectedProduct.Category,
                selectedProduct.Quantity,
                selectedProduct.Warehouse,
                selectedProduct.IsColdStorage
            );

            selectedProduct.Name = txtProductName.Text;
            selectedProduct.Category = cmbCategory.SelectedItem.ToString();
            selectedProduct.Quantity = (int)numQuantity.Value;
            selectedProduct.IsColdStorage = chkColdStorage.Checked;
            selectedProduct.Warehouse = DetermineWarehouse(selectedProduct.Category);
            selectedProduct.LastUpdated = DateTime.Now;

            // Add to undo stack
            var action = new ProductAction("UPDATE", selectedProduct, previousState);
            undoRedoStack.Push(action);

            LoadInventoryTree(); // Refresh tree
            RefreshProductList();
            UpdateUndoRedoButtons();

            MessageBox.Show($"✅ Product '{selectedProduct.Name}' updated!\n\n" +
                          $"📍 New Location: {selectedProduct.Warehouse}",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to delete!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (Product)lstProducts.SelectedItem;
            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedProduct.Name}'?\n\n" +
                $"📍 Location: {selectedProduct.Warehouse}\n" +
                $"📂 Category: {selectedProduct.Category}",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                inventoryService.RemoveProduct(selectedProduct.ProductId);
                products.Remove(selectedProduct);

                // Add to undo stack
                var action = new ProductAction("DELETE", selectedProduct);
                undoRedoStack.Push(action);

                LoadInventoryTree(); // Refresh tree
                RefreshProductList();
                ClearInputs();
                UpdateUndoRedoButtons();

                MessageBox.Show($"✅ Product '{selectedProduct.Name}' deleted!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (!undoRedoStack.CanUndo)
            {
                MessageBox.Show("Nothing to undo!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var action = undoRedoStack.Undo();
            PerformUndoAction(action);
            LoadInventoryTree(); // Refresh tree
            RefreshProductList();
            UpdateUndoRedoButtons();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (!undoRedoStack.CanRedo)
            {
                MessageBox.Show("Nothing to redo!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var action = undoRedoStack.Redo();
            PerformRedoAction(action);
            LoadInventoryTree(); // Refresh tree
            RefreshProductList();
            UpdateUndoRedoButtons();
        }

        private void PerformUndoAction(ProductAction action)
        {
            switch (action.ActionType)
            {
                case "ADD":
                    inventoryService.RemoveProduct(action.Product.ProductId);
                    products.Remove(action.Product);
                    lblStatus.Text = $"⏪ Undone: Added '{action.Product.Name}'";
                    break;

                case "UPDATE":
                    var product = inventoryService.GetProduct(action.Product.ProductId);
                    if (product != null && action.PreviousState != null)
                    {
                        product.Name = action.PreviousState.Name;
                        product.Category = action.PreviousState.Category;
                        product.Quantity = action.PreviousState.Quantity;
                        product.IsColdStorage = action.PreviousState.IsColdStorage;
                        product.Warehouse = action.PreviousState.Warehouse;
                    }
                    lblStatus.Text = $"⏪ Undone: Updated '{action.Product.Name}'";
                    break;

                case "DELETE":
                    inventoryService.AddProduct(action.Product);
                    products.Add(action.Product);
                    lblStatus.Text = $"⏪ Undone: Deleted '{action.Product.Name}'";
                    break;
            }
            lblStatus.ForeColor = Color.Orange;
        }

        private void PerformRedoAction(ProductAction action)
        {
            switch (action.ActionType)
            {
                case "ADD":
                    inventoryService.AddProduct(action.Product);
                    products.Add(action.Product);
                    lblStatus.Text = $"⏩ Redone: Added '{action.Product.Name}'";
                    break;

                case "UPDATE":
                    var product = inventoryService.GetProduct(action.Product.ProductId);
                    if (product != null)
                    {
                        product.Name = action.Product.Name;
                        product.Category = action.Product.Category;
                        product.Quantity = action.Product.Quantity;
                        product.IsColdStorage = action.Product.IsColdStorage;
                        product.Warehouse = action.Product.Warehouse;
                    }
                    lblStatus.Text = $"⏩ Redone: Updated '{action.Product.Name}'";
                    break;

                case "DELETE":
                    inventoryService.RemoveProduct(action.Product.ProductId);
                    products.Remove(action.Product);
                    lblStatus.Text = $"⏩ Redone: Deleted '{action.Product.Name}'";
                    break;
            }
            lblStatus.ForeColor = Color.Green;
        }

        private void UpdateUndoRedoButtons()
        {
            btnUndo.Enabled = undoRedoStack.CanUndo;
            btnRedo.Enabled = undoRedoStack.CanRedo;
        }

        private void RefreshProductList()
        {
            lstProducts.Items.Clear();
            foreach (var product in products.OrderBy(p => p.Warehouse).ThenBy(p => p.Name))
            {
                lstProducts.Items.Add(product);
            }
            lblTotalProducts.Text = $"Total Products: {products.Count}";
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProducts.SelectedItem != null)
            {
                var product = (Product)lstProducts.SelectedItem;
                txtProductId.Text = product.ProductId;
                txtProductName.Text = product.Name;
                cmbCategory.SelectedItem = product.Category;
                numQuantity.Value = product.Quantity;
                chkColdStorage.Checked = product.IsColdStorage;

                lblStatus.Text = $"Selected: {product.Name} | Location: {product.Warehouse}";
                lblStatus.ForeColor = Color.Blue;
            }
        }

        private void treeInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // When user clicks on a product in tree, select it in the list too
            if (e.Node.Tag is Product product)
            {
                int index = lstProducts.Items.IndexOf(product);
                if (index >= 0)
                {
                    lstProducts.SelectedIndex = index;
                }
            }
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            numQuantity.Value = 0;
            chkColdStorage.Checked = false;
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Black;
        }

        private void btnClearInputs_Click(object sender, EventArgs e)
        {
            ClearInputs();
            lstProducts.ClearSelected();
        }

        private void grpProductInfo_Enter(object sender, EventArgs e) { }
        private void numQuantity_ValueChanged(object sender, EventArgs e) { }
        private void ProductTrackingForm_Load(object sender, EventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}