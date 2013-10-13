using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Sheets
{
    class Sheets
    {
        
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] sheet = new int[11];

            sheet[0] = 1;
            for (int i = 1; i < sheet.Length; i++)
            {
                sheet[i] = sheet[i - 1] * 2;
            }

            int sheetCount = 0,
                sheetIndex = 0;

            for (int i = sheet.Length - 1; i >= 0; i--)
            {
                
                if (sheet[i] > number)
                {
                    switch (sheet[i])
                    {
                        case 1:
                            Console.WriteLine("A10");
                            break;
                        case 2:
                            Console.WriteLine("A9");
                            break;
                        case 4:
                            Console.WriteLine("A8");
                            break;
                        case 8:
                            Console.WriteLine("A7");
                            break;
                        case 16:
                            Console.WriteLine("A6");
                            break;
                        case 32:
                            Console.WriteLine("A5");
                            break;
                        case 64:
                            Console.WriteLine("A4");
                            break;
                        case 128:
                            Console.WriteLine("A3");
                            break;
                        case 256:
                            Console.WriteLine("A2");
                            break;
                        case 512:
                            Console.WriteLine("A1");
                            break;
                        case 1024:
                            Console.WriteLine("A0");
                            break;
                        default:
                            Console.WriteLine("WTF???");
                            break;
                    }
                }
                else //if (sheet[i] <= number)
                {
                    sheetCount = sheet[i];
                    sheetIndex = i;
                    break;
                }
            }
            for (int i = sheetIndex - 1; i >= 0; i--)
            {
                if (sheetCount + sheet[i] <= number)
                {
                    sheetCount = sheetCount + sheet[i];
                }
                else
                {
                    switch (sheet[i])
                    {
                        case 1:
                            Console.WriteLine("A10");
                            break;
                        case 2:
                            Console.WriteLine("A9");
                            break;
                        case 4:
                            Console.WriteLine("A8");
                            break;
                        case 8:
                            Console.WriteLine("A7");
                            break;
                        case 16:
                            Console.WriteLine("A6");
                            break;
                        case 32:
                            Console.WriteLine("A5");
                            break;
                        case 64:
                            Console.WriteLine("A4");
                            break;
                        case 128:
                            Console.WriteLine("A3");
                            break;
                        case 256:
                            Console.WriteLine("A2");
                            break;
                        case 512:
                            Console.WriteLine("A1");
                            break;
                        case 1024:
                            Console.WriteLine("A0");
                            break;
                        default:
                            Console.WriteLine("WTF???");
                            break;
                    }
                }
            }


        }
    }
}
