using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H11AddPolynomials
{
    class AddPolynomials
    {
        static void Main(string[] args)
        {
            string input = "x^2 + 5";
            string patternBaseTwo = @"x^2";
            bool isMatch = true;
            string polynom = "0";
            int[] coefficients = new int [3];
            

            while (true)
            {
                isMatch = Regex.IsMatch(input, patternBaseTwo);

                if (isMatch == false)
                {
                    break;
                }

                polynom = Regex.Match(input,patternBaseTwo).ToString();
                
                if (polynom[0] != 'x')
	            {
                    int num = polynom.IndexOf('x');
                    polynom = polynom.Substring(0, polynom.Length - num);
                    coefficients[0] = int.Parse(polynom);
	            }
                else
                {
                    coefficients[0] = 1;
                }
                
            }

        }
    }
}
