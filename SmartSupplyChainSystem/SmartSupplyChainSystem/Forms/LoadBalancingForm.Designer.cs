// Forms/LoadBalancingForm.Designer.cs
namespace SmartSupplyChainSystem.Forms
{
    partial class LoadBalancingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelVisualization;
        private System.Windows.Forms.GroupBox grpWarehouseControl;
        private System.Windows.Forms.Label lblSelectWarehouse;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblWarehouseInfo;
        private System.Windows.Forms.Label lblLoadAmount;
        private System.Windows.Forms.NumericUpDown numLoadAmount;
        private System.Windows.Forms.Button btnAddLoad;
        private System.Windows.Forms.Button btnRemoveLoad;
        private System.Windows.Forms.Button btnAutoBalance;
        private System.Windows.Forms.Button btnFindBestWarehouse;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.Label lblTotalCapacity;
        private System.Windows.Forms.Label lblTotalLoad;
        private System.Windows.Forms.Label lblAvgLoad;
        private System.Windows.Forms.Label lblMostLoaded;
        private System.Windows.Forms.Label lblLeastLoaded;
        private System.Windows.Forms.ListBox lstWarehouses;
        private System.Windows.Forms.ListBox lstBalanceLog;
        private System.Windows.Forms.GroupBox grpWarehouseList;
        private System.Windows.Forms.GroupBox grpBalanceLog;

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
            this.panelVisualization = new System.Windows.Forms.Panel();
            this.grpWarehouseControl = new System.Windows.Forms.GroupBox();
            this.lblSelectWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblWarehouseInfo = new System.Windows.Forms.Label();
            this.lblLoadAmount = new System.Windows.Forms.Label();
            this.numLoadAmount = new System.Windows.Forms.NumericUpDown();
            this.btnAddLoad = new System.Windows.Forms.Button();
            this.btnRemoveLoad = new System.Windows.Forms.Button();
            this.btnAutoBalance = new System.Windows.Forms.Button();
            this.btnFindBestWarehouse = new System.Windows.Forms.Button();
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.lblTotalCapacity = new System.Windows.Forms.Label();
            this.lblTotalLoad = new System.Windows.Forms.Label();
            this.lblAvgLoad = new System.Windows.Forms.Label();
            this.lblMostLoaded = new System.Windows.Forms.Label();
            this.lblLeastLoaded = new System.Windows.Forms.Label();
            this.grpWarehouseList = new System.Windows.Forms.GroupBox();
            this.lstWarehouses = new System.Windows.Forms.ListBox();
            this.grpBalanceLog = new System.Windows.Forms.GroupBox();
            this.lstBalanceLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadAmount)).BeginInit();
            this.grpWarehouseControl.SuspendLayout();
            this.grpStatistics.SuspendLayout();
            this.grpWarehouseList.SuspendLayout();
            this.grpBalanceLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚖️ Load Balancing (Multi-Warehouse Distribution)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelVisualization
            // 
            this.panelVisualization.BackColor = System.Drawing.Color.White;
            this.panelVisualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVisualization.Location = new System.Drawing.Point(20, 80);
            this.panelVisualization.Name = "panelVisualization";
            this.panelVisualization.Size = new System.Drawing.Size(720, 450);
            this.panelVisualization.TabIndex = 1;
            this.panelVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVisualization_Paint);
            // 
            // grpWarehouseControl
            // 
            this.grpWarehouseControl.BackColor = System.Drawing.Color.White;
            this.grpWarehouseControl.Controls.Add(this.lblSelectWarehouse);
            this.grpWarehouseControl.Controls.Add(this.cmbWarehouse);
            this.grpWarehouseControl.Controls.Add(this.lblWarehouseInfo);
            this.grpWarehouseControl.Controls.Add(this.lblLoadAmount);
            this.grpWarehouseControl.Controls.Add(this.numLoadAmount);
            this.grpWarehouseControl.Controls.Add(this.btnAddLoad);
            this.grpWarehouseControl.Controls.Add(this.btnRemoveLoad);
            this.grpWarehouseControl.Controls.Add(this.btnAutoBalance);
            this.grpWarehouseControl.Controls.Add(this.btnFindBestWarehouse);
            this.grpWarehouseControl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpWarehouseControl.Location = new System.Drawing.Point(760, 80);
            this.grpWarehouseControl.Name = "grpWarehouseControl";
            this.grpWarehouseControl.Size = new System.Drawing.Size(620, 280);
            this.grpWarehouseControl.TabIndex = 2;
            this.grpWarehouseControl.TabStop = false;
            this.grpWarehouseControl.Text = "Warehouse Control";
            // 
            // lblSelectWarehouse
            // 
            this.lblSelectWarehouse.AutoSize = true;
            this.lblSelectWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectWarehouse.Location = new System.Drawing.Point(20, 35);
            this.lblSelectWarehouse.Name = "lblSelectWarehouse";
            this.lblSelectWarehouse.Size = new System.Drawing.Size(146, 23);
            this.lblSelectWarehouse.TabIndex = 0;
            this.lblSelectWarehouse.Text = "Select Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(180, 32);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(420, 31);
            this.cmbWarehouse.TabIndex = 1;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // lblWarehouseInfo
            // 
            this.lblWarehouseInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWarehouseInfo.Location = new System.Drawing.Point(20, 75);
            this.lblWarehouseInfo.Name = "lblWarehouseInfo";
            this.lblWarehouseInfo.Size = new System.Drawing.Size(580, 40);
            this.lblWarehouseInfo.TabIndex = 2;
            this.lblWarehouseInfo.Text = "Select a warehouse to view details";
            // 
            // lblLoadAmount
            // 
            this.lblLoadAmount.AutoSize = true;
            this.lblLoadAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoadAmount.Location = new System.Drawing.Point(20, 125);
            this.lblLoadAmount.Name = "lblLoadAmount";
            this.lblLoadAmount.Size = new System.Drawing.Size(120, 23);
            this.lblLoadAmount.TabIndex = 3;
            this.lblLoadAmount.Text = "Load Amount:";
            // 
            // numLoadAmount
            // 
            this.numLoadAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numLoadAmount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLoadAmount.Location = new System.Drawing.Point(180, 123);
            this.numLoadAmount.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numLoadAmount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLoadAmount.Name = "numLoadAmount";
            this.numLoadAmount.Size = new System.Drawing.Size(150, 30);
            this.numLoadAmount.TabIndex = 4;
            this.numLoadAmount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddLoad.ForeColor = System.Drawing.Color.White;
            this.btnAddLoad.Location = new System.Drawing.Point(20, 170);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(140, 40);
            this.btnAddLoad.TabIndex = 5;
            this.btnAddLoad.Text = "➕ Add Load";
            this.btnAddLoad.UseVisualStyleBackColor = false;
            this.btnAddLoad.Click += new System.EventHandler(this.btnAddLoad_Click);
            // 
            // btnRemoveLoad
            // 
            this.btnRemoveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveLoad.ForeColor = System.Drawing.Color.White;
            this.btnRemoveLoad.Location = new System.Drawing.Point(170, 170);
            this.btnRemoveLoad.Name = "btnRemoveLoad";
            this.btnRemoveLoad.Size = new System.Drawing.Size(140, 40);
            this.btnRemoveLoad.TabIndex = 6;
            this.btnRemoveLoad.Text = "➖ Remove Load";
            this.btnRemoveLoad.UseVisualStyleBackColor = false;
            this.btnRemoveLoad.Click += new System.EventHandler(this.btnRemoveLoad_Click);
            // 
            // btnAutoBalance
            // 
            this.btnAutoBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAutoBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAutoBalance.ForeColor = System.Drawing.Color.White;
            this.btnAutoBalance.Location = new System.Drawing.Point(20, 225);
            this.btnAutoBalance.Name = "btnAutoBalance";
            this.btnAutoBalance.Size = new System.Drawing.Size(290, 40);
            this.btnAutoBalance.TabIndex = 7;
            this.btnAutoBalance.Text = "⚖️ Auto Balance All Warehouses";
            this.btnAutoBalance.UseVisualStyleBackColor = false;
            this.btnAutoBalance.Click += new System.EventHandler(this.btnAutoBalance_Click);
            // 
            // btnFindBestWarehouse
            // 
            this.btnFindBestWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnFindBestWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindBestWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFindBestWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnFindBestWarehouse.Location = new System.Drawing.Point(320, 170);
            this.btnFindBestWarehouse.Name = "btnFindBestWarehouse";
            this.btnFindBestWarehouse.Size = new System.Drawing.Size(280, 95);
            this.btnFindBestWarehouse.TabIndex = 8;
            this.btnFindBestWarehouse.Text = "🎯 Find Best Warehouse\r\nfor Load";
            this.btnFindBestWarehouse.UseVisualStyleBackColor = false;
            this.btnFindBestWarehouse.Click += new System.EventHandler(this.btnFindBestWarehouse_Click);
            // 
            // grpStatistics
            // 
            this.grpStatistics.BackColor = System.Drawing.Color.White;
            this.grpStatistics.Controls.Add(this.lblTotalCapacity);
            this.grpStatistics.Controls.Add(this.lblTotalLoad);
            this.grpStatistics.Controls.Add(this.lblAvgLoad);
            this.grpStatistics.Controls.Add(this.lblMostLoaded);
            this.grpStatistics.Controls.Add(this.lblLeastLoaded);
            this.grpStatistics.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpStatistics.Location = new System.Drawing.Point(20, 550);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.Size = new System.Drawing.Size(720, 140);
            this.grpStatistics.TabIndex = 3;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "📊 Statistics";
            // 
            // lblTotalCapacity
            // 
            this.lblTotalCapacity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCapacity.Location = new System.Drawing.Point(20, 35);
            this.lblTotalCapacity.Name = "lblTotalCapacity";
            this.lblTotalCapacity.Size = new System.Drawing.Size(330, 25);
            this.lblTotalCapacity.TabIndex = 0;
            this.lblTotalCapacity.Text = "Total Capacity: 0 kg";
            // 
            // lblTotalLoad
            // 
            this.lblTotalLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalLoad.Location = new System.Drawing.Point(370, 35);
            this.lblTotalLoad.Name = "lblTotalLoad";
            this.lblTotalLoad.Size = new System.Drawing.Size(330, 25);
            this.lblTotalLoad.TabIndex = 1;
            this.lblTotalLoad.Text = "Total Load: 0 kg";
            //
            // lblAvgLoad
            //
            this.lblAvgLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgLoad.Location = new System.Drawing.Point(20, 70);
            this.lblAvgLoad.Name = "lblAvgLoad";
            this.lblAvgLoad.Size = new System.Drawing.Size(330, 25);
            this.lblAvgLoad.TabIndex = 2;
            this.lblAvgLoad.Text = "Average Load: 0%";
            //
            // lblMostLoaded
            //
            this.lblMostLoaded.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMostLoaded.Location = new System.Drawing.Point(20, 105);
            this.lblMostLoaded.Name = "lblMostLoaded";
            this.lblMostLoaded.Size = new System.Drawing.Size(330, 25);
            this.lblMostLoaded.TabIndex = 3;
            this.lblMostLoaded.Text = "Most Loaded: N/A";
            //
            // lblLeastLoaded
            //
            this.lblLeastLoaded.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeastLoaded.Location = new System.Drawing.Point(370, 105);
            this.lblLeastLoaded.Name = "lblLeastLoaded";
            this.lblLeastLoaded.Size = new System.Drawing.Size(330, 25);
            this.lblLeastLoaded.TabIndex = 4;
            this.lblLeastLoaded.Text = "Least Loaded: N/A";
            //
            // grpWarehouseList
            //
            this.grpWarehouseList.BackColor = System.Drawing.Color.White;
            this.grpWarehouseList.Controls.Add(this.lstWarehouses);
            this.grpWarehouseList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpWarehouseList.Location = new System.Drawing.Point(760, 380);
            this.grpWarehouseList.Name = "grpWarehouseList";
            this.grpWarehouseList.Size = new System.Drawing.Size(300, 310);
            this.grpWarehouseList.TabIndex = 4;
            this.grpWarehouseList.TabStop = false;
            this.grpWarehouseList.Text = "📦 Warehouse List";
            //
            // lstWarehouses
            //
            this.lstWarehouses.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstWarehouses.FormattingEnabled = true;
            this.lstWarehouses.ItemHeight = 18;
            this.lstWarehouses.Location = new System.Drawing.Point(15, 35);
            this.lstWarehouses.Name = "lstWarehouses";
            this.lstWarehouses.Size = new System.Drawing.Size(270, 256);
            this.lstWarehouses.TabIndex = 0;
            //
            // grpBalanceLog
            //
            this.grpBalanceLog.BackColor = System.Drawing.Color.White;
            this.grpBalanceLog.Controls.Add(this.lstBalanceLog);
            this.grpBalanceLog.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBalanceLog.Location = new System.Drawing.Point(1080, 380);
            this.grpBalanceLog.Name = "grpBalanceLog";
            this.grpBalanceLog.Size = new System.Drawing.Size(300, 310);
            this.grpBalanceLog.TabIndex = 5;
            this.grpBalanceLog.TabStop = false;
            this.grpBalanceLog.Text = "📝 Balance Log";
            //
            // lstBalanceLog
            //
            this.lstBalanceLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstBalanceLog.FormattingEnabled = true;
            this.lstBalanceLog.ItemHeight = 18;
            this.lstBalanceLog.Location = new System.Drawing.Point(15, 35);
            this.lstBalanceLog.Name = "lstBalanceLog";
            this.lstBalanceLog.Size = new System.Drawing.Size(270, 256);
            this.lstBalanceLog.TabIndex = 0;
            //
            // LoadBalancingForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1400, 710);
            this.Controls.Add(this.grpBalanceLog);
            this.Controls.Add(this.grpWarehouseList);
            this.Controls.Add(this.grpStatistics);
            this.Controls.Add(this.grpWarehouseControl);
            this.Controls.Add(this.panelVisualization);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "LoadBalancingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Balancing";
            ((System.ComponentModel.ISupportInitialize)(this.numLoadAmount)).EndInit();
            this.grpWarehouseControl.ResumeLayout(false);
            this.grpWarehouseControl.PerformLayout();
            this.grpStatistics.ResumeLayout(false);
            this.grpWarehouseList.ResumeLayout(false);
            this.grpBalanceLog.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}