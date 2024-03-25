using CarServiceDBApp.Helpers;
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
    public partial class ReportDateForm : Form
    {
        public ReportDateForm()
        {
            InitializeComponent();
        }

        public DateTime StartDate
        {
            get { return dtpStartDate.Value; }
            set {; }
        }

        public DateTime EndDate
        {
            get { return dtpEndDate.Value; }
            set {; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DateTime selectedStartDate = StartDate.Date;
            DateTime selectedEndDate = EndDate.Date;
            DateTime currentDate = DateTime.Today;

            if (selectedStartDate > currentDate)
            {
                ErrorHandler.ShowErrorMessage("Дата начала не может быть позже сегодняшней");
            }
            else if (selectedEndDate < currentDate)
            {
                ErrorHandler.ShowErrorMessage("Дата окочания не может быть позже сегодняшней");
            }
            else if (selectedStartDate > selectedEndDate)
            {
                ErrorHandler.ShowErrorMessage("Дата начала не может быть позже даты окончания");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
