using CarServiceDBApp.Repositories;
using CarServiceDBApp.Helpers;
using MySql.Data.MySqlClient;

namespace CarServiceDBApp.Forms
{
    public partial class ClientsForm : Form
    {
        MainForm mainForm;
        ClientsRepository clientsRepository;
        CarsRepository carsRepository;
        HistoryForm historyForm;
        OrdersRepository ordersRepository;
        OwnershipRepository ownershipRepository;

        public ClientsForm(MainForm mainForm)
        {
            InitializeComponent();

            clientsRepository = new ClientsRepository();
            carsRepository = new CarsRepository();
            ordersRepository = new OrdersRepository();
            ownershipRepository = new OwnershipRepository();
            this.mainForm = mainForm;

            UpdateClients();
        }

        private void HandleDatabaseError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                ErrorHandler.ShowErrorMessage("Клиент с такими данными уже добавлен");
            }
            else if (ex.Number == 1451)
            {
                ErrorHandler.ShowErrorMessage("Невозможно удалить клиента, так как у него есть заказ");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
            }
        }

        private void UpdateClients()
        {
            try
            {
                dgvClients.DataSource = clientsRepository.GetClients();
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
            UpdateClients();
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.SelectedRows.Count >= 1)
                {
                    int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value.ToString());
                    dgvCars.DataSource = carsRepository.GetCarsByClientId(clientId);

                    string fullName = dgvClients.CurrentRow.Cells["ClientFullName"].Value.ToString();
                    string[] fio = fullName.Split(' ');
                    tbSurnameToEdit.Text = fio.Length > 0 ? fio[0] : "";
                    tbNameToEdit.Text = fio.Length > 1 ? fio[1] : "";
                    tbPatronymicToEdit.Text = fio.Length > 2 ? fio[2] : "";
                    dtpBirthDateToEdit.Value = (DateTime)dgvClients.CurrentRow.Cells["ClientBirthDate"].Value;
                    tbNumberToEdit.Text = dgvClients.CurrentRow.Cells["ClientPhoneNumber"].Value.ToString();
                    tbEmailToEdit.Text = dgvClients.CurrentRow.Cells["ClientEmail"].Value.ToString();
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
                if (dgvClients.SelectedRows.Count == 1)
                {
                    int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value.ToString());
                    historyForm = new HistoryForm();
                    historyForm.dgvOrders.DataSource = ordersRepository.GetAllOrdersByClientId(clientId);
                    historyForm.ShowDialog();
                }
                else if (dgvClients.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для просмотра заказов");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного клиента для просмотра заказов");
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

        private bool ValidateClientInput(string surname, string name, string patronymic, DateTime birthDate, string number, string email)
        {
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(number) || string.IsNullOrEmpty(email))
            {
                ErrorHandler.ShowErrorMessage("Необходимо заполнить все обязательные поля (Фамилия, Имя, Дата рождения, Номер телефона, Email)");
                return false;
            }

            if (surname.Length > 25)
            {
                ErrorHandler.ShowErrorMessage("Фамилия не должна быть длиннее 25 символов");
                return false;
            }

            if (name.Length > 25)
            {
                ErrorHandler.ShowErrorMessage("Имя не должно быть длиннее 25 символов");
                return false;
            }

            if (patronymic.Length > 25)
            {
                ErrorHandler.ShowErrorMessage("Отчество не должно быть длиннее 25 символов");
                return false;
            }

            int age = DateTime.Today.Year - birthDate.Year - 1
                + ((DateTime.Today.Month > birthDate.Month
                || DateTime.Today.Month == birthDate.Month && DateTime.Today.Day >= birthDate.Day) ? 1 : 0);
            if (age < 18)
            {
                ErrorHandler.ShowErrorMessage("Клиент должен быть совершеннолетним");
                return false;
            }

            if (number.Length != 12)
            {
                ErrorHandler.ShowErrorMessage("Введите номер телефона полностью");
                return false;
            }

            if (!email.Contains('@'))
            {
                ErrorHandler.ShowErrorMessage("Некорректный адрес электронной почты");
                return false;
            }

            return true;
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            try
            {
                string surname = tbSurnameToAdd.Text.Trim();
                string name = tbNameToAdd.Text.Trim();
                string patronymic = tbPatronymicToAdd.Text.Trim();
                DateTime birthDate = dtpBirthDateToAdd.Value;
                string number = new string(tbNumberToAdd.Text.Where(c => char.IsDigit(c) || c == '+').ToArray());
                string email = tbEmailToAdd.Text.Trim();

                if (ValidateClientInput(surname, name, patronymic, birthDate, number, email))
                {
                    clientsRepository.CreateClient(surname, name, patronymic, birthDate, number, email);
                    UpdateClients();
                    mainForm.UpadateAll();

                    tbSurnameToAdd.Clear();
                    tbNameToAdd.Clear();
                    tbPatronymicToAdd.Clear();
                    tbNumberToAdd.Clear();
                    tbEmailToAdd.Clear();
                    dtpBirthDateToAdd.Value = DateTime.Now;
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

        private void bntEditClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.SelectedRows.Count == 1)
                {
                    int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value);

                    string surname = tbSurnameToEdit.Text.Trim();
                    string name = tbNameToEdit.Text.Trim();
                    string patronymic = tbPatronymicToEdit.Text.Trim();
                    DateTime birthDate = dtpBirthDateToEdit.Value;
                    string number = new string(tbNumberToEdit.Text.Where(c => char.IsDigit(c) || c == '+').ToArray());
                    string email = tbEmailToEdit.Text.Trim();

                    if (ValidateClientInput(surname, name, patronymic, birthDate, number, email))
                    {
                        clientsRepository.UpdateClient(clientId, surname, name, patronymic, birthDate, number, email);
                        UpdateClients();
                        mainForm.UpadateAll();
                    }
                }
                else if (dgvClients.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для редактирования");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного клиента для редактирования");
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

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.SelectedRows.Count == 1)
                {
                    int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value);
                    clientsRepository.DeleteClient(clientId);
                    dgvClients.Rows.RemoveAt(dgvClients.SelectedRows[0].Index);
                    mainForm.UpadateAll();
                }
                else if (dgvClients.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для удаления");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного клиента для удаления");
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

        private void btnDeleteCarFromClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.SelectedRows.Count == 1)
                {
                    int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value);

                    if (dgvCars.SelectedRows.Count == 1)
                    {
                        int ownershipId = Convert.ToInt32(dgvCars.CurrentRow.Cells["OwnershipId"].Value);
                        ownershipRepository.DeleteOwnership(ownershipId);
                        dgvCars.Rows.RemoveAt(dgvCars.SelectedRows[0].Index);
                        mainForm.UpadateAll();
                    }
                    else if (dgvCars.SelectedRows.Count == 0)
                    {
                        ErrorHandler.ShowWarningMessage("Выберите автомобиль для открепления");
                    }
                    else
                    {
                        ErrorHandler.ShowWarningMessage("Выберите только один автомобиль для открепления");
                    }
                }
                else if (dgvClients.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для открепления автомобиля");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного клиента для открепления автомобиля");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    ErrorHandler.ShowErrorMessage("Невозможно отвязать автомобиль, так как по нему и выбранному клиенту есть заказ");
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

        private void btnOpenAddCarToClientForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.SelectedRows.Count == 1)
                {
                    AddCarToClientForm addCarToClientForm = new AddCarToClientForm();
                    if (addCarToClientForm.ShowDialog() == DialogResult.OK)
                    {
                        int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientId"].Value);
                        int carId = addCarToClientForm.GetCarId();

                        ownershipRepository.CreateOwnership(carId, clientId);
                        dgvCars.DataSource = carsRepository.GetCarsByClientId(clientId);
                        mainForm.UpadateAll();
                    }
                }
                else if (dgvClients.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите клиента для прикрепления автомобиля");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного клиента для прикрепления автомобиля");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    ErrorHandler.ShowErrorMessage("Этот автомобиль уже привязан");
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
    }
}
