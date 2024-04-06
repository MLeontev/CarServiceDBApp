namespace CarServiceDBApp.Forms
{
    partial class WorkersForm
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
            dgvWorkers = new DataGridView();
            WorkerId = new DataGridViewTextBoxColumn();
            WorkerSurname = new DataGridViewTextBoxColumn();
            WorkerName = new DataGridViewTextBoxColumn();
            WorkerPatronymic = new DataGridViewTextBoxColumn();
            WorkerSalary = new DataGridViewTextBoxColumn();
            WorkerPosition = new DataGridViewTextBoxColumn();
            WorkerPhoneNumber = new DataGridViewTextBoxColumn();
            PositionId = new DataGridViewTextBoxColumn();
            gbOrder = new GroupBox();
            tcOrders = new TabControl();
            tpNewWorker = new TabPage();
            tbIdToAdd = new MaskedTextBox();
            label6 = new Label();
            tbNumberToAdd = new MaskedTextBox();
            cbPositionToAdd = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            tbPatronymicToAdd = new TextBox();
            label3 = new Label();
            tbNameToAdd = new TextBox();
            label2 = new Label();
            tbSurnameToAdd = new TextBox();
            label1 = new Label();
            btnCreateWorker = new Button();
            tpCurrentWorker = new TabPage();
            btnChangePassword = new Button();
            bntEditWorker = new Button();
            tbNumberToEdit = new MaskedTextBox();
            btnDeleteWorker = new Button();
            cbPositionToEdit = new ComboBox();
            label12 = new Label();
            label7 = new Label();
            tbSurnameToEdit = new TextBox();
            label8 = new Label();
            label10 = new Label();
            tbPatronymicToEdit = new TextBox();
            tbNameToEdit = new TextBox();
            label9 = new Label();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvWorkers).BeginInit();
            gbOrder.SuspendLayout();
            tcOrders.SuspendLayout();
            tpNewWorker.SuspendLayout();
            tpCurrentWorker.SuspendLayout();
            SuspendLayout();
            // 
            // dgvWorkers
            // 
            dgvWorkers.AllowUserToAddRows = false;
            dgvWorkers.AllowUserToDeleteRows = false;
            dgvWorkers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvWorkers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWorkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkers.Columns.AddRange(new DataGridViewColumn[] { WorkerId, WorkerSurname, WorkerName, WorkerPatronymic, WorkerSalary, WorkerPosition, WorkerPhoneNumber, PositionId });
            dgvWorkers.Location = new Point(12, 35);
            dgvWorkers.Name = "dgvWorkers";
            dgvWorkers.ReadOnly = true;
            dgvWorkers.RowTemplate.Height = 25;
            dgvWorkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkers.Size = new Size(1040, 366);
            dgvWorkers.TabIndex = 1;
            dgvWorkers.SelectionChanged += dgvWorkers_SelectionChanged;
            // 
            // WorkerId
            // 
            WorkerId.DataPropertyName = "WorkerId";
            WorkerId.HeaderText = "Табельный номер";
            WorkerId.Name = "WorkerId";
            WorkerId.ReadOnly = true;
            // 
            // WorkerSurname
            // 
            WorkerSurname.DataPropertyName = "WorkerSurname";
            WorkerSurname.HeaderText = "Фамилия";
            WorkerSurname.Name = "WorkerSurname";
            WorkerSurname.ReadOnly = true;
            // 
            // WorkerName
            // 
            WorkerName.DataPropertyName = "WorkerName";
            WorkerName.HeaderText = "Имя";
            WorkerName.Name = "WorkerName";
            WorkerName.ReadOnly = true;
            // 
            // WorkerPatronymic
            // 
            WorkerPatronymic.DataPropertyName = "WorkerPatronymic";
            WorkerPatronymic.HeaderText = "Отчество";
            WorkerPatronymic.Name = "WorkerPatronymic";
            WorkerPatronymic.ReadOnly = true;
            // 
            // WorkerSalary
            // 
            WorkerSalary.DataPropertyName = "WorkerSalary";
            WorkerSalary.HeaderText = "Зарплата";
            WorkerSalary.Name = "WorkerSalary";
            WorkerSalary.ReadOnly = true;
            // 
            // WorkerPosition
            // 
            WorkerPosition.DataPropertyName = "WorkerPosition";
            WorkerPosition.HeaderText = "Должность";
            WorkerPosition.Name = "WorkerPosition";
            WorkerPosition.ReadOnly = true;
            // 
            // WorkerPhoneNumber
            // 
            WorkerPhoneNumber.DataPropertyName = "WorkerPhoneNumber";
            WorkerPhoneNumber.HeaderText = "Телефон";
            WorkerPhoneNumber.Name = "WorkerPhoneNumber";
            WorkerPhoneNumber.ReadOnly = true;
            // 
            // PositionId
            // 
            PositionId.DataPropertyName = "PositionId";
            PositionId.HeaderText = "PositionId";
            PositionId.Name = "PositionId";
            PositionId.ReadOnly = true;
            PositionId.Visible = false;
            // 
            // gbOrder
            // 
            gbOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbOrder.Controls.Add(tcOrders);
            gbOrder.Location = new Point(12, 421);
            gbOrder.Name = "gbOrder";
            gbOrder.Size = new Size(1038, 353);
            gbOrder.TabIndex = 2;
            gbOrder.TabStop = false;
            gbOrder.Text = "Работа с сотрудниками";
            // 
            // tcOrders
            // 
            tcOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcOrders.Controls.Add(tpNewWorker);
            tcOrders.Controls.Add(tpCurrentWorker);
            tcOrders.Location = new Point(6, 22);
            tcOrders.Name = "tcOrders";
            tcOrders.SelectedIndex = 0;
            tcOrders.Size = new Size(1026, 325);
            tcOrders.TabIndex = 0;
            // 
            // tpNewWorker
            // 
            tpNewWorker.Controls.Add(tbIdToAdd);
            tpNewWorker.Controls.Add(label6);
            tpNewWorker.Controls.Add(tbNumberToAdd);
            tpNewWorker.Controls.Add(cbPositionToAdd);
            tpNewWorker.Controls.Add(label4);
            tpNewWorker.Controls.Add(label5);
            tpNewWorker.Controls.Add(tbPatronymicToAdd);
            tpNewWorker.Controls.Add(label3);
            tpNewWorker.Controls.Add(tbNameToAdd);
            tpNewWorker.Controls.Add(label2);
            tpNewWorker.Controls.Add(tbSurnameToAdd);
            tpNewWorker.Controls.Add(label1);
            tpNewWorker.Controls.Add(btnCreateWorker);
            tpNewWorker.Location = new Point(4, 24);
            tpNewWorker.Name = "tpNewWorker";
            tpNewWorker.Padding = new Padding(3);
            tpNewWorker.Size = new Size(1018, 297);
            tpNewWorker.TabIndex = 0;
            tpNewWorker.Text = "Новый сотрудник";
            tpNewWorker.UseVisualStyleBackColor = true;
            // 
            // tbIdToAdd
            // 
            tbIdToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbIdToAdd.Location = new Point(136, 21);
            tbIdToAdd.Mask = "00000";
            tbIdToAdd.Name = "tbIdToAdd";
            tbIdToAdd.Size = new Size(264, 23);
            tbIdToAdd.TabIndex = 3;
            tbIdToAdd.ValidatingType = typeof(int);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 24);
            label6.Name = "label6";
            label6.Size = new Size(110, 15);
            label6.TabIndex = 24;
            label6.Text = "Табельный номер:";
            // 
            // tbNumberToAdd
            // 
            tbNumberToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNumberToAdd.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            tbNumberToAdd.Location = new Point(136, 245);
            tbNumberToAdd.Mask = "+7 999 000-00-00";
            tbNumberToAdd.Name = "tbNumberToAdd";
            tbNumberToAdd.Size = new Size(264, 23);
            tbNumberToAdd.TabIndex = 8;
            // 
            // cbPositionToAdd
            // 
            cbPositionToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbPositionToAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPositionToAdd.FormattingEnabled = true;
            cbPositionToAdd.Location = new Point(136, 199);
            cbPositionToAdd.Name = "cbPositionToAdd";
            cbPositionToAdd.Size = new Size(264, 23);
            cbPositionToAdd.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 202);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 19;
            label4.Text = "Должность:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 248);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 17;
            label5.Text = "Телефон:";
            // 
            // tbPatronymicToAdd
            // 
            tbPatronymicToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPatronymicToAdd.Location = new Point(136, 147);
            tbPatronymicToAdd.Name = "tbPatronymicToAdd";
            tbPatronymicToAdd.Size = new Size(264, 23);
            tbPatronymicToAdd.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 150);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 13;
            label3.Text = "Отчество:";
            // 
            // tbNameToAdd
            // 
            tbNameToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNameToAdd.Location = new Point(136, 101);
            tbNameToAdd.Name = "tbNameToAdd";
            tbNameToAdd.Size = new Size(264, 23);
            tbNameToAdd.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 104);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "Имя:";
            // 
            // tbSurnameToAdd
            // 
            tbSurnameToAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSurnameToAdd.Location = new Point(136, 62);
            tbSurnameToAdd.Name = "tbSurnameToAdd";
            tbSurnameToAdd.Size = new Size(264, 23);
            tbSurnameToAdd.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 65);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 9;
            label1.Text = "Фамилия:";
            // 
            // btnCreateWorker
            // 
            btnCreateWorker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateWorker.Location = new Point(432, 21);
            btnCreateWorker.Name = "btnCreateWorker";
            btnCreateWorker.Size = new Size(364, 36);
            btnCreateWorker.TabIndex = 9;
            btnCreateWorker.Text = "Добавить сотрудника";
            btnCreateWorker.UseVisualStyleBackColor = true;
            btnCreateWorker.Click += btnCreateWorker_Click;
            // 
            // tpCurrentWorker
            // 
            tpCurrentWorker.Controls.Add(btnChangePassword);
            tpCurrentWorker.Controls.Add(bntEditWorker);
            tpCurrentWorker.Controls.Add(tbNumberToEdit);
            tpCurrentWorker.Controls.Add(btnDeleteWorker);
            tpCurrentWorker.Controls.Add(cbPositionToEdit);
            tpCurrentWorker.Controls.Add(label12);
            tpCurrentWorker.Controls.Add(label7);
            tpCurrentWorker.Controls.Add(tbSurnameToEdit);
            tpCurrentWorker.Controls.Add(label8);
            tpCurrentWorker.Controls.Add(label10);
            tpCurrentWorker.Controls.Add(tbPatronymicToEdit);
            tpCurrentWorker.Controls.Add(tbNameToEdit);
            tpCurrentWorker.Controls.Add(label9);
            tpCurrentWorker.Location = new Point(4, 24);
            tpCurrentWorker.Name = "tpCurrentWorker";
            tpCurrentWorker.Padding = new Padding(3);
            tpCurrentWorker.Size = new Size(1018, 297);
            tpCurrentWorker.TabIndex = 1;
            tpCurrentWorker.Text = "Выбранный сотрудник";
            tpCurrentWorker.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.Location = new Point(431, 67);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(364, 35);
            btnChangePassword.TabIndex = 17;
            btnChangePassword.Text = "Сменить пароль";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // bntEditWorker
            // 
            bntEditWorker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bntEditWorker.Location = new Point(431, 25);
            bntEditWorker.Name = "bntEditWorker";
            bntEditWorker.Size = new Size(364, 36);
            bntEditWorker.TabIndex = 16;
            bntEditWorker.Text = "Редактировать сотрудника";
            bntEditWorker.UseVisualStyleBackColor = true;
            bntEditWorker.Click += bntEditWorker_Click;
            // 
            // tbNumberToEdit
            // 
            tbNumberToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNumberToEdit.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            tbNumberToEdit.Location = new Point(133, 208);
            tbNumberToEdit.Mask = "+7 999 000-00-00";
            tbNumberToEdit.Name = "tbNumberToEdit";
            tbNumberToEdit.Size = new Size(264, 23);
            tbNumberToEdit.TabIndex = 15;
            // 
            // btnDeleteWorker
            // 
            btnDeleteWorker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteWorker.Location = new Point(431, 145);
            btnDeleteWorker.Name = "btnDeleteWorker";
            btnDeleteWorker.Size = new Size(364, 35);
            btnDeleteWorker.TabIndex = 18;
            btnDeleteWorker.Text = "Удалить сотрудника";
            btnDeleteWorker.UseVisualStyleBackColor = true;
            btnDeleteWorker.Click += btnDeleteWorker_Click;
            // 
            // cbPositionToEdit
            // 
            cbPositionToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbPositionToEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPositionToEdit.FormattingEnabled = true;
            cbPositionToEdit.Location = new Point(133, 162);
            cbPositionToEdit.Name = "cbPositionToEdit";
            cbPositionToEdit.Size = new Size(264, 23);
            cbPositionToEdit.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(17, 28);
            label12.Name = "label12";
            label12.Size = new Size(61, 15);
            label12.TabIndex = 27;
            label12.Text = "Фамилия:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 165);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 34;
            label7.Text = "Должность:";
            // 
            // tbSurnameToEdit
            // 
            tbSurnameToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSurnameToEdit.Location = new Point(133, 25);
            tbSurnameToEdit.Name = "tbSurnameToEdit";
            tbSurnameToEdit.Size = new Size(264, 23);
            tbSurnameToEdit.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 211);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 33;
            label8.Text = "Телефон:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 67);
            label10.Name = "label10";
            label10.Size = new Size(34, 15);
            label10.TabIndex = 29;
            label10.Text = "Имя:";
            // 
            // tbPatronymicToEdit
            // 
            tbPatronymicToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPatronymicToEdit.Location = new Point(133, 110);
            tbPatronymicToEdit.Name = "tbPatronymicToEdit";
            tbPatronymicToEdit.Size = new Size(264, 23);
            tbPatronymicToEdit.TabIndex = 13;
            // 
            // tbNameToEdit
            // 
            tbNameToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNameToEdit.Location = new Point(133, 64);
            tbNameToEdit.Name = "tbNameToEdit";
            tbNameToEdit.Size = new Size(264, 23);
            tbNameToEdit.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 113);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 31;
            label9.Text = "Отчество:";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(977, 6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // WorkersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 785);
            Controls.Add(btnUpdate);
            Controls.Add(gbOrder);
            Controls.Add(dgvWorkers);
            MinimumSize = new Size(1080, 824);
            Name = "WorkersForm";
            Text = "База сотрудников";
            Load += WorkersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWorkers).EndInit();
            gbOrder.ResumeLayout(false);
            tcOrders.ResumeLayout(false);
            tpNewWorker.ResumeLayout(false);
            tpNewWorker.PerformLayout();
            tpCurrentWorker.ResumeLayout(false);
            tpCurrentWorker.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvWorkers;
        private GroupBox gbOrder;
        private TabControl tcOrders;
        private TabPage tpNewWorker;
        private ComboBox cbPositionToAdd;
        private Label label4;
        private Label label5;
        private TextBox tbPatronymicToAdd;
        private Label label3;
        private TextBox tbNameToAdd;
        private Label label2;
        private TextBox tbSurnameToAdd;
        private Label label1;
        private Button btnCreateWorker;
        private TabPage tpCurrentWorker;
        private ComboBox comboBox2;
        private Button bntEditWorker;
        private Button btnDeleteWorker;
        private TextBox textBox4;
        private TextBox textBox8;
        private TextBox textBox6;
        private TextBox textBox7;
        private MaskedTextBox tbNumberToAdd;
        private Button btnUpdate;
        private MaskedTextBox tbNumberToEdit;
        private ComboBox cbPositionToEdit;
        private Label label12;
        private Label label7;
        private TextBox tbSurnameToEdit;
        private Label label8;
        private Label label10;
        private TextBox tbPatronymicToEdit;
        private TextBox tbNameToEdit;
        private Label label9;
        private MaskedTextBox tbIdToAdd;
        private Label label6;
        private DataGridViewTextBoxColumn WorkerId;
        private DataGridViewTextBoxColumn WorkerSurname;
        private DataGridViewTextBoxColumn WorkerName;
        private DataGridViewTextBoxColumn WorkerPatronymic;
        private DataGridViewTextBoxColumn WorkerSalary;
        private DataGridViewTextBoxColumn WorkerPosition;
        private DataGridViewTextBoxColumn WorkerPhoneNumber;
        private DataGridViewTextBoxColumn PositionId;
        private Button btnChangePassword;
    }
}