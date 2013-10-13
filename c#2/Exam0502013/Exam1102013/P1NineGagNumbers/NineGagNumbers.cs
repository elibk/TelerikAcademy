using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P1NineGagNumbers
{
    class NineGagNumbers
    {
        static void Main(string[] args)
        {

            string nineGagNum = Console.ReadLine();
            List<byte> digits = new List<byte>();

            while (nineGagNum.Length > 0)
            {
                if (nineGagNum[0] == '-')
                {
                    digits.Add(0);
                    nineGagNum = nineGagNum.Substring(2);
                }
                else if (nineGagNum[0] == '*')
                {
                    if (nineGagNum[1] == '*')
                    {
                        digits.Add(1);
                        nineGagNum = nineGagNum.Substring(2);
                    }
                    else//// if (nineGagNum[1] == '!')
                    {
                        digits.Add(6);
                        nineGagNum = nineGagNum.Substring(4);
                    }
                }
                else if (nineGagNum[0] == '!')
                {
                    if (nineGagNum[1] == '-')
                    {
                        digits.Add(5);
                        nineGagNum = nineGagNum.Substring(2);
                    }
                    else ////if (nineGagNum[1] == '!')
                    {
                        if (nineGagNum[2] == '*')
                        {
                            digits.Add(8);
                            nineGagNum = nineGagNum.Substring(6);
                        }
                        else ////if (nineGagNum[2] == '!')
                        {
                            digits.Add(2);
                            nineGagNum = nineGagNum.Substring(3);
                        }
                    }
                }
                else ////if (nineGagNum[0] == '&')
                {
                    if (nineGagNum[1] == '&')
                    {
                        digits.Add(3);
                        nineGagNum = nineGagNum.Substring(2);
                    }
                    else if (nineGagNum[1] == '-')
                    {
                        digits.Add(4);
                        nineGagNum = nineGagNum.Substring(2);
                    }
                    else ////if (nineGagNum[1] == '*')
                    {
                        digits.Add(7);
                        nineGagNum = nineGagNum.Substring(3);
                    }
                }
            }

            //foreach (var item in digits)
            //{
            //    Console.WriteLine(item);
            //}

            BigInteger decimalNum = 0;

            for (int i = digits.Count - 1, baseMultiplicatior = 0; i >= 0; i--, baseMultiplicatior++)
            {
                BigInteger pow = 1;
                for (int bases = baseMultiplicatior; bases > 0; bases--)
                {
                    pow *= 9;
                }
                decimalNum += (BigInteger)digits[i] * pow;
            }

            Console.WriteLine(decimalNum);
        }
    }
}
