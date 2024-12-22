using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrainBookingSystem
{
    public class Trains
    {
        protected string connectionString = "Server=ICS-LT-D244D6CY;Database=MiniProject;Trusted_Connection=True;";

        // Function to show all active trains
        public void ShowAllTrains()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Trains WHERE Status = 'Active'" ,con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("TrainID | TrainName | Class | TotalBerths | AvailableBerths | Source | Destination | Status ");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TrainID"]} | {reader["TrainName"]} | {reader["Class"]} | {reader["TotalBerths"]} | {reader["AvailableBerths"]} | {reader["Source"]} | {reader["Destination"]} | {reader["Status"]}");
                }
            }
        }
    }
}