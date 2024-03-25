namespace CarServiceDBApp.Forms
{
    partial class AddServiceToOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvServicesToOrder = new DataGridView();
            ServiceId = new DataGridViewTextBoxColumn();
            ServiceName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            cbWorkerToService = new ComboBox();
            btnAddServiceToOrder = new Button();
            btnCancel = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvServicesToOrder).BeginInit();
            SuspendLayout();
            // 
            // dgvServicesToOrder
            // 
            dgvServicesToOrder.AllowUserToAddRows = false;
            dgvServicesToOrder.AllowUserToDeleteRows = false;
            dgvServicesToOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicesToOrder.Columns.AddRange(new DataGridViewColumn[] { ServiceId, ServiceName, Price });
            dgvServicesToOrder.Location = new Point(12, 12);
            dgvServicesToOrder.Name = "dgvServicesToOrder";
            dgvServicesToOrder.ReadOnly = true;
            dgvServicesToOrder.RowTemplate.Height = 25;
            dgvServicesToOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicesToOrder.Size = new Size(520, 240);
            dgvServicesToOrder.TabIndex = 0;
            // 
            // ServiceId
            // 
            ServiceId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ServiceId.DataPropertyName = "ServiceId";
            ServiceId.HeaderText = "ServiceId";
            ServiceId.MinimumWidth = 100;
            ServiceId.Name = "ServiceId";
            ServiceId.ReadOnly = true;
            ServiceId.Visible = false;
            // 
            // ServiceName
            // 
            ServiceName.DataPropertyName = "ServiceName";
            ServiceName.HeaderText = "Название";
            ServiceName.Name = "ServiceName";
            ServiceName.ReadOnly = true;
            ServiceName.Width = 300;
            // 
            // Price
            // 
            Price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Стоимость";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // cbWorkerToService
            // 
            cbWorkerToService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWorkerToService.FormattingEnabled = true;
            cbWorkerToService.Location = new Point(12, 300);
            cbWorkerToService.Name = "cbWorkerToService";
            cbWorkerToService.Size = new Size(520, 23);
            cbWorkerToService.TabIndex = 1;
            // 
            // btnAddServiceToOrder
            // 
            btnAddServiceToOrder.Location = new Point(364, 349);
            btnAddServiceToOrder.Name = "btnAddServiceToOrder";
            btnAddServiceToOrder.Size = new Size(81, 39);
            btnAddServiceToOrder.TabIndex = 2;
            btnAddServiceToOrder.Text = "Добавить";
            btnAddServiceToOrder.UseVisualStyleBackColor = true;
            btnAddServiceToOrder.Click += btnAddServiceToOrder_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(451, 349);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(81, 39);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 276);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 4;
            label1.Text = "Выберите исполнителя:";
            // 
            // AddServiceToOrderForm
            // 
            AcceptButton = btnAddServiceToOrder;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(544, 400);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnAddServiceToOrder);
            Controls.Add(cbWorkerToService);
            Controls.Add(dgvServicesToOrder);
            Name = "AddServiceToOrderForm";
            Text = "Добавление услуги к заказу";
            ((System.ComponentModel.ISupportInitialize)dgvServicesToOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvServicesToOrder;
        private ComboBox cbWorkerToService;
        private Button btnAddServiceToOrder;
        private Button btnCancel;
        private DataGridViewTextBoxColumn ServiceId;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn Price;
        private Label label1;
    }
}