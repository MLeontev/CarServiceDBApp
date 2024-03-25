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

            try
            {
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
                            Clients
                        ORDER BY 
                            Clients.surname
                       ";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла неопознанная ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public DataTable GetClientsByCarId(int id)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT
                                    Ownership.id AS OwnershipId,
                                    Clients.id AS ClientId,
                                    CONCAT(Clients.surname, ' ', Clients.name, ' ', IFNULL(Clients.patronymic, '')) AS ClientFullName,
                                    Clients.birth_date,
                                    Clients.phone_number,
                                    Clients.email
                                  FROM Ownership
                                  JOIN Clients ON Ownership.client_id = Clients.id
                                  WHERE Ownership.car_id = @id
                                  ORDER BY 
                                     Clients.surname";

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

        public void CreateClient(string surname, string name, string patronymic, DateTime birthDate, string number, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Clients values (0, @surname, @name, @patronymic, @birthDate, @number, @email)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@birthDate", birthDate);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClient(int id, string surname, string name, string patronymic, DateTime birthDate, string number, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Clients SET surname = @surname, name = @name, patronymic = @patronymic, birth_date = @birthDate, phone_number = @number, email = @email WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@birthDate", birthDate);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClient(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Clients WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
