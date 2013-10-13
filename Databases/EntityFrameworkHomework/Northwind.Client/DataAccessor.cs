using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;

namespace Northwind.Client
{
   public class DataAccessorCustomer
    {
       NorthwindEntities dbContext;

        public DataAccessorCustomer(NorthwindEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public string InsertCutomer(Customer newCustomer)
        {
           
            dbContext.Customers.Add(newCustomer);
            this.dbContext.SaveChanges();
            return newCustomer.CustomerID;
        }

        public void DeleteCutomer(Customer customer)
        {
            dbContext.Customers.Remove(customer);
            this.dbContext.SaveChanges();
        }

        public void ModifyCutomer(Customer oldCustomer, Customer newCustomer)
        {
            this.DeleteCutomer(oldCustomer);
            this.InsertCutomer(newCustomer);
        }
    }
}
