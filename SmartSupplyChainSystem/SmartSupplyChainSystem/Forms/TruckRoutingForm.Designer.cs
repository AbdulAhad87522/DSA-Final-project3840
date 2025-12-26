// Forms/TruckRoutingForm.Designer.cs - FINAL COMPLETE VERSION
namespace SmartSupplyChainSystem.Forms
{
    partial class TruckRoutingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectTruck;
        private System.Windows.Forms.ComboBox cmbTruck;
        private System.Windows.Forms.Label lblTruckInfo;
        private System.Windows.Forms.Label lblDestinationMode;
        private System.Windows.Forms.CheckedListBox lstDestinations;
        private System.Windows.Forms.ListBox lstOptimizedRoute;
        private System.Windows.Forms.Button btnOptimizeRoute;
        private System.Windows.Forms.Button btnResetRoute;
        private System.Windows.Forms.Panel panelVisualization;
        private System.Windows.Forms.Label lblRouteInfo;
        private System.Windows.Forms.GroupBox grpDestinations;
        private System.Windows.Forms.GroupBox grpRouteDetails;

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
            this.lblSelectTruck = new System.Windows.Forms.Label();
            this.cmbTruck = new System.Windows.Forms.ComboBox();
            this.lblTruckInfo = new System.Windows.Forms.Label();
            this.grpDestinations = new System.Windows.Forms.GroupBox();
            this.lblDestinationMode = new System.Windows.Forms.Label();
            this.lstDestinations = new System.Windows.Forms.CheckedListBox();
            this.grpRouteDetails = new System.Windows.Forms.GroupBox();
            this.lstOptimizedRoute = new System.Windows.Forms.ListBox();
            this.btnOptimizeRoute = new System.Windows.Forms.Button();
            this.btnResetRoute = new System.Windows.Forms.Button();
            this.panelVisualization = new System.Windows.Forms.Panel();
            this.lblRouteInfo = new System.Windows.Forms.Label();
            this.grpDestinations.SuspendLayout();
            this.grpRouteDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1807, 75);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🚛 Truck Route Optimization (TSP Algorithm)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSelectTruck
            // 
            this.lblSelectTruck.AutoSize = true;
            this.lblSelectTruck.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectTruck.Location = new System.Drawing.Point(22, 100);
            this.lblSelectTruck.Name = "lblSelectTruck";
            this.lblSelectTruck.Size = new System.Drawing.Size(144, 30);
            this.lblSelectTruck.TabIndex = 1;
            this.lblSelectTruck.Text = "Select Truck:";
            this.lblSelectTruck.Click += new System.EventHandler(this.lblSelectTruck_Click);
            // 
            // cmbTruck
            // 
            this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTruck.FormattingEnabled = true;
            this.cmbTruck.Location = new System.Drawing.Point(158, 98);
            this.cmbTruck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.Size = new System.Drawing.Size(337, 36);
            this.cmbTruck.TabIndex = 2;
            this.cmbTruck.SelectedIndexChanged += new System.EventHandler(this.cmbTruck_SelectedIndexChanged);
            // 
            // lblTruckInfo
            // 
            this.lblTruckInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTruckInfo.Location = new System.Drawing.Point(518, 100);
            this.lblTruckInfo.Name = "lblTruckInfo";
            this.lblTruckInfo.Size = new System.Drawing.Size(810, 38);
            this.lblTruckInfo.TabIndex = 3;
            this.lblTruckInfo.Text = "Select a truck to view details";
            this.lblTruckInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTruckInfo.Click += new System.EventHandler(this.lblTruckInfo_Click);
            // 
            // grpDestinations
            // 
            this.grpDestinations.BackColor = System.Drawing.Color.White;
            this.grpDestinations.Controls.Add(this.lblDestinationMode);
            this.grpDestinations.Controls.Add(this.lstDestinations);
            this.grpDestinations.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpDestinations.Location = new System.Drawing.Point(22, 162);
            this.grpDestinations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDestinations.Name = "grpDestinations";
            this.grpDestinations.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDestinations.Size = new System.Drawing.Size(315, 500);
            this.grpDestinations.TabIndex = 4;
            this.grpDestinations.TabStop = false;
            this.grpDestinations.Text = "🎯 Destinations";
            this.grpDestinations.Enter += new System.EventHandler(this.grpDestinations_Enter);
            // 
            // lblDestinationMode
            // 
            this.lblDestinationMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDestinationMode.Location = new System.Drawing.Point(17, 35);
            this.lblDestinationMode.Name = "lblDestinationMode";
            this.lblDestinationMode.Size = new System.Drawing.Size(281, 25);
            this.lblDestinationMode.TabIndex = 1;
            this.lblDestinationMode.Text = "Select destinations:";
            this.lblDestinationMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDestinationMode.Click += new System.EventHandler(this.lblDestinationMode_Click);
            // 
            // lstDestinations
            // 
            this.lstDestinations.CheckOnClick = true;
            this.lstDestinations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstDestinations.FormattingEnabled = true;
            this.lstDestinations.Location = new System.Drawing.Point(17, 70);
            this.lstDestinations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstDestinations.Name = "lstDestinations";
            this.lstDestinations.Size = new System.Drawing.Size(281, 368);
            this.lstDestinations.TabIndex = 0;
            this.lstDestinations.SelectedIndexChanged += new System.EventHandler(this.lstDestinations_SelectedIndexChanged);
            // 
            // grpRouteDetails
            // 
            this.grpRouteDetails.BackColor = System.Drawing.Color.White;
            this.grpRouteDetails.Controls.Add(this.lstOptimizedRoute);
            this.grpRouteDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpRouteDetails.Location = new System.Drawing.Point(1503, 162);
            this.grpRouteDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRouteDetails.Name = "grpRouteDetails";
            this.grpRouteDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRouteDetails.Size = new System.Drawing.Size(292, 500);
            this.grpRouteDetails.TabIndex = 5;
            this.grpRouteDetails.TabStop = false;
            this.grpRouteDetails.Text = "📍 Optimized Route";
            this.grpRouteDetails.Enter += new System.EventHandler(this.grpRouteDetails_Enter);
            // 
            // lstOptimizedRoute
            // 
            this.lstOptimizedRoute.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstOptimizedRoute.FormattingEnabled = true;
            this.lstOptimizedRoute.ItemHeight = 22;
            this.lstOptimizedRoute.Location = new System.Drawing.Point(17, 44);
            this.lstOptimizedRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstOptimizedRoute.Name = "lstOptimizedRoute";
            this.lstOptimizedRoute.Size = new System.Drawing.Size(258, 422);
            this.lstOptimizedRoute.TabIndex = 0;
            this.lstOptimizedRoute.SelectedIndexChanged += new System.EventHandler(this.lstOptimizedRoute_SelectedIndexChanged);
            // 
            // btnOptimizeRoute
            // 
            this.btnOptimizeRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOptimizeRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptimizeRoute.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOptimizeRoute.ForeColor = System.Drawing.Color.White;
            this.btnOptimizeRoute.Location = new System.Drawing.Point(22, 688);
            this.btnOptimizeRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOptimizeRoute.Name = "btnOptimizeRoute";
            this.btnOptimizeRoute.Size = new System.Drawing.Size(315, 62);
            this.btnOptimizeRoute.TabIndex = 6;
            this.btnOptimizeRoute.Text = "🚀 Optimize Route";
            this.btnOptimizeRoute.UseVisualStyleBackColor = false;
            this.btnOptimizeRoute.Click += new System.EventHandler(this.btnOptimizeRoute_Click);
            // 
            // btnResetRoute
            // 
            this.btnResetRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnResetRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRoute.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnResetRoute.ForeColor = System.Drawing.Color.White;
            this.btnResetRoute.Location = new System.Drawing.Point(1035, 688);
            this.btnResetRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResetRoute.Name = "btnResetRoute";
            this.btnResetRoute.Size = new System.Drawing.Size(292, 62);
            this.btnResetRoute.TabIndex = 7;
            this.btnResetRoute.Text = "🔄 Reset Route";
            this.btnResetRoute.UseVisualStyleBackColor = false;
            this.btnResetRoute.Click += new System.EventHandler(this.btnResetRoute_Click);
            // 
            // panelVisualization
            // 
            this.panelVisualization.BackColor = System.Drawing.Color.White;
            this.panelVisualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVisualization.Location = new System.Drawing.Point(360, 162);
            this.panelVisualization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelVisualization.Name = "panelVisualization";
            this.panelVisualization.Size = new System.Drawing.Size(1118, 500);
            this.panelVisualization.TabIndex = 8;
            this.panelVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVisualization_Paint);
            // 
            // lblRouteInfo
            // 
            this.lblRouteInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRouteInfo.Location = new System.Drawing.Point(360, 700);
            this.lblRouteInfo.Name = "lblRouteInfo";
            this.lblRouteInfo.Size = new System.Drawing.Size(652, 38);
            this.lblRouteInfo.TabIndex = 9;
            this.lblRouteInfo.Text = "Select destinations and click \'Optimize Route\'";
            this.lblRouteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRouteInfo.Click += new System.EventHandler(this.lblRouteInfo_Click);
            // 
            // TruckRoutingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1807, 775);
            this.Controls.Add(this.lblRouteInfo);
            this.Controls.Add(this.panelVisualization);
            this.Controls.Add(this.btnResetRoute);
            this.Controls.Add(this.btnOptimizeRoute);
            this.Controls.Add(this.grpRouteDetails);
            this.Controls.Add(this.grpDestinations);
            this.Controls.Add(this.lblTruckInfo);
            this.Controls.Add(this.cmbTruck);
            this.Controls.Add(this.lblSelectTruck);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TruckRoutingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truck Route Optimization";
            this.grpDestinations.ResumeLayout(false);
            this.grpRouteDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}