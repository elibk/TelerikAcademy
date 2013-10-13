using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.ELinq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data
{
     [NotMapped]
   public partial class Employee
    {

       public ICollection<Territory> MyPropTerritories
        {
            get { return this.Territories; }
        }
    }
}
