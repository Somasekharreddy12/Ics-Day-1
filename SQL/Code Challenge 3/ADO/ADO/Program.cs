using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace StoredProcedure
{
    public class Program
    {
        public static SqlConnection sqlconn = null;
        public static SqlCommand sqlcomm = null;

        public void Input()
        {
            try
            {
                // Establish the connection
                sqlconn = new SqlConnection("Data Source=ICS-LT-D244D6CY; Database=SQL_Code_challenge; Trusted_Connection=True;");
                sqlconn.Open();
                Console.WriteLine("Connected successfully:");

                // Get user input for product details
                Console.WriteLine("Enter the Product Name:");
                string productName = Console.ReadLine();

                Console.WriteLine("Enter the Product Price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                // Setup the command to call the stored procedure
                sqlcomm = new SqlCommand("sp_InsertProductDetails", sqlconn);
                sqlcomm.CommandType = CommandType.StoredProcedure;

                // Add input parameters
                sqlcomm.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 100)).Value = productName;
                sqlcomm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)).Value = price;

                // Add output parameters
                SqlParameter generatedProductIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                sqlcomm.Parameters.Add(generatedProductIdParam);

                SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };
                sqlcomm.Parameters.Add(discountedPriceParam);

                // Execute the procedure
                sqlcomm.ExecuteNonQuery();

                // Retrieve output values
                int generatedProductId = Convert.ToInt32(generatedProductIdParam.Value);
                decimal discountedPrice = Convert.ToDecimal(discountedPriceParam.Value);

                // Display results
                Console.WriteLine("Inserted successfully:");
                Console.WriteLine($"Generated ProductId: {generatedProductId}");
                Console.WriteLine($"Discounted Price: {discountedPrice}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Close the connection
                if (sqlconn != null && sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Input();
            Console.ReadLine();
        }
    }
}
