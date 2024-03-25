using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace CarServiceDBApp.Forms
{
    public partial class ServicesForm : Form
    {
        ServicesRepository servicesRepository;
        private MainForm mainForm;

        public ServicesForm(MainForm mainForm)
        {
            InitializeComponent();

            servicesRepository = new();
            this.mainForm = mainForm;

            UpdateServices();
        }

        private void UpdateServices()
        {
            try
            {
                dgvServices.DataSource = servicesRepository.GetAllServicesWithoutDescription();
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
            UpdateServices();
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvServices.SelectedRows.Count >= 1)
                {
                    int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceId"].Value);
                    string description = servicesRepository.GetDescriptionByServiceId(serviceId);
                    tbDescription.Text = description;

                    tbDescriptionToEdit.Text = description;
                    tbNameToEdit.Text = dgvServices.CurrentRow.Cells["ServiceName"].Value.ToString();
                    tbPriceToEdit.Text = dgvServices.CurrentRow.Cells["Price"].Value.ToString();
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

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvServices.SelectedRows.Count == 1)
                {
                    int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceId"].Value);
                    servicesRepository.DeleteService(serviceId);
                    dgvServices.Rows.RemoveAt(dgvServices.SelectedRows[0].Index);

                    tbNameToEdit.Clear();
                    tbPriceToEdit.Clear();
                    tbDescriptionToEdit.Clear();
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите одну услугу для редактирования");
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

        private bool ValidateServiceInput(string name, string priceText, out decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText))
            {
                ErrorHandler.ShowErrorMessage("Введите название и цену");
                price = 0;
                return false;
            }

            if (name.Length > 50)
            {
                ErrorHandler.ShowErrorMessage("Название услуги не должно быть длиннее 50 символов");
                price = 0;
                return false;
            }

            if (!decimal.TryParse(priceText, NumberStyles.Currency, CultureInfo.CurrentCulture, out price) || price < 0)
            {
                ErrorHandler.ShowErrorMessage("Введите корректное значение цены");
                return false;
            }

            return true;
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbNameToAdd.Text.Trim();
                string description = tbDescriptionToAdd.Text.Trim();
                string priceText = tbPriceToAdd.Text.Trim();

                if (ValidateServiceInput(name, priceText, out decimal price))
                {
                    servicesRepository.CreateService(name, price, description);
                    UpdateServices();

                    tbNameToAdd.Clear();
                    tbPriceToAdd.Clear();
                    tbDescriptionToAdd.Clear();
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

        private void btnEditService_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvServices.SelectedRows.Count == 1)
                {
                    string name = tbNameToEdit.Text.Trim();
                    string description = tbDescriptionToEdit.Text.Trim();
                    string priceText = tbPriceToEdit.Text.Trim();

                    if (ValidateServiceInput(name, priceText, out decimal price))
                    {
                        int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceId"].Value);
                        servicesRepository.UpdateService(serviceId, name, price, description);
                        UpdateServices();
                    }
                }
                else
                {
                    ErrorHandler.ShowWarningMessage("Выберите одну услугу для редактирования");
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
        private void HandleDatabaseError(MySqlException ex)
        {
            if (ex.Number == 1451)
            {
                ErrorHandler.ShowErrorMessage("Нельзя удалить услугу. Она содержится в заказах.");
            }
            else if (ex.Number == 1062)
            {
                ErrorHandler.ShowErrorMessage("Такая услуга уже создана!");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("Ошибка при работе с базой данных: " + ex.Message);
            }
        }
    }
}
