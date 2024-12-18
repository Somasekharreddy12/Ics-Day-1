using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment6
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        static SqlConnection getConnection()
        {
            try
            {
                con = new SqlConnection("Data Source=ICS-LT-D244D6CY;Initial Catalog=SQL Code challenge;Integrated Security=true;");
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
                return null;
            }
        }

        static void GetProductDetails()
        {
            try
            {
                con = getConnection();
                if (con == null)
                {
                    Console.WriteLine("Unable to establish connection to the database.");
                    return;
                }

                cmd = new SqlCommand("sp_Insert_ProductDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Enter the product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter the product price: ");
                int productPrice = Convert.ToInt32(Console.ReadLine());

                cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 20) { Value = productName });
                cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int) { Value = productPrice });

                
                SqlParameter generatedProductId = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(generatedProductId);

                SqlParameter discountedPrice = new SqlParameter("@DiscountedPrice", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(discountedPrice);

                
                cmd.ExecuteNonQuery();

                
                int productId = (int)generatedProductId.Value;
                int discount = (int)discountedPrice.Value;

                Console.WriteLine($"Product inserted successfully.");
                Console.WriteLine($"Generated Product ID: {productId}");
                Console.WriteLine($"Discounted Price: {discount}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }

        static void Main(string[] args)
        {
            GetProductDetails();
            Console.ReadLine();
        }
    }
}
