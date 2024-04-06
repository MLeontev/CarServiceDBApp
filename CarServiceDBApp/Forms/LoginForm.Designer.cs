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
            tbPassword = new TextBox();
            btnLogin = new Button();
            tbNumber = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(77, 24);
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
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new Point(182, 128);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(152, 23);
            tbPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(12, 174);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(322, 33);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbNumber
            // 
            tbNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNumber.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            tbNumber.Location = new Point(182, 82);
            tbNumber.Mask = "+7 000 000-00-00";
            tbNumber.Name = "tbNumber";
            tbNumber.Size = new Size(152, 23);
            tbNumber.TabIndex = 1;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 228);
            Controls.Add(tbNumber);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(369, 267);
            Name = "LoginForm";
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbPassword;
        private Button btnLogin;
        private MaskedTextBox tbNumber;
    }
}