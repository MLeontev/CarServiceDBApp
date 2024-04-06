using CarServiceDBApp.Authorization;
using CarServiceDBApp.Helpers;
using System.Data;

namespace CarServiceDBApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string number = new string(tbNumber.Text.Where(c => char.IsDigit(c) || c == '+').ToArray());
            string password = tbPassword.Text;

            if (number.Length != 12)
            {
                ErrorHandler.ShowErrorMessage("Введите номер телефона");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorHandler.ShowErrorMessage("Введите пароль");
                return;
            }

            var user = new User();
            if (user.Login(number, password))
            {
                var mainForm = new MainForm();
                mainForm.MainFormClosed += MainForm_MainFormClosed;
                mainForm.Show();
                this.Hide();
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Пользователь не найден");
            }
        }

        private void MainForm_MainFormClosed(object sender, EventArgs e)
        {
            this.Show();
            tbNumber.Text = "";
            tbPassword.Text = "";
        }
    }
}
