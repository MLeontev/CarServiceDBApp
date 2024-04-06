using MySql.Data.MySqlClient;
using System.Configuration;

namespace CarServiceDBApp.Authorization
{
    public class User
    {
        public static int Id { get; set; }

        public static int PositionId { get; set; }

        public bool Login(string phone_number, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string hashed = PasswordGenerator.HashPassword(password);

                string query = @"SELECT * FROM Workers WHERE phone_number = @phone_number AND password = @password LIMIT 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@phone_number", phone_number);
                    command.Parameters.AddWithValue("@password", hashed);

                    using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            mySqlDataReader.Read();

                            Id = (int)mySqlDataReader["id"];
                            PositionId = (int)mySqlDataReader["position_id"];

                            return true;
                        }
                        return false;
                    }
                }
            }
        }
    }
}
