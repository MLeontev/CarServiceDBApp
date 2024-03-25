namespace CarServiceDBApp.Forms
{
    partial class ServicesForm
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
            dgvServices = new DataGridView();
            ServiceName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            ServiceId = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tbDescription = new TextBox();
            gbService = new GroupBox();
            tcServices = new TabControl();
            tpNewService = new TabPage();
            tbDescriptionToAdd = new TextBox();
            label4 = new Label();
            tbPriceToAdd = new TextBox();
            btnCreateService = new Button();
            label2 = new Label();
            label3 = new Label();
            tbNameToAdd = new TextBox();
            tpCurrentService = new TabPage();
            btnDeleteService = new Button();
            tbDescriptionToEdit = new TextBox();
            btnDeleteOrder = new Button();
            label5 = new Label();
            label7 = new Label();
            tbPriceToEdit = new TextBox();
            tbNameToEdit = new TextBox();
            btnEditService = new Button();
            label6 = new Label();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            gbService.SuspendLayout();
            tcServices.SuspendLayout();
            tpNewService.SuspendLayout();
            tpCurrentService.SuspendLayout();
            SuspendLayout();
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { ServiceName, Price, ServiceId });
            dgvServices.Location = new Point(12, 12);
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowTemplate.Height = 25;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(467, 253);
            dgvServices.TabIndex = 0;
            dgvServices.SelectionChanged += dgvServices_SelectionChanged;
            // 
            // ServiceName
            // 
            ServiceName.DataPropertyName = "ServiceName";
            ServiceName.HeaderText = "Услуга";
            ServiceName.Name = "ServiceName";
            ServiceName.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Стоимость";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // ServiceId
            // 
            ServiceId.DataPropertyName = "ServiceId";
            ServiceId.HeaderText = "ServiceId";
            ServiceId.Name = "ServiceId";
            ServiceId.ReadOnly = true;
            ServiceId.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(498, 12);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Описание:";
            // 
            // tbDescription
            // 
            tbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tbDescription.BorderStyle = BorderStyle.FixedSingle;
            tbDescription.Location = new Point(498, 40);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.ReadOnly = true;
            tbDescription.Size = new Size(365, 225);
            tbDescription.TabIndex = 2;
            // 
            // gbService
            // 
            gbService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbService.Controls.Add(tcServices);
            gbService.Location = new Point(12, 283);
            gbService.Name = "gbService";
            gbService.Size = new Size(851, 276);
            gbService.TabIndex = 11;
            gbService.TabStop = false;
            gbService.Text = "Работа с услугами";
            // 
            // tcServices
            // 
            tcServices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcServices.Controls.Add(tpNewService);
            tcServices.Controls.Add(tpCurrentService);
            tcServices.Location = new Point(6, 22);
            tcServices.Name = "tcServices";
            tcServices.SelectedIndex = 0;
            tcServices.Size = new Size(839, 245);
            tcServices.TabIndex = 0;
            // 
            // tpNewService
            // 
            tpNewService.Controls.Add(tbDescriptionToAdd);
            tpNewService.Controls.Add(label4);
            tpNewService.Controls.Add(tbPriceToAdd);
            tpNewService.Controls.Add(btnCreateService);
            tpNewService.Controls.Add(label2);
            tpNewService.Controls.Add(label3);
            tpNewService.Controls.Add(tbNameToAdd);
            tpNewService.Location = new Point(4, 24);
            tpNewService.Name = "tpNewService";
            tpNewService.Padding = new Padding(3);
            tpNewService.Size = new Size(831, 217);
            tpNewService.TabIndex = 0;
            tpNewService.Text = "Новая услуга";
            tpNewService.UseVisualStyleBackColor = true;
            // 
            // tbDescriptionToAdd
            // 
            tbDescriptionToAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbDescriptionToAdd.BorderStyle = BorderStyle.FixedSingle;
            tbDescriptionToAdd.Location = new Point(450, 47);
            tbDescriptionToAdd.Multiline = true;
            tbDescriptionToAdd.Name = "tbDescriptionToAdd";
            tbDescriptionToAdd.Size = new Size(361, 141);
            tbDescriptionToAdd.TabIndex = 18;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(450, 20);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 17;
            label4.Text = "Описание:";
            // 
            // tbPriceToAdd
            // 
            tbPriceToAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbPriceToAdd.Location = new Point(82, 86);
            tbPriceToAdd.Name = "tbPriceToAdd";
            tbPriceToAdd.Size = new Size(340, 23);
            tbPriceToAdd.TabIndex = 16;
            // 
            // btnCreateService
            // 
            btnCreateService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateService.Location = new Point(8, 139);
            btnCreateService.Name = "btnCreateService";
            btnCreateService.Size = new Size(414, 36);
            btnCreateService.TabIndex = 8;
            btnCreateService.Text = "Создать услугу";
            btnCreateService.UseVisualStyleBackColor = true;
            btnCreateService.Click += btnCreateService_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 89);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 15;
            label2.Text = "Цена:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 50);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 13;
            label3.Text = "Название:";
            // 
            // tbNameToAdd
            // 
            tbNameToAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbNameToAdd.Location = new Point(82, 47);
            tbNameToAdd.Name = "tbNameToAdd";
            tbNameToAdd.Size = new Size(340, 23);
            tbNameToAdd.TabIndex = 14;
            // 
            // tpCurrentService
            // 
            tpCurrentService.Controls.Add(btnDeleteService);
            tpCurrentService.Controls.Add(tbDescriptionToEdit);
            tpCurrentService.Controls.Add(btnDeleteOrder);
            tpCurrentService.Controls.Add(label5);
            tpCurrentService.Controls.Add(label7);
            tpCurrentService.Controls.Add(tbPriceToEdit);
            tpCurrentService.Controls.Add(tbNameToEdit);
            tpCurrentService.Controls.Add(btnEditService);
            tpCurrentService.Controls.Add(label6);
            tpCurrentService.Location = new Point(4, 24);
            tpCurrentService.Name = "tpCurrentService";
            tpCurrentService.Padding = new Padding(3);
            tpCurrentService.Size = new Size(831, 217);
            tpCurrentService.TabIndex = 1;
            tpCurrentService.Text = "Выбранная услуга";
            tpCurrentService.UseVisualStyleBackColor = true;
            // 
            // btnDeleteService
            // 
            btnDeleteService.Location = new Point(16, 175);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(414, 36);
            btnDeleteService.TabIndex = 26;
            btnDeleteService.Text = "Удалить услугу";
            btnDeleteService.UseVisualStyleBackColor = true;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // tbDescriptionToEdit
            // 
            tbDescriptionToEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbDescriptionToEdit.BorderStyle = BorderStyle.FixedSingle;
            tbDescriptionToEdit.Location = new Point(458, 41);
            tbDescriptionToEdit.Multiline = true;
            tbDescriptionToEdit.Name = "tbDescriptionToEdit";
            tbDescriptionToEdit.Size = new Size(361, 141);
            tbDescriptionToEdit.TabIndex = 25;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(6, 229);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(383, 35);
            btnDeleteOrder.TabIndex = 5;
            btnDeleteOrder.Text = "Удалить заказ";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(458, 14);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 24;
            label5.Text = "Описание:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 44);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 20;
            label7.Text = "Название:";
            // 
            // tbPriceToEdit
            // 
            tbPriceToEdit.Location = new Point(90, 80);
            tbPriceToEdit.Name = "tbPriceToEdit";
            tbPriceToEdit.Size = new Size(340, 23);
            tbPriceToEdit.TabIndex = 23;
            // 
            // tbNameToEdit
            // 
            tbNameToEdit.Location = new Point(90, 41);
            tbNameToEdit.Name = "tbNameToEdit";
            tbNameToEdit.Size = new Size(340, 23);
            tbNameToEdit.TabIndex = 21;
            // 
            // btnEditService
            // 
            btnEditService.Location = new Point(16, 124);
            btnEditService.Name = "btnEditService";
            btnEditService.Size = new Size(414, 36);
            btnEditService.TabIndex = 19;
            btnEditService.Text = "Редактировать услугу";
            btnEditService.UseVisualStyleBackColor = true;
            btnEditService.Click += btnEditService_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 83);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 22;
            label6.Text = "Цена:";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(788, 8);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ServicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 572);
            Controls.Add(btnUpdate);
            Controls.Add(gbService);
            Controls.Add(tbDescription);
            Controls.Add(label1);
            Controls.Add(dgvServices);
            MinimumSize = new Size(891, 611);
            Name = "ServicesForm";
            Text = "Справочник услуг";
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            gbService.ResumeLayout(false);
            tcServices.ResumeLayout(false);
            tpNewService.ResumeLayout(false);
            tpNewService.PerformLayout();
            tpCurrentService.ResumeLayout(false);
            tpCurrentService.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvServices;
        private Label label1;
        private TextBox tbDescription;
        private GroupBox gbService;
        private TabControl tcServices;
        private TabPage tpNewService;
        private Button btnCreateService;
        private TabPage tpCurrentService;
        private Button btnDeleteOrder;
        private TextBox tbDescriptionToAdd;
        private Label label4;
        private TextBox tbPriceToAdd;
        private Label label2;
        private Label label3;
        private TextBox tbNameToAdd;
        private Button btnDeleteService;
        private TextBox tbDescriptionToEdit;
        private Label label5;
        private Label label7;
        private TextBox tbPriceToEdit;
        private TextBox tbNameToEdit;
        private Button btnEditService;
        private Label label6;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn ServiceId;
        private Button btnUpdate;
    }
}