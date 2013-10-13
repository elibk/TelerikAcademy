using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Carpets
{
    class Carpets
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int row = 1, dots = N /2 -1; dots >= 0; row++, dots--)
            {
                Console.Write(new string('.',dots));
                for (int lines = 1; lines <= row / 2; lines++)
                {
                    Console.Write("/ ");
                }
                if (row % 2 != 0)
                {
                    Console.Write("/");
                }

                    if (row % 2 != 0 )
                    {
                        Console.Write("\\");
                    }
                    for (int i = 1; i <= row / 2; i++)
                    {
                        Console.Write(" \\");
                    }
                   
                Console.WriteLine(new string('.',dots));
            }
            for (int row = N/2, dots = 0; dots <= N / 2 - 1; row--, dots++)
            {
                Console.Write(new string('.', dots));

                    for (int lines = 1; lines <= row / 2; lines++)
                    {                      
                          Console.Write("\\ ");      
                        
                    }
                    if (row % 2 != 0)
                    {
                        Console.Write("\\");
                    }

                    if (row % 2 != 0)
                    {
                        Console.Write("/");
                    }
                    for (int lines = 1; lines <= row / 2; lines++)
                    {
                        Console.Write(" /");

                    }               
                Console.WriteLine(new string('.', dots));
            }
        }
    }
}
