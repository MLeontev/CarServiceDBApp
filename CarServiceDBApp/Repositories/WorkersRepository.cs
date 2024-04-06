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

        public DataTable GetAllWorkers()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Workers.id AS WorkerId,
                                    Workers.surname AS WorkerSurname,
                                    Workers.name AS WorkerName,
                                    Workers.patronymic AS WorkerPatronymic,
                                    Workers.phone_number AS WorkerPhoneNumber,
                                    Positions.name AS WorkerPosition,
                                    Positions.id AS PositionId,
                                    Positions.salary AS WorkerSalary
                                FROM 
                                    Workers
                                JOIN Positions ON Workers.position_id = Positions.id;
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

        public void DeleteWorker(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Workers WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CreateWorker(int id, int positionId, string surname, string name, string patronymic, string number, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Workers values (@id, @positionId, @surname, @name, @patronymic, @number, @password)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@positionId", positionId);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWorker(int id, int positionId, string surname, string name, string patronymic, string number)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Workers
                                SET position_id = @positionId,
                                    surname = @surname,
                                    name = @name,
                                    patronymic = @patronymic,
                                    phone_number = @number
                                WHERE id = @id;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@positionId", positionId);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@number", number);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWorkerPassword(int id, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Workers
                                SET password = @password
                                WHERE id = @id;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int CountDirectors()
        {
            int k = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) FROM Workers WHERE position_id = 21495";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    k = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return k;
        }
    }
}
