﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDBApp.Repositories
{
    public class OwnershipRepository
    {
        private string connectionString;

        public OwnershipRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CarService"].ToString();
        }

        public int GetOwnershipId(int clientId, int carId)
        {
            int ownershipId;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT id 
                                 FROM Ownership 
                                 WHERE client_id = @clientId AND car_id = @carId";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientId", clientId);
                    command.Parameters.AddWithValue("@carId", carId);
                    ownershipId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return ownershipId;
        }
    }
}
