namespace CarServiceDBApp.Forms
{
    partial class HistoryForm
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
            dgvOrders = new DataGridView();
            OrderId = new DataGridViewTextBoxColumn();
            OwnershipId = new DataGridViewTextBoxColumn();
            ClientId = new DataGridViewTextBoxColumn();
            CarId = new DataGridViewTextBoxColumn();
            ClientFullName = new DataGridViewTextBoxColumn();
            CarFullName = new DataGridViewTextBoxColumn();
            AppointmentDate = new DataGridViewTextBoxColumn();
            CompletionDate = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            StatusId = new DataGridViewTextBoxColumn();
            StatusName = new DataGridViewTextBoxColumn();
            gbOrderDetails = new GroupBox();
            dgvOrderDetails = new DataGridView();
            ServiceId = new DataGridViewTextBoxColumn();
            OrderDetailsId = new DataGridViewTextBoxColumn();
            ServiceName = new DataGridViewTextBoxColumn();
            WorkerId = new DataGridViewTextBoxColumn();
            WorkerFullName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            gbOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { OrderId, OwnershipId, ClientId, CarId, ClientFullName, CarFullName, AppointmentDate, CompletionDate, Sum, StatusId, StatusName });
            dgvOrders.Location = new Point(12, 12);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowTemplate.Height = 25;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(993, 283);
            dgvOrders.TabIndex = 1;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // OrderId
            // 
            OrderId.DataPropertyName = "OrderId";
            OrderId.HeaderText = "Номер заказа";
            OrderId.Name = "OrderId";
            OrderId.ReadOnly = true;
            // 
            // OwnershipId
            // 
            OwnershipId.DataPropertyName = "OwnershipId";
            OwnershipId.HeaderText = "OwnershipId";
            OwnershipId.Name = "OwnershipId";
            OwnershipId.ReadOnly = true;
            OwnershipId.Visible = false;
            // 
            // ClientId
            // 
            ClientId.DataPropertyName = "ClientId";
            ClientId.HeaderText = "ClientId";
            ClientId.Name = "ClientId";
            ClientId.ReadOnly = true;
            ClientId.Visible = false;
            // 
            // CarId
            // 
            CarId.DataPropertyName = "CarId";
            CarId.HeaderText = "CarId";
            CarId.Name = "CarId";
            CarId.ReadOnly = true;
            CarId.Visible = false;
            // 
            // ClientFullName
            // 
            ClientFullName.DataPropertyName = "ClientFullName";
            ClientFullName.HeaderText = "Клиент";
            ClientFullName.Name = "ClientFullName";
            ClientFullName.ReadOnly = true;
            // 
            // CarFullName
            // 
            CarFullName.DataPropertyName = "CarFullName";
            CarFullName.HeaderText = "Автомобиль";
            CarFullName.Name = "CarFullName";
            CarFullName.ReadOnly = true;
            // 
            // AppointmentDate
            // 
            AppointmentDate.DataPropertyName = "AppointmentDate";
            AppointmentDate.HeaderText = "Дата приема";
            AppointmentDate.Name = "AppointmentDate";
            AppointmentDate.ReadOnly = true;
            // 
            // CompletionDate
            // 
            CompletionDate.DataPropertyName = "CompletionDate";
            CompletionDate.HeaderText = "Дата выпуска";
            CompletionDate.Name = "CompletionDate";
            CompletionDate.ReadOnly = true;
            // 
            // Sum
            // 
            Sum.DataPropertyName = "Sum";
            Sum.HeaderText = "Сумма";
            Sum.Name = "Sum";
            Sum.ReadOnly = true;
            // 
            // StatusId
            // 
            StatusId.DataPropertyName = "StatusId";
            StatusId.HeaderText = "StatusId";
            StatusId.Name = "StatusId";
            StatusId.ReadOnly = true;
            StatusId.Visible = false;
            // 
            // StatusName
            // 
            StatusName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StatusName.DataPropertyName = "StatusName";
            StatusName.HeaderText = "Статус";
            StatusName.Name = "StatusName";
            StatusName.ReadOnly = true;
            // 
            // gbOrderDetails
            // 
            gbOrderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbOrderDetails.Controls.Add(dgvOrderDetails);
            gbOrderDetails.Location = new Point(13, 301);
            gbOrderDetails.Name = "gbOrderDetails";
            gbOrderDetails.Size = new Size(993, 218);
            gbOrderDetails.TabIndex = 12;
            gbOrderDetails.TabStop = false;
            gbOrderDetails.Text = "Состав выбранного заказа";
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[] { ServiceId, OrderDetailsId, ServiceName, WorkerId, WorkerFullName, Price, Status });
            dgvOrderDetails.Location = new Point(6, 20);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowTemplate.Height = 25;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(981, 182);
            dgvOrderDetails.TabIndex = 2;
            // 
            // ServiceId
            // 
            ServiceId.DataPropertyName = "ServiceId";
            ServiceId.HeaderText = "ServiceId";
            ServiceId.Name = "ServiceId";
            ServiceId.ReadOnly = true;
            ServiceId.Visible = false;
            // 
            // OrderDetailsId
            // 
            OrderDetailsId.DataPropertyName = "OrderDetailsId";
            OrderDetailsId.HeaderText = "OrderDetailsId";
            OrderDetailsId.Name = "OrderDetailsId";
            OrderDetailsId.ReadOnly = true;
            OrderDetailsId.Visible = false;
            // 
            // ServiceName
            // 
            ServiceName.DataPropertyName = "ServiceName";
            ServiceName.HeaderText = "Услуга";
            ServiceName.Name = "ServiceName";
            ServiceName.ReadOnly = true;
            // 
            // WorkerId
            // 
            WorkerId.DataPropertyName = "WorkerId";
            WorkerId.HeaderText = "WorkerId";
            WorkerId.Name = "WorkerId";
            WorkerId.ReadOnly = true;
            WorkerId.Visible = false;
            // 
            // WorkerFullName
            // 
            WorkerFullName.DataPropertyName = "WorkerFullName";
            WorkerFullName.HeaderText = "Исполнитель";
            WorkerFullName.Name = "WorkerFullName";
            WorkerFullName.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Стоимость";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Статус";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 528);
            Controls.Add(gbOrderDetails);
            Controls.Add(dgvOrders);
            MinimumSize = new Size(912, 478);
            Name = "HistoryForm";
            Text = "История заказов";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            gbOrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn OwnershipId;
        private DataGridViewTextBoxColumn ClientId;
        private DataGridViewTextBoxColumn CarId;
        private DataGridViewTextBoxColumn ClientFullName;
        private DataGridViewTextBoxColumn CarFullName;
        private DataGridViewTextBoxColumn AppointmentDate;
        private DataGridViewTextBoxColumn CompletionDate;
        private DataGridViewTextBoxColumn Sum;
        private DataGridViewTextBoxColumn StatusId;
        private DataGridViewTextBoxColumn StatusName;
        private GroupBox gbOrderDetails;
        private DataGridViewTextBoxColumn ServiceId;
        private DataGridViewTextBoxColumn OrderDetailsId;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn WorkerId;
        private DataGridViewTextBoxColumn WorkerFullName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Status;
        public DataGridView dgvOrders;
        public DataGridView dgvOrderDetails;
    }
}