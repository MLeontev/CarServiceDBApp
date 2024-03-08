using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class OrderDetailsRepository
    {
        private string connectionString;

        public OrderDetailsRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetDetailsByOrderId(int orderId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT
                                    Order_details.Id AS OrderDetailsId,
                                    Services.id AS ServiceId,
                                    Services.name AS ServiceName,
                                    Services.price AS Price,
                                    Order_details.employee_id AS WorkerId,
                                    CONCAT(Workers.surname, ' ', Workers.name, ' ',  IFNULL(Workers.patronymic, '')) AS WorkerFullName,
                                    CASE 
                                        WHEN is_completed = TRUE THEN 'Выполнена'
                                        ELSE 'Не выполнена'
                                    END AS Status
                                FROM 
                                    Order_details
                                INNER JOIN 
                                    Services ON Order_details.service_id = Services.id
                                INNER JOIN 
                                    Workers ON Order_details.employee_id = Workers.id
                                WHERE 
                                    Order_details.order_id = @orderId;
                            ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderId", orderId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public void DeleteServiceFromOrder(int orderDetailsId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Order_details WHERE id = @orderDetailsId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderDetailsId", orderDetailsId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CompleteService(int orderDetailsId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Order_details SET is_completed = TRUE WHERE id = @orderDetailsId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderDetailsId", orderDetailsId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddServiceToOrder(int OrderId, int ServiceId, int WorkerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Order_details VALUES (0, @OrderId, @ServiceId, @WorkerId,FALSE)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", OrderId);
                    command.Parameters.AddWithValue("@ServiceId", ServiceId);
                    command.Parameters.AddWithValue("@WorkerId", WorkerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditWorkerInOrderDetails(int orderDetailsId, int WorkerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Order_details SET Order_details.employee_id = @WorkerId WHERE id = @orderDetailsId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderDetailsId", orderDetailsId);
                    command.Parameters.AddWithValue("@WorkerId", WorkerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateOrderDetail(int orderId, int employeeId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Order_details (order_id, service_id, employee_id, is_completed) 
                                     VALUES (@orderId, 1, @employeeId, FALSE);";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@orderId", orderId);
                        command.Parameters.AddWithValue("@employeeId", employeeId);
                        command.ExecuteNonQuery();
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
        }
    }
}
