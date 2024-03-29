using CarServiceDBApp.Repositories;
using MySql.Data.MySqlClient;
using System.Data;

namespace TestProject
{
    public class Tests
    {
        private string connectionString = "server=localhost; database=carservicedbtest; port=3306; user=root; password=123ml";

        [SetUp]
        public void Setup()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Services (id, name, description, price) VALUES
                    (1, 'Прием', 'Описание1', 1000.0),
                    (2, 'Диагностика', 'Описание2', 1500.0),
                    (3, 'Шиномонтаж', 'Описание3', 2000.0)";
                    command.ExecuteNonQuery();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Services";
                    command.ExecuteNonQuery();
                }
            }
        }

        [Test]
        public void TestGetAllServices()
        {
            ServicesRepository servicesRepository = new ServicesRepository(connectionString);

            DataTable result = servicesRepository.GetAllServices();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Rows.Count, Is.EqualTo(3));

                Assert.That(result.Rows[0]["ServiceName"], Is.EqualTo("Прием"));
                Assert.That(result.Rows[0]["Price"], Is.EqualTo((decimal)1000.0));

                Assert.That(result.Rows[1]["ServiceName"], Is.EqualTo("Диагностика"));
                Assert.That(result.Rows[1]["Price"], Is.EqualTo((decimal)1500.0));

                Assert.That(result.Rows[2]["ServiceName"], Is.EqualTo("Шиномонтаж"));
                Assert.That(result.Rows[2]["Price"], Is.EqualTo((decimal)2000.0));
            });
        }
    }
}