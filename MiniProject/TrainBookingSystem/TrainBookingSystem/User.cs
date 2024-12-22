using System;
using System.Data;
using System.Data.SqlClient;

namespace TrainBookingSystem
{
    public class User : Trains
    {
        protected new string connectionString = "Server=ICS-LT-D244D6CY;Database=MiniProject;Trusted_Connection=True;";
        // Book a ticket
        public void BookTicket()
        {
            ShowAllTrains();

            Console.Write("Enter Train ID: ");
            int trainID = Convert.ToInt32(Console.ReadLine());

            // Check if the train exists
            if (!CheckTrainAvailability(trainID))
            {
                Console.WriteLine("Train not available. Please try again.");
                return;
            }

            Console.WriteLine("Available Classes and Berths:");
            ShowTrainClasses(trainID);

            Console.Write("Enter the Class you want to book (1st, 2nd, Sleeper): ");
            string ticketClass = Console.ReadLine();


            Console.Write("Enter the number of berths you want to book (User can select only 1 berth at a time): ");
            int requiredBerths = Convert.ToInt32(Console.ReadLine());

            // Check berth availability for the selected class
            if (!CheckBerthAvailability(trainID, ticketClass, requiredBerths))
            {
                Console.WriteLine("There are 2 reasons for this error:\n1. Selected class is not available in the train.\n2. Not enough berths available in the selected class.\nPlease try again.");
                return;
            }

            Console.Write("Enter Booking ID: ");
            int bookingID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your UserName: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Your Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Enter Your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your Source: ");
            string source = Console.ReadLine();

            Console.Write("Enter Your Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Your Booking Date (YYYY-MM-DD): ");
            string bookingDate = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("BookTicket", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    cmd.Parameters.AddWithValue("@TrainID", trainID);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Class", ticketClass);
                    cmd.Parameters.AddWithValue("@Berths", requiredBerths);
                    cmd.Parameters.AddWithValue("@Source", source);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@BookingDate", bookingDate);

                    SqlParameter statusParam = new SqlParameter("@Status", SqlDbType.VarChar, 30)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(statusParam);

                    cmd.ExecuteNonQuery();

                    string status = statusParam.Value.ToString();
                    Console.WriteLine(status == "Booked" ? "Ticket booked successfully." : $"Ticket not booked. Reason: {status}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        // Check train availability
        private bool CheckTrainAvailability(int trainID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Trains WHERE TrainID = @TrainID", con);
                    cmd.Parameters.AddWithValue("@TrainID", trainID);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while checking train availability: {ex.Message}");
                    return false;
                }
            }
        }

        // Show available classes and berths
        private void ShowTrainClasses(int trainID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowTrainClasses", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@TrainID", trainID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Class | Total Berths | Available Berths");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Class"]} | {reader["TotalBerths"]} | {reader["AvailableBerths"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while showing train classes: {ex.Message}");
                }
            }
        }

        // Check berth availability
        private bool CheckBerthAvailability(int trainID, string ticketClass, int requiredBerths)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CheckBerthAvailability", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@TrainID", trainID);
                    cmd.Parameters.AddWithValue("@Class", ticketClass);
                    cmd.Parameters.AddWithValue("@RequiredBerths", requiredBerths);

                    SqlParameter isAvailable = new SqlParameter("@IsAvailable", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isAvailable);

                    cmd.ExecuteNonQuery();
                    return Convert.ToBoolean(isAvailable.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while checking berth availability: {ex.Message}");
                    return false;
                }
            }
        }

        // Cancel a ticket
        public void CancelTicket()
        {
            ShowBookings();

            Console.Write("Enter Booking ID to Cancel: ");
            int bookingID = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CancelTicket", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Ticket cancelled successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        // Show all bookings
        public void ShowBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ShowBookings", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("BookingID | UserName | TrainName | Class | Source | Destination | Status");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["BookingID"]} | {reader["UserName"]} | {reader["TrainName"]} | {reader["Class"]} | {reader["Source"]} | {reader["Destination"]} | {reader["Status"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while showing bookings: {ex.Message}");
                }
            }
        }
    }
}
