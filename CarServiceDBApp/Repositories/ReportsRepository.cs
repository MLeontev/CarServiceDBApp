using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDBApp.Repositories
{
    public class ReportsRepository
    {
        private string connectionString;

        public ReportsRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public DataTable GetMastersData(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT 
                                    Workers.id AS WorkerId,
                                    CONCAT(Workers.surname, ' ', Workers.name, ' ', Workers.patronymic) AS WorkerFullName,
                                    COUNT(Order_details.service_id) AS ServicesCount,
                                    SUM(Services.price) AS TotalSum
                                FROM 
                                    Workers
                                INNER JOIN 
                                    Order_details ON Workers.id = Order_details.employee_id
                                INNER JOIN 
                                    Orders ON Order_details.order_id = Orders.id
                                INNER JOIN 
                                    Services ON Order_details.service_id = Services.id
                                WHERE 
                                    Workers.position_id = 18511
                                    AND Orders.appointment_date >= @startDate
                                    AND Orders.appointment_date <= @endDate
                                    AND Order_details.is_completed = true
                                GROUP BY 
                                    WorkerId, WorkerFullName
                                ORDER BY WorkerFullName";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetServicesData(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT 
                                    Services.name AS Услуга,
                                    COUNT(Order_details.id) AS Количество_выполнений,
                                    SUM(Services.price) AS Выручка
                                FROM 
                                    Order_details
                                JOIN 
                                    Services ON Order_details.service_id = Services.id
                                JOIN 
                                    Orders ON Order_details.order_id = Orders.id
                                WHERE 
                                    Order_details.is_completed = TRUE
                                    AND Orders.appointment_date >= @startDate
                                    AND Orders.appointment_date <= @endDate
                                GROUP BY 
                                    Services.name;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetOrdersData(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT 
                                    Orders.id AS OrderId,
                                    CONCAT(Clients.surname, ' ', Clients.name, ' ', IFNULL(Clients.patronymic, '')) AS ClientFullName,
                                    Clients.phone_number,
                                    CONCAT(Cars.brand, ' ', Cars.model, ' ', Cars.registration_number) AS CarFullName,
                                    Orders.appointment_date AS AppointmentDate,
                                    Orders.completion_date AS CompletionDate,
                                    SUM(Services.price) AS Sum,
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
                                WHERE 
                                    Orders.appointment_date >= @startDate
                                    AND Orders.appointment_date <= @endDate
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
                                    Orders.appointment_date DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

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
