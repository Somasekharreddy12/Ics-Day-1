using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrainBookingSystem
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("----------Welcome to the Train Ticket Booking System!----------");

            while (true)
            {
                Console.WriteLine("Login as: \n1. Admin\n2. User\n3. Exit");
                int loginChoice = Convert.ToInt32(Console.ReadLine());

                if (loginChoice == 1)
                {
                    Console.Write("Enter Admin Password: ");
                    string adminPassword = Console.ReadLine();

                    if (adminPassword == "admin123")
                    {
                        Admin admin = new Admin();
                        Console.WriteLine("Welcome, -------Admin------!");
                        while (true)
                        {
                            Console.WriteLine("1. Add Train\n2. Modify Train\n3. Delete Train\n4. Show All Trains\n5. Logout");
                            int adminChoice = Convert.ToInt32(Console.ReadLine());

                            if (adminChoice == 1) admin.AddTrain();
                            else if (adminChoice == 2) admin.ModifyTrain();
                            else if (adminChoice == 3) admin.DeleteTrain();
                            else if (adminChoice == 4) admin.ShowAllTrains();
                            else break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Admin Password!");
                    }
                }
                else if (loginChoice == 2)
                {
                    Console.Write("Enter User Password: ");
                    string userPassword = Console.ReadLine();

                    if (userPassword == "user123")
                    {
                        User user = new User();
                        Console.WriteLine("Welcome, ----------User!--------");
                        while (true)
                        {
                            Console.WriteLine("1. Book Ticket\n2. Cancel Ticket\n3. Show All Trains\n4. Show Bookings\n5. Logout");
                            int userChoice = Convert.ToInt32(Console.ReadLine());

                            if (userChoice == 1) user.BookTicket();
                            else if (userChoice == 2) user.CancelTicket();
                            else if (userChoice == 3) user.ShowAllTrains();
                            else if (userChoice == 4) user.ShowBookings();
                            else break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid User Password!");
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Thank you for using the Train Booking System. Goodbye!");
            Console.ReadLine();
        }
    }
}
