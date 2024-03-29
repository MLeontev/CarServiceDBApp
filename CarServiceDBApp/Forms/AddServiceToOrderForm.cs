using CarServiceDBApp.Repositories;
using System.Data;

namespace CarServiceDBApp.Forms
{
    public partial class AddServiceToOrderForm : Form
    {
        ServicesRepository servicesRepository;
        WorkersRepository workersRepository;

        public int ServiceId_prop
        {
            get { return Convert.ToInt32(dgvServicesToOrder.SelectedRows[0].Cells["ServiceId"].Value); }
        }

        public int WorkerId
        {
            get { return Convert.ToInt32(cbWorkerToService.SelectedValue); }
        }

        public AddServiceToOrderForm()
        {
            InitializeComponent();

            servicesRepository = new();
            workersRepository = new();

            dgvServicesToOrder.DataSource = servicesRepository.GetAllServicesWithoutReception();
            FillReceptionistsComboBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddServiceToOrder_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FillReceptionistsComboBox()
        {
            DataTable receptionistsData = workersRepository.GetСarMechanics();
            cbWorkerToService.DisplayMember = "WorkerFullName";
            cbWorkerToService.ValueMember = "WorkerId";
            cbWorkerToService.DataSource = receptionistsData;
        }
    }
}
