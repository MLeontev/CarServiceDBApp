using CarServiceDBApp.Repositories;
using Google.Protobuf.WellKnownTypes;

namespace CarServiceDBApp.Forms
{
    public partial class EditServiceInOrderForm : Form
    {
        private WorkersRepository workersRepository;

        public EditServiceInOrderForm(int serviceId)
        {
            InitializeComponent();

            workersRepository = new();

            if (serviceId == 1)
            {
                dgvWorkersToOrder.DataSource = workersRepository.GetReceptionists();
            }
            else
            {
                dgvWorkersToOrder.DataSource = workersRepository.GetСarMechanics();
            }
        }

        public int WorkerId_prop
        {
            get { return Convert.ToInt32(dgvWorkersToOrder.SelectedRows[0].Cells["WorkerId"].Value); }
            set {; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditWorkerInService_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
