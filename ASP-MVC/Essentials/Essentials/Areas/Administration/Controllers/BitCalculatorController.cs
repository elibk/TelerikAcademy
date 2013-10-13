using Essentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Essentials.Areas.Administration.Controllers
{
    public class BitCalculatorController : Controller
    {
        //
        // GET: /Administration/BitCalculator/
        public ActionResult Index(string unitInitials)
        {
           ViewBag.SelectedUnit = unitInitials;
           var units = LoadUnits();
           return View(units);
        }

        private List<IUnit> LoadUnits()
        {
            return new List<IUnit> 
            {
                new Unit
                { 
                    UnitInitials = "b",
                    IsBit = true,
                    PowerOfTen = 0,
                    PowerOfTwo = 0,
                    Prefix =  string.Empty,
                    Quantity = 0
                },

                 new Unit
                { 
                    UnitInitials = "B",
                    IsBit = false,
                    PowerOfTen = 0,
                    PowerOfTwo = 0,
                    Prefix =  string.Empty,
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "Kb",
                    IsBit = true,
                    PowerOfTen = 3,
                    PowerOfTwo = 10,
                    Prefix =  "Kilo",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "KB",
                    IsBit = false,
                    PowerOfTen = 3,
                    PowerOfTwo = 10,
                    Prefix =  "Kilo",
                    Quantity = 0
                },

                 new Unit
                { 
                    UnitInitials = "Mb",
                    IsBit = true,
                    PowerOfTen = 6,
                    PowerOfTwo = 20,
                    Prefix = "Mega",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "MB",
                    IsBit = false,
                    PowerOfTen = 6,
                    PowerOfTwo = 20,
                    Prefix =  "Mega",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "Gb",
                    IsBit = true,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Giga",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "GB",
                    IsBit = false,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Giga",
                    Quantity = 0
                },

                  new Unit
                { 
                    UnitInitials = "Tb",
                    IsBit = true,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Tera",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "TB",
                    IsBit = false,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Tera",
                    Quantity = 0
                },

                  new Unit
                { 
                    UnitInitials = "Pb",
                    IsBit = true,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Peta",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "PB",
                    IsBit = false,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Peta",
                    Quantity = 0
                },

                      new Unit
                { 
                    UnitInitials = "Eb",
                    IsBit = true,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Exa",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "EB",
                    IsBit = false,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Exa",
                    Quantity = 0
                },

                       new Unit
                { 
                    UnitInitials = "Zb",
                    IsBit = true,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Zetta",
                    Quantity = 0
                },

                new Unit
                { 
                    UnitInitials = "EB",
                    IsBit = false,
                    PowerOfTen = 9,
                    PowerOfTwo = 30,
                    Prefix =  "Exa",
                    Quantity = 0
                },
            };
        }
	}
}