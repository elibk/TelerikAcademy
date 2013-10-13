using System;
using System.Linq;
using System.Data.SqlClient;

namespace H01NumberOfRowsInTheCategoriesTable
{
   public class Program
    {
       public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\; " +
             "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}
