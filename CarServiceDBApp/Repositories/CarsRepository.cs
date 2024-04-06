using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class CarsRepository
    {
        private string connectionString;

        public CarsRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetAllCars()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Cars";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetCar(int id)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Cars WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetCarNamesByClientId(int clientId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT 
                                    Cars.id AS CarId,
                                    CONCAT(Cars.brand, ' ', Cars.model, ' ', Cars.registration_number) AS CarFullName
                                FROM Ownership
                                JOIN Cars ON Ownership.car_id = Cars.id
                                WHERE Ownership.client_id = @clientId;
                               ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientId", clientId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetCarsByClientId(int clientId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Ownership.id AS OwnershipId,
                                    Cars.id AS CarId,
                                    Cars.brand AS CarBrand,
                                    Cars.model AS CarModel,
                                    Cars.registration_number AS CarNumber,
                                    Cars.VIN AS CarVIN,
                                    Cars.year AS CarYear,
                                    Cars.mileage AS CarMileage
                                FROM Ownership
                                JOIN Cars ON Ownership.car_id = Cars.id
                                WHERE Ownership.client_id = @clientId;
                               ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientId", clientId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public void CreateCar(string brand, string model, string number, string vin, DateTime year, int mileage)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Cars values (0, @brand, @model, @number, @vin, @year, @mileage)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@vin", vin);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@mileage", mileage);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCar(int id, string brand, string model, string number, string vin, DateTime year, int mileage)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Cars set
                                    brand = @brand,
                                    model = @model,
                                    registration_number = @number,
                                    VIN = @vin,
                                    year = @year,
                                    mileage = @mileage
                                WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@vin", vin);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@mileage", mileage);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Cars WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
