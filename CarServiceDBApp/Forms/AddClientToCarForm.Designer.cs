namespace CarServiceDBApp.Forms
{
    partial class AddClientToCarForm
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
            dgvClients = new DataGridView();
            btnCancel = new Button();
            btnAdd = new Button();
            ClientFullName = new DataGridViewTextBoxColumn();
            birth_date = new DataGridViewTextBoxColumn();
            phone_number = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            ClientId = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Columns.AddRange(new DataGridViewColumn[] { ClientFullName, birth_date, phone_number, email, ClientId });
            dgvClients.Location = new Point(12, 12);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowTemplate.Height = 25;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(750, 260);
            dgvClients.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(646, 287);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 39);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(524, 287);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 39);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Выбрать";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ClientFullName
            // 
            ClientFullName.DataPropertyName = "ClientFullName";
            ClientFullName.HeaderText = "Клиент";
            ClientFullName.Name = "ClientFullName";
            ClientFullName.ReadOnly = true;
            // 
            // birth_date
            // 
            birth_date.DataPropertyName = "ClientBirthDate";
            birth_date.HeaderText = "Дата рождения";
            birth_date.Name = "birth_date";
            birth_date.ReadOnly = true;
            // 
            // phone_number
            // 
            phone_number.DataPropertyName = "ClientPhoneNumber";
            phone_number.HeaderText = "Телефон";
            phone_number.Name = "phone_number";
            phone_number.ReadOnly = true;
            // 
            // email
            // 
            email.DataPropertyName = "ClientEmail";
            email.HeaderText = "Почта";
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // ClientId
            // 
            ClientId.DataPropertyName = "ClientId";
            ClientId.HeaderText = "ClientId";
            ClientId.Name = "ClientId";
            ClientId.ReadOnly = true;
            ClientId.Visible = false;
            // 
            // AddClientToCarForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(774, 340);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(dgvClients);
            Name = "AddClientToCarForm";
            Text = "AddClientToCarForm";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClients;
        private Button btnCancel;
        private Button btnAdd;
        private DataGridViewTextBoxColumn ClientFullName;
        private DataGridViewTextBoxColumn birth_date;
        private DataGridViewTextBoxColumn phone_number;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn ClientId;
    }
}