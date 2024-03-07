using CarServiceDBApp.Forms;
using CarServiceDBApp.Repositories;
using MySqlX.XDevAPI;
using System.Data;

namespace CarServiceDBApp
{
    public partial class MainForm : Form
    {
        OrdersRepository ordersRepository;
        OrderDetailsRepository orderDetailsRepository;
        ClientsRepository clientsRepository;
        CarsRepository carsRepository;
        WorkersRepository workersRepository;
        OwnershipRepository ownershipRepository;

        public MainForm()
        {
            InitializeComponent();

            ordersRepository = new();
            orderDetailsRepository = new();
            clientsRepository = new();
            carsRepository = new();
            workersRepository = new();
            ownershipRepository = new();

            UpdateOrders();
            LoadClientsToAdd();
            LoadWorkersToAdd();
        }

        private void UpdateOrders()
        {
            dgvOrders.DataSource = ordersRepository.GetAllOrders();
        }

        private void btnUpdateOrders_Click(object sender, EventArgs e)
        {
            UpdateOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);

                LoadClientsToEdit();
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                ordersRepository.DeleteOrderById(orderId);
                dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("�������� ������ ���� ����� ��� ��������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteServiceFromOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);
                orderDetailsRepository.DeleteServiceFromOrder(orderDetailsId);
                dgvOrderDetails.Rows.RemoveAt(dgvOrderDetails.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("�������� ���� ������ ��� ��������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCompleteService_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);
                orderDetailsRepository.CompleteService(orderDetailsId);
                dgvOrderDetails.SelectedRows[0].Cells["Status"].Value = "���������";
            }
            else
            {
                MessageBox.Show("�������� ���� ������ ��� ����������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOpenAddServiceForm_Click(object sender, EventArgs e)
        {
            AddServiceToOrderForm addServiceToOrderForm = new AddServiceToOrderForm();
            if (addServiceToOrderForm.ShowDialog() == DialogResult.OK)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                int serviceId = addServiceToOrderForm.ServiceId_prop;
                int workerId = addServiceToOrderForm.WorkerId;
                orderDetailsRepository.AddServiceToOrder(orderId, serviceId, workerId);

                orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);
            }
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                int serviceId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["ServiceId"].Value);

                EditServiceInOrderForm editForm = new(serviceId);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);
                    int workerId = editForm.WorkerId_prop;
                    orderDetailsRepository.EditWorkerInOrderDetails(orderDetailsId, workerId);

                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);
                }
            }
            else
            {
                MessageBox.Show("�������� ���� ������ ��� ���������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadClientsToAdd()
        {
            DataTable clientsDataTable = clientsRepository.GetClients();
            cbClientsToAdd.DataSource = clientsDataTable;
            cbClientsToAdd.ValueMember = "ClientId";
            cbClientsToAdd.DisplayMember = "ClientFullName";
        }

        private void LoadWorkersToAdd()
        {
            DataTable workersDataTable = workersRepository.GetReceptionists();
            cbWorkersToAdd.DataSource = workersDataTable;
            cbWorkersToAdd.ValueMember = "WorkerId";
            cbWorkersToAdd.DisplayMember = "WorkerFullName";
        }

        private void LoadCarsToAdd(int clientId)
        {
            DataTable carsDataTable = carsRepository.GetCarsByClientId(clientId);
            cbCarsToAdd.DataSource = carsDataTable;
            cbCarsToAdd.ValueMember = "CarId";
            cbCarsToAdd.DisplayMember = "CarFullName";
        }

        private void cbClientsToAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientsToAdd != null)
            {
                DataRowView drv = (DataRowView)cbClientsToAdd.SelectedItem;
                int clientId = Convert.ToInt32(drv["ClientId"]);

                LoadCarsToAdd(clientId);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            DataRowView drvClient = (DataRowView)cbClientsToAdd.SelectedItem;
            int clientId = Convert.ToInt32(drvClient["ClientId"]);

            DataRowView drvCar = (DataRowView)cbCarsToAdd.SelectedItem;
            int carId = Convert.ToInt32(drvCar["CarId"]);

            int ownershipId = ownershipRepository.GetOwnershipId(clientId, carId);

            DataRowView drvWorker = (DataRowView)cbWorkersToAdd.SelectedItem;
            int workerId = Convert.ToInt32(drvWorker["WorkerId"]);

            DateTime dateTime = dptDateToAdd.Value;

            ordersRepository.CreateOrder(ownershipId, dateTime, workerId);

            UpdateOrders();
        }

        private void LoadClientsToEdit()
        {
            DataTable clientsDataTable = clientsRepository.GetClients();
            cbClientsToEdit.DataSource = clientsDataTable;
            cbClientsToEdit.ValueMember = "ClientId";
            cbClientsToEdit.DisplayMember = "ClientFullName";
            var clientIdToSelect = Convert.ToInt32(dgvOrders.CurrentRow.Cells["ClientId"].Value);
            cbClientsToEdit.SelectedValue = clientIdToSelect;
        }

        private void LoadCarsToEdit(int clientId)
        {
            DataTable carsDataTable = carsRepository.GetCarsByClientId(clientId);
            cbCarsToEdit.DataSource = carsDataTable;
            cbCarsToEdit.ValueMember = "CarId";
            cbCarsToEdit.DisplayMember = "CarFullName";

            var carIdToSelect = Convert.ToInt32(dgvOrders.CurrentRow.Cells["CarId"].Value);
            cbCarsToEdit.SelectedValue = carIdToSelect;
        }

        private void cbClientsToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientsToAdd != null)
            {
                DataRowView drv = (DataRowView)cbClientsToEdit.SelectedItem;
                int clientId = Convert.ToInt32(drv["ClientId"]);

                LoadCarsToEdit(clientId);
            }
        }

        private void bntEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ����� ��� ��������������.", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbClientsToEdit.SelectedItem == null)
            {
                MessageBox.Show("�������� ������� ��� �������������� ������.", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCarsToEdit.SelectedItem == null)
            {
                MessageBox.Show("�������� ���������� ��� �������������� ������.", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);

            DataRowView drvClient = (DataRowView)cbClientsToEdit.SelectedItem;
            int clientId = Convert.ToInt32(drvClient["ClientId"]);

            DataRowView drvCar = (DataRowView)cbCarsToEdit.SelectedItem;
            int carId = Convert.ToInt32(drvCar["CarId"]);

            int ownershipId = ownershipRepository.GetOwnershipId(clientId, carId);

            DateTime dateTime = dptDateToEdit.Value;

            ordersRepository.UpdateOrder(orderId, ownershipId, dateTime);

            UpdateOrders();
        }
    }
}