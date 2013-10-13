using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Data.Entity.Infrastructure;

using Northwind.Data;

namespace Northwind.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            NorthwindEntities dbContext = new NorthwindEntities();
           
            using (dbContext)
            {
                // task 2
                DataAccessorCustomer dataaccsess = new DataAccessorCustomer(dbContext);

                //task 3
                FindCustomersWithOrdersMadeIn1997ShippedToCanada(dbContext);

                // task 4
                FindCustomersWithOrdersMadeIn1997ShippedToCanadaNative(dbContext);

                // task 5
                FindsAllTheSalesBySpecifiedRegionAndPeriod(dbContext, "WA", new DateTime(1997, 12, 1), new DateTime(1997, 12, 31));

                // task 6
                CreateTwinDateBase(dbContext, "NorthwindTwin");

                //task 7
                using (NorthwindEntities concurencyContext = new NorthwindEntities())
                {
                    var firstRegion = dbContext.Regions.First(x => x.RegionID == 1);
                    firstRegion.RegionDescription = "Changed by first context";

                    var secondRegion = concurencyContext.Regions.First(x => x.RegionID == 1);
                    secondRegion.RegionDescription = "Changed by concurency context";

                    dbContext.SaveChanges();
                    concurencyContext.SaveChanges();

                    //ConcurencyContext wins.
                }

                // task 8

                foreach (var item in dbContext.Employees)
                {
                    foreach (var ter in item.MyPropTerritories)
                    {
                        Console.WriteLine(ter.TerritoryDescription);
                    }
                }

            }
        }

        static List<string> FindCustomersWithOrdersMadeIn1997ShippedToCanada(NorthwindEntities dbContext)
        {
            /*   SELECT 
                    c.ContactName,
                    o.OrderDate
                       FROM
                       Orders o
                       INNER JOIN Customers c ON o.CustomerID = c.CustomerID
                       WHERE 
                       o.ShipCountry = 'Canada' AND year(o.OrderDate) =  1997
           */
            var customers = from order in dbContext.Orders
                            where order.ShipCountry == "Canada" && order.OrderDate.Value.Year == 1997
                            select order.Customer.ContactName;
           // var cust2 = dbContext.Orders.Where(x => x.ShipCountry == "Canada" && x.OrderDate.Value.Year == 1997).Select(x => new { x.Customer.CompanyName, x.Customer.ContactTitle });
            //List<Customer> result = new List<Customer>();

            return customers.ToList();
        }


        static List<SalesByRegion> FindsAllTheSalesBySpecifiedRegionAndPeriod(NorthwindEntities dbContext, string region, DateTime startDate, DateTime endDate)
        {
            var salesByRegion =
                from sale in dbContext.Sales_by_Year(startDate, endDate)
                join order in dbContext.Orders
                on sale.OrderID equals order.OrderID
                join employee in dbContext.Employees
                on order.EmployeeID equals employee.EmployeeID
                where employee.Region == region
                select new SalesByRegion
                {
                    OrderDate = order.OrderDate,
                    Subtotal = sale.Subtotal,
                    OrderRegion = employee.Region
                };

            var result = salesByRegion.ToList() ;
            return result;
        }

        static List<Customer> FindCustomersWithOrdersMadeIn1997ShippedToCanadaNative(NorthwindEntities dbContext)
        {
            int year = 1997;
            string country = "Canada";
            string query = @"
               SELECT 
                c.ContactName as Name,
                o.OrderDate as Date
                
                FROM  Orders o
                LEFT OUTER JOIN Customers c ON o.CustomerID = c.CustomerID
                WHERE ({1} = o.ShipCountry) AND ({0} = year(o.OrderDate))
           ";
            var customers = dbContext.Database.SqlQuery<OrderContactName>(query, year, country);

            //var customers = from order in dbContext.Orders
            //                where order.ShipCountry == "Canada" && order.OrderDate.Value.Year == 1997
            //                select new { order.Customer.ContactName, 
            //                             order.OrderDate
            //                };

            foreach (var item in customers)
            {
                Console.WriteLine("{0} {1}",item.Date, item.Name);
                
            }

            return null;
        }

        public static void CreateTwinDateBase(NorthwindEntities dbContext, string newDatabaseName)
        {
            IObjectContextAdapter schema = new NorthwindEntities();
            
            string scripts = schema.ObjectContext.CreateDatabaseScript();

            var dataBaseNAme = dbContext.Database.SqlQuery<string>("SELECT DB_NAME() AS DataBaseName");
            string dbName = dataBaseNAme.First();
            scripts = scripts.Replace(dbName, newDatabaseName);
            string conStr = dbContext.Database.Connection.ConnectionString;

            var conection = new SqlConnection(conStr);
            conection.Open();
            using (conection)
            {

                SqlCommand query = new SqlCommand("CREATE DATABASE " + newDatabaseName, conection);
                query.Parameters.AddWithValue("@name", newDatabaseName);
                
                query.ExecuteNonQuery();
                // if there is such database exeption will be thrown
            }

            conStr = conStr.Replace(dbName, newDatabaseName);
            conection = new SqlConnection(conStr);
            conection.Open();
            using (conection)
            {

                SqlCommand query = new SqlCommand(scripts, conection);
                query.ExecuteNonQuery();

            }
          
       
        }
    }

    class OrderContactName
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

      
        public override string ToString()
        {
            return string.Format("{0}, {1}",this.Name, this.Date);
        }
    }

    class SalesByRegion
    {
        public string OrderRegion { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? Subtotal { get; set; }


        public override string ToString()
        {
            return string.Format("{0}, {1}, {2:C2}", this.OrderRegion, this.OrderDate, this.Subtotal);
        }
    }
}
