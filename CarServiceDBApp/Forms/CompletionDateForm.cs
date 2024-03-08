using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarServiceDBApp.Forms
{
    public partial class CompletionDateForm : Form
    {
        public CompletionDateForm(DateTime appointmentDate)
        {
            InitializeComponent();
            AppointmentDate = appointmentDate;
        }

        public DateTime CompletionDate
        {
            get { return dtpCompletionDate.Value; }
            set {; }
        }

        public DateTime AppointmentDate { get; set; }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = CompletionDate.Date;
            DateTime currentDate = DateTime.Today;

            if (selectedDate > currentDate)
            {
                MessageBox.Show("Выбранная дата не может быть позже сегодняшней.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedDate < AppointmentDate)
            {
                MessageBox.Show("Выбранная дата не может быть раньше даты приема.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
