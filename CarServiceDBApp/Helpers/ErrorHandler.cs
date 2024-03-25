using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDBApp.Helpers
{
    public static class ErrorHandler
    {
        public static void HandleUnknownError(Exception ex)
        {
            ShowErrorMessage("Возникла неопознанная ошибка: " + ex.Message);
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
