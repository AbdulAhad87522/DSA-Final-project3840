// Forms/ColdStorageForm.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using SmartSupplyChainSystem.Services;

namespace SmartSupplyChainSystem.Forms
{
    public partial class ColdStorageForm : Form
    {
        private TemperatureMonitoringService tempService;
        private Timer sensorTimer;
        private string[] sensors = { "Sensor-A", "Sensor-B", "Sensor-C", "Sensor-D", "Sensor-E" };
        private int sensorIndex = 0;

        public ColdStorageForm()
        {
            InitializeComponent();
            tempService = new TemperatureMonitoringService();
            InitializeSensorSimulation();
        }

        private void InitializeSensorSimulation()
        {
            sensorTimer = new Timer();
            sensorTimer.Interval = 2000; // 2 seconds
            sensorTimer.Tick += SensorTimer_Tick;
        }

        private void SensorTimer_Tick(object sender, EventArgs e)
        {
            // Simulate sensor reading
            string sensorId = sensors[sensorIndex];
            tempService.SimulateSensorReading(sensorId);

            sensorIndex = (sensorIndex + 1) % sensors.Length;
            UpdatePendingCount();
            UpdateSensorStatus();

            // NEW: Update alerts list automatically
            UpdateAlertsList();
        }

        private void btnStartMonitoring_Click(object sender, EventArgs e)
        {
            sensorTimer.Start();
            btnStartMonitoring.Enabled = false;
            btnStopMonitoring.Enabled = true;
            lblStatus.Text = "✅ Monitoring Active - Sensors collecting data...";
            lblStatus.ForeColor = Color.Green;
        }

        private void btnStopMonitoring_Click(object sender, EventArgs e)
        {
            sensorTimer.Stop();
            btnStartMonitoring.Enabled = true;
            btnStopMonitoring.Enabled = false;
            lblStatus.Text = "⏸️ Monitoring Stopped";
            lblStatus.ForeColor = Color.Orange;
        }

