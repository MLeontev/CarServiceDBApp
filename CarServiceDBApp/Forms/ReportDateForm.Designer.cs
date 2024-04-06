namespace CarServiceDBApp.Forms
{
    partial class ReportDateForm
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
            btnAccept = new Button();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(226, 98);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(93, 39);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(119, 98);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(93, 39);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Выбрать";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpEndDate.Location = new Point(119, 51);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpStartDate.Location = new Point(119, 9);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 7;
            label1.Text = "Начало периода:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 8;
            label2.Text = "Конец периода:";
            // 
            // ReportDateForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(342, 155);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpStartDate);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(dtpEndDate);
            MinimumSize = new Size(358, 194);
            Name = "ReportDateForm";
            Text = "Отчетный период";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnAccept;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private Label label2;
    }
}