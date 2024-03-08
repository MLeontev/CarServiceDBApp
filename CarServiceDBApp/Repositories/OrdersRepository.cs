using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Configuration;
using System.Data;

namespace CarServiceDBApp.Repositories
{
    public class OrdersRepository
    {
        private string connectionString;

        public OrdersRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetAllOrders()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT 
                                    Orders.id AS OrderId,
                                    Ownership.id AS OwnershipId,
                                    Clients.id AS ClientId,
                                    Cars.id AS CarId,
                                    CONCAT(Clients.surname, ' ', Clients.name, ' ', IFNULL(Clients.patronymic, '')) AS ClientFullName,
                                    CONCAT(Cars.brand, ' ', Cars.model, ' ', Cars.registration_number) AS CarFullName,
                                    Orders.appointment_date AS AppointmentDate,
                                    Orders.completion_date AS CompletionDate,
                                    CONCAT(SUM(Services.price), ' руб.') AS Sum,
                                    Order_status.Id AS StatusId,
                                    Order_status.Name AS StatusName
                                FROM 
                                    Orders
                                LEFT JOIN 
                                    Ownership ON Orders.ownership_id = Ownership.id
                                LEFT JOIN 
                                    Clients ON Ownership.client_id = Clients.id
                                LEFT JOIN 
                                    Cars ON Ownership.car_id = Cars.id
                                LEFT JOIN 
                                    Order_details ON Orders.id = Order_details.order_id
                                LEFT JOIN 
                                    Services ON Order_details.service_id = Services.id
                                LEFT JOIN 
                                    Order_status ON Orders.status_id = Order_status.id
                                GROUP BY 
                                    Orders.id, 
                                    Ownership.id, 
                                    Clients.id, 
                                    Cars.id,
                                    ClientFullName,
                                    CarFullName,
                                    AppointmentDate,
                                    CompletionDate,
                                    Order_status.id,
                                    Order_status.Name
                                ORDER BY 
                                    Orders.appointment_date DESC
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

        public void DeleteOrderById(int orderId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Orders WHERE id = @orderIdToDelete";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderIdToDelete", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateOrder(int ownershipId, DateTime date, int workerId)
        {
            int orderId = -1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Orders (ownership_id, status_id, appointment_date, completion_date) 
                                 VALUES (@ownershipId, 1, @date, NULL);
                                 SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ownershipId", ownershipId);
                        command.Parameters.AddWithValue("@date", date);
                        orderId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
                orderDetailsRepository.CreateOrderDetail(orderId, workerId);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Такой заказ уже создан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла неопознанная ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateOrder(int orderId, int ownershipId, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Orders 
                                     SET ownership_id = @ownershipId, 
                                         appointment_date = @date
                                     WHERE id = @orderId;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ownershipId", ownershipId);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@orderId", orderId);
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

        public void UpdateStatus(int orderId, int statusId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Orders 
                                     SET status_id = @statusId
                                     WHERE id = @orderId;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@statusId", statusId);
                        command.Parameters.AddWithValue("@orderId", orderId);
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

        public void UpdateCompletionDate(int orderId, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Orders 
                                     SET completion_date = @completion_date
                                     WHERE id = @orderId;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@completion_date", date);
                        command.Parameters.AddWithValue("@orderId", orderId);
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