        private void btnProcessReading_Click(object sender, EventArgs e)
        {
            var reading = tempService.ProcessNextReading();
            if (reading != null)
            {
                lstProcessedReadings.Items.Insert(0, reading);

                // Keep only last 20 readings
                if (lstProcessedReadings.Items.Count > 20)
                    lstProcessedReadings.Items.RemoveAt(lstProcessedReadings.Items.Count - 1);

                UpdatePendingCount();
                UpdateChart();
            }
            else
            {
                MessageBox.Show("No pending readings in queue!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // NEW: Process next alert from Priority Queue
        private void btnProcessAlert_Click(object sender, EventArgs e)
        {
            var alert = tempService.ProcessNextAlert();
            if (alert != null)
            {
                lstProcessedAlerts.Items.Insert(0,
                    $"✅ PROCESSED: {alert} - Action Taken at {DateTime.Now:HH:mm:ss}");

                // Keep last 15 processed alerts
                if (lstProcessedAlerts.Items.Count > 15)
                    lstProcessedAlerts.Items.RemoveAt(lstProcessedAlerts.Items.Count - 1);

                // Show action message
                string action = alert.Priority == 1
                    ? "🚨 Emergency cooling activated! Admin notified!"
                    : "⚠️ Monitoring frequency increased!";

                MessageBox.Show($"{action}\n\n{alert}", "Alert Processed",
                    MessageBoxButtons.OK,
                    alert.Priority == 1 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                UpdatePendingCount();
                UpdateAlertsList();
            }
            else
            {
                MessageBox.Show("No pending alerts!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProcessAll_Click(object sender, EventArgs e)
        {
            if (tempService.PendingReadings == 0)
            {
                MessageBox.Show("No pending readings!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int count = 0;
            while (tempService.PendingReadings > 0)
            {
                var reading = tempService.ProcessNextReading();
                if (reading != null)
                {
                    lstProcessedReadings.Items.Insert(0, reading);
                    count++;
                }
            }

            // Trim list
            while (lstProcessedReadings.Items.Count > 20)
                lstProcessedReadings.Items.RemoveAt(lstProcessedReadings.Items.Count - 1);

            UpdatePendingCount();
            UpdateChart();

            MessageBox.Show($"✅ Processed {count} readings!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NEW: Process all alerts
        private void btnProcessAllAlerts_Click(object sender, EventArgs e)
        {
            if (tempService.PendingAlerts == 0)
            {
                MessageBox.Show("No pending alerts!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int count = 0;
            int criticalCount = 0;
            int warningCount = 0;

            while (tempService.PendingAlerts > 0)
            {
                var alert = tempService.ProcessNextAlert();
                if (alert != null)
                {
                    lstProcessedAlerts.Items.Insert(0,
                        $"✅ PROCESSED: {alert}");
                    count++;

                    if (alert.Priority == 1)
                        criticalCount++;
                    else
                        warningCount++;
                }
            }

            // Trim list
            while (lstProcessedAlerts.Items.Count > 15)
                lstProcessedAlerts.Items.RemoveAt(lstProcessedAlerts.Items.Count - 1);

            UpdatePendingCount();
            UpdateAlertsList();

            MessageBox.Show(
                $"✅ Processed {count} alerts!\n\n" +
                $"🚨 Critical: {criticalCount}\n" +
                $"⚠️ Warnings: {warningCount}",
                "Alerts Processed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Clear all data?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lstProcessedReadings.Items.Clear();
                lstAlerts.Items.Clear();
                lstProcessedAlerts.Items.Clear();
                tempService = new TemperatureMonitoringService();
                UpdatePendingCount();
                UpdateSensorStatus();
                UpdateAlertsList();
                panelChart.Invalidate();
            }
        }

        private void UpdatePendingCount()
        {
            lblPendingReadings.Text = $"Pending Readings: {tempService.PendingReadings}/100";
            lblCriticalAlerts.Text = $"Pending Alerts: {tempService.PendingAlerts}";
            lblCriticalAlerts.ForeColor = tempService.PendingAlerts > 0 ? Color.Red : Color.Green;
        }

        // NEW: Update alerts list from Priority Queue
        private void UpdateAlertsList()
        {
            lstAlerts.Items.Clear();
            lstAlerts.Items.Add("=== PENDING ALERTS (Priority Order) ===");
            lstAlerts.Items.Add("");

            var alerts = tempService.GetAllAlerts();
            if (alerts.Count == 0)
            {
                lstAlerts.Items.Add("✅ No pending alerts");
            }
            else
            {
                foreach (var alert in alerts)
                {
                    lstAlerts.Items.Add(alert);
                }
            }
        }

        private void UpdateSensorStatus()
        {
            lstSensorStatus.Items.Clear();
            lstSensorStatus.Items.Add("=== SENSOR STATUS ===");
            lstSensorStatus.Items.Add("");

            foreach (var sensor in sensors)
            {
                lstSensorStatus.Items.Add($"🌡️ {sensor}: Active");
            }

            lstSensorStatus.Items.Add("");
            lstSensorStatus.Items.Add($"Queue: {tempService.PendingReadings}/100");
            lstSensorStatus.Items.Add($"Alerts: {tempService.PendingAlerts}");
        }

        private void UpdateChart()
        {
            panelChart.Invalidate();
        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw background
            g.Clear(Color.White);

            // Draw grid
            Pen gridPen = new Pen(Color.LightGray, 1);
            for (int i = 0; i <= 10; i++)
            {
                int y = 30 + i * 30;
                g.DrawLine(gridPen, 40, y, 560, y);
            }

            // Draw axes
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, 40, 330, 560, 330); // X-axis
            g.DrawLine(axisPen, 40, 30, 40, 330);   // Y-axis

            // Draw temperature labels
            Font labelFont = new Font("Arial", 8);
            for (int i = 0; i <= 10; i++)
            {
                int temp = 10 - i * 2; // From 10°C to -10°C
                int y = 30 + i * 30;
                g.DrawString($"{temp}°C", labelFont, Brushes.Black, 5, y - 8);
            }

            // Draw temperature zones
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 46, 204, 113)), 40, 120, 520, 90);  // Good zone (-5 to 0)
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 241, 196, 15)), 40, 90, 520, 30); // Warning zone (0 to 3)
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 241, 196, 15)), 40, 210, 520, 60); // Warning zone (-8 to -5)
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 231, 76, 60)), 40, 30, 520, 60); // Critical zone (>3)
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 231, 76, 60)), 40, 270, 520, 60); // Critical zone (<-8)

            // Draw zone labels
            g.DrawString("🚨 Critical (>3°C)", new Font("Arial", 9, FontStyle.Bold),
                Brushes.DarkRed, 200, 50);
            g.DrawString("⚠️ Warning (0-3°C)", new Font("Arial", 9, FontStyle.Bold),
                Brushes.DarkOrange, 200, 100);
            g.DrawString("✅ Optimal (-5 to 0°C)", new Font("Arial", 9, FontStyle.Bold),
                Brushes.DarkGreen, 200, 160);
            g.DrawString("⚠️ Warning (-8 to -5°C)", new Font("Arial", 9, FontStyle.Bold),
                Brushes.DarkOrange, 200, 230);
            g.DrawString("🚨 Critical (<-8°C)", new Font("Arial", 9, FontStyle.Bold),
                Brushes.DarkRed, 200, 290);

            // Plot recent readings
            var history = tempService.GetHistory();
            if (history.Count > 1)
            {
                int maxPoints = Math.Min(25, history.Count);
                int startIndex = Math.Max(0, history.Count - maxPoints);

                Pen linePen = new Pen(Color.Blue, 2);
                for (int i = startIndex; i < history.Count - 1; i++)
                {
                    double temp1 = history[i].Temperature;
                    double temp2 = history[i + 1].Temperature;

                    int x1 = 40 + ((i - startIndex) * 520 / maxPoints);
                    int x2 = 40 + ((i + 1 - startIndex) * 520 / maxPoints);

                    int y1 = 330 - (int)((temp1 + 10) * 300 / 20);
                    int y2 = 330 - (int)((temp2 + 10) * 300 / 20);

                    // Clamp to visible area
                    y1 = Math.Max(30, Math.Min(330, y1));
                    y2 = Math.Max(30, Math.Min(330, y2));

                    g.DrawLine(linePen, x1, y1, x2, y2);

                    // Draw point
                    Color pointColor = history[i].Status == "Critical" ? Color.Red :
                                      history[i].Status == "Warning" ? Color.Orange : Color.Green;
                    g.FillEllipse(new SolidBrush(pointColor), x1 - 4, y1 - 4, 8, 8);
                }
            }
        }

        private void ColdStorageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sensorTimer != null)
            {
                sensorTimer.Stop();
                sensorTimer.Dispose();
            }
        }
    }
}