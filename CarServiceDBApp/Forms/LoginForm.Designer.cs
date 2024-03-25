namespace CarServiceDBApp.Forms
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            tbNumberToAdd = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(69, 24);
            label1.Name = "label1";
            label1.Size = new Size(198, 30);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 1;
            label2.Text = "Введите номер телефона:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 3;
            label3.Text = "Введите пароль:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(182, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 174);
            button1.Name = "button1";
            button1.Size = new Size(322, 33);
            button1.TabIndex = 5;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            // 
            // tbNumberToAdd
            // 
            tbNumberToAdd.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            tbNumberToAdd.Location = new Point(182, 82);
            tbNumberToAdd.Mask = "+7 000 000-00-00";
            tbNumberToAdd.Name = "tbNumberToAdd";
            tbNumberToAdd.Size = new Size(152, 23);
            tbNumberToAdd.TabIndex = 23;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 227);
            Controls.Add(tbNumberToAdd);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
        private MaskedTextBox tbNumberToAdd;
    }
}