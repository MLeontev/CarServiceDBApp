using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;

namespace CarServiceDBApp.Forms
{
    public partial class AddClientToCarForm : Form
    {
        ClientsRepository clientRepository;

        public AddClientToCarForm()
        {
            InitializeComponent();
            clientRepository = new ClientsRepository();
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                dgvClients.DataSource = clientRepository.GetClients();
            }
            catch (MySqlException)
            {
                ErrorHandler.ShowErrorMessage("Не удалось загрузить клиентов");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        public int GetClientId()
        {
            return Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientId"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 1)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (dgvClients.SelectedRows.Count == 0)
            {
                ErrorHandler.ShowWarningMessage("Выберите клиента");
            }
            else
            {
                ErrorHandler.ShowWarningMessage("Выберите только одного клиента");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
