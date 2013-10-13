using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5FallDown
{
    class FallDown
    {
        static void Main(string[] args)
        {
            long[] nums = new long[8]; ;
            string[] numbersString = new string[8];
            char[,] grid = new char[8, 8];
            bool chek = true;

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = long.Parse(Console.ReadLine());
                numbersString[i] = Convert.ToString(nums[i], 2).PadLeft(8, '0');

            }

            for (int row = 0; row < nums.Length; row++)
            {
                int col = 0;
                foreach (var item in numbersString[row])
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

            while (chek)
            {
                chek = false;
                //for (int rowI = 0; rowI < 8; rowI++)
                //{

                //    for (int colI = 0; colI < 8; colI++)
                //    {
                //        Console.Write("{0,-5}", grid[rowI, colI]);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine();
                for (int col = 0; col < 8; col++)
                {
                    
                    for (int row = 0; row < 7; row++)
                    {

                        if (grid[row, col] == '1' && grid[row +1, col] == '0')
                        {
                            grid[row, col] = '0';
                            grid[row + 1, col] = '1';
                            chek = true;  
                        }                     
                    }
                }
            }

            for (int row = 0; row < 8; row++)
            {
                numbersString[row] = ""; 
                for (int col = 0; col < 8; col++)
                {
                    numbersString [row] +=grid[row,col] ;
                }
                nums[row] = long.Parse(numbersString[row]);
                numbersString[row] = Convert.ToString(nums[row]);
            }

            for (int num = 0; num < nums.Length; num++)
            {
                nums[num] = 0;
                for (int i = 0; i < numbersString[num].Length - 1; i++)
                {
                    nums[num] = (nums[num] + (numbersString[num][i] - '0')) * 2;
                }
                nums[num] += (numbersString[num][numbersString[num].Length - 1] - '0');
                Console.WriteLine(nums[num]);
            }
            
        }
    }
}
