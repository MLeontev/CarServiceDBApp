using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDBApp.Repositories
{
    public class StatusRepository
    {
        private string connectionString;

        public StatusRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public string GetStatusById(int id)
        {
            string status = "";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                                SELECT
                                    Order_status.name AS StatusName
                                FROM 
                                    Order_status
                                WHERE Order_status.id = @id;
                               ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            status = Convert.ToString(result);
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

            return status;
        }
    }
}
