using CarServiceDBApp.Repositories;
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
    public partial class HistoryForm : Form
    {
        OrderDetailsRepository orderDetailsRepository;

        public HistoryForm()
        {
            InitializeComponent();
            orderDetailsRepository = new OrderDetailsRepository();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderId"].Value);
                dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);
            }
        }
    }
}
