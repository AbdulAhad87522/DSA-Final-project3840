// Forms/OrderProcessingForm.Designer.cs - FIXED VERSION
namespace SmartSupplyChainSystem.Forms
{
    partial class OrderProcessingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpOrderInput;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblDeliveryAddress;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.GroupBox grpNormalQueue;
        private System.Windows.Forms.GroupBox grpPriorityQueue;
        private System.Windows.Forms.GroupBox grpProcessed;
        private System.Windows.Forms.ListBox lstNormalQueue;
        private System.Windows.Forms.ListBox lstPriorityQueue;
        private System.Windows.Forms.ListBox lstProcessed;
        private System.Windows.Forms.Button btnProcessNormal;
        private System.Windows.Forms.Button btnProcessPriority;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblNormalCount;
        private System.Windows.Forms.Label lblPriorityCount;
        private System.Windows.Forms.Label lblProcessedCount;
        private System.Windows.Forms.Label lblLastProcessed;

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
            this.grpOrderInput = new System.Windows.Forms.GroupBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.lblDeliveryAddress = new System.Windows.Forms.Label();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.grpNormalQueue = new System.Windows.Forms.GroupBox();
            this.lstNormalQueue = new System.Windows.Forms.ListBox();
            this.lblNormalCount = new System.Windows.Forms.Label();
            this.btnProcessNormal = new System.Windows.Forms.Button();
            this.grpPriorityQueue = new System.Windows.Forms.GroupBox();
            this.lstPriorityQueue = new System.Windows.Forms.ListBox();
            this.lblPriorityCount = new System.Windows.Forms.Label();
            this.btnProcessPriority = new System.Windows.Forms.Button();
            this.grpProcessed = new System.Windows.Forms.GroupBox();
            this.lstProcessed = new System.Windows.Forms.ListBox();
            this.lblProcessedCount = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblLastProcessed = new System.Windows.Forms.Label();
            this.grpOrderInput.SuspendLayout();
            this.grpNormalQueue.SuspendLayout();
            this.grpPriorityQueue.SuspendLayout();
            this.grpProcessed.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1575, 75);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Order Processing (Queue + Priority Queue)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // grpOrderInput
            // 
            this.grpOrderInput.BackColor = System.Drawing.Color.White;
            this.grpOrderInput.Controls.Add(this.lblOrderId);
            this.grpOrderInput.Controls.Add(this.txtOrderId);
            this.grpOrderInput.Controls.Add(this.lblCustomerName);
            this.grpOrderInput.Controls.Add(this.txtCustomerName);
            this.grpOrderInput.Controls.Add(this.lblProduct);
            this.grpOrderInput.Controls.Add(this.cmbProduct);
            this.grpOrderInput.Controls.Add(this.lblProductInfo);
            this.grpOrderInput.Controls.Add(this.lblDeliveryAddress);
            this.grpOrderInput.Controls.Add(this.txtDeliveryAddress);
            this.grpOrderInput.Controls.Add(this.lblPriority);
            this.grpOrderInput.Controls.Add(this.cmbPriority);
            this.grpOrderInput.Controls.Add(this.btnAddOrder);
            this.grpOrderInput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpOrderInput.Location = new System.Drawing.Point(22, 100);
            this.grpOrderInput.Name = "grpOrderInput";
            this.grpOrderInput.Size = new System.Drawing.Size(1530, 280);
            this.grpOrderInput.TabIndex = 1;
            this.grpOrderInput.TabStop = false;
            this.grpOrderInput.Text = "Create New Order";
            this.grpOrderInput.Enter += new System.EventHandler(this.grpOrderInput_Enter);
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrderId.Location = new System.Drawing.Point(34, 50);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(91, 28);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Order ID:";
            this.lblOrderId.Click += new System.EventHandler(this.lblOrderId_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOrderId.Location = new System.Drawing.Point(202, 46);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(224, 34);
            this.txtOrderId.TabIndex = 1;
            this.txtOrderId.TextChanged += new System.EventHandler(this.txtOrderId_TextChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomerName.Location = new System.Drawing.Point(472, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(157, 28);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Customer Name:";
            this.lblCustomerName.Click += new System.EventHandler(this.lblCustomerName_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(652, 46);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(337, 34);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProduct.Location = new System.Drawing.Point(34, 112);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(85, 28);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Product:";
            this.lblProduct.Click += new System.EventHandler(this.lblProduct_Click);
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(202, 109);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(540, 36);
            this.cmbProduct.TabIndex = 5;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProductInfo.Location = new System.Drawing.Point(202, 150);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(787, 25);
            this.lblProductInfo.TabIndex = 6;
            this.lblProductInfo.Text = "Select a product to view details";
            this.lblProductInfo.Click += new System.EventHandler(this.lblProductInfo_Click);
            // 
            // lblDeliveryAddress
            // 
            this.lblDeliveryAddress.AutoSize = true;
            this.lblDeliveryAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeliveryAddress.Location = new System.Drawing.Point(34, 185);
            this.lblDeliveryAddress.Name = "lblDeliveryAddress";
            this.lblDeliveryAddress.Size = new System.Drawing.Size(162, 28);
            this.lblDeliveryAddress.TabIndex = 7;
            this.lblDeliveryAddress.Text = "Delivery Address:";
            this.lblDeliveryAddress.Click += new System.EventHandler(this.lblDeliveryAddress_Click);
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDeliveryAddress.Location = new System.Drawing.Point(202, 182);
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(540, 34);
            this.txtDeliveryAddress.TabIndex = 8;
            this.txtDeliveryAddress.TextChanged += new System.EventHandler(this.txtDeliveryAddress_TextChanged);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPriority.Location = new System.Drawing.Point(1035, 50);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(80, 28);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "Priority:";
            this.lblPriority.Click += new System.EventHandler(this.lblPriority_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "🚨 Emergency",
            "⚡ High",
            "📦 Normal"});
            this.cmbPriority.Location = new System.Drawing.Point(1136, 46);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(224, 36);
            this.cmbPriority.TabIndex = 10;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddOrder.Location = new System.Drawing.Point(1035, 110);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(326, 106);
            this.btnAddOrder.TabIndex = 11;
            this.btnAddOrder.Text = "➕ Add Order to Queue";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // grpNormalQueue
            // 
            this.grpNormalQueue.BackColor = System.Drawing.Color.White;
            this.grpNormalQueue.Controls.Add(this.lstNormalQueue);
            this.grpNormalQueue.Controls.Add(this.lblNormalCount);
            this.grpNormalQueue.Controls.Add(this.btnProcessNormal);
            this.grpNormalQueue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpNormalQueue.Location = new System.Drawing.Point(22, 400);
            this.grpNormalQueue.Name = "grpNormalQueue";
            this.grpNormalQueue.Size = new System.Drawing.Size(484, 500);
            this.grpNormalQueue.TabIndex = 2;
            this.grpNormalQueue.TabStop = false;
            this.grpNormalQueue.Text = "📦 Normal Queue (FIFO)";
            this.grpNormalQueue.Enter += new System.EventHandler(this.grpNormalQueue_Enter);
            // 
            // lstNormalQueue
            // 
            this.lstNormalQueue.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstNormalQueue.FormattingEnabled = true;
            this.lstNormalQueue.ItemHeight = 22;
            this.lstNormalQueue.Location = new System.Drawing.Point(22, 50);
            this.lstNormalQueue.Name = "lstNormalQueue";
            this.lstNormalQueue.Size = new System.Drawing.Size(438, 312);
            this.lstNormalQueue.TabIndex = 0;
            this.lstNormalQueue.SelectedIndexChanged += new System.EventHandler(this.lstNormalQueue_SelectedIndexChanged);
            // 
            // lblNormalCount
            // 
            this.lblNormalCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNormalCount.Location = new System.Drawing.Point(22, 388);
            this.lblNormalCount.Name = "lblNormalCount";
            this.lblNormalCount.Size = new System.Drawing.Size(439, 31);
            this.lblNormalCount.TabIndex = 1;
            this.lblNormalCount.Text = "Normal Orders: 0";
            this.lblNormalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNormalCount.Click += new System.EventHandler(this.lblNormalCount_Click);
            // 
            // btnProcessNormal
            // 
            this.btnProcessNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProcessNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessNormal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessNormal.ForeColor = System.Drawing.Color.White;
            this.btnProcessNormal.Location = new System.Drawing.Point(90, 431);
            this.btnProcessNormal.Name = "btnProcessNormal";
            this.btnProcessNormal.Size = new System.Drawing.Size(304, 50);
            this.btnProcessNormal.TabIndex = 2;
            this.btnProcessNormal.Text = "▶️ Process Next Order";
            this.btnProcessNormal.UseVisualStyleBackColor = false;
            this.btnProcessNormal.Click += new System.EventHandler(this.btnProcessNormal_Click);
            // 
            // grpPriorityQueue
            // 
            this.grpPriorityQueue.BackColor = System.Drawing.Color.White;
            this.grpPriorityQueue.Controls.Add(this.lstPriorityQueue);
            this.grpPriorityQueue.Controls.Add(this.lblPriorityCount);
            this.grpPriorityQueue.Controls.Add(this.btnProcessPriority);
            this.grpPriorityQueue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpPriorityQueue.Location = new System.Drawing.Point(529, 400);
            this.grpPriorityQueue.Name = "grpPriorityQueue";
            this.grpPriorityQueue.Size = new System.Drawing.Size(484, 500);
            this.grpPriorityQueue.TabIndex = 3;
            this.grpPriorityQueue.TabStop = false;
            this.grpPriorityQueue.Text = "🚨 Priority Queue";
            this.grpPriorityQueue.Enter += new System.EventHandler(this.grpPriorityQueue_Enter);
            // 
            // lstPriorityQueue
            // 
            this.lstPriorityQueue.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstPriorityQueue.FormattingEnabled = true;
            this.lstPriorityQueue.ItemHeight = 22;
            this.lstPriorityQueue.Location = new System.Drawing.Point(22, 50);
            this.lstPriorityQueue.Name = "lstPriorityQueue";
            this.lstPriorityQueue.Size = new System.Drawing.Size(438, 312);
            this.lstPriorityQueue.TabIndex = 0;
            this.lstPriorityQueue.SelectedIndexChanged += new System.EventHandler(this.lstPriorityQueue_SelectedIndexChanged);
            // 
            // lblPriorityCount
            // 
            this.lblPriorityCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriorityCount.Location = new System.Drawing.Point(22, 388);
            this.lblPriorityCount.Name = "lblPriorityCount";
            this.lblPriorityCount.Size = new System.Drawing.Size(439, 31);
            this.lblPriorityCount.TabIndex = 1;
            this.lblPriorityCount.Text = "Priority Orders: 0";
            this.lblPriorityCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPriorityCount.Click += new System.EventHandler(this.lblPriorityCount_Click);
            // 
            // btnProcessPriority
            // 
            this.btnProcessPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnProcessPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessPriority.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessPriority.ForeColor = System.Drawing.Color.White;
            this.btnProcessPriority.Location = new System.Drawing.Point(90, 431);
            this.btnProcessPriority.Name = "btnProcessPriority";
            this.btnProcessPriority.Size = new System.Drawing.Size(304, 50);
            this.btnProcessPriority.TabIndex = 2;
            this.btnProcessPriority.Text = "⚡ Process Priority Order";
            this.btnProcessPriority.UseVisualStyleBackColor = false;
            this.btnProcessPriority.Click += new System.EventHandler(this.btnProcessPriority_Click);
            // 
            // grpProcessed
            // 
            this.grpProcessed.BackColor = System.Drawing.Color.White;
            this.grpProcessed.Controls.Add(this.lstProcessed);
            this.grpProcessed.Controls.Add(this.lblProcessedCount);
            this.grpProcessed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcessed.Location = new System.Drawing.Point(1035, 400);
            this.grpProcessed.Name = "grpProcessed";
            this.grpProcessed.Size = new System.Drawing.Size(518, 500);
            this.grpProcessed.TabIndex = 4;
            this.grpProcessed.TabStop = false;
            this.grpProcessed.Text = "✅ Processed Orders";
            this.grpProcessed.Enter += new System.EventHandler(this.grpProcessed_Enter);
            // 
            // lstProcessed
            // 
            this.lstProcessed.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstProcessed.FormattingEnabled = true;
            this.lstProcessed.ItemHeight = 22;
            this.lstProcessed.Location = new System.Drawing.Point(22, 50);
            this.lstProcessed.Name = "lstProcessed";
            this.lstProcessed.Size = new System.Drawing.Size(472, 378);
            this.lstProcessed.TabIndex = 0;
            this.lstProcessed.SelectedIndexChanged += new System.EventHandler(this.lstProcessed_SelectedIndexChanged);
            // 
            // lblProcessedCount
            // 
            this.lblProcessedCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProcessedCount.Location = new System.Drawing.Point(22, 450);
            this.lblProcessedCount.Name = "lblProcessedCount";
            this.lblProcessedCount.Size = new System.Drawing.Size(472, 31);
            this.lblProcessedCount.TabIndex = 1;
            this.lblProcessedCount.Text = "Processed: 0";
            this.lblProcessedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcessedCount.Click += new System.EventHandler(this.lblProcessedCount_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Location = new System.Drawing.Point(1238, 920);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(315, 50);
            this.btnClearAll.TabIndex = 5;
            this.btnClearAll.Text = "🗑️ Clear All Queues";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblLastProcessed
            // 
            this.lblLastProcessed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLastProcessed.Location = new System.Drawing.Point(22, 920);
            this.lblLastProcessed.Name = "lblLastProcessed";
            this.lblLastProcessed.Size = new System.Drawing.Size(1192, 50);
            this.lblLastProcessed.TabIndex = 6;
            this.lblLastProcessed.Text = "Ready to process orders";
            this.lblLastProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLastProcessed.Click += new System.EventHandler(this.lblLastProcessed_Click);
            // 
            // OrderProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1575, 990);
            this.Controls.Add(this.lblLastProcessed);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.grpProcessed);
            this.Controls.Add(this.grpPriorityQueue);
            this.Controls.Add(this.grpNormalQueue);
            this.Controls.Add(this.grpOrderInput);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "OrderProcessingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Processing";
            this.grpOrderInput.ResumeLayout(false);
            this.grpOrderInput.PerformLayout();
            this.grpNormalQueue.ResumeLayout(false);
            this.grpPriorityQueue.ResumeLayout(false);
            this.grpProcessed.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}