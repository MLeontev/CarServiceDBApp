namespace CarServiceDBApp.Forms
{
    partial class ClientsForm
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
            ClientFullName = new DataGridViewTextBoxColumn();
            ClientBirthDate = new DataGridViewTextBoxColumn();
            ClientPhoneNumber = new DataGridViewTextBoxColumn();
            ClientEmail = new DataGridViewTextBoxColumn();
            ClientId = new DataGridViewTextBoxColumn();
            gbOrder = new GroupBox();
            tcOrders = new TabControl();
            tpNewOrder = new TabPage();
            tbNumberToAdd = new MaskedTextBox();
            dtpBirthDateToAdd = new DateTimePicker();
            tbEmailToAdd = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            tbPatronymicToAdd = new TextBox();
            label3 = new Label();
            tbNameToAdd = new TextBox();
            label2 = new Label();
            tbSurnameToAdd = new TextBox();
            label1 = new Label();
            btnCreateClient = new Button();
            tpCurrentOrder = new TabPage();
            tbNumberToEdit = new MaskedTextBox();
            dtpBirthDateToEdit = new DateTimePicker();
            tbEmailToEdit = new TextBox();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbPatronymicToEdit = new TextBox();
            label10 = new Label();
            tbNameToEdit = new TextBox();
            label11 = new Label();
            tbSurnameToEdit = new TextBox();
            label12 = new Label();
            bntEditClient = new Button();
            btnDeleteClient = new Button();
            gbOrderDetails = new GroupBox();
            dgvCars = new DataGridView();
            CarBrand = new DataGridViewTextBoxColumn();
            CarModel = new DataGridViewTextBoxColumn();
            CarNumber = new DataGridViewTextBoxColumn();
            CarYear = new DataGridViewTextBoxColumn();
            CarVIN = new DataGridViewTextBoxColumn();
            CarMileage = new DataGridViewTextBoxColumn();
            CarId = new DataGridViewTextBoxColumn();
            OwnershipId = new DataGridViewTextBoxColumn();
            btnDeleteCarFromClient = new Button();
            btnOpenAddCarToClientForm = new Button();
            btnHistory = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            gbOrder.SuspendLayout();
            tcOrders.SuspendLayout();
            tpNewOrder.SuspendLayout();
            tpCurrentOrder.SuspendLayout();
            gbOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Columns.AddRange(new DataGridViewColumn[] { ClientFullName, ClientBirthDate, ClientPhoneNumber, ClientEmail, ClientId });
            dgvClients.Location = new Point(12, 32);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowTemplate.Height = 25;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(1038, 367);
            dgvClients.TabIndex = 0;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            // 
            // ClientFullName
            // 
            ClientFullName.DataPropertyName = "ClientFullName";
            ClientFullName.HeaderText = "Клиент";
            ClientFullName.Name = "ClientFullName";
            ClientFullName.ReadOnly = true;
            // 
            // ClientBirthDate
            // 
            ClientBirthDate.DataPropertyName = "ClientBirthDate";
            ClientBirthDate.HeaderText = "Дата рождения";
            ClientBirthDate.Name = "ClientBirthDate";
            ClientBirthDate.ReadOnly = true;
            // 
            // ClientPhoneNumber
            // 
            ClientPhoneNumber.DataPropertyName = "ClientPhoneNumber";
            ClientPhoneNumber.HeaderText = "Телефон";
            ClientPhoneNumber.Name = "ClientPhoneNumber";
            ClientPhoneNumber.ReadOnly = true;
            // 
            // ClientEmail
            // 
            ClientEmail.DataPropertyName = "ClientEmail";
            ClientEmail.HeaderText = "Адрес электронной почты";
            ClientEmail.Name = "ClientEmail";
            ClientEmail.ReadOnly = true;
            // 
            // ClientId
            // 
            ClientId.DataPropertyName = "ClientId";
            ClientId.HeaderText = "ClientId";
            ClientId.Name = "ClientId";
            ClientId.ReadOnly = true;
            ClientId.Visible = false;
            // 
            // gbOrder
            // 
            gbOrder.Controls.Add(tcOrders);
            gbOrder.Location = new Point(12, 421);
            gbOrder.Name = "gbOrder";
            gbOrder.Size = new Size(403, 443);
            gbOrder.TabIndex = 11;
            gbOrder.TabStop = false;
            gbOrder.Text = "Работа с клиентами";
            // 
            // tcOrders
            // 
            tcOrders.Controls.Add(tpNewOrder);
            tcOrders.Controls.Add(tpCurrentOrder);
            tcOrders.Location = new Point(6, 22);
            tcOrders.Name = "tcOrders";
            tcOrders.SelectedIndex = 0;
            tcOrders.Size = new Size(391, 415);
            tcOrders.TabIndex = 0;
            // 
            // tpNewOrder
            // 
            tpNewOrder.Controls.Add(tbNumberToAdd);
            tpNewOrder.Controls.Add(dtpBirthDateToAdd);
            tpNewOrder.Controls.Add(tbEmailToAdd);
            tpNewOrder.Controls.Add(label7);
            tpNewOrder.Controls.Add(label5);
            tpNewOrder.Controls.Add(label4);
            tpNewOrder.Controls.Add(tbPatronymicToAdd);
            tpNewOrder.Controls.Add(label3);
            tpNewOrder.Controls.Add(tbNameToAdd);
            tpNewOrder.Controls.Add(label2);
            tpNewOrder.Controls.Add(tbSurnameToAdd);
            tpNewOrder.Controls.Add(label1);
            tpNewOrder.Controls.Add(btnCreateClient);
            tpNewOrder.Location = new Point(4, 24);
            tpNewOrder.Name = "tpNewOrder";
            tpNewOrder.Padding = new Padding(3);
            tpNewOrder.Size = new Size(383, 387);
            tpNewOrder.TabIndex = 0;
            tpNewOrder.Text = "Новый клиент";
            tpNewOrder.UseVisualStyleBackColor = true;
            // 
            // tbNumberToAdd
            // 
            tbNumberToAdd.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            tbNumberToAdd.Location = new Point(106, 193);
            tbNumberToAdd.Mask = "+7 999 000-00-00";
            tbNumberToAdd.Name = "tbNumberToAdd";
            tbNumberToAdd.Size = new Size(264, 23);
            tbNumberToAdd.TabIndex = 22;
            // 
            // dtpBirthDateToAdd
            // 
            dtpBirthDateToAdd.Location = new Point(106, 143);
            dtpBirthDateToAdd.Name = "dtpBirthDateToAdd";
            dtpBirthDateToAdd.Size = new Size(264, 23);
            dtpBirthDateToAdd.TabIndex = 21;
            // 
            // tbEmailToAdd
            // 
            tbEmailToAdd.Location = new Point(106, 238);
            tbEmailToAdd.Name = "tbEmailToAdd";
            tbEmailToAdd.Size = new Size(264, 23);
            tbEmailToAdd.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 241);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 19;
            label7.Text = "Почта:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 196);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 17;
            label5.Text = "Телефон:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 149);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 15;
            label4.Text = "Дата рождения:";
            // 
            // tbPatronymicToAdd
            // 
            tbPatronymicToAdd.Location = new Point(106, 98);
            tbPatronymicToAdd.Name = "tbPatronymicToAdd";
            tbPatronymicToAdd.Size = new Size(264, 23);
            tbPatronymicToAdd.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 101);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 13;
            label3.Text = "Отчество:";
            // 
            // tbNameToAdd
            // 
            tbNameToAdd.Location = new Point(106, 52);
            tbNameToAdd.Name = "tbNameToAdd";
            tbNameToAdd.Size = new Size(264, 23);
            tbNameToAdd.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "Имя:";
            // 
            // tbSurnameToAdd
            // 
            tbSurnameToAdd.Location = new Point(106, 13);
            tbSurnameToAdd.Name = "tbSurnameToAdd";
            tbSurnameToAdd.Size = new Size(264, 23);
            tbSurnameToAdd.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 16);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 9;
            label1.Text = "Фамилия:";
            // 
            // btnCreateClient
            // 
            btnCreateClient.Location = new Point(6, 289);
            btnCreateClient.Name = "btnCreateClient";
            btnCreateClient.Size = new Size(364, 36);
            btnCreateClient.TabIndex = 8;
            btnCreateClient.Text = "Добавить клиента";
            btnCreateClient.UseVisualStyleBackColor = true;
            btnCreateClient.Click += btnCreateClient_Click;
            // 
            // tpCurrentOrder
            // 
            tpCurrentOrder.Controls.Add(tbNumberToEdit);
            tpCurrentOrder.Controls.Add(dtpBirthDateToEdit);
            tpCurrentOrder.Controls.Add(tbEmailToEdit);
            tpCurrentOrder.Controls.Add(label6);
            tpCurrentOrder.Controls.Add(label8);
            tpCurrentOrder.Controls.Add(label9);
            tpCurrentOrder.Controls.Add(tbPatronymicToEdit);
            tpCurrentOrder.Controls.Add(label10);
            tpCurrentOrder.Controls.Add(tbNameToEdit);
            tpCurrentOrder.Controls.Add(label11);
            tpCurrentOrder.Controls.Add(tbSurnameToEdit);
            tpCurrentOrder.Controls.Add(label12);
            tpCurrentOrder.Controls.Add(bntEditClient);
            tpCurrentOrder.Controls.Add(btnDeleteClient);
            tpCurrentOrder.Location = new Point(4, 24);
            tpCurrentOrder.Name = "tpCurrentOrder";
            tpCurrentOrder.Padding = new Padding(3);
            tpCurrentOrder.Size = new Size(383, 387);
            tpCurrentOrder.TabIndex = 1;
            tpCurrentOrder.Text = "Выбранный клиент";
            tpCurrentOrder.UseVisualStyleBackColor = true;
            // 
            // tbNumberToEdit
            // 
            tbNumberToEdit.Location = new Point(106, 193);
            tbNumberToEdit.Mask = "+7 999 000-00-00";
            tbNumberToEdit.Name = "tbNumberToEdit";
            tbNumberToEdit.Size = new Size(264, 23);
            tbNumberToEdit.TabIndex = 33;
            // 
            // dtpBirthDateToEdit
            // 
            dtpBirthDateToEdit.Location = new Point(107, 143);
            dtpBirthDateToEdit.Name = "dtpBirthDateToEdit";
            dtpBirthDateToEdit.Size = new Size(263, 23);
            dtpBirthDateToEdit.TabIndex = 32;
            // 
            // tbEmailToEdit
            // 
            tbEmailToEdit.Location = new Point(107, 238);
            tbEmailToEdit.Name = "tbEmailToEdit";
            tbEmailToEdit.Size = new Size(264, 23);
            tbEmailToEdit.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 241);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 30;
            label6.Text = "Почта:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 196);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 28;
            label8.Text = "Телефон:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 149);
            label9.Name = "label9";
            label9.Size = new Size(93, 15);
            label9.TabIndex = 27;
            label9.Text = "Дата рождения:";
            // 
            // tbPatronymicToEdit
            // 
            tbPatronymicToEdit.Location = new Point(107, 98);
            tbPatronymicToEdit.Name = "tbPatronymicToEdit";
            tbPatronymicToEdit.Size = new Size(264, 23);
            tbPatronymicToEdit.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 101);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 25;
            label10.Text = "Отчество:";
            // 
            // tbNameToEdit
            // 
            tbNameToEdit.Location = new Point(107, 52);
            tbNameToEdit.Name = "tbNameToEdit";
            tbNameToEdit.Size = new Size(264, 23);
            tbNameToEdit.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 55);
            label11.Name = "label11";
            label11.Size = new Size(34, 15);
            label11.TabIndex = 23;
            label11.Text = "Имя:";
            // 
            // tbSurnameToEdit
            // 
            tbSurnameToEdit.Location = new Point(107, 13);
            tbSurnameToEdit.Name = "tbSurnameToEdit";
            tbSurnameToEdit.Size = new Size(264, 23);
            tbSurnameToEdit.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 16);
            label12.Name = "label12";
            label12.Size = new Size(61, 15);
            label12.TabIndex = 21;
            label12.Text = "Фамилия:";
            // 
            // bntEditClient
            // 
            bntEditClient.Location = new Point(7, 290);
            bntEditClient.Name = "bntEditClient";
            bntEditClient.Size = new Size(364, 36);
            bntEditClient.TabIndex = 17;
            bntEditClient.Text = "Редактировать клиента";
            bntEditClient.UseVisualStyleBackColor = true;
            bntEditClient.Click += bntEditClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(7, 346);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(364, 35);
            btnDeleteClient.TabIndex = 5;
            btnDeleteClient.Text = "Удалить клиента";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click;
            // 
            // gbOrderDetails
            // 
            gbOrderDetails.Controls.Add(dgvCars);
            gbOrderDetails.Controls.Add(btnDeleteCarFromClient);
            gbOrderDetails.Controls.Add(btnOpenAddCarToClientForm);
            gbOrderDetails.Location = new Point(421, 483);
            gbOrderDetails.Name = "gbOrderDetails";
            gbOrderDetails.Size = new Size(629, 381);
            gbOrderDetails.TabIndex = 12;
            gbOrderDetails.TabStop = false;
            gbOrderDetails.Text = "Автомобили клиента";
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Columns.AddRange(new DataGridViewColumn[] { CarBrand, CarModel, CarNumber, CarYear, CarVIN, CarMileage, CarId, OwnershipId });
            dgvCars.Location = new Point(10, 24);
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowTemplate.Height = 25;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(613, 238);
            dgvCars.TabIndex = 4;
            // 
            // CarBrand
            // 
            CarBrand.DataPropertyName = "CarBrand";
            CarBrand.HeaderText = "Марка";
            CarBrand.Name = "CarBrand";
            CarBrand.ReadOnly = true;
            // 
            // CarModel
            // 
            CarModel.DataPropertyName = "CarModel";
            CarModel.HeaderText = "Модель";
            CarModel.Name = "CarModel";
            CarModel.ReadOnly = true;
            // 
            // CarNumber
            // 
            CarNumber.DataPropertyName = "CarNumber";
            CarNumber.HeaderText = "Номер";
            CarNumber.Name = "CarNumber";
            CarNumber.ReadOnly = true;
            // 
            // CarYear
            // 
            CarYear.DataPropertyName = "CarYear";
            CarYear.HeaderText = "Год";
            CarYear.Name = "CarYear";
            CarYear.ReadOnly = true;
            // 
            // CarVIN
            // 
            CarVIN.DataPropertyName = "CarVIN";
            CarVIN.HeaderText = "VIN";
            CarVIN.Name = "CarVIN";
            CarVIN.ReadOnly = true;
            // 
            // CarMileage
            // 
            CarMileage.DataPropertyName = "CarMileage";
            CarMileage.HeaderText = "Пробег";
            CarMileage.Name = "CarMileage";
            CarMileage.ReadOnly = true;
            // 
            // CarId
            // 
            CarId.DataPropertyName = "CarId";
            CarId.HeaderText = "CarId";
            CarId.Name = "CarId";
            CarId.ReadOnly = true;
            CarId.Visible = false;
            // 
            // OwnershipId
            // 
            OwnershipId.DataPropertyName = "OwnershipId";
            OwnershipId.HeaderText = "OwnershipId";
            OwnershipId.Name = "OwnershipId";
            OwnershipId.ReadOnly = true;
            OwnershipId.Visible = false;
            // 
            // btnDeleteCarFromClient
            // 
            btnDeleteCarFromClient.Location = new Point(185, 284);
            btnDeleteCarFromClient.Name = "btnDeleteCarFromClient";
            btnDeleteCarFromClient.Size = new Size(169, 43);
            btnDeleteCarFromClient.TabIndex = 7;
            btnDeleteCarFromClient.Text = "Открепить автомобиль";
            btnDeleteCarFromClient.UseVisualStyleBackColor = true;
            btnDeleteCarFromClient.Click += btnDeleteCarFromClient_Click;
            // 
            // btnOpenAddCarToClientForm
            // 
            btnOpenAddCarToClientForm.Location = new Point(10, 284);
            btnOpenAddCarToClientForm.Name = "btnOpenAddCarToClientForm";
            btnOpenAddCarToClientForm.Size = new Size(169, 43);
            btnOpenAddCarToClientForm.TabIndex = 8;
            btnOpenAddCarToClientForm.Text = "Прикрепить автомобиль";
            btnOpenAddCarToClientForm.UseVisualStyleBackColor = true;
            btnOpenAddCarToClientForm.Click += btnOpenAddCarToClientForm_Click;
            // 
            // btnHistory
            // 
            btnHistory.Location = new Point(427, 427);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(623, 42);
            btnHistory.TabIndex = 13;
            btnHistory.Text = "Посмотреть историю заказов клиента";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(975, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 877);
            Controls.Add(btnUpdate);
            Controls.Add(btnHistory);
            Controls.Add(gbOrderDetails);
            Controls.Add(gbOrder);
            Controls.Add(dgvClients);
            Name = "ClientsForm";
            Text = "База клиентов";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            gbOrder.ResumeLayout(false);
            tcOrders.ResumeLayout(false);
            tpNewOrder.ResumeLayout(false);
            tpNewOrder.PerformLayout();
            tpCurrentOrder.ResumeLayout(false);
            tpCurrentOrder.PerformLayout();
            gbOrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClients;
        private GroupBox gbOrder;
        private TabControl tcOrders;
        private TabPage tpNewOrder;
        private Label label1;
        private Button btnCreateClient;
        private TabPage tpCurrentOrder;
        private Button bntEditClient;
        private Button btnDeleteClient;
        private DateTimePicker dtpBirthDateToAdd;
        private TextBox tbEmailToAdd;
        private Label label7;
        private Label label5;
        private Label label4;
        private TextBox tbPatronymicToAdd;
        private Label label3;
        private TextBox tbNameToAdd;
        private Label label2;
        private TextBox tbSurnameToAdd;
        private DateTimePicker dtpBirthDateToEdit;
        private TextBox tbEmailToEdit;
        private Label label6;
        private Label label8;
        private Label label9;
        private TextBox tbPatronymicToEdit;
        private Label label10;
        private TextBox tbNameToEdit;
        private Label label11;
        private TextBox tbSurnameToEdit;
        private Label label12;
        private GroupBox gbOrderDetails;
        private DataGridView dgvCars;
        private Button btnDeleteCarFromClient;
        private Button btnOpenAddCarToClientForm;
        private Button btnHistory;
        private DataGridViewTextBoxColumn ClientFullName;
        private DataGridViewTextBoxColumn ClientBirthDate;
        private DataGridViewTextBoxColumn ClientPhoneNumber;
        private DataGridViewTextBoxColumn ClientEmail;
        private DataGridViewTextBoxColumn ClientId;
        private Button btnUpdate;
        private DataGridViewTextBoxColumn CarBrand;
        private DataGridViewTextBoxColumn CarModel;
        private DataGridViewTextBoxColumn CarNumber;
        private DataGridViewTextBoxColumn CarYear;
        private DataGridViewTextBoxColumn CarVIN;
        private DataGridViewTextBoxColumn CarMileage;
        private DataGridViewTextBoxColumn CarId;
        private DataGridViewTextBoxColumn OwnershipId;
        private MaskedTextBox tbNumberToAdd;
        private MaskedTextBox tbNumberToEdit;
    }
}