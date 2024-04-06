namespace CarServiceDBApp.Forms
{
    partial class CarsForm
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
            btnHistory = new Button();
            gbClients = new GroupBox();
            dgvClients = new DataGridView();
            ClientFullName = new DataGridViewTextBoxColumn();
            birth_date = new DataGridViewTextBoxColumn();
            phone_number = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            ClientId = new DataGridViewTextBoxColumn();
            OwnershipId = new DataGridViewTextBoxColumn();
            btnDeleteClientFromCar = new Button();
            btnOpenAddClientForm = new Button();
            gbCar = new GroupBox();
            tcOrders = new TabControl();
            tpNewOrder = new TabPage();
            dtpYearToAdd = new DateTimePicker();
            tbMileageToAdd = new TextBox();
            label7 = new Label();
            tbVINToAdd = new TextBox();
            label5 = new Label();
            label4 = new Label();
            tbNumberToAdd = new TextBox();
            label3 = new Label();
            tbModelToAdd = new TextBox();
            label2 = new Label();
            tbBrandToAdd = new TextBox();
            label1 = new Label();
            btnCreateCar = new Button();
            tpCurrentOrder = new TabPage();
            dtpYearToEdit = new DateTimePicker();
            tbMileageToEdit = new TextBox();
            label6 = new Label();
            tbVINToEdit = new TextBox();
            label8 = new Label();
            label9 = new Label();
            tbNumberToEdit = new TextBox();
            label10 = new Label();
            tbModelToEdit = new TextBox();
            label11 = new Label();
            tbBrandToEdit = new TextBox();
            label12 = new Label();
            bntEditCar = new Button();
            btnDeleteCar = new Button();
            dgvCars = new DataGridView();
            Brand = new DataGridViewTextBoxColumn();
            Model = new DataGridViewTextBoxColumn();
            Plate = new DataGridViewTextBoxColumn();
            VIN = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            Mileage = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            btnUpdate = new Button();
            gbClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            gbCar.SuspendLayout();
            tcOrders.SuspendLayout();
            tpNewOrder.SuspendLayout();
            tpCurrentOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnHistory.Location = new Point(427, 348);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(623, 44);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "Посмотреть историю заказов по автомобилю";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // gbClients
            // 
            gbClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbClients.Controls.Add(dgvClients);
            gbClients.Controls.Add(btnDeleteClientFromCar);
            gbClients.Controls.Add(btnOpenAddClientForm);
            gbClients.Location = new Point(421, 408);
            gbClients.Name = "gbClients";
            gbClients.Size = new Size(629, 385);
            gbClients.TabIndex = 16;
            gbClients.TabStop = false;
            gbClients.Text = "Владельцы:";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Columns.AddRange(new DataGridViewColumn[] { ClientFullName, birth_date, phone_number, email, ClientId, OwnershipId });
            dgvClients.Location = new Point(10, 22);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowTemplate.Height = 25;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(613, 238);
            dgvClients.TabIndex = 19;
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
            birth_date.DataPropertyName = "birth_date";
            birth_date.HeaderText = "Дата рождения";
            birth_date.Name = "birth_date";
            birth_date.ReadOnly = true;
            // 
            // phone_number
            // 
            phone_number.DataPropertyName = "phone_number";
            phone_number.HeaderText = "Телефон";
            phone_number.Name = "phone_number";
            phone_number.ReadOnly = true;
            // 
            // email
            // 
            email.DataPropertyName = "email";
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
            // OwnershipId
            // 
            OwnershipId.DataPropertyName = "OwnershipId";
            OwnershipId.HeaderText = "OwnershipId";
            OwnershipId.Name = "OwnershipId";
            OwnershipId.ReadOnly = true;
            OwnershipId.Visible = false;
            // 
            // btnDeleteClientFromCar
            // 
            btnDeleteClientFromCar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteClientFromCar.Location = new Point(185, 283);
            btnDeleteClientFromCar.Name = "btnDeleteClientFromCar";
            btnDeleteClientFromCar.Size = new Size(169, 43);
            btnDeleteClientFromCar.TabIndex = 21;
            btnDeleteClientFromCar.Text = "Открепить владельца";
            btnDeleteClientFromCar.UseVisualStyleBackColor = true;
            btnDeleteClientFromCar.Click += btnDeleteClientFromCar_Click;
            // 
            // btnOpenAddClientForm
            // 
            btnOpenAddClientForm.Location = new Point(10, 283);
            btnOpenAddClientForm.Name = "btnOpenAddClientForm";
            btnOpenAddClientForm.Size = new Size(169, 43);
            btnOpenAddClientForm.TabIndex = 20;
            btnOpenAddClientForm.Text = "Добавить владельца";
            btnOpenAddClientForm.UseVisualStyleBackColor = true;
            btnOpenAddClientForm.Click += btnOpenAddClientForm_Click;
            // 
            // gbCar
            // 
            gbCar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            gbCar.Controls.Add(tcOrders);
            gbCar.Location = new Point(12, 342);
            gbCar.Name = "gbCar";
            gbCar.Size = new Size(385, 451);
            gbCar.TabIndex = 15;
            gbCar.TabStop = false;
            gbCar.Text = "Работа с автомобилями";
            // 
            // tcOrders
            // 
            tcOrders.Controls.Add(tpNewOrder);
            tcOrders.Controls.Add(tpCurrentOrder);
            tcOrders.Location = new Point(6, 22);
            tcOrders.Name = "tcOrders";
            tcOrders.SelectedIndex = 0;
            tcOrders.Size = new Size(366, 421);
            tcOrders.TabIndex = 3;
            // 
            // tpNewOrder
            // 
            tpNewOrder.Controls.Add(dtpYearToAdd);
            tpNewOrder.Controls.Add(tbMileageToAdd);
            tpNewOrder.Controls.Add(label7);
            tpNewOrder.Controls.Add(tbVINToAdd);
            tpNewOrder.Controls.Add(label5);
            tpNewOrder.Controls.Add(label4);
            tpNewOrder.Controls.Add(tbNumberToAdd);
            tpNewOrder.Controls.Add(label3);
            tpNewOrder.Controls.Add(tbModelToAdd);
            tpNewOrder.Controls.Add(label2);
            tpNewOrder.Controls.Add(tbBrandToAdd);
            tpNewOrder.Controls.Add(label1);
            tpNewOrder.Controls.Add(btnCreateCar);
            tpNewOrder.Location = new Point(4, 24);
            tpNewOrder.Name = "tpNewOrder";
            tpNewOrder.Padding = new Padding(3);
            tpNewOrder.Size = new Size(358, 393);
            tpNewOrder.TabIndex = 0;
            tpNewOrder.Text = "Новый автомобиль";
            tpNewOrder.UseVisualStyleBackColor = true;
            // 
            // dtpYearToAdd
            // 
            dtpYearToAdd.CustomFormat = "yyyy";
            dtpYearToAdd.Format = DateTimePickerFormat.Custom;
            dtpYearToAdd.Location = new Point(75, 194);
            dtpYearToAdd.Name = "dtpYearToAdd";
            dtpYearToAdd.ShowUpDown = true;
            dtpYearToAdd.Size = new Size(264, 23);
            dtpYearToAdd.TabIndex = 8;
            // 
            // tbMileageToAdd
            // 
            tbMileageToAdd.Location = new Point(75, 242);
            tbMileageToAdd.Name = "tbMileageToAdd";
            tbMileageToAdd.Size = new Size(264, 23);
            tbMileageToAdd.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 245);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 19;
            label7.Text = "Пробег:";
            // 
            // tbVINToAdd
            // 
            tbVINToAdd.Location = new Point(75, 150);
            tbVINToAdd.Name = "tbVINToAdd";
            tbVINToAdd.Size = new Size(264, 23);
            tbVINToAdd.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 200);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 17;
            label5.Text = "Год:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 153);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 15;
            label4.Text = "VIN:";
            // 
            // tbNumberToAdd
            // 
            tbNumberToAdd.Location = new Point(75, 102);
            tbNumberToAdd.Name = "tbNumberToAdd";
            tbNumberToAdd.Size = new Size(264, 23);
            tbNumberToAdd.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 105);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 13;
            label3.Text = "Номер:";
            // 
            // tbModelToAdd
            // 
            tbModelToAdd.Location = new Point(75, 56);
            tbModelToAdd.Name = "tbModelToAdd";
            tbModelToAdd.Size = new Size(264, 23);
            tbModelToAdd.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 59);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 11;
            label2.Text = "Модель:";
            // 
            // tbBrandToAdd
            // 
            tbBrandToAdd.Location = new Point(75, 17);
            tbBrandToAdd.Name = "tbBrandToAdd";
            tbBrandToAdd.Size = new Size(264, 23);
            tbBrandToAdd.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 9;
            label1.Text = "Марка:";
            // 
            // btnCreateCar
            // 
            btnCreateCar.Location = new Point(18, 290);
            btnCreateCar.Name = "btnCreateCar";
            btnCreateCar.Size = new Size(321, 36);
            btnCreateCar.TabIndex = 10;
            btnCreateCar.Text = "Добавить автомобиль";
            btnCreateCar.UseVisualStyleBackColor = true;
            btnCreateCar.Click += btnCreateCar_Click;
            // 
            // tpCurrentOrder
            // 
            tpCurrentOrder.Controls.Add(dtpYearToEdit);
            tpCurrentOrder.Controls.Add(tbMileageToEdit);
            tpCurrentOrder.Controls.Add(label6);
            tpCurrentOrder.Controls.Add(tbVINToEdit);
            tpCurrentOrder.Controls.Add(label8);
            tpCurrentOrder.Controls.Add(label9);
            tpCurrentOrder.Controls.Add(tbNumberToEdit);
            tpCurrentOrder.Controls.Add(label10);
            tpCurrentOrder.Controls.Add(tbModelToEdit);
            tpCurrentOrder.Controls.Add(label11);
            tpCurrentOrder.Controls.Add(tbBrandToEdit);
            tpCurrentOrder.Controls.Add(label12);
            tpCurrentOrder.Controls.Add(bntEditCar);
            tpCurrentOrder.Controls.Add(btnDeleteCar);
            tpCurrentOrder.Location = new Point(4, 24);
            tpCurrentOrder.Name = "tpCurrentOrder";
            tpCurrentOrder.Padding = new Padding(3);
            tpCurrentOrder.Size = new Size(358, 393);
            tpCurrentOrder.TabIndex = 1;
            tpCurrentOrder.Text = "Выбранный автомобиль";
            tpCurrentOrder.UseVisualStyleBackColor = true;
            // 
            // dtpYearToEdit
            // 
            dtpYearToEdit.CustomFormat = "yyyy";
            dtpYearToEdit.Format = DateTimePickerFormat.Custom;
            dtpYearToEdit.Location = new Point(75, 194);
            dtpYearToEdit.Name = "dtpYearToEdit";
            dtpYearToEdit.ShowUpDown = true;
            dtpYearToEdit.Size = new Size(264, 23);
            dtpYearToEdit.TabIndex = 15;
            // 
            // tbMileageToEdit
            // 
            tbMileageToEdit.Location = new Point(75, 242);
            tbMileageToEdit.Name = "tbMileageToEdit";
            tbMileageToEdit.Size = new Size(264, 23);
            tbMileageToEdit.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 245);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 31;
            label6.Text = "Пробег:";
            // 
            // tbVINToEdit
            // 
            tbVINToEdit.Location = new Point(75, 150);
            tbVINToEdit.Name = "tbVINToEdit";
            tbVINToEdit.Size = new Size(264, 23);
            tbVINToEdit.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 200);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 29;
            label8.Text = "Год:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 153);
            label9.Name = "label9";
            label9.Size = new Size(29, 15);
            label9.TabIndex = 28;
            label9.Text = "VIN:";
            // 
            // tbNumberToEdit
            // 
            tbNumberToEdit.Location = new Point(75, 102);
            tbNumberToEdit.Name = "tbNumberToEdit";
            tbNumberToEdit.Size = new Size(264, 23);
            tbNumberToEdit.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 105);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 26;
            label10.Text = "Номер:";
            // 
            // tbModelToEdit
            // 
            tbModelToEdit.Location = new Point(75, 56);
            tbModelToEdit.Name = "tbModelToEdit";
            tbModelToEdit.Size = new Size(264, 23);
            tbModelToEdit.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 59);
            label11.Name = "label11";
            label11.Size = new Size(53, 15);
            label11.TabIndex = 24;
            label11.Text = "Модель:";
            // 
            // tbBrandToEdit
            // 
            tbBrandToEdit.Location = new Point(75, 17);
            tbBrandToEdit.Name = "tbBrandToEdit";
            tbBrandToEdit.Size = new Size(264, 23);
            tbBrandToEdit.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 20);
            label12.Name = "label12";
            label12.Size = new Size(46, 15);
            label12.TabIndex = 22;
            label12.Text = "Марка:";
            // 
            // bntEditCar
            // 
            bntEditCar.Location = new Point(18, 290);
            bntEditCar.Name = "bntEditCar";
            bntEditCar.Size = new Size(321, 36);
            bntEditCar.TabIndex = 17;
            bntEditCar.Text = "Редактировать автомобиль";
            bntEditCar.UseVisualStyleBackColor = true;
            bntEditCar.Click += bntEditCar_Click;
            // 
            // btnDeleteCar
            // 
            btnDeleteCar.Location = new Point(18, 346);
            btnDeleteCar.Name = "btnDeleteCar";
            btnDeleteCar.Size = new Size(321, 35);
            btnDeleteCar.TabIndex = 18;
            btnDeleteCar.Text = "Удалить автомобиль";
            btnDeleteCar.UseVisualStyleBackColor = true;
            btnDeleteCar.Click += btnDeleteCar_Click;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Columns.AddRange(new DataGridViewColumn[] { Brand, Model, Plate, VIN, Year, Mileage, Id });
            dgvCars.Location = new Point(12, 35);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowTemplate.Height = 25;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(1038, 285);
            dgvCars.TabIndex = 1;
            dgvCars.SelectionChanged += dgvCars_SelectionChanged;
            // 
            // Brand
            // 
            Brand.DataPropertyName = "brand";
            Brand.HeaderText = "Марка";
            Brand.Name = "Brand";
            Brand.ReadOnly = true;
            // 
            // Model
            // 
            Model.DataPropertyName = "model";
            Model.HeaderText = "Модель";
            Model.Name = "Model";
            Model.ReadOnly = true;
            // 
            // Plate
            // 
            Plate.DataPropertyName = "registration_number";
            Plate.HeaderText = "Номер";
            Plate.Name = "Plate";
            Plate.ReadOnly = true;
            // 
            // VIN
            // 
            VIN.DataPropertyName = "VIN";
            VIN.HeaderText = "VIN";
            VIN.Name = "VIN";
            VIN.ReadOnly = true;
            // 
            // Year
            // 
            Year.DataPropertyName = "year";
            Year.HeaderText = "Год";
            Year.Name = "Year";
            Year.ReadOnly = true;
            // 
            // Mileage
            // 
            Mileage.DataPropertyName = "mileage";
            Mileage.HeaderText = "Пробег";
            Mileage.Name = "Mileage";
            Mileage.ReadOnly = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(975, 6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // CarsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 811);
            Controls.Add(btnUpdate);
            Controls.Add(btnHistory);
            Controls.Add(gbClients);
            Controls.Add(gbCar);
            Controls.Add(dgvCars);
            MinimumSize = new Size(1078, 850);
            Name = "CarsForm";
            Text = "База автомобилей";
            Load += CarsForm_Load;
            gbClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            gbCar.ResumeLayout(false);
            tcOrders.ResumeLayout(false);
            tpNewOrder.ResumeLayout(false);
            tpNewOrder.PerformLayout();
            tpCurrentOrder.ResumeLayout(false);
            tpCurrentOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnHistory;
        private GroupBox gbClients;
        private DataGridView dgvClients;
        private Button btnDeleteClientFromCar;
        private Button btnOpenAddClientForm;
        private GroupBox gbCar;
        private TabControl tcOrders;
        private TabPage tpNewOrder;
        private DateTimePicker dtpYearToAdd;
        private TextBox tbMileageToAdd;
        private Label label7;
        private TextBox tbVINToAdd;
        private Label label5;
        private Label label4;
        private TextBox tbNumberToAdd;
        private Label label3;
        private TextBox tbModelToAdd;
        private Label label2;
        private TextBox tbBrandToAdd;
        private Label label1;
        private Button btnCreateCar;
        private TabPage tpCurrentOrder;
        private Button bntEditCar;
        private Button btnDeleteCar;
        private DataGridView dgvCars;
        private DateTimePicker dtpYearToEdit;
        private TextBox tbMileageToEdit;
        private Label label6;
        private TextBox tbVINToEdit;
        private Label label8;
        private Label label9;
        private TextBox tbNumberToEdit;
        private Label label10;
        private TextBox tbModelToEdit;
        private Label label11;
        private TextBox tbBrandToEdit;
        private Label label12;
        private DataGridViewTextBoxColumn Brand;
        private DataGridViewTextBoxColumn Model;
        private DataGridViewTextBoxColumn Plate;
        private DataGridViewTextBoxColumn VIN;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Mileage;
        private DataGridViewTextBoxColumn Id;
        private Button btnUpdate;
        private DataGridViewTextBoxColumn ClientFullName;
        private DataGridViewTextBoxColumn birth_date;
        private DataGridViewTextBoxColumn phone_number;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn ClientId;
        private DataGridViewTextBoxColumn OwnershipId;
    }
}