using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Matrix
{
    static void Main()
    {

        int num = 0;
        
        do
        {
           Console.WriteLine("Enter positive integer num < 20 :");
           string input = Console.ReadLine() ;
           bool parse = int.TryParse(input, out num);
        }
        while (num > 20 || num < 1);

        for (int row = 1; row <= num; row++)
        {
            Console.WriteLine();
            Console.Write("{0,-3}", row);

            for (int col = row + 1; col < row + num; col++)
            {
                Console.Write("{0,-3}", col);
            }
        }
        Console.WriteLine();
    }
}