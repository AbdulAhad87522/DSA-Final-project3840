// Forms/ProductManagerForm.Designer.cs - FIXED VERSION WITH PROPER VISIBILITY
namespace SmartSupplyChainSystem.Forms
{
    partial class ProductManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpOrders;
        private System.Windows.Forms.CheckedListBox lstOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.GroupBox grpOrderDetails;
        private System.Windows.Forms.TextBox txtOrderDetails;
        private System.Windows.Forms.GroupBox grpTracking;
        private System.Windows.Forms.ListBox lstTrackingLog;
        private System.Windows.Forms.Button btnTrackProduct;
        private System.Windows.Forms.GroupBox grpTruckAssignment;
        private System.Windows.Forms.Label lblSelectTruck;
        private System.Windows.Forms.ComboBox cmbTruck;
        private System.Windows.Forms.Button btnAssignTruck;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInstructions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpOrders = new System.Windows.Forms.GroupBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lstOrders = new System.Windows.Forms.CheckedListBox();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.grpOrderDetails = new System.Windows.Forms.GroupBox();
            this.txtOrderDetails = new System.Windows.Forms.TextBox();
            this.grpTracking = new System.Windows.Forms.GroupBox();
            this.lstTrackingLog = new System.Windows.Forms.ListBox();
            this.btnTrackProduct = new System.Windows.Forms.Button();
            this.grpTruckAssignment = new System.Windows.Forms.GroupBox();
            this.lblSelectTruck = new System.Windows.Forms.Label();
            this.cmbTruck = new System.Windows.Forms.ComboBox();
            this.btnAssignTruck = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpOrders.SuspendLayout();
            this.grpOrderDetails.SuspendLayout();
            this.grpTracking.SuspendLayout();
            this.grpTruckAssignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1380, 75);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📦 Product Manager - Order Tracking & Dispatch";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpOrders
            // 
            this.grpOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpOrders.BackColor = System.Drawing.Color.White;
            this.grpOrders.Controls.Add(this.lblInstructions);
            this.grpOrders.Controls.Add(this.lstOrders);
            this.grpOrders.Controls.Add(this.lblTotalOrders);
            this.grpOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpOrders.Location = new System.Drawing.Point(20, 100);
            this.grpOrders.Name = "grpOrders";
            this.grpOrders.Size = new System.Drawing.Size(350, 480);
            this.grpOrders.TabIndex = 1;
            this.grpOrders.TabStop = false;
            this.grpOrders.Text = "📋 Orders Ready for Dispatch";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInstructions.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInstructions.Location = new System.Drawing.Point(15, 35);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(390, 25);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "✓ Check orders to select for truck assignment";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstOrders
            // 
            this.lstOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOrders.CheckOnClick = true;
            this.lstOrders.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.Location = new System.Drawing.Point(15, 65);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(320, 342);
            this.lstOrders.TabIndex = 0;
            this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.Location = new System.Drawing.Point(15, 435);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(320, 30);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "Total Orders: 0";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpOrderDetails
            // 
            this.grpOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrderDetails.BackColor = System.Drawing.Color.White;
            this.grpOrderDetails.Controls.Add(this.txtOrderDetails);
            this.grpOrderDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpOrderDetails.Location = new System.Drawing.Point(390, 100);
            this.grpOrderDetails.Name = "grpOrderDetails";
            this.grpOrderDetails.Size = new System.Drawing.Size(350, 480);
            this.grpOrderDetails.TabIndex = 2;
            this.grpOrderDetails.TabStop = false;
            this.grpOrderDetails.Text = "📄 Order Details";
            // 
            // txtOrderDetails
            // 
            this.txtOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderDetails.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtOrderDetails.Location = new System.Drawing.Point(15, 40);
            this.txtOrderDetails.Multiline = true;
            this.txtOrderDetails.Name = "txtOrderDetails";
            this.txtOrderDetails.ReadOnly = true;
            this.txtOrderDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrderDetails.Size = new System.Drawing.Size(320, 425);
            this.txtOrderDetails.TabIndex = 0;
            this.txtOrderDetails.TextChanged += new System.EventHandler(this.txtOrderDetails_TextChanged);
            // 
            // grpTracking
            // 
            this.grpTracking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTracking.BackColor = System.Drawing.Color.White;
            this.grpTracking.Controls.Add(this.lstTrackingLog);
            this.grpTracking.Controls.Add(this.btnTrackProduct);
            this.grpTracking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpTracking.Location = new System.Drawing.Point(760, 100);
            this.grpTracking.Name = "grpTracking";
            this.grpTracking.Size = new System.Drawing.Size(600, 480);
            this.grpTracking.TabIndex = 3;
            this.grpTracking.TabStop = false;
            this.grpTracking.Text = "🔍 Product Tracking & Route";
            // 
            // lstTrackingLog
            // 
            this.lstTrackingLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTrackingLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstTrackingLog.FormattingEnabled = true;
            this.lstTrackingLog.ItemHeight = 22;
            this.lstTrackingLog.Location = new System.Drawing.Point(15, 90);
            this.lstTrackingLog.Name = "lstTrackingLog";
            this.lstTrackingLog.Size = new System.Drawing.Size(570, 378);
            this.lstTrackingLog.TabIndex = 0;
            // 
            // btnTrackProduct
            // 
            this.btnTrackProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrackProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTrackProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTrackProduct.ForeColor = System.Drawing.Color.White;
            this.btnTrackProduct.Location = new System.Drawing.Point(15, 35);
            this.btnTrackProduct.Name = "btnTrackProduct";
            this.btnTrackProduct.Size = new System.Drawing.Size(570, 45);
            this.btnTrackProduct.TabIndex = 1;
            this.btnTrackProduct.Text = "🔍 Track Selected Order Product";
            this.btnTrackProduct.UseVisualStyleBackColor = false;
            this.btnTrackProduct.Click += new System.EventHandler(this.btnTrackProduct_Click);
            // 
            // grpTruckAssignment
            // 
            this.grpTruckAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTruckAssignment.BackColor = System.Drawing.Color.White;
            this.grpTruckAssignment.Controls.Add(this.lblSelectTruck);
            this.grpTruckAssignment.Controls.Add(this.cmbTruck);
            this.grpTruckAssignment.Controls.Add(this.btnAssignTruck);
            this.grpTruckAssignment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpTruckAssignment.Location = new System.Drawing.Point(20, 600);
            this.grpTruckAssignment.Name = "grpTruckAssignment";
            this.grpTruckAssignment.Size = new System.Drawing.Size(820, 120);
            this.grpTruckAssignment.TabIndex = 4;
            this.grpTruckAssignment.TabStop = false;
            this.grpTruckAssignment.Text = "🚛 Truck Assignment & Dispatch";
            // 
            // lblSelectTruck
            // 
            this.lblSelectTruck.AutoSize = true;
            this.lblSelectTruck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectTruck.Location = new System.Drawing.Point(20, 50);
            this.lblSelectTruck.Name = "lblSelectTruck";
            this.lblSelectTruck.Size = new System.Drawing.Size(118, 28);
            this.lblSelectTruck.TabIndex = 0;
            this.lblSelectTruck.Text = "Select Truck:";
            // 
            // cmbTruck
            // 
            this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTruck.FormattingEnabled = true;
            this.cmbTruck.Location = new System.Drawing.Point(150, 47);
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.Size = new System.Drawing.Size(280, 36);
            this.cmbTruck.TabIndex = 1;
            // 
            // btnAssignTruck
            // 
            this.btnAssignTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAssignTruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignTruck.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAssignTruck.ForeColor = System.Drawing.Color.White;
            this.btnAssignTruck.Location = new System.Drawing.Point(450, 35);
            this.btnAssignTruck.Name = "btnAssignTruck";
            this.btnAssignTruck.Size = new System.Drawing.Size(350, 60);
            this.btnAssignTruck.TabIndex = 2;
            this.btnAssignTruck.Text = "✅ Assign CHECKED Orders to Truck";
            this.btnAssignTruck.UseVisualStyleBackColor = false;
            this.btnAssignTruck.Click += new System.EventHandler(this.btnAssignTruck_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(860, 600);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(500, 55);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄 Refresh Orders & Trucks";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(860, 670);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 50);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Ready - Select orders and assign to truck";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1380, 740);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpTruckAssignment);
            this.Controls.Add(this.grpTracking);
            this.Controls.Add(this.grpOrderDetails);
            this.Controls.Add(this.grpOrders);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new System.Drawing.Size(1400, 780);
            this.Name = "ProductManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Manager - Order Tracking & Dispatch";
            this.grpOrders.ResumeLayout(false);
            this.grpOrderDetails.ResumeLayout(false);
            this.grpOrderDetails.PerformLayout();
            this.grpTracking.ResumeLayout(false);
            this.grpTruckAssignment.ResumeLayout(false);
            this.grpTruckAssignment.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}