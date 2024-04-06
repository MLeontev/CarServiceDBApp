namespace CarServiceDBApp.Forms
{
    partial class EditServiceInOrderForm
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
            btnCancel = new Button();
            btnEditWorkerInService = new Button();
            dgvWorkersToOrder = new DataGridView();
            WorkerId = new DataGridViewTextBoxColumn();
            WorkerFullName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvWorkersToOrder).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(433, 282);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(81, 39);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEditWorkerInService
            // 
            btnEditWorkerInService.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditWorkerInService.Location = new Point(327, 282);
            btnEditWorkerInService.Name = "btnEditWorkerInService";
            btnEditWorkerInService.Size = new Size(100, 39);
            btnEditWorkerInService.TabIndex = 2;
            btnEditWorkerInService.Text = "Выбрать";
            btnEditWorkerInService.UseVisualStyleBackColor = true;
            btnEditWorkerInService.Click += btnEditWorkerInService_Click;
            // 
            // dgvWorkersToOrder
            // 
            dgvWorkersToOrder.AllowUserToAddRows = false;
            dgvWorkersToOrder.AllowUserToDeleteRows = false;
            dgvWorkersToOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvWorkersToOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkersToOrder.Columns.AddRange(new DataGridViewColumn[] { WorkerId, WorkerFullName, PhoneNumber });
            dgvWorkersToOrder.Location = new Point(12, 12);
            dgvWorkersToOrder.Name = "dgvWorkersToOrder";
            dgvWorkersToOrder.ReadOnly = true;
            dgvWorkersToOrder.RowTemplate.Height = 25;
            dgvWorkersToOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkersToOrder.Size = new Size(502, 252);
            dgvWorkersToOrder.TabIndex = 1;
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
            WorkerFullName.HeaderText = "Работник";
            WorkerFullName.Name = "WorkerFullName";
            WorkerFullName.ReadOnly = true;
            WorkerFullName.Width = 250;
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "Номер телефона";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            // 
            // EditServiceInOrderForm
            // 
            AcceptButton = btnEditWorkerInService;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(527, 331);
            Controls.Add(btnCancel);
            Controls.Add(btnEditWorkerInService);
            Controls.Add(dgvWorkersToOrder);
            MinimumSize = new Size(491, 321);
            Name = "EditServiceInOrderForm";
            Text = "Изменение исполнителя";
            ((System.ComponentModel.ISupportInitialize)dgvWorkersToOrder).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnEditWorkerInService;
        private DataGridView dgvWorkersToOrder;
        private DataGridViewTextBoxColumn WorkerId;
        private DataGridViewTextBoxColumn WorkerFullName;
        private DataGridViewTextBoxColumn PhoneNumber;
    }
}