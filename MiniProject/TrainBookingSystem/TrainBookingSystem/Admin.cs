using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrainBookingSystem
{
    public class Admin : Trains
    {
        // Add a train
        public void AddTrain()
        {
            Console.Write("Enter Train ID: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter Class (1st, 2nd, Sleeper): ");
            string trainClass = Console.ReadLine();

            Console.Write("Enter Total Berths: ");
            int totalBerths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Total AvailableBerths: ");
            int AvailableBerths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Source: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Status: ");
            String Status = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainID", trainID);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Class", trainClass);
                cmd.Parameters.AddWithValue("@TotalBerths", totalBerths);
                cmd.Parameters.AddWithValue("@AvailableBerths", AvailableBerths);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Status", Status);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Train added successfully.");
            }
        }

        // Modify a train
        public void ModifyTrain()
        {
            Console.Write("Enter Train ID to Modify: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter New Class: ");
            string trainClass = Console.ReadLine();

            Console.Write("Enter New Total Berths: ");
            int totalBerths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Available Berths: ");
            int availableBerths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Source: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();


            Console.Write("Enter status :");
            string status = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ModifyTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainID", trainID);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Class", trainClass);
                cmd.Parameters.AddWithValue("@TotalBerths", totalBerths);
                cmd.Parameters.AddWithValue("@AvailableBerths", availableBerths);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@status", status);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Train modified successfully.");

                ShowAllTrains();
            }
        }

        // Soft delete a train
        public void DeleteTrain()
        {
            Console.Write("Enter Train ID to Delete: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainID", trainID);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train deleted successfully.");
            }
        }
    }
}