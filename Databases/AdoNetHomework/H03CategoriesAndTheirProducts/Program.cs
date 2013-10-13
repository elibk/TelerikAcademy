using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H03CategoriesAndTheirProducts
{
    class Program
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\; " +
             "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdSelectNameAndDescr = new SqlCommand(
                 @"SELECT 
                    c.CategoryName as Category, p.ProductName as Product 
                        FROM Products p 
                        INNER JOIN Categories c ON p.CategoryID = c.CategoryID
                   ORDER BY c.CategoryName", dbCon);
                SqlDataReader reader = cmdSelectNameAndDescr.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("{0,-35} | Category", "Product");
                    Console.WriteLine(new string('_', Console.WindowWidth));
                    while (reader.Read())
                    {
                        string catName = (string)reader["Category"];
                        string productName = (string)reader["Product"];

                        Console.WriteLine("{0,-35} | {1}", productName, catName);
                    }
                }
            }
        }
    }
}
