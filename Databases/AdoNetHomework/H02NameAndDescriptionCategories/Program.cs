using System;
using System.Linq;
using System.Data.SqlClient;

namespace H02NameAndDescriptionCategories
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
               SqlCommand cmdSelectNameAndDescr = new SqlCommand(
                "SELECT c.CategoryName as Name, c.Description as Description FROM Categories c", dbCon);
               SqlDataReader reader = cmdSelectNameAndDescr.ExecuteReader();

               using (reader)
               {
                   Console.WriteLine("{0,-15} | Description", "Categoriy name");
                   Console.WriteLine(new string('_', Console.WindowWidth));
                   while (reader.Read())
                   {
                       string catName = (string)reader["Name"];
                       string catDescr = (string)reader["Description"];

                       Console.WriteLine("{0,-15} | {1}", catName, catDescr);
                   }
               }
           }
       }
    }
}
