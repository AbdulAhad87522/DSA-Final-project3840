// Forms/ColdStorageForm.Designer.cs
namespace SmartSupplyChainSystem.Forms
{
    partial class ColdStorageForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Button btnStartMonitoring;
        private System.Windows.Forms.Button btnStopMonitoring;
        private System.Windows.Forms.Button btnProcessReading;
        private System.Windows.Forms.Button btnProcessAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpReadings;
        private System.Windows.Forms.ListBox lstProcessedReadings;
        private System.Windows.Forms.GroupBox grpAlerts;
        private System.Windows.Forms.ListBox lstAlerts;
        private System.Windows.Forms.GroupBox grpSensorStatus;
        private System.Windows.Forms.ListBox lstSensorStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPendingReadings;
        private System.Windows.Forms.Label lblCriticalAlerts;

        // NEW CONTROLS
        private System.Windows.Forms.Button btnProcessAlert;
        private System.Windows.Forms.Button btnProcessAllAlerts;
        private System.Windows.Forms.GroupBox grpProcessedAlerts;
        private System.Windows.Forms.ListBox lstProcessedAlerts;

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
            this.panelChart = new System.Windows.Forms.Panel();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.btnStopMonitoring = new System.Windows.Forms.Button();
            this.btnProcessReading = new System.Windows.Forms.Button();
            this.btnProcessAll = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblPendingReadings = new System.Windows.Forms.Label();
            this.lblCriticalAlerts = new System.Windows.Forms.Label();
            this.grpReadings = new System.Windows.Forms.GroupBox();
            this.lstProcessedReadings = new System.Windows.Forms.ListBox();
            this.grpAlerts = new System.Windows.Forms.GroupBox();
            this.lstAlerts = new System.Windows.Forms.ListBox();
            this.btnProcessAlert = new System.Windows.Forms.Button();
            this.btnProcessAllAlerts = new System.Windows.Forms.Button();
            this.grpSensorStatus = new System.Windows.Forms.GroupBox();
            this.lstSensorStatus = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpProcessedAlerts = new System.Windows.Forms.GroupBox();
            this.lstProcessedAlerts = new System.Windows.Forms.ListBox();
            this.grpControls.SuspendLayout();
            this.grpReadings.SuspendLayout();
            this.grpAlerts.SuspendLayout();
            this.grpSensorStatus.SuspendLayout();
            this.grpProcessedAlerts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "❄️ Cold Storage Monitoring (Circular Queue + Priority Queue)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChart
            // 
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Location = new System.Drawing.Point(20, 80);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(600, 370);
            this.panelChart.TabIndex = 1;
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);
            // 
            // grpControls
            // 
            this.grpControls.BackColor = System.Drawing.Color.White;
            this.grpControls.Controls.Add(this.btnStartMonitoring);
            this.grpControls.Controls.Add(this.btnStopMonitoring);
            this.grpControls.Controls.Add(this.btnProcessReading);
            this.grpControls.Controls.Add(this.btnProcessAll);
            this.grpControls.Controls.Add(this.btnClearAll);
            this.grpControls.Controls.Add(this.lblPendingReadings);
            this.grpControls.Controls.Add(this.lblCriticalAlerts);
            this.grpControls.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpControls.Location = new System.Drawing.Point(640, 80);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(740, 180);
            this.grpControls.TabIndex = 2;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "🎛️ Control Panel";
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnStartMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMonitoring.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnStartMonitoring.Location = new System.Drawing.Point(20, 40);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(170, 45);
            this.btnStartMonitoring.TabIndex = 0;
            this.btnStartMonitoring.Text = "▶️ Start";
            this.btnStartMonitoring.UseVisualStyleBackColor = false;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click);
            // 
            // btnStopMonitoring
            // 
            this.btnStopMonitoring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnStopMonitoring.Enabled = false;
            this.btnStopMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMonitoring.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnStopMonitoring.Location = new System.Drawing.Point(200, 40);
            this.btnStopMonitoring.Name = "btnStopMonitoring";
            this.btnStopMonitoring.Size = new System.Drawing.Size(170, 45);
            this.btnStopMonitoring.TabIndex = 1;
            this.btnStopMonitoring.Text = "⏸️ Stop";
            this.btnStopMonitoring.UseVisualStyleBackColor = false;
            this.btnStopMonitoring.Click += new System.EventHandler(this.btnStopMonitoring_Click);
            // 
            // btnProcessReading
            // 
            this.btnProcessReading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProcessReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessReading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProcessReading.ForeColor = System.Drawing.Color.White;
            this.btnProcessReading.Location = new System.Drawing.Point(380, 40);
            this.btnProcessReading.Name = "btnProcessReading";
            this.btnProcessReading.Size = new System.Drawing.Size(170, 45);
            this.btnProcessReading.TabIndex = 2;
            this.btnProcessReading.Text = "📊 Process Reading";
            this.btnProcessReading.UseVisualStyleBackColor = false;
            this.btnProcessReading.Click += new System.EventHandler(this.btnProcessReading_Click);
            // 
            // btnProcessAll
            // 
            this.btnProcessAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnProcessAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProcessAll.ForeColor = System.Drawing.Color.White;
            this.btnProcessAll.Location = new System.Drawing.Point(560, 40);
            this.btnProcessAll.Name = "btnProcessAll";
            this.btnProcessAll.Size = new System.Drawing.Size(165, 45);
            this.btnProcessAll.TabIndex = 3;
            this.btnProcessAll.Text = "⚡ Process All";
            this.btnProcessAll.UseVisualStyleBackColor = false;
            this.btnProcessAll.Click += new System.EventHandler(this.btnProcessAll_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Location = new System.Drawing.Point(20, 100);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(705, 40);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "🗑️ Clear All Data";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblPendingReadings
            // 
            this.lblPendingReadings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPendingReadings.Location = new System.Drawing.Point(20, 150);
            this.lblPendingReadings.Name = "lblPendingReadings";
            this.lblPendingReadings.Size = new System.Drawing.Size(350, 25);
            this.lblPendingReadings.TabIndex = 5;
            this.lblPendingReadings.Text = "Pending Readings: 0/100";
            // 
            // lblCriticalAlerts
            // 
            this.lblCriticalAlerts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCriticalAlerts.Location = new System.Drawing.Point(380, 150);
            this.lblCriticalAlerts.Name = "lblCriticalAlerts";
            this.lblCriticalAlerts.Size = new System.Drawing.Size(345, 25);
            this.lblCriticalAlerts.TabIndex = 6;
            this.lblCriticalAlerts.Text = "Pending Alerts: 0";
            // 
            // grpReadings
            // 
            this.grpReadings.BackColor = System.Drawing.Color.White;
            this.grpReadings.Controls.Add(this.lstProcessedReadings);
            this.grpReadings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpReadings.Location = new System.Drawing.Point(20, 470);
            this.grpReadings.Name = "grpReadings";
            this.grpReadings.Size = new System.Drawing.Size(600, 280);
            this.grpReadings.TabIndex = 3;
            this.grpReadings.TabStop = false;
            this.grpReadings.Text = "📊 Processed Readings";
            // 
            // lstProcessedReadings
            // 
            this.lstProcessedReadings.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstProcessedReadings.FormattingEnabled = true;
            this.lstProcessedReadings.ItemHeight = 18;
            this.lstProcessedReadings.Location = new System.Drawing.Point(15, 35);
            this.lstProcessedReadings.Name = "lstProcessedReadings";
            this.lstProcessedReadings.Size = new System.Drawing.Size(570, 230);
            this.lstProcessedReadings.TabIndex = 0;
            // 
            // grpAlerts
            // 
            this.grpAlerts.BackColor = System.Drawing.Color.White;
            this.grpAlerts.Controls.Add(this.lstAlerts);
            this.grpAlerts.Controls.Add(this.btnProcessAlert);
            this.grpAlerts.Controls.Add(this.btnProcessAllAlerts);
            this.grpAlerts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpAlerts.Location = new System.Drawing.Point(640, 280);
            this.grpAlerts.Name = "grpAlerts";
            this.grpAlerts.Size = new System.Drawing.Size(450, 470);
            this.grpAlerts.TabIndex = 4;
            this.grpAlerts.TabStop = false;
            this.grpAlerts.Text = "🚨 Pending Alerts (Priority Queue)";
            // 
            // lstAlerts
            // 
            this.lstAlerts.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstAlerts.FormattingEnabled = true;
            this.lstAlerts.ItemHeight = 18;
            this.lstAlerts.Location = new System.Drawing.Point(15, 35);
            this.lstAlerts.Name = "lstAlerts";
            this.lstAlerts.Size = new System.Drawing.Size(420, 310);
            this.lstAlerts.TabIndex = 0;
            // 
            // btnProcessAlert
            // 
            this.btnProcessAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnProcessAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessAlert.ForeColor = System.Drawing.Color.White;
            this.btnProcessAlert.Location = new System.Drawing.Point(15, 360);
            this.btnProcessAlert.Name = "btnProcessAlert";
            this.btnProcessAlert.Size = new System.Drawing.Size(420, 45);
            this.btnProcessAlert.TabIndex = 1;
            this.btnProcessAlert.Text = "🚨 Process Next Alert";
            this.btnProcessAlert.UseVisualStyleBackColor = false;
            this.btnProcessAlert.Click += new System.EventHandler(this.btnProcessAlert_Click);
            // 
            // btnProcessAllAlerts
            // 
            this.btnProcessAllAlerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnProcessAllAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessAllAlerts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessAllAlerts.ForeColor = System.Drawing.Color.White;
            this.btnProcessAllAlerts.Location = new System.Drawing.Point(15, 415);
            this.btnProcessAllAlerts.Name = "btnProcessAllAlerts";
            this.btnProcessAllAlerts.Size = new System.Drawing.Size(420, 45);
            this.btnProcessAllAlerts.TabIndex = 2;
            this.btnProcessAllAlerts.Text = "⚡ Process All Alerts";
            this.btnProcessAllAlerts.UseVisualStyleBackColor = false;
            this.btnProcessAllAlerts.Click += new System.EventHandler(this.btnProcessAllAlerts_Click);
            // 
            // grpSensorStatus
            // 
            this.grpSensorStatus.BackColor = System.Drawing.Color.White;
            this.grpSensorStatus.Controls.Add(this.lstSensorStatus);
            this.grpSensorStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSensorStatus.Location = new System.Drawing.Point(1110, 280);
            this.grpSensorStatus.Name = "grpSensorStatus";
            this.grpSensorStatus.Size = new System.Drawing.Size(270, 235);
            this.grpSensorStatus.TabIndex = 5;
            this.grpSensorStatus.TabStop = false;
            this.grpSensorStatus.Text = "🌡️ Sensors";
            // 
            // lstSensorStatus
            // 
            this.lstSensorStatus.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstSensorStatus.FormattingEnabled = true;
            this.lstSensorStatus.ItemHeight = 18;
            this.lstSensorStatus.Location = new System.Drawing.Point(15, 35);
            this.lstSensorStatus.Name = "lstSensorStatus";
            this.lstSensorStatus.Size = new System.Drawing.Size(240, 184);
            this.lstSensorStatus.TabIndex = 0;
            // 
            // grpProcessedAlerts
            // 
            this.grpProcessedAlerts.BackColor = System.Drawing.Color.White;
            this.grpProcessedAlerts.Controls.Add(this.lstProcessedAlerts);
            this.grpProcessedAlerts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcessedAlerts.Location = new System.Drawing.Point(1110, 535);
            this.grpProcessedAlerts.Name = "grpProcessedAlerts";
            this.grpProcessedAlerts.Size = new System.Drawing.Size(270, 215);
            this.grpProcessedAlerts.TabIndex = 6;
            this.grpProcessedAlerts.TabStop = false;
            this.grpProcessedAlerts.Text = "✅ Processed";
            // 
            // lstProcessedAlerts
            // 
            this.lstProcessedAlerts.Font = new System.Drawing.Font("Consolas", 8F);
            this.lstProcessedAlerts.FormattingEnabled = true;
            this.lstProcessedAlerts.ItemHeight = 15;
            this.lstProcessedAlerts.Location = new System.Drawing.Point(15, 35);
            this.lstProcessedAlerts.Name = "lstProcessedAlerts";
            this.lstProcessedAlerts.Size = new System.Drawing.Size(240, 169);
            this.lstProcessedAlerts.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(640, 760);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(740, 30);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready to start monitoring";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColdStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpProcessedAlerts);
            this.Controls.Add(this.grpSensorStatus);
            this.Controls.Add(this.grpAlerts);
            this.Controls.Add(this.grpReadings);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "ColdStorageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cold Storage Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColdStorageForm_FormClosing);
            this.grpControls.ResumeLayout(false);
            this.grpReadings.ResumeLayout(false);
            this.grpAlerts.ResumeLayout(false);
            this.grpSensorStatus.ResumeLayout(false);
            this.grpProcessedAlerts.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}