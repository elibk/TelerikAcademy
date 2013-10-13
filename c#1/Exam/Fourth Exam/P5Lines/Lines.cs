using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5Lines
{
    class Lines
    {
        static void Main(string[] args)
        {
            byte[] nums = new byte[8]; ;
            string[] numbers = new string[8];
            char[,] grid = new char[8,8];
            byte[] line = new byte[9];
            byte len = 0;
            byte biggest = line[1], freqency = 0;



            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = byte.Parse(Console.ReadLine());
                numbers [i] = Convert.ToString(nums[i], 2).PadLeft(8, '0');

            }

            for (int row = 0; row < nums.Length; row++)
            {
                int col = 0;
                    foreach (var item in numbers[row])
                    {
                        
                        grid[row, col] = item;
                        col++;
                    }
                
            }

            //for (int row = 0; row < 8; row++)
            //{

            //    for (int col = 0; col < 8; col++)
            //    {
            //        Console.Write("{0,-5}", grid[row, col]);
            //    }
            //    Console.WriteLine();
            //}

            for (int row = 0; row < 8; row++)
            {
                len = 0;
                for (int col = 0; col < 8; col++)
                {
                    
                    if (grid[row, col] == '1')
                    {
                        len++;
                        line[len]++;
                    }
                    else
                    {
                        
                        len = 0;
                    }
                    
                }              
            }
            for (int col = 0; col < 8; col++)
            {
                len = 0;
                for (int row = 0; row < 8; row++)
                {

                    if (grid[row, col] == '1')
                    {
                        len++;
                        line[len]++;
                    }
                    else
                    {
                        len = 0;
                    }

                }
            }
            for (byte i = 1; i < line.Length; i++)
            {
                if (line [i]!=0)
                {
                    biggest = i;
                    freqency = line[i];
                }
            }
            if (biggest == 1)
            {
                freqency /= 2;
            }
            Console.WriteLine(biggest + "\n" + freqency);
           
        }
    }
}
