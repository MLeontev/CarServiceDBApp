using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDBApp.Repositories
{
    public class CarsRepository
    {
        private string connectionString;

        public CarsRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetCarsByClientId(int clientId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT 
                                    Cars.Id AS CarId,
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
    }
}
