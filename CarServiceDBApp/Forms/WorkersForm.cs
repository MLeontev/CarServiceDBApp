using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;
using System.Data;

namespace CarServiceDBApp.Forms
{
    public partial class WorkersForm : Form
    {
        MainForm mainForm;
        WorkersRepository workersRepository;
        PositionsRepository positionsRepository;

        public WorkersForm(MainForm mainForm)
        {
            InitializeComponent();
            workersRepository = new WorkersRepository();
            positionsRepository = new PositionsRepository();
            UpdateWorkers();
            LoadPositionsToAdd();
            this.mainForm = mainForm;
        }

        private void UpdateWorkers()
        {
            try
            {
                dgvWorkers.DataSource = workersRepository.GetAllWorkers();
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

        private void HandleDatabaseError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                ErrorHandler.ShowErrorMessage("Сотрудник с такими данными уже добавлен");
            }
            else if (ex.Number == 1451)
            {
                ErrorHandler.ShowErrorMessage("Невозможно удалить сотрудника, так как у него есть работы");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWorkers.SelectedRows.Count == 1)
                {
                    int workerId = Convert.ToInt32(dgvWorkers.CurrentRow.Cells["WorkerId"].Value);
                    workersRepository.DeleteWorker(workerId);
                    dgvWorkers.Rows.RemoveAt(dgvWorkers.SelectedRows[0].Index);
                    mainForm.UpadateAll();
                }
                else if (dgvWorkers.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите сотрудника для удаления");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного сотрудника для удаления");
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

        private void LoadPositionsToAdd()
        {
            try
            {
                DataTable positionsDataTable = positionsRepository.GetPositions();
                cbPositionToAdd.DataSource = positionsDataTable;
                cbPositionToAdd.ValueMember = "PositionId";
                cbPositionToAdd.DisplayMember = "PositionName";
            }
            catch (MySqlException ex)
            {
                ErrorHandler.ShowErrorMessage("Не удалось загрузить должности");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void LoadPositionsToEdit()
        {
            try
            {
                DataTable positionsDataTable = positionsRepository.GetPositions();
                cbPositionToEdit.DataSource = positionsDataTable;
                cbPositionToEdit.ValueMember = "PositionId";
                cbPositionToEdit.DisplayMember = "PositionName";
                var posIdToSelect = Convert.ToInt32(dgvWorkers.CurrentRow.Cells["PositionId"].Value);
                cbPositionToEdit.SelectedValue = posIdToSelect;
            }
            catch (MySqlException ex)
            {
                ErrorHandler.ShowErrorMessage("Не удалось загрузить должности");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private bool ValidateWorkerInput(string id, string surname, string name, string patronymic, string number)
        {
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(number) || string.IsNullOrEmpty(id))
            {
                ErrorHandler.ShowErrorMessage("Необходимо заполнить все обязательные поля (Табельный номер, Фамилия, Имя, Номер телефона)");
                return false;
            }

            if (id.Length != 5)
            {
                ErrorHandler.ShowErrorMessage("Табельный номер должен содержать 5 символов");
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

            if (number.Length != 12)
            {
                ErrorHandler.ShowErrorMessage("Введите номер телефона полностью");
                return false;
            }

            return true;
        }

        private void btnCreateWorker_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbIdToAdd.Text.Trim();
                string surname = tbSurnameToAdd.Text.Trim();
                string name = tbNameToAdd.Text.Trim();
                string patronymic = tbPatronymicToAdd.Text.Trim();
                string number = new string(tbNumberToAdd.Text.Where(c => char.IsDigit(c) || c == '+').ToArray());

                if (cbPositionToAdd.SelectedItem != null)
                {
                    DataRowView drvWorker = (DataRowView)cbPositionToAdd.SelectedItem;
                    int positionId = Convert.ToInt32(drvWorker["PositionId"]);

                    if (ValidateWorkerInput(id, surname, name, patronymic, number))
                    {
                        int workerId = Convert.ToInt32(id);
                        workersRepository.CreateWorker(workerId, positionId, surname, name, patronymic, number);
                        UpdateWorkers();
                        mainForm.UpadateAll();

                        tbSurnameToAdd.Clear();
                        tbNameToAdd.Clear();
                        tbPatronymicToAdd.Clear();
                        tbNumberToAdd.Clear();
                    }
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите должность");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateWorkers();
        }

        private void bntEditWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWorkers.SelectedRows.Count == 1)
                {
                    string id = dgvWorkers.CurrentRow.Cells["WorkerId"].Value.ToString();
                    string surname = tbSurnameToEdit.Text.Trim();
                    string name = tbNameToEdit.Text.Trim();
                    string patronymic = tbPatronymicToEdit.Text.Trim();
                    string number = new string(tbNumberToEdit.Text.Where(c => char.IsDigit(c) || c == '+').ToArray());

                    if (cbPositionToEdit.SelectedItem != null)
                    {
                        DataRowView drvWorker = (DataRowView)cbPositionToEdit.SelectedItem;
                        int positionId = Convert.ToInt32(drvWorker["PositionId"]);

                        if (ValidateWorkerInput(id, surname, name, patronymic, number))
                        {
                            int workerId = Convert.ToInt32(id);
                            workersRepository.UpdateWorker(workerId, positionId, surname, name, patronymic, number);
                            UpdateWorkers();
                            mainForm.UpadateAll();
                        }
                    }
                    else
                    {
                        ErrorHandler.ShowWarningMessage("Выберите должность");
                    }
                }
                else if (dgvWorkers.SelectedRows.Count == 0)
                {
                    ErrorHandler.ShowWarningMessage("Выберите сотрудника для редактирования");
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите только одного сотрудника для редактирования");
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

        private void dgvWorkers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvWorkers.SelectedRows.Count >= 1)
                {
                    tbSurnameToEdit.Text = dgvWorkers.CurrentRow.Cells["WorkerSurname"].Value.ToString();
                    tbNameToEdit.Text = dgvWorkers.CurrentRow.Cells["WorkerName"].Value.ToString();
                    tbPatronymicToEdit.Text = dgvWorkers.CurrentRow.Cells["WorkerPatronymic"].Value.ToString();
                    tbNumberToEdit.Text = dgvWorkers.CurrentRow.Cells["WorkerPhoneNumber"].Value.ToString();
                    LoadPositionsToEdit();
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
