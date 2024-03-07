using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class WorkersRepository
    {
        private string connectionString;

        public WorkersRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetReceptionists()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Workers.id AS WorkerId,
                                    CONCAT(Workers.surname, ' ', Workers.name, ' ', IFNULL(Workers.patronymic, '')) AS WorkerFullName,
                                    Workers.phone_number AS PhoneNumber
                                FROM 
                                    Workers
                                WHERE Workers.position_id = 23796
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

        public DataTable GetСarMechanics()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Workers.id AS WorkerId,
                                    CONCAT(Workers.surname, ' ', Workers.name, ' ', IFNULL(Workers.patronymic, '')) AS WorkerFullName,
                                    Workers.phone_number AS PhoneNumber
                                FROM 
                                    Workers
                                WHERE Workers.position_id = 18511
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
    }
}
