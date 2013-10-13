﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data;
using Supermarket.Model;
using System.Data.Entity;
using Supermarket.Data.Migrations;
using Supermarket.Reports;
using System.IO;



namespace Supermarket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());
            var dbCobntext = new SupermarketContext();
            //FromMySqlNeverAgain();

            foreach (var item in dbCobntext.Locations)
            {
                
            }

            ExecuteJsonToFile(dbCobntext, "../../../../products.json");

        }

        private static void ExecuteJsonToFile(SupermarketContext dbContext, string filePath)
        {
            JsonReport jsonReport = new JsonReport(dbContext);
            string productsJson = jsonReport.GetProductsReport();

            File.WriteAllText(filePath, productsJson);
        }

        private static void FromMySqlNeverAgain()
        {
            var dbcontext = new SupermarketContext();

            var mySqlContx = new SupermarketModel();
            using (mySqlContx)
            {
                var products = mySqlContx.Products.OrderBy(e => e.ID).ToList();
                var vendors = mySqlContx.Vendors.ToList();
                var mesuares = mySqlContx.Measures.ToList();
                using (dbcontext)
                {

                    foreach (var mesuare in mesuares)
                    {
                        var newMeasure = new Measure()
                        {
                            ID = mesuare.ID,
                            Name = mesuare.Name
                        };
                        dbcontext.Measures.Add(newMeasure);

                    }

                    foreach (var vendor in vendors)
                    {
                        var newVendor = new Vendor()
                        {
                            ID = vendor.ID,
                            Name = vendor.Name
                        };
                        dbcontext.Vendors.Add(newVendor);
                    }


                    foreach (var product in products)
                    {
                        var some = new Product
                        {
                            BasePrice = product.BasePrice,
                            Measure_ID = product.Measure_ID,
                            Name = product.Name,
                            Vendor_ID = product.Vendor_ID,
                        };
                        dbcontext.Products.Add(some);
                    }

                    dbcontext.SaveChanges();
                }


            }
        }
    }
}
