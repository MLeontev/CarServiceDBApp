namespace CarServiceDBApp.Forms
{
    partial class AddCarToClientForm
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
            dgvCars = new DataGridView();
            brand = new DataGridViewTextBoxColumn();
            model = new DataGridViewTextBoxColumn();
            registration_number = new DataGridViewTextBoxColumn();
            year = new DataGridViewTextBoxColumn();
            VIN = new DataGridViewTextBoxColumn();
            mileage = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            btnCancel = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Columns.AddRange(new DataGridViewColumn[] { brand, model, registration_number, year, VIN, mileage, id });
            dgvCars.Location = new Point(12, 12);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowTemplate.Height = 25;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(776, 297);
            dgvCars.TabIndex = 1;
            dgvCars.TabStop = false;
            // 
            // brand
            // 
            brand.DataPropertyName = "brand";
            brand.HeaderText = "Марка";
            brand.Name = "brand";
            brand.ReadOnly = true;
            // 
            // model
            // 
            model.DataPropertyName = "model";
            model.HeaderText = "Модель";
            model.Name = "model";
            model.ReadOnly = true;
            // 
            // registration_number
            // 
            registration_number.DataPropertyName = "registration_number";
            registration_number.HeaderText = "Номер";
            registration_number.Name = "registration_number";
            registration_number.ReadOnly = true;
            // 
            // year
            // 
            year.DataPropertyName = "year";
            year.HeaderText = "Год";
            year.Name = "year";
            year.ReadOnly = true;
            // 
            // VIN
            // 
            VIN.DataPropertyName = "VIN";
            VIN.HeaderText = "VIN";
            VIN.Name = "VIN";
            VIN.ReadOnly = true;
            // 
            // mileage
            // 
            mileage.DataPropertyName = "mileage";
            mileage.HeaderText = "Пробег";
            mileage.Name = "mileage";
            mileage.ReadOnly = true;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "CarId";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(672, 327);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 39);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(550, 327);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 39);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Выбрать";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddCarToClientForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(803, 382);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(dgvCars);
            MinimumSize = new Size(819, 421);
            Name = "AddCarToClientForm";
            Text = "Выбор автомобиля";
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCars;
        private Button btnCancel;
        private Button btnAdd;
        private DataGridViewTextBoxColumn brand;
        private DataGridViewTextBoxColumn model;
        private DataGridViewTextBoxColumn registration_number;
        private DataGridViewTextBoxColumn year;
        private DataGridViewTextBoxColumn VIN;
        private DataGridViewTextBoxColumn mileage;
        private DataGridViewTextBoxColumn id;
    }
}