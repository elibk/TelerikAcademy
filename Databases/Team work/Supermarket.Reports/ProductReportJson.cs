using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Reports
{
   internal class ProductReportJson
    {
       
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public int QuantitySold { get; set; }
        public decimal Incomes { get; set; }

    }
}
