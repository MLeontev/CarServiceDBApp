using CarServiceDBApp.Authorization;
using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CarServiceDBApp.Forms
{
    public partial class CarsForm : Form
    {
        MainForm mainForm;
        CarsRepository carsRepository;
        ClientsRepository clientsRepository;
        OrdersRepository ordersRepository;
        OwnershipRepository ownershipRepository;

        HistoryForm historyForm;

        public CarsForm(MainForm mainForm)
        {
            InitializeComponent();

            carsRepository = new CarsRepository();
            clientsRepository = new ClientsRepository();
            ordersRepository = new OrdersRepository();
            ownershipRepository = new OwnershipRepository();

            this.mainForm = mainForm;
        }

        private void CarsForm_Load(object sender, EventArgs e)
        {
            RoleInterface(User.PositionId);
            UpdateCars();
        }

        private void RoleInterface(int positionId)
        {
            switch (positionId)
            {
                case 21495:
                    gbClients.Enabled = false;
                    gbCar.Enabled = false;
                    break;
            }
        }

        private void UpdateCars()
        {
            try
            {
                dgvCars.DataSource = carsRepository.GetAllCars();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCars();
        }

        private void HandleDatabaseError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                ErrorHandler.ShowErrorMessage("Автомобиль с такими данными уже добавлен");
            }
            else if (ex.Number == 1451)
            {
                ErrorHandler.ShowErrorMessage("Невозможно удалить автомобиль, так как по нему есть заказ");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
            }
        }

        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count >= 1)
                {
                    int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["id"].Value.ToString());
                    dgvClients.DataSource = clientsRepository.GetClientsByCarId(carId);

                    tbBrandToEdit.Text = dgvCars.CurrentRow.Cells["Brand"].Value.ToString();
                    tbModelToEdit.Text = dgvCars.CurrentRow.Cells["Model"].Value.ToString();
                    tbNumberToEdit.Text = dgvCars.CurrentRow.Cells["Plate"].Value.ToString();
                    tbVINToEdit.Text = dgvCars.CurrentRow.Cells["VIN"].Value.ToString();
                    tbMileageToEdit.Text = dgvCars.CurrentRow.Cells["Mileage"].Value.ToString();

                    string yearString = dgvCars.CurrentRow.Cells["Year"].Value.ToString();
                    DateTime year = DateTime.ParseExact(yearString, "yyyy", CultureInfo.InvariantCulture);
                    dtpYearToEdit.Value = year;
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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count == 1)
                {
                    int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["id"].Value.ToString());
                    historyForm = new HistoryForm();
                    historyForm.dgvOrders.DataSource = ordersRepository.GetAllOrdersByCarId(carId);
                    historyForm.ShowDialog();
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для просмотра заказов");
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

        private bool ValidateCarInput(string brand, string model, string number, string vin, DateTime year, string mileageText, out int mileage)
        {
            mileage = 0;

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(vin) || string.IsNullOrWhiteSpace(mileageText))
            {
                ErrorHandler.ShowErrorMessage("Все поля должны быть заполнены");
                return false;
            }

            if (brand.Length > 25)
            {
                ErrorHandler.ShowErrorMessage("Марка не должна быть длиннее 25 символов");
                return false;
            }

            if (model.Length > 25)
            {
                ErrorHandler.ShowErrorMessage("Модель не должна быть длиннее 25 символов");
                return false;
            }

            Regex regex = new Regex(@"^[А-Я]{1}\d{3}[А-Я]{2}\d{2,3}$");
            if (!regex.IsMatch(number))
            {
                ErrorHandler.ShowErrorMessage("Номер должен соответствовать формату А999АА99(9)");
                return false;
            }

            if (vin.Length != 17)
            {
                ErrorHandler.ShowErrorMessage("VIN должен содержать ровно 17 символов");
                return false;
            }

            if (year.Year > DateTime.Now.Year)
            {
                ErrorHandler.ShowErrorMessage("Год выпуска не может быть позднее текущего года");
                return false;
            }

            if (!int.TryParse(mileageText, out mileage) || mileage < 0)
            {
                ErrorHandler.ShowErrorMessage("Пробег должен быть положительным целым числом");
                return false;
            }

            return true;
        }

        private void btnCreateCar_Click(object sender, EventArgs e)
        {
            try
            {
                string brand = tbBrandToAdd.Text.Trim();
                string model = tbModelToAdd.Text.Trim();
                string number = tbNumberToAdd.Text.Trim();
                string vin = tbVINToAdd.Text.Trim();
                DateTime year = dtpYearToAdd.Value;
                string mileageText = tbMileageToAdd.Text.Trim();

                if (ValidateCarInput(brand, model, number, vin, year, mileageText, out int mileage))
                {
                    carsRepository.CreateCar(brand, model, number, vin, year, mileage);
                    UpdateCars();
                    mainForm.UpadateAll();

                    tbBrandToAdd.Clear();
                    tbModelToAdd.Clear();
                    tbNumberToAdd.Clear();
                    tbVINToAdd.Clear();
                    dtpYearToAdd.Value = DateTime.Now;
                    tbMileageToAdd.Clear();
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

        private void bntEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count == 1)
                {
                    int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["id"].Value.ToString());

                    string brand = tbBrandToEdit.Text.Trim();
                    string model = tbModelToEdit.Text.Trim();
                    string number = tbNumberToEdit.Text.Trim();
                    string vin = tbVINToEdit.Text.Trim();
                    DateTime year = dtpYearToEdit.Value;
                    string mileageText = tbMileageToEdit.Text.Trim();

                    if (ValidateCarInput(brand, model, number, vin, year, mileageText, out int mileage))
                    {
                        carsRepository.UpdateCar(carId, brand, model, number, vin, year, mileage);
                        UpdateCars();
                        mainForm.UpadateAll();
                    }
                }
                else if (dgvCars.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для редактирования");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один автомобиль для редактирования");
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

        private void btnDeleteClientFromCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count == 1)
                {
                    int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);

                    if (dgvClients.SelectedRows.Count == 1)
                    {
                        int ownershipId = Convert.ToInt32(dgvClients.CurrentRow.Cells["OwnershipId"].Value);
                        ownershipRepository.DeleteOwnership(ownershipId);
                        dgvClients.Rows.RemoveAt(dgvClients.SelectedRows[0].Index);
                        mainForm.UpadateAll();
                    }
                    else if (dgvClients.SelectedRows.Count == 0)
                    {
                        ErrorHandler.ShowWarningMessage("Выберите клиента для открепления");
                    }
                    else
                    {
                        ErrorHandler.ShowWarningMessage("Выберите только одного клиента для открепления");
                    }
                }
                else if (dgvCars.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для открепления клиента");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один автомобиль для открепления клиента");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    ErrorHandler.ShowErrorMessage("Невозможно отвязать клиента, так как по нему и выбранному автомобилю есть заказ");
                }
                else
                {
                    ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnOpenAddClientForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count == 1)
                {
                    AddClientToCarForm addClientToCarForm = new AddClientToCarForm();
                    if (addClientToCarForm.ShowDialog() == DialogResult.OK)
                    {
                        int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
                        int clientId = addClientToCarForm.GetClientId();

                        ownershipRepository.CreateOwnership(carId, clientId);
                        dgvClients.DataSource = clientsRepository.GetClientsByCarId(carId);
                        mainForm.UpadateAll();
                    }
                }
                else if (dgvCars.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для прикрепления клиента");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один автомобиль для прикрепления клиента");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ErrorHandler.ShowErrorMessage("Этот клиент уже привязан");
                }
                else
                {
                    ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCars.SelectedRows.Count == 1)
                {
                    int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
                    carsRepository.DeleteCar(carId);
                    dgvCars.Rows.RemoveAt(dgvCars.SelectedRows[0].Index);
                    mainForm.UpadateAll();
                }
                else if (dgvCars.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите автомобиль для удаления");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только один автомобиль для удаления");
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
    }
}
