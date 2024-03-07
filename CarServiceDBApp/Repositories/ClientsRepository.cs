using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class ClientsRepository
    {
        private string connectionString;

        public ClientsRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetClients()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Clients.id AS ClientId,
                                    CONCAT(Clients.surname, ' ', Clients.name, ' ', IFNULL(Clients.patronymic, '')) AS ClientFullName,
                                    Clients.birth_date AS ClientBirthDate,
                                    Clients.phone_number AS ClientPhoneNumber,
                                    Clients.email AS ClientEmail
                                FROM 
                                    Clients;
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
