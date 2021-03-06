﻿using Newtonsoft.Json;
using Supermarket.Data;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.IO;

namespace Supermarket.Reports
{
    public class JsonReport
    {
        public SupermarketContext dbContext { get; set; }

        public JsonReport(SupermarketContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetProductsReport()
        {
            var products = from product in this.dbContext.Products

               
                select new ProductReportJson
                {
                    ProductId = product.ID,
                    Name = product.Name,
                    Vendor = product.Vendor.Name,
                };


            var resultForJson = new List<ProductReportJson>();
            foreach (var prod in products.ToList())
            {
                resultForJson.Add(new ProductReportJson
                {
                    ProductId = prod.ProductId,
                    Name = prod.Name,
                    Vendor = prod.Vendor,
                    QuantitySold = GetQuantity(prod.ProductId),
                    Incomes = GetIncomes(prod.ProductId)
                });
            }

            string json = JsonConvert.SerializeObject(resultForJson, Formatting.Indented);

            using (FileStream fs = File.Open(@"../person3.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, resultForJson);
            }
            return json;
        }


        private int GetQuantity(int productId)
        {
            //var query = dbContext.Database.ExecuteSqlCommand("SELECT COUNT(*) FROM Sales s Where s.Product_ID = {0};", productId);
            
            var result = (from sale in dbContext.Sales where sale.Product.ID == productId select sale).Count();

            return result;
        }

        private decimal GetIncomes(int productId)
        {
            //decimal query = dbContext.Database.ExecuteSqlCommand("SELECT SUM(s.[Sum]) from Sales s where s.Product_ID = {1};", productId);

            var result = (from sale in dbContext.Sales where sale.Product.ID == productId select sale.Sum);
            if (result.Count() > 0)
            {
                return result.Sum();
            }

            return 0;
        }

    }
}
