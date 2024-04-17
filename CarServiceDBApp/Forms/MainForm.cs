using CarServiceDBApp.Authorization;
using CarServiceDBApp.Forms;
using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.Data;
using LicenseContext = OfficeOpenXml.LicenseContext;

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
        StatusRepository statusRepository;
        ReportsRepository reportsRepository;


        bool onlyActiveOrders;
        public bool OnlyActiveOrders { get => onlyActiveOrders; set => onlyActiveOrders = value; }

        public MainForm()
        {
            InitializeComponent();

            ordersRepository = new();
            orderDetailsRepository = new();
            clientsRepository = new();
            carsRepository = new();
            workersRepository = new();
            ownershipRepository = new();
            statusRepository = new();
            reportsRepository = new();

            OnlyActiveOrders = true;
            btnActiveOrders.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RoleInterface(User.PositionId);
            UpadateAll();
        }

        private void RoleInterface(int positionId)
        {
            switch (positionId)
            {
                case 21495:
                    gbOrder.Enabled = false;
                    gbStatus.Enabled = false;
                    gbOrderDetails.Enabled = false;
                    break;
                case 18511:
                    автомобилиToolStripMenuItem.Enabled = false;
                    клиентыToolStripMenuItem.Enabled = false;
                    сотрудникиToolStripMenuItem.Enabled = false;
                    tsddbReports.Enabled = false;
                    button1.Enabled = false;
                    btnEditWorker.Enabled = false;
                    btnDeleteServiceFromOrder.Enabled = false;
                    btnOpenAddServiceForm.Enabled = false;
                    gbOrder.Enabled = false;
                    gbStatus.Enabled = false;
                    dgvOrderDetails.Columns["Price"].Visible = false;
                    dgvOrders.Columns["Sum"].Visible = false;
                    break;
                case 23796:
                    сотрудникиToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void HandleDatabaseError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                ErrorHandler.ShowErrorMessage("Заказ с указанными данными уже добавлен");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
            }
        }

        public void UpadateAll()
        {
            UpdateOrders();
            LoadClientsToAdd();
            LoadWorkersToAdd();
        }

        private void btnAllOrders_Click(object sender, EventArgs e)
        {
            OnlyActiveOrders = false;

            btnAllOrders.Enabled = false;
            btnActiveOrders.Enabled = true;

            UpdateOrders();
        }

        private void btnActiveOrders_Click(object sender, EventArgs e)
        {
            OnlyActiveOrders = true;

            btnAllOrders.Enabled = true;
            btnActiveOrders.Enabled = false;

            UpdateOrders();
        }

        public void UpdateOrders()
        {
            try
            {
                if (OnlyActiveOrders)
                {
                    dgvOrders.DataSource = ordersRepository.GetActiveOrders();
                }
                else
                {
                    dgvOrders.DataSource = ordersRepository.GetAllOrders();
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnUpdateOrders_Click(object sender, EventArgs e)
        {
            UpdateOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);

                    if (User.PositionId == 23796)
                    {
                        LoadClientsToEdit();

                        dtpDateToEdit.Value = (DateTime)dgvOrders.SelectedRows[0].Cells["AppointmentDate"].Value;

                        int statusId = (int)dgvOrders.SelectedRows[0].Cells["StatusId"].Value;
                        if (statusId == 1)
                        {
                            btnStatusЗаявка.Enabled = false;
                            btnStatusВРаботе.Enabled = true;
                            btnStatusВыполнен.Enabled = true;
                            btnStatusОтменен.Enabled = true;

                            bntEditOrder.Enabled = true;

                            gbOrderDetails.Enabled = true;
                        }
                        else if (statusId == 2)
                        {
                            btnStatusЗаявка.Enabled = false;
                            btnStatusВРаботе.Enabled = false;
                            btnStatusВыполнен.Enabled = true;
                            btnStatusОтменен.Enabled = true;

                            bntEditOrder.Enabled = true;

                            gbOrderDetails.Enabled = true;
                        }
                        else if (statusId == 3)
                        {
                            btnStatusЗаявка.Enabled = false;
                            btnStatusВРаботе.Enabled = false;
                            btnStatusВыполнен.Enabled = false;
                            btnStatusОтменен.Enabled = false;

                            bntEditOrder.Enabled = false;

                            gbOrderDetails.Enabled = false;
                        }
                        else if (statusId == 4)
                        {
                            btnStatusЗаявка.Enabled = false;
                            btnStatusВРаботе.Enabled = false;
                            btnStatusВыполнен.Enabled = false;
                            btnStatusОтменен.Enabled = false;

                            bntEditOrder.Enabled = false;

                            gbOrderDetails.Enabled = false;
                        }
                    }

                    if (User.PositionId == 18511)
                    {
                        int statusId = (int)dgvOrders.SelectedRows[0].Cells["StatusId"].Value;
                        if (statusId == 1 || statusId == 2)
                        {
                            gbOrderDetails.Enabled = true;
                        }
                        else if (statusId == 3 || statusId == 4)
                        {
                            gbOrderDetails.Enabled = false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnStatusЗаявка_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    ordersRepository.UpdateStatus(orderId, 1);
                    dgvOrders.SelectedRows[0].Cells["StatusName"].Value = statusRepository.GetStatusById(1);

                    btnStatusЗаявка.Enabled = false;
                    btnStatusВРаботе.Enabled = true;
                    btnStatusВыполнен.Enabled = true;
                    btnStatusОтменен.Enabled = true;

                    dgvOrders.SelectedRows[0].Cells["StatusId"].Value = 1;
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для изменения статуса");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для изменения статуса");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnStatusВРаботе_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    ordersRepository.UpdateStatus(orderId, 2);
                    dgvOrders.SelectedRows[0].Cells["StatusName"].Value = statusRepository.GetStatusById(2);

                    btnStatusЗаявка.Enabled = false;
                    btnStatusВРаботе.Enabled = false;
                    btnStatusВыполнен.Enabled = true;
                    btnStatusОтменен.Enabled = true;

                    dgvOrders.SelectedRows[0].Cells["StatusId"].Value = 2;
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для изменения статуса");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для изменения статуса");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnStatusВыполнен_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);

                    bool hasUncompletedOrder = false;

                    foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        if (status != "Выполнена")
                        {
                            hasUncompletedOrder = true;
                            break;
                        }
                    }

                    if (hasUncompletedOrder)
                    {
                        MessageBox.Show("Выполнены не все услуги.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        CompletionDateForm completionDateForm = new CompletionDateForm((DateTime)dgvOrders.SelectedRows[0].Cells["AppointmentDate"].Value);
                        if (completionDateForm.ShowDialog() == DialogResult.OK)
                        {
                            ordersRepository.UpdateStatus(orderId, 3);
                            ordersRepository.UpdateCompletionDate(orderId, completionDateForm.CompletionDate);
                            dgvOrders.SelectedRows[0].Cells["StatusName"].Value = statusRepository.GetStatusById(3);
                            dgvOrders.SelectedRows[0].Cells["CompletionDate"].Value = completionDateForm.CompletionDate.Date;

                            btnStatusЗаявка.Enabled = false;
                            btnStatusВРаботе.Enabled = false;
                            btnStatusВыполнен.Enabled = false;
                            btnStatusОтменен.Enabled = false;

                            dgvOrders.SelectedRows[0].Cells["StatusId"].Value = 3;

                            if (OnlyActiveOrders)
                            {
                                dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
                            }
                        }
                    }
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для изменения статуса");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для изменения статуса");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnStatusОтменен_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    ordersRepository.UpdateStatus(orderId, 4);
                    dgvOrders.SelectedRows[0].Cells["StatusName"].Value = statusRepository.GetStatusById(4);

                    btnStatusЗаявка.Enabled = false;
                    btnStatusВРаботе.Enabled = false;
                    btnStatusВыполнен.Enabled = false;
                    btnStatusОтменен.Enabled = false;

                    dgvOrders.SelectedRows[0].Cells["StatusId"].Value = 4;

                    if (OnlyActiveOrders)
                    {
                        dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
                    }
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для изменения статуса");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для изменения статуса");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный заказ?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    ordersRepository.DeleteOrderById(orderId);
                    dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Выберите один заказ для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteServiceFromOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.SelectedRows.Count == 1)
                {
                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                    int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);

                    if (Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["ServiceId"].Value) != 1)
                    {
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить услугу из заказа?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            orderDetailsRepository.DeleteServiceFromOrder(orderDetailsId);
                            dgvOrderDetails.Rows.RemoveAt(dgvOrderDetails.SelectedRows[0].Index);

                            dgvOrders.SelectedRows[0].Cells["Sum"].Value = ordersRepository.GetOrderSum(orderId);
                        }
                    }
                    else
                    {
                        ErrorHandler.ShowWarningMessage("Нельзя удалить прием. Вы можете изменить исполнителя");
                    }
                }
                else if (dgvOrderDetails.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите услугу для удаления");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одну услугу для удаления");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnCompleteService_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.SelectedRows.Count == 1)
                {
                    int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);
                    orderDetailsRepository.CompleteService(orderDetailsId);
                    dgvOrderDetails.SelectedRows[0].Cells["Status"].Value = "Выполнена";
                    btnCompleteService.Enabled = false;
                    btnEditWorker.Enabled = false;
                }
                else if (dgvOrderDetails.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите услугу для выполнения");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одну услугу для выполнения");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnOpenAddServiceForm_Click(object sender, EventArgs e)
        {
            try
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

                    dgvOrders.SelectedRows[0].Cells["Sum"].Value = ordersRepository.GetOrderSum(orderId);
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            try
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
                else if (dgvOrderDetails.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите услугу для изменения");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одну услугу для изменения");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void LoadClientsToAdd()
        {
            try
            {
                DataTable clientsDataTable = clientsRepository.GetClients();
                cbClientsToAdd.DataSource = clientsDataTable;
                cbClientsToAdd.ValueMember = "ClientId";
                cbClientsToAdd.DisplayMember = "ClientFullName";
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить клиентов");
            }
        }

        private void LoadWorkersToAdd()
        {
            try
            {
                DataTable workersDataTable = workersRepository.GetReceptionists();
                cbWorkersToAdd.DataSource = workersDataTable;
                cbWorkersToAdd.ValueMember = "WorkerId";
                cbWorkersToAdd.DisplayMember = "WorkerFullName";
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить мастеров");
            }
        }

        private void LoadCarsToAdd(int clientId)
        {
            try
            {
                DataTable carsDataTable = carsRepository.GetCarNamesByClientId(clientId);
                cbCarsToAdd.DataSource = carsDataTable;
                cbCarsToAdd.ValueMember = "CarId";
                cbCarsToAdd.DisplayMember = "CarFullName";
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить автомобили");
            }
        }

        private void cbClientsToAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbClientsToAdd != null)
                {
                    DataRowView drv = (DataRowView)cbClientsToAdd.SelectedItem;
                    int clientId = Convert.ToInt32(drv["ClientId"]);

                    LoadCarsToAdd(clientId);
                }
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить автомобили");
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbClientsToAdd.SelectedItem == null)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для создания заказа");
                    return;
                }

                if (cbCarsToAdd.SelectedItem == null)
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для создания заказа");
                    return;
                }

                if (cbWorkersToAdd.SelectedItem == null)
                {
                    ErrorHandler.ShowWarningMessage("Выберите мастера-приемщика для создания заказа");
                    return;
                }

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
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void LoadClientsToEdit()
        {
            try
            {
                DataTable clientsDataTable = clientsRepository.GetClients();
                cbClientsToEdit.DataSource = clientsDataTable;
                cbClientsToEdit.ValueMember = "ClientId";
                cbClientsToEdit.DisplayMember = "ClientFullName";
                var clientIdToSelect = Convert.ToInt32(dgvOrders.CurrentRow.Cells["ClientId"].Value);
                cbClientsToEdit.SelectedValue = clientIdToSelect;
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить клиентов");
            }
        }

        private void LoadCarsToEdit(int clientId)
        {
            try
            {
                DataTable carsDataTable = carsRepository.GetCarNamesByClientId(clientId);
                cbCarsToEdit.DataSource = carsDataTable;
                cbCarsToEdit.ValueMember = "CarId";
                cbCarsToEdit.DisplayMember = "CarFullName";
                var carIdToSelect = Convert.ToInt32(dgvOrders.CurrentRow.Cells["CarId"].Value);
                cbCarsToEdit.SelectedValue = carIdToSelect;
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить автомобили");
            }
        }

        private void cbClientsToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbClientsToAdd != null)
                {
                    DataRowView drv = (DataRowView)cbClientsToEdit.SelectedItem;
                    int clientId = Convert.ToInt32(drv["ClientId"]);

                    LoadCarsToEdit(clientId);
                }
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось загрузить автомобили");
            }
        }

        private void bntEditOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    if (cbClientsToEdit.SelectedItem == null)
                    {
                        ErrorHandler.ShowWarningMessage("Выберите клиента для редактирования заказа");
                        return;
                    }

                    if (cbCarsToEdit.SelectedItem == null)
                    {
                        ErrorHandler.ShowWarningMessage("Выберите автомобиль для редактирования заказа");
                        return;
                    }

                    int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);

                    DataRowView drvClient = (DataRowView)cbClientsToEdit.SelectedItem;
                    int clientId = Convert.ToInt32(drvClient["ClientId"]);

                    DataRowView drvCar = (DataRowView)cbCarsToEdit.SelectedItem;
                    int carId = Convert.ToInt32(drvCar["CarId"]);

                    int ownershipId = ownershipRepository.GetOwnershipId(clientId, carId);

                    DateTime dateTime = dtpDateToEdit.Value;

                    ordersRepository.UpdateOrder(orderId, ownershipId, dateTime);

                    UpdateOrders();
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для редактирования");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для редактирования");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void dgvOrderDetails_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.SelectedRows.Count == 1)
                {
                    string orderDetailsStatus = dgvOrderDetails.SelectedRows[0].Cells["Status"].Value.ToString();

                    if (User.PositionId == 23796)
                    {
                        if (orderDetailsStatus == "Выполнена")
                        {
                            btnCompleteService.Enabled = false;
                            btnEditWorker.Enabled = false;
                        }
                        else
                        {
                            btnCompleteService.Enabled = true;
                            btnEditWorker.Enabled = true;
                        }
                    }

                    else if (User.PositionId == 18511)
                    {
                        if (orderDetailsStatus == "Выполнена")
                        {
                            btnCompleteService.Enabled = false;
                        }
                        else
                        {
                            btnCompleteService.Enabled = false;
                            if (User.Id == (int)dgvOrderDetails.SelectedRows[0].Cells["WorkerId"].Value)
                                btnCompleteService.Enabled = true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsForm clientsForm = new ClientsForm(this);
                clientsForm.ShowDialog();
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось открыть справочник");
            }
        }

        private void автомобилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CarsForm carsForm = new CarsForm(this);
                carsForm.ShowDialog();
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось открыть справочник");
            }
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ServicesForm servicesForm = new ServicesForm(this);
                servicesForm.ShowDialog();
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось открыть справочник");
            }
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WorkersForm workersForm = new WorkersForm(this);
                workersForm.ShowDialog();
            }
            catch (Exception)
            {
                ErrorHandler.ShowWarningMessage("Не удалось открыть справочник");
            }
        }

        private void отчетОМастерахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDateForm reportDateForm = new ReportDateForm();
                if (reportDateForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime startDate = reportDateForm.StartDate;
                    DateTime endDate = reportDateForm.EndDate;

                    DataTable reportData = reportsRepository.GetMastersData(startDate, endDate);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет о мастерах");

                        worksheet.Column(1).Width = 20;
                        worksheet.Column(2).Width = 26;
                        worksheet.Column(3).Width = 22;
                        worksheet.Column(4).Width = 10;

                        worksheet.Cells["A1"].Value = "Начало периода:";
                        worksheet.Cells["B1"].Value = startDate.ToShortDateString();
                        worksheet.Cells["A2"].Value = "Конец периода:";
                        worksheet.Cells["B2"].Value = endDate.ToShortDateString();

                        worksheet.Cells["A4"].Value = "Табельный номер";
                        worksheet.Cells["B4"].Value = "ФИО сотрудника";
                        worksheet.Cells["C4"].Value = "Выполненные услуги";
                        worksheet.Cells["D4"].Value = "Выручка";

                        var headerCells = worksheet.Cells["A4:D4"];
                        headerCells.Style.Font.Bold = true;
                        headerCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        worksheet.Cells["A5"].LoadFromDataTable(reportData, false);

                        var tableCells = worksheet.Cells["A4:D" + (reportData.Rows.Count + 4)];
                        tableCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        FileInfo excelFile = new FileInfo($"Отчет о мастерах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx");

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void отчетОВыполненныхУслугахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDateForm reportDateForm = new ReportDateForm();
                if (reportDateForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime startDate = reportDateForm.StartDate;
                    DateTime endDate = reportDateForm.EndDate;

                    DataTable reportData = reportsRepository.GetServicesData(startDate, endDate);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет о выполненных услугах");

                        worksheet.Column(1).Width = 29;
                        worksheet.Column(2).Width = 14;
                        worksheet.Column(3).Width = 15;

                        worksheet.Cells["A1"].Value = "Начало периода:";
                        worksheet.Cells["B1"].Value = startDate.ToShortDateString();
                        worksheet.Cells["A2"].Value = "Конец периода:";
                        worksheet.Cells["B2"].Value = endDate.ToShortDateString();

                        worksheet.Cells["A4"].Value = "Услуга";
                        worksheet.Cells["B4"].Value = "Количество";
                        worksheet.Cells["C4"].Value = "Выручка";

                        var headerCells = worksheet.Cells["A4:C4"];
                        headerCells.Style.Font.Bold = true;
                        headerCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        worksheet.Cells["A5"].LoadFromDataTable(reportData, false);

                        var tableCells = worksheet.Cells["A4:C" + (reportData.Rows.Count + 4)];
                        tableCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        FileInfo excelFile = new FileInfo($"Отчет о выполненных услугах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx");

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void отчетОЗаказахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDateForm reportDateForm = new ReportDateForm();
                if (reportDateForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime startDate = reportDateForm.StartDate;
                    DateTime endDate = reportDateForm.EndDate;

                    DataTable reportData = reportsRepository.GetOrdersData(startDate, endDate);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет о заказах");

                        worksheet.Column(1).Width = 20;
                        worksheet.Column(2).Width = 32;
                        worksheet.Column(3).Width = 22;
                        worksheet.Column(4).Width = 26;
                        worksheet.Column(5).Width = 15;
                        worksheet.Column(6).Width = 15;
                        worksheet.Column(7).Width = 15;
                        worksheet.Column(8).Width = 21;

                        worksheet.Cells["A1"].Value = "Начало периода:";
                        worksheet.Cells["B1"].Value = startDate.ToShortDateString();
                        worksheet.Cells["A2"].Value = "Конец периода:";
                        worksheet.Cells["B2"].Value = endDate.ToShortDateString();

                        worksheet.Cells["A4"].Value = "Номер заказа";
                        worksheet.Cells["B4"].Value = "ФИО клиента";
                        worksheet.Cells["C4"].Value = "Номер телефона";
                        worksheet.Cells["D4"].Value = "Автомобиль";
                        worksheet.Cells["E4"].Value = "Дата приема";
                        worksheet.Cells["F4"].Value = "Дата выпуска";
                        worksheet.Cells["G4"].Value = "Сумма заказа";
                        worksheet.Cells["H4"].Value = "Статус";

                        var headerCells = worksheet.Cells["A4:H4"];
                        headerCells.Style.Font.Bold = true;
                        headerCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        ExcelRange dateRange = worksheet.Cells["E5:F" + (reportData.Rows.Count + 5)];
                        dateRange.Style.Numberformat.Format = "dd-mm-yyyy";

                        worksheet.Cells["A5"].LoadFromDataTable(reportData, false);

                        var tableCells = worksheet.Cells["A4:H" + (reportData.Rows.Count + 4)];
                        tableCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        tableCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        FileInfo excelFile = new FileInfo($"Отчет о заказах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx");

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 1)
                {
                    var selectedOrder = dgvOrders.SelectedRows[0];

                    int orderId = Convert.ToInt32(selectedOrder.Cells["OrderId"].Value);
                    string date = ((DateTime)selectedOrder.Cells["AppointmentDate"].Value).ToShortDateString().ToString();

                    int clientId = ownershipRepository.GetClientId(Convert.ToInt32(selectedOrder.Cells["OwnershipId"].Value));
                    DataTable clientDT = clientsRepository.GetClient(clientId);
                    DataRow client = clientDT.Rows[0];
                    string clientFullName = Convert.ToString(client["ClientFullName"]);
                    string clientPhoneNumber = Convert.ToString(client["ClientPhoneNumber"]);

                    int carId = ownershipRepository.GetCarId(Convert.ToInt32(selectedOrder.Cells["OwnershipId"].Value));
                    DataTable carDT = carsRepository.GetCar(carId);
                    DataRow car = carDT.Rows[0];
                    string carName = Convert.ToString(car["brand"]) + " " + Convert.ToString(car["model"]);
                    string number = Convert.ToString(car["registration_number"]);
                    string VIN = Convert.ToString(car["VIN"]);
                    int year = Convert.ToInt32(car["year"]);
                    int mileage = Convert.ToInt32(car["mileage"]);

                    DataTable servicesData = reportsRepository.GetDetailsData(orderId);

                    int sum = Convert.ToInt32(selectedOrder.Cells["Sum"].Value);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Заказ наряд");

                        worksheet.Cells["A1:D1"].Merge = true;
                        worksheet.Cells["A1"].Value = $"Заказ-наряд №{orderId} от {date}";
                        worksheet.Cells["A1"].Style.Font.Bold = true;
                        worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        worksheet.Cells["A2"].Value = "Заказчик:";
                        worksheet.Cells["B2"].Value = clientFullName;

                        worksheet.Cells["A3"].Value = "Номер телефона:";
                        worksheet.Cells["B3"].Value = clientPhoneNumber;

                        worksheet.Cells["A5"].Value = "Автомобиль:";
                        worksheet.Cells["B5"].Value = carName;

                        worksheet.Cells["A6"].Value = "Регистрационный номер:";
                        worksheet.Cells["B6"].Value = number;

                        worksheet.Cells["A7"].Value = "VIN:";
                        worksheet.Cells["B7"].Value = VIN;

                        worksheet.Cells["A8"].Value = "Год выпуска:";
                        worksheet.Cells["B8"].Value = year;

                        worksheet.Cells["A9"].Value = "Пробег:";
                        worksheet.Cells["B9"].Value = mileage;

                        var clientCells = worksheet.Cells["A2:B3"];
                        clientCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        clientCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        clientCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        clientCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        var carCells = worksheet.Cells["A5:B9"];
                        carCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        carCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        carCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        carCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;


                        worksheet.Cells["A11:D11"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        worksheet.Cells["A11:D11"].Style.Font.Bold = true;
                        worksheet.Cells["A11"].Value = "№";
                        worksheet.Cells["B11"].Value = "Услуга";
                        worksheet.Cells["C11"].Value = "Цена";
                        worksheet.Cells["D11"].Value = "Исполнитель";

                        int row = 12;
                        int serviceNumber = 1;
                        foreach (DataRow serviceRow in servicesData.Rows)
                        {
                            worksheet.Cells["A" + row].Value = serviceNumber;
                            worksheet.Cells["B" + row].Value = serviceRow["ServiceName"].ToString();
                            worksheet.Cells["C" + row].Value = serviceRow["Price"];
                            worksheet.Cells["D" + row].Value = serviceRow["WorkerFullName"].ToString();
                            row++;
                            serviceNumber++;
                        }

                        var servicesCells = worksheet.Cells["A11:D" + (row - 1)];
                        servicesCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        servicesCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        servicesCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        servicesCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;


                        worksheet.Cells["A" + row].Value = "Итого:";
                        worksheet.Cells["C" + row].Value = sum.ToString() + " руб.";
                        worksheet.Cells["A" + row + ":D" + row].Style.Font.Bold = true;
                        worksheet.Cells["A" + (row + 2)].Value = "Мастер:";
                        worksheet.Cells["A" + (row + 4)].Value = "Заказчик:";
                        worksheet.Cells["B" + (row + 2)].Value = "______________________";
                        worksheet.Cells["B" + (row + 4)].Value = "______________________";

                        worksheet.PrinterSettings.PrintArea = worksheet.Cells["A1:D" + (row + 5)];

                        worksheet.Cells.AutoFitColumns();

                        string filePath = $"Заказ-наряд №{orderId} от {date}.xlsx";
                        FileInfo excelFile = new FileInfo(filePath);
                        excelPackage.SaveAs(excelFile);
                        MessageBox.Show("Заказ-наряд сформирован");
                    }
                }
                else if (dgvOrders.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите один заказ для составления заказ-наряда");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один заказ для составления заказ-наряда");
                }
            }
            catch (MySqlException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }


        public event EventHandler MainFormClosed;
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainFormClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}