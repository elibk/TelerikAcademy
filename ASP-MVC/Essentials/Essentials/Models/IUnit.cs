using System;
namespace Essentials.Models
{
   public interface IUnit
    {

       string UnitInitials { get; set; }
        bool IsBit { get; set; }
        int PowerOfTen { get; set; }
        int PowerOfTwo { get; set; }
        string Prefix { get; set; }
        decimal Quantity { get; set; }
    }
}
