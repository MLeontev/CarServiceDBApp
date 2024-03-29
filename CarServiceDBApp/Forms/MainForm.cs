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

            onlyActiveOrders = true;
            btnActiveOrders.Enabled = false;

            UpadateAll();
        }

        public void UpadateAll()
        {
            UpdateOrders();
            LoadClientsToAdd();
            LoadWorkersToAdd();
        }

        private void btnAllOrders_Click(object sender, EventArgs e)
        {
            onlyActiveOrders = false;
            btnAllOrders.Enabled = false;
            btnActiveOrders.Enabled = true;
            UpdateOrders();
        }

        private void btnActiveOrders_Click(object sender, EventArgs e)
        {
            onlyActiveOrders = true;
            btnAllOrders.Enabled = true;
            btnActiveOrders.Enabled = false;
            UpdateOrders();
        }

        public void UpdateOrders()
        {
            if (onlyActiveOrders)
            {
                dgvOrders.DataSource = ordersRepository.GetActiveOrders();
            }
            else
            {
                dgvOrders.DataSource = ordersRepository.GetAllOrders();
            }
        }

        private void btnUpdateOrders_Click(object sender, EventArgs e)
        {
            UpdateOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                dgvOrderDetails.DataSource = orderDetailsRepository.GetDetailsByOrderId(orderId);

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
                MessageBox.Show("Выберите один заказ для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteServiceFromOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);

                if (Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["ServiceId"].Value) != 1)
                {
                    orderDetailsRepository.DeleteServiceFromOrder(orderDetailsId);
                    dgvOrderDetails.Rows.RemoveAt(dgvOrderDetails.SelectedRows[0].Index);

                    dgvOrders.SelectedRows[0].Cells["Sum"].Value = ordersRepository.GetOrderSum(orderId);
                }
                else
                {
                    MessageBox.Show("Нельзя удалить прием. Вы можете изменить исполнителя.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите одну услугу для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCompleteService_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                int orderDetailsId = Convert.ToInt32(dgvOrderDetails.SelectedRows[0].Cells["OrderDetailsId"].Value);
                orderDetailsRepository.CompleteService(orderDetailsId);
                dgvOrderDetails.SelectedRows[0].Cells["Status"].Value = "Выполнена";
            }
            else
            {
                MessageBox.Show("Выберите одну услугу для выполнения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dgvOrders.SelectedRows[0].Cells["Sum"].Value = ordersRepository.GetOrderSum(orderId);
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
                MessageBox.Show("Выберите одну услугу для изменения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            DataTable carsDataTable = carsRepository.GetCarNamesByClientId(clientId);
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
            DataTable carsDataTable = carsRepository.GetCarNamesByClientId(clientId);
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
            if (dgvOrders.SelectedRows.Count == 1)
            {
                if (dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите заказ для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbClientsToEdit.SelectedItem == null)
                {
                    MessageBox.Show("Выберите клиента для редактирования заказа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbCarsToEdit.SelectedItem == null)
                {
                    MessageBox.Show("Выберите автомобиль для редактирования заказа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else
            {
                MessageBox.Show("Выберите один заказ для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatusЗаявка_Click(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("Выберите только один заказ для изменения статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatusВРаботе_Click(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("Выберите только один заказ для изменения статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatusВыполнен_Click(object sender, EventArgs e)
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

                        if (onlyActiveOrders)
                        {
                            dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите только один заказ для изменения статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatusОтменен_Click(object sender, EventArgs e)
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

                if (onlyActiveOrders)
                {
                    dgvOrders.Rows.RemoveAt(dgvOrders.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Выберите только один заказ для изменения статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrderDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count == 1)
            {
                string orderDetailsStatus = dgvOrderDetails.SelectedRows[0].Cells["Status"].Value.ToString();

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
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm(this);
            clientsForm.ShowDialog();
        }

        private void автомобилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarsForm carsForm = new CarsForm(this);
            carsForm.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicesForm servicesForm = new ServicesForm(this);
            servicesForm.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersForm workersForm = new WorkersForm(this);
            workersForm.ShowDialog();
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

                        FileInfo excelFile = new FileInfo($"Отчет о мастерах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx");

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                //HandleDatabaseError(ex);
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

                        FileInfo excelFile = new FileInfo(
                            $"Отчет о выполненных услугах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx"
                        );

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                //HandleDatabaseError(ex);
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

                        ExcelRange dateRange = worksheet.Cells["E5:F" + (reportData.Rows.Count + 4)];
                        dateRange.Style.Numberformat.Format = "dd-mm-yyyy";

                        worksheet.Cells["A5"].LoadFromDataTable(reportData, false);

                        FileInfo excelFile = new FileInfo($"Отчет о заказах {startDate.ToShortDateString()}-{endDate.ToShortDateString()}.xlsx");

                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Отчет успешно построен");
                    }
                }
            }
            catch (MySqlException ex)
            {
                //HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }
    }
}