namespace CarServiceDBApp.Forms
{
    partial class CompletionDateForm
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
            dtpCompletionDate = new DateTimePicker();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // dtpCompletionDate
            // 
            dtpCompletionDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpCompletionDate.Location = new Point(12, 12);
            dtpCompletionDate.Name = "dtpCompletionDate";
            dtpCompletionDate.Size = new Size(200, 23);
            dtpCompletionDate.TabIndex = 1;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(12, 53);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(93, 39);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "Выбрать";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(119, 53);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(93, 39);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CompletionDateForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(226, 110);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(dtpCompletionDate);
            MinimumSize = new Size(242, 149);
            Name = "CompletionDateForm";
            Text = "Дата закрытия";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpCompletionDate;
        private Button btnAccept;
        private Button btnCancel;
    }
}