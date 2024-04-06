namespace CarServiceDBApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            toolStrip1 = new ToolStrip();
            tsddbBases = new ToolStripDropDownButton();
            клиентыToolStripMenuItem = new ToolStripMenuItem();
            автомобилиToolStripMenuItem = new ToolStripMenuItem();
            услугиToolStripMenuItem = new ToolStripMenuItem();
            сотрудникиToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsddbReports = new ToolStripDropDownButton();
            отчетОМастерахToolStripMenuItem = new ToolStripMenuItem();
            отчетОВыполненныхУслугахToolStripMenuItem = new ToolStripMenuItem();
            отчетОЗаказахToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            btnUpdateOrders = new Button();
            dgvOrderDetails = new DataGridView();
            ServiceId = new DataGridViewTextBoxColumn();
            OrderDetailsId = new DataGridViewTextBoxColumn();
            ServiceName = new DataGridViewTextBoxColumn();
            WorkerId = new DataGridViewTextBoxColumn();
            WorkerFullName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnDeleteOrder = new Button();
            btnDeleteServiceFromOrder = new Button();
            btnCompleteService = new Button();
            btnOpenAddServiceForm = new Button();
            btnEditWorker = new Button();
            gbOrder = new GroupBox();
            tcOrders = new TabControl();
            tpNewOrder = new TabPage();
            btnCreateOrder = new Button();
            dptDateToAdd = new DateTimePicker();
            label5 = new Label();
            cbWorkersToAdd = new ComboBox();
            label4 = new Label();
            cbCarsToAdd = new ComboBox();
            label3 = new Label();
            cbClientsToAdd = new ComboBox();
            label2 = new Label();
            tpCurrentOrder = new TabPage();
            bntEditOrder = new Button();
            dtpDateToEdit = new DateTimePicker();
            label6 = new Label();
            cbCarsToEdit = new ComboBox();
            label8 = new Label();
            cbClientsToEdit = new ComboBox();
            label9 = new Label();
            gbOrderDetails = new GroupBox();
            gbStatus = new GroupBox();
            btnStatusОтменен = new Button();
            btnStatusВыполнен = new Button();
            btnStatusВРаботе = new Button();
            btnStatusЗаявка = new Button();
            btnAllOrders = new Button();
            btnActiveOrders = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            gbOrder.SuspendLayout();
            tcOrders.SuspendLayout();
            tpNewOrder.SuspendLayout();
            tpCurrentOrder.SuspendLayout();
            gbOrderDetails.SuspendLayout();
            gbStatus.SuspendLayout();
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
            dgvOrders.Location = new Point(12, 69);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowTemplate.Height = 25;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1129, 395);
            dgvOrders.TabIndex = 3;
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
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsddbBases, toolStripSeparator1, tsddbReports });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1152, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsddbBases
            // 
            tsddbBases.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsddbBases.DropDownItems.AddRange(new ToolStripItem[] { клиентыToolStripMenuItem, автомобилиToolStripMenuItem, услугиToolStripMenuItem, сотрудникиToolStripMenuItem });
            tsddbBases.Image = (Image)resources.GetObject("tsddbBases.Image");
            tsddbBases.ImageTransparentColor = Color.Magenta;
            tsddbBases.Name = "tsddbBases";
            tsddbBases.Size = new Size(95, 22);
            tsddbBases.Text = "Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            клиентыToolStripMenuItem.Size = new Size(144, 22);
            клиентыToolStripMenuItem.Text = "Клиенты";
            клиентыToolStripMenuItem.Click += клиентыToolStripMenuItem_Click;
            // 
            // автомобилиToolStripMenuItem
            // 
            автомобилиToolStripMenuItem.Name = "автомобилиToolStripMenuItem";
            автомобилиToolStripMenuItem.Size = new Size(144, 22);
            автомобилиToolStripMenuItem.Text = "Автомобили";
            автомобилиToolStripMenuItem.Click += автомобилиToolStripMenuItem_Click;
            // 
            // услугиToolStripMenuItem
            // 
            услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            услугиToolStripMenuItem.Size = new Size(144, 22);
            услугиToolStripMenuItem.Text = "Услуги";
            услугиToolStripMenuItem.Click += услугиToolStripMenuItem_Click;
            // 
            // сотрудникиToolStripMenuItem
            // 
            сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            сотрудникиToolStripMenuItem.Size = new Size(144, 22);
            сотрудникиToolStripMenuItem.Text = "Сотрудники";
            сотрудникиToolStripMenuItem.Click += сотрудникиToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsddbReports
            // 
            tsddbReports.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsddbReports.DropDownItems.AddRange(new ToolStripItem[] { отчетОМастерахToolStripMenuItem, отчетОВыполненныхУслугахToolStripMenuItem, отчетОЗаказахToolStripMenuItem });
            tsddbReports.Image = (Image)resources.GetObject("tsddbReports.Image");
            tsddbReports.ImageTransparentColor = Color.Magenta;
            tsddbReports.Name = "tsddbReports";
            tsddbReports.Size = new Size(61, 22);
            tsddbReports.Text = "Отчеты";
            // 
            // отчетОМастерахToolStripMenuItem
            // 
            отчетОМастерахToolStripMenuItem.Name = "отчетОМастерахToolStripMenuItem";
            отчетОМастерахToolStripMenuItem.Size = new Size(242, 22);
            отчетОМастерахToolStripMenuItem.Text = "Отчет о мастерах";
            отчетОМастерахToolStripMenuItem.Click += отчетОМастерахToolStripMenuItem_Click;
            // 
            // отчетОВыполненныхУслугахToolStripMenuItem
            // 
            отчетОВыполненныхУслугахToolStripMenuItem.Name = "отчетОВыполненныхУслугахToolStripMenuItem";
            отчетОВыполненныхУслугахToolStripMenuItem.Size = new Size(242, 22);
            отчетОВыполненныхУслугахToolStripMenuItem.Text = "Отчет о выполненных услугах";
            отчетОВыполненныхУслугахToolStripMenuItem.Click += отчетОВыполненныхУслугахToolStripMenuItem_Click;
            // 
            // отчетОЗаказахToolStripMenuItem
            // 
            отчетОЗаказахToolStripMenuItem.Name = "отчетОЗаказахToolStripMenuItem";
            отчетОЗаказахToolStripMenuItem.Size = new Size(242, 22);
            отчетОЗаказахToolStripMenuItem.Text = "Отчет о заказах";
            отчетОЗаказахToolStripMenuItem.Click += отчетОЗаказахToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(57, 17);
            label1.TabIndex = 2;
            label1.Text = "Заказы:";
            // 
            // btnUpdateOrders
            // 
            btnUpdateOrders.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdateOrders.Location = new Point(1065, 38);
            btnUpdateOrders.Name = "btnUpdateOrders";
            btnUpdateOrders.Size = new Size(75, 23);
            btnUpdateOrders.TabIndex = 0;
            btnUpdateOrders.Text = "Обновить";
            btnUpdateOrders.UseVisualStyleBackColor = true;
            btnUpdateOrders.Click += btnUpdateOrders_Click;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[] { ServiceId, OrderDetailsId, ServiceName, WorkerId, WorkerFullName, Price, Status });
            dgvOrderDetails.Location = new Point(6, 20);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowTemplate.Height = 25;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(696, 182);
            dgvOrderDetails.TabIndex = 9;
            dgvOrderDetails.SelectionChanged += dgvOrderDetails_SelectionChanged;
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
            ServiceName.Width = 200;
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
            WorkerFullName.Width = 200;
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
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Статус";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(6, 229);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(383, 35);
            btnDeleteOrder.TabIndex = 24;
            btnDeleteOrder.Text = "Удалить заказ";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnDeleteServiceFromOrder
            // 
            btnDeleteServiceFromOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteServiceFromOrder.Location = new Point(531, 208);
            btnDeleteServiceFromOrder.Name = "btnDeleteServiceFromOrder";
            btnDeleteServiceFromOrder.Size = new Size(171, 28);
            btnDeleteServiceFromOrder.TabIndex = 13;
            btnDeleteServiceFromOrder.Text = "Удалить услугу из заказа";
            btnDeleteServiceFromOrder.UseVisualStyleBackColor = true;
            btnDeleteServiceFromOrder.Click += btnDeleteServiceFromOrder_Click;
            // 
            // btnCompleteService
            // 
            btnCompleteService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCompleteService.Location = new Point(181, 208);
            btnCompleteService.Name = "btnCompleteService";
            btnCompleteService.Size = new Size(169, 28);
            btnCompleteService.TabIndex = 11;
            btnCompleteService.Text = "Выполнить услугу";
            btnCompleteService.UseVisualStyleBackColor = true;
            btnCompleteService.Click += btnCompleteService_Click;
            // 
            // btnOpenAddServiceForm
            // 
            btnOpenAddServiceForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOpenAddServiceForm.Location = new Point(6, 208);
            btnOpenAddServiceForm.Name = "btnOpenAddServiceForm";
            btnOpenAddServiceForm.Size = new Size(169, 28);
            btnOpenAddServiceForm.TabIndex = 10;
            btnOpenAddServiceForm.Text = "Добавить услугу";
            btnOpenAddServiceForm.UseVisualStyleBackColor = true;
            btnOpenAddServiceForm.Click += btnOpenAddServiceForm_Click;
            // 
            // btnEditWorker
            // 
            btnEditWorker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditWorker.Location = new Point(356, 208);
            btnEditWorker.Name = "btnEditWorker";
            btnEditWorker.Size = new Size(169, 28);
            btnEditWorker.TabIndex = 12;
            btnEditWorker.Text = "Заменить исполнителя";
            btnEditWorker.UseVisualStyleBackColor = true;
            btnEditWorker.Click += btnEditWorker_Click;
            // 
            // gbOrder
            // 
            gbOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            gbOrder.Controls.Add(tcOrders);
            gbOrder.Location = new Point(12, 470);
            gbOrder.Name = "gbOrder";
            gbOrder.Size = new Size(415, 331);
            gbOrder.TabIndex = 14;
            gbOrder.TabStop = false;
            gbOrder.Text = "Работа с заказами";
            // 
            // tcOrders
            // 
            tcOrders.Controls.Add(tpNewOrder);
            tcOrders.Controls.Add(tpCurrentOrder);
            tcOrders.Location = new Point(6, 22);
            tcOrders.Name = "tcOrders";
            tcOrders.SelectedIndex = 0;
            tcOrders.Size = new Size(403, 298);
            tcOrders.TabIndex = 0;
            // 
            // tpNewOrder
            // 
            tpNewOrder.Controls.Add(btnCreateOrder);
            tpNewOrder.Controls.Add(dptDateToAdd);
            tpNewOrder.Controls.Add(label5);
            tpNewOrder.Controls.Add(cbWorkersToAdd);
            tpNewOrder.Controls.Add(label4);
            tpNewOrder.Controls.Add(cbCarsToAdd);
            tpNewOrder.Controls.Add(label3);
            tpNewOrder.Controls.Add(cbClientsToAdd);
            tpNewOrder.Controls.Add(label2);
            tpNewOrder.Location = new Point(4, 24);
            tpNewOrder.Name = "tpNewOrder";
            tpNewOrder.Padding = new Padding(3);
            tpNewOrder.Size = new Size(395, 270);
            tpNewOrder.TabIndex = 0;
            tpNewOrder.Text = "Новый заказ";
            tpNewOrder.UseVisualStyleBackColor = true;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Location = new Point(6, 228);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(383, 36);
            btnCreateOrder.TabIndex = 19;
            btnCreateOrder.Text = "Создать заказ";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // dptDateToAdd
            // 
            dptDateToAdd.Location = new Point(6, 187);
            dptDateToAdd.Name = "dptDateToAdd";
            dptDateToAdd.Size = new Size(383, 23);
            dptDateToAdd.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 169);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 6;
            label5.Text = "Дата приема";
            // 
            // cbWorkersToAdd
            // 
            cbWorkersToAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWorkersToAdd.FormattingEnabled = true;
            cbWorkersToAdd.Location = new Point(6, 132);
            cbWorkersToAdd.Name = "cbWorkersToAdd";
            cbWorkersToAdd.Size = new Size(383, 23);
            cbWorkersToAdd.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 114);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 4;
            label4.Text = "Мастер приемщик";
            // 
            // cbCarsToAdd
            // 
            cbCarsToAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarsToAdd.FormattingEnabled = true;
            cbCarsToAdd.Location = new Point(6, 76);
            cbCarsToAdd.Name = "cbCarsToAdd";
            cbCarsToAdd.Size = new Size(383, 23);
            cbCarsToAdd.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 58);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 2;
            label3.Text = "Автомобиль";
            // 
            // cbClientsToAdd
            // 
            cbClientsToAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClientsToAdd.FormattingEnabled = true;
            cbClientsToAdd.Location = new Point(6, 21);
            cbClientsToAdd.Name = "cbClientsToAdd";
            cbClientsToAdd.Size = new Size(383, 23);
            cbClientsToAdd.TabIndex = 15;
            cbClientsToAdd.SelectedIndexChanged += cbClientsToAdd_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 3);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Клиент";
            // 
            // tpCurrentOrder
            // 
            tpCurrentOrder.Controls.Add(bntEditOrder);
            tpCurrentOrder.Controls.Add(dtpDateToEdit);
            tpCurrentOrder.Controls.Add(label6);
            tpCurrentOrder.Controls.Add(btnDeleteOrder);
            tpCurrentOrder.Controls.Add(cbCarsToEdit);
            tpCurrentOrder.Controls.Add(label8);
            tpCurrentOrder.Controls.Add(cbClientsToEdit);
            tpCurrentOrder.Controls.Add(label9);
            tpCurrentOrder.Location = new Point(4, 24);
            tpCurrentOrder.Name = "tpCurrentOrder";
            tpCurrentOrder.Padding = new Padding(3);
            tpCurrentOrder.Size = new Size(395, 270);
            tpCurrentOrder.TabIndex = 1;
            tpCurrentOrder.Text = "Выбранный заказ";
            tpCurrentOrder.UseVisualStyleBackColor = true;
            // 
            // bntEditOrder
            // 
            bntEditOrder.Location = new Point(6, 171);
            bntEditOrder.Name = "bntEditOrder";
            bntEditOrder.Size = new Size(383, 36);
            bntEditOrder.TabIndex = 23;
            bntEditOrder.Text = "Редактировать заказ";
            bntEditOrder.UseVisualStyleBackColor = true;
            bntEditOrder.Click += bntEditOrder_Click;
            // 
            // dtpDateToEdit
            // 
            dtpDateToEdit.Location = new Point(6, 135);
            dtpDateToEdit.Name = "dtpDateToEdit";
            dtpDateToEdit.Size = new Size(383, 23);
            dtpDateToEdit.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 116);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 15;
            label6.Text = "Дата приема";
            // 
            // cbCarsToEdit
            // 
            cbCarsToEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarsToEdit.FormattingEnabled = true;
            cbCarsToEdit.Location = new Point(6, 78);
            cbCarsToEdit.Name = "cbCarsToEdit";
            cbCarsToEdit.Size = new Size(383, 23);
            cbCarsToEdit.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 60);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 11;
            label8.Text = "Автомобиль";
            // 
            // cbClientsToEdit
            // 
            cbClientsToEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClientsToEdit.FormattingEnabled = true;
            cbClientsToEdit.Location = new Point(6, 23);
            cbClientsToEdit.Name = "cbClientsToEdit";
            cbClientsToEdit.Size = new Size(383, 23);
            cbClientsToEdit.TabIndex = 20;
            cbClientsToEdit.SelectedIndexChanged += cbClientsToEdit_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 5);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 9;
            label9.Text = "Клиент";
            // 
            // gbOrderDetails
            // 
            gbOrderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbOrderDetails.Controls.Add(dgvOrderDetails);
            gbOrderDetails.Controls.Add(btnDeleteServiceFromOrder);
            gbOrderDetails.Controls.Add(btnEditWorker);
            gbOrderDetails.Controls.Add(btnCompleteService);
            gbOrderDetails.Controls.Add(btnOpenAddServiceForm);
            gbOrderDetails.Location = new Point(433, 550);
            gbOrderDetails.Name = "gbOrderDetails";
            gbOrderDetails.Size = new Size(708, 251);
            gbOrderDetails.TabIndex = 11;
            gbOrderDetails.TabStop = false;
            gbOrderDetails.Text = "Состав выбранного заказа";
            // 
            // gbStatus
            // 
            gbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbStatus.Controls.Add(btnStatusОтменен);
            gbStatus.Controls.Add(btnStatusВыполнен);
            gbStatus.Controls.Add(btnStatusВРаботе);
            gbStatus.Controls.Add(btnStatusЗаявка);
            gbStatus.Location = new Point(433, 470);
            gbStatus.Name = "gbStatus";
            gbStatus.Size = new Size(571, 74);
            gbStatus.TabIndex = 12;
            gbStatus.TabStop = false;
            gbStatus.Text = "Статус выбранного заказа";
            // 
            // btnStatusОтменен
            // 
            btnStatusОтменен.Location = new Point(429, 22);
            btnStatusОтменен.Name = "btnStatusОтменен";
            btnStatusОтменен.Size = new Size(135, 41);
            btnStatusОтменен.TabIndex = 7;
            btnStatusОтменен.Text = "Отменен";
            btnStatusОтменен.UseVisualStyleBackColor = true;
            btnStatusОтменен.Click += btnStatusОтменен_Click;
            // 
            // btnStatusВыполнен
            // 
            btnStatusВыполнен.Location = new Point(288, 22);
            btnStatusВыполнен.Name = "btnStatusВыполнен";
            btnStatusВыполнен.Size = new Size(135, 41);
            btnStatusВыполнен.TabIndex = 6;
            btnStatusВыполнен.Text = "Выполнен-закрыт";
            btnStatusВыполнен.UseVisualStyleBackColor = true;
            btnStatusВыполнен.Click += btnStatusВыполнен_Click;
            // 
            // btnStatusВРаботе
            // 
            btnStatusВРаботе.Location = new Point(147, 22);
            btnStatusВРаботе.Name = "btnStatusВРаботе";
            btnStatusВРаботе.Size = new Size(135, 41);
            btnStatusВРаботе.TabIndex = 5;
            btnStatusВРаботе.Text = "В работе";
            btnStatusВРаботе.UseVisualStyleBackColor = true;
            btnStatusВРаботе.Click += btnStatusВРаботе_Click;
            // 
            // btnStatusЗаявка
            // 
            btnStatusЗаявка.Location = new Point(6, 22);
            btnStatusЗаявка.Name = "btnStatusЗаявка";
            btnStatusЗаявка.Size = new Size(135, 41);
            btnStatusЗаявка.TabIndex = 4;
            btnStatusЗаявка.Text = "Заявка";
            btnStatusЗаявка.UseVisualStyleBackColor = true;
            btnStatusЗаявка.Click += btnStatusЗаявка_Click;
            // 
            // btnAllOrders
            // 
            btnAllOrders.Location = new Point(75, 36);
            btnAllOrders.Name = "btnAllOrders";
            btnAllOrders.Size = new Size(92, 23);
            btnAllOrders.TabIndex = 1;
            btnAllOrders.Text = "Все заказы";
            btnAllOrders.UseVisualStyleBackColor = true;
            btnAllOrders.Click += btnAllOrders_Click;
            // 
            // btnActiveOrders
            // 
            btnActiveOrders.Location = new Point(173, 36);
            btnActiveOrders.Name = "btnActiveOrders";
            btnActiveOrders.Size = new Size(172, 23);
            btnActiveOrders.TabIndex = 2;
            btnActiveOrders.Text = "Только активные заказы";
            btnActiveOrders.UseVisualStyleBackColor = true;
            btnActiveOrders.Click += btnActiveOrders_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1010, 470);
            button1.Name = "button1";
            button1.Size = new Size(131, 74);
            button1.TabIndex = 8;
            button1.Text = "Составить заказ-наряд";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1152, 817);
            Controls.Add(button1);
            Controls.Add(btnActiveOrders);
            Controls.Add(btnAllOrders);
            Controls.Add(gbStatus);
            Controls.Add(gbOrderDetails);
            Controls.Add(gbOrder);
            Controls.Add(btnUpdateOrders);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Controls.Add(dgvOrders);
            MinimumSize = new Size(1168, 856);
            Name = "MainForm";
            Text = "Заказы";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            gbOrder.ResumeLayout(false);
            tcOrders.ResumeLayout(false);
            tpNewOrder.ResumeLayout(false);
            tpNewOrder.PerformLayout();
            tpCurrentOrder.ResumeLayout(false);
            tpCurrentOrder.PerformLayout();
            gbOrderDetails.ResumeLayout(false);
            gbStatus.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton tsddbBases;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton tsddbReports;
        private Label label1;
        private Button btnUpdateOrders;
        private DataGridView dgvOrderDetails;
        private Button btnDeleteOrder;
        private Button btnDeleteServiceFromOrder;
        private Button btnCompleteService;
        private Button btnOpenAddServiceForm;
        private Button btnEditWorker;
        private GroupBox gbOrder;
        private TabControl tcOrders;
        private TabPage tpNewOrder;
        private TabPage tpCurrentOrder;
        private Label label5;
        private ComboBox cbWorkersToAdd;
        private Label label4;
        private ComboBox cbCarsToAdd;
        private Label label3;
        private ComboBox cbClientsToAdd;
        private Label label2;
        private DateTimePicker dptDateToAdd;
        private Button btnCreateOrder;
        private GroupBox gbOrderDetails;
        private Button bntEditOrder;
        private DateTimePicker dtpDateToEdit;
        private Label label6;
        private ComboBox cbCarsToEdit;
        private Label label8;
        private ComboBox cbClientsToEdit;
        private Label label9;
        private DataGridViewTextBoxColumn ServiceId;
        private DataGridViewTextBoxColumn OrderDetailsId;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn WorkerId;
        private DataGridViewTextBoxColumn WorkerFullName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Status;
        private GroupBox gbStatus;
        private Button btnStatusОтменен;
        private Button btnStatusВыполнен;
        private Button btnStatusВРаботе;
        private Button btnStatusЗаявка;
        private Button btnAllOrders;
        private Button btnActiveOrders;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private ToolStripMenuItem автомобилиToolStripMenuItem;
        private ToolStripMenuItem услугиToolStripMenuItem;
        private ToolStripMenuItem сотрудникиToolStripMenuItem;
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
        private ToolStripMenuItem отчетОМастерахToolStripMenuItem;
        private ToolStripMenuItem отчетОВыполненныхУслугахToolStripMenuItem;
        private ToolStripMenuItem отчетОЗаказахToolStripMenuItem;
        private Button button1;
    }
}