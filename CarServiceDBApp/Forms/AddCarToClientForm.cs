using CarServiceDBApp.Helpers;
using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;

namespace CarServiceDBApp.Forms
{
    public partial class AddCarToClientForm : Form
    {
        CarsRepository carsRepository;

        public AddCarToClientForm()
        {
            InitializeComponent();
            carsRepository = new CarsRepository();
            LoadCars();
        }

        public int GetCarId()
        {
            return Convert.ToInt32(dgvCars.SelectedRows[0].Cells["id"].Value);
        }

        private void LoadCars()
        {
            try
            {
                dgvCars.DataSource = carsRepository.GetAllCars();
            }
            catch (MySqlException)
            {
                ErrorHandler.ShowErrorMessage("Не удалось загрузить автомобили");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleUnknownError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 1)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (dgvCars.SelectedRows.Count == 0)
            {
                ErrorHandler.ShowWarningMessage("Выберите автомобиль");
            }
            else
            {
                ErrorHandler.ShowWarningMessage("Выберите только один автомобиль");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
