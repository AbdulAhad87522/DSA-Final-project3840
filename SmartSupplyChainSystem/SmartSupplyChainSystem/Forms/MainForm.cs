// Forms/MainForm.cs - UPDATED
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartSupplyChainSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Smart Supply Chain System - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnWarehouseNav_Click(object sender, EventArgs e)
        {
            var form = new WarehouseNavigationForm();
            form.ShowDialog();
        }

        private void btnTruckRouting_Click(object sender, EventArgs e)
        {
            var form = new TruckRoutingForm();
            form.ShowDialog();
        }

        private void btnProductTracking_Click(object sender, EventArgs e)
        {
            var form = new ProductTrackingForm();
            form.ShowDialog();
        }

        private void btnOrderProcessing_Click(object sender, EventArgs e)
        {
            var form = new OrderProcessingForm();
            form.ShowDialog();
        }

        private void btnLoadBalancing_Click(object sender, EventArgs e)
        {
            var form = new LoadBalancingForm();
            form.ShowDialog();
        }

        private void btnColdStorage_Click(object sender, EventArgs e)
        {
            var form = new ColdStorageForm();
            form.ShowDialog();
        }

        private void btnProductManager_Click(object sender, EventArgs e)
        {
            var form = new ProductManagerForm();
            form.ShowDialog();
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}