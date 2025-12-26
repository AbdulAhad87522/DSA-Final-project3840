// Forms/MainForm.Designer.cs - UPDATED
namespace SmartSupplyChainSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnWarehouseNav;
        private System.Windows.Forms.Button btnTruckRouting;
        private System.Windows.Forms.Button btnProductTracking;
        private System.Windows.Forms.Button btnOrderProcessing;
        private System.Windows.Forms.Button btnLoadBalancing;
        private System.Windows.Forms.Button btnColdStorage;
        private System.Windows.Forms.Button btnProductManager;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelButtons;

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
            this.btnWarehouseNav = new System.Windows.Forms.Button();
            this.btnTruckRouting = new System.Windows.Forms.Button();
            this.btnProductTracking = new System.Windows.Forms.Button();
            this.btnOrderProcessing = new System.Windows.Forms.Button();
            this.btnLoadBalancing = new System.Windows.Forms.Button();
            this.btnColdStorage = new System.Windows.Forms.Button();
            this.btnProductManager = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1050, 125);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🚚 Smart Supply Chain System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnWarehouseNav
            // 
            this.btnWarehouseNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnWarehouseNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouseNav.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnWarehouseNav.ForeColor = System.Drawing.Color.White;
            this.btnWarehouseNav.Location = new System.Drawing.Point(60, 30);
            this.btnWarehouseNav.Name = "btnWarehouseNav";
            this.btnWarehouseNav.Size = new System.Drawing.Size(450, 90);
            this.btnWarehouseNav.TabIndex = 0;
            this.btnWarehouseNav.Text = "📍 Warehouse Navigation (Graph BFS)";
            this.btnWarehouseNav.UseVisualStyleBackColor = false;
            this.btnWarehouseNav.Click += new System.EventHandler(this.btnWarehouseNav_Click);
            // 
            // btnTruckRouting
            // 
            this.btnTruckRouting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnTruckRouting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruckRouting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTruckRouting.ForeColor = System.Drawing.Color.White;
            this.btnTruckRouting.Location = new System.Drawing.Point(540, 30);
            this.btnTruckRouting.Name = "btnTruckRouting";
            this.btnTruckRouting.Size = new System.Drawing.Size(450, 90);
            this.btnTruckRouting.TabIndex = 1;
            this.btnTruckRouting.Text = "🚛 Truck Route Optimization (TSP)";
            this.btnTruckRouting.UseVisualStyleBackColor = false;
            this.btnTruckRouting.Click += new System.EventHandler(this.btnTruckRouting_Click);
            // 
            // btnProductTracking
            // 
            this.btnProductTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnProductTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductTracking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductTracking.ForeColor = System.Drawing.Color.White;
            this.btnProductTracking.Location = new System.Drawing.Point(60, 140);
            this.btnProductTracking.Name = "btnProductTracking";
            this.btnProductTracking.Size = new System.Drawing.Size(450, 90);
            this.btnProductTracking.TabIndex = 2;
            this.btnProductTracking.Text = "📦 Product Tracking (Tree + Stack)";
            this.btnProductTracking.UseVisualStyleBackColor = false;
            this.btnProductTracking.Click += new System.EventHandler(this.btnProductTracking_Click);
            // 
            // btnOrderProcessing
            // 
            this.btnOrderProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnOrderProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderProcessing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrderProcessing.ForeColor = System.Drawing.Color.White;
            this.btnOrderProcessing.Location = new System.Drawing.Point(540, 140);
            this.btnOrderProcessing.Name = "btnOrderProcessing";
            this.btnOrderProcessing.Size = new System.Drawing.Size(450, 90);
            this.btnOrderProcessing.TabIndex = 3;
            this.btnOrderProcessing.Text = "📋 Order Processing (Queue + Priority)";
            this.btnOrderProcessing.UseVisualStyleBackColor = false;
            this.btnOrderProcessing.Click += new System.EventHandler(this.btnOrderProcessing_Click);
            // 
            // btnLoadBalancing
            // 
            this.btnLoadBalancing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLoadBalancing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadBalancing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLoadBalancing.ForeColor = System.Drawing.Color.White;
            this.btnLoadBalancing.Location = new System.Drawing.Point(60, 250);
            this.btnLoadBalancing.Name = "btnLoadBalancing";
            this.btnLoadBalancing.Size = new System.Drawing.Size(450, 90);
            this.btnLoadBalancing.TabIndex = 4;
            this.btnLoadBalancing.Text = "⚖️ Load Balancing (Multi-Warehouse)";
            this.btnLoadBalancing.UseVisualStyleBackColor = false;
            this.btnLoadBalancing.Click += new System.EventHandler(this.btnLoadBalancing_Click);
            // 
            // btnColdStorage
            // 
            this.btnColdStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnColdStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColdStorage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnColdStorage.ForeColor = System.Drawing.Color.White;
            this.btnColdStorage.Location = new System.Drawing.Point(540, 250);
            this.btnColdStorage.Name = "btnColdStorage";
            this.btnColdStorage.Size = new System.Drawing.Size(450, 90);
            this.btnColdStorage.TabIndex = 5;
            this.btnColdStorage.Text = "❄️ Cold Storage Monitoring (Queue)";
            this.btnColdStorage.UseVisualStyleBackColor = false;
            this.btnColdStorage.Click += new System.EventHandler(this.btnColdStorage_Click);
            // 
            // btnProductManager
            // 
            this.btnProductManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnProductManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductManager.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnProductManager.ForeColor = System.Drawing.Color.White;
            this.btnProductManager.Location = new System.Drawing.Point(60, 360);
            this.btnProductManager.Name = "btnProductManager";
            this.btnProductManager.Size = new System.Drawing.Size(930, 90);
            this.btnProductManager.TabIndex = 6;
            this.btnProductManager.Text = "🎯 Product Manager (Track & Dispatch Orders)";
            this.btnProductManager.UseVisualStyleBackColor = false;
            this.btnProductManager.Click += new System.EventHandler(this.btnProductManager_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1050, 125);
            this.panelHeader.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnWarehouseNav);
            this.panelButtons.Controls.Add(this.btnTruckRouting);
            this.panelButtons.Controls.Add(this.btnProductTracking);
            this.panelButtons.Controls.Add(this.btnOrderProcessing);
            this.panelButtons.Controls.Add(this.btnLoadBalancing);
            this.panelButtons.Controls.Add(this.btnColdStorage);
            this.panelButtons.Controls.Add(this.btnProductManager);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 125);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(50);
            this.panelButtons.Size = new System.Drawing.Size(1050, 500);
            this.panelButtons.TabIndex = 1;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtons_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1050, 625);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Supply Chain System";
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}