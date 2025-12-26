// Forms/WarehouseNavigationForm.Designer.cs
namespace SmartSupplyChainSystem.Forms
{
    partial class WarehouseNavigationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox cmbStart;
        private System.Windows.Forms.ComboBox cmbEnd;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Panel panelVisualization;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panelControls;

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
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cmbStart = new System.Windows.Forms.ComboBox();
            this.cmbEnd = new System.Windows.Forms.ComboBox();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.panelVisualization = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1238, 75);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📍 Warehouse Navigation (BFS + Dijkstra)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStart.Location = new System.Drawing.Point(34, 38);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(119, 28);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start Point:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEnd.Location = new System.Drawing.Point(416, 38);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(107, 28);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End Point:";
            // 
            // cmbStart
            // 
            this.cmbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStart.FormattingEnabled = true;
            this.cmbStart.Location = new System.Drawing.Point(158, 34);
            this.cmbStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new System.Drawing.Size(224, 36);
            this.cmbStart.TabIndex = 1;
            // 
            // cmbEnd
            // 
            this.cmbEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEnd.FormattingEnabled = true;
            this.cmbEnd.Location = new System.Drawing.Point(529, 34);
            this.cmbEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEnd.Name = "cmbEnd";
            this.cmbEnd.Size = new System.Drawing.Size(224, 36);
            this.cmbEnd.TabIndex = 3;
            this.cmbEnd.SelectedIndexChanged += new System.EventHandler(this.cmbEnd_SelectedIndexChanged);
            // 
            // btnFindPath
            // 
            this.btnFindPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnFindPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPath.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFindPath.ForeColor = System.Drawing.Color.White;
            this.btnFindPath.Location = new System.Drawing.Point(788, 25);
            this.btnFindPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(169, 56);
            this.btnFindPath.TabIndex = 4;
            this.btnFindPath.Text = "🔍 Find Path";
            this.btnFindPath.UseVisualStyleBackColor = false;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // lstPath
            // 
            this.lstPath.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstPath.FormattingEnabled = true;
            this.lstPath.ItemHeight = 23;
            this.lstPath.Location = new System.Drawing.Point(889, 250);
            this.lstPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(326, 487);
            this.lstPath.TabIndex = 3;
            // 
            // panelVisualization
            // 
            this.panelVisualization.BackColor = System.Drawing.Color.White;
            this.panelVisualization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVisualization.Location = new System.Drawing.Point(22, 250);
            this.panelVisualization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelVisualization.Name = "panelVisualization";
            this.panelVisualization.Size = new System.Drawing.Size(844, 500);
            this.panelVisualization.TabIndex = 2;
            this.panelVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVisualization_Paint);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(34, 94);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(1170, 38);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Select start and end points to find shortest path";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.Controls.Add(this.lblStart);
            this.panelControls.Controls.Add(this.cmbStart);
            this.panelControls.Controls.Add(this.lblEnd);
            this.panelControls.Controls.Add(this.cmbEnd);
            this.panelControls.Controls.Add(this.btnFindPath);
            this.panelControls.Controls.Add(this.lblResult);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 75);
            this.panelControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.panelControls.Size = new System.Drawing.Size(1238, 150);
            this.panelControls.TabIndex = 1;
            // 
            // WarehouseNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1238, 775);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.panelVisualization);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = true;
            this.Name = "WarehouseNavigationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Navigation";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}