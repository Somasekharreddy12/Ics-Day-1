using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class products
    {
        public int ProductsId 
        { get; 
          
            set; }
        public string ProductsName 
        { get; 
            
            set; }
        public decimal Price
        { get;
            
            set; }


        public products(int productsId, string productsName, decimal price)
        {
            ProductsId = productsId;
            ProductsName = productsName;
            Price = price;
        }
    }

    class program
    {
        static void main()
        {
            List<products> products = new List<products>();


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Products {i + 1}:");

                Console.Write("Enter Products ID: ");
                int productsId = int.Parse(Console.ReadLine());

                Console.Write("Enter Products Name: ");
                string productsName = Console.ReadLine();

                Console.Write("Enter Price: ");
                int productprice = int.Parse(Console.ReadLine());


                products.Add(new products(productsId, productsName,productprice));
                Console.WriteLine();  
            }


            var sortProducts = products.OrderBy(p => p.Price).ToList();


            Console.WriteLine("SortProducts based on Price:");
            
            

            foreach (var product in sortProducts)
            {
                Console.WriteLine("{0,-12} {1,-20} {2,-10:C}", product.ProductsId, product.ProductsName, product.Price);
            }
        }
    }
}
    
