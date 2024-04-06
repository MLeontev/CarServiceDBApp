using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class ServicesRepository
    {
        private string connectionString;

        public ServicesRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public ServicesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetAllServices()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Services.id AS ServiceId,
                                    Services.name AS ServiceName,
                                    Services.price AS Price
                                FROM 
                                    Services
                               ";

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

        public DataTable GetAllServicesWithoutReception()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Services.id AS ServiceId,
                                    Services.name AS ServiceName,
                                    Services.price AS Price
                                FROM 
                                    Services
                                WHERE id != 1
                               ";

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

        public string GetDescriptionByServiceId(int id)
        {
            string descrpition = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT description FROM Services WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        descrpition = command.ExecuteScalar().ToString();
                    }
                }
            }
            return descrpition;
        }

        public void DeleteService(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Services WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateService(string name, decimal price, string description)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Services values (0, @name, @description, @price)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", price);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateService(int id, string name, decimal price, string description)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Services SET name = @name, description = @description, price = @price WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
