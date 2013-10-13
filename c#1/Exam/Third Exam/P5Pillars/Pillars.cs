using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5Pillars
{
    class Pillars
    {
        static void Main(string[] args)
        {
            byte[] nums = new byte[8]; ;
            string[] numbers = new string[8];
            char[,] grid = new char[8, 8];
            int lenLeftHalf = 0, lenRightHalf = 0;
            int leftRowStart = 0, leftRowEnd = 0;
            int rightRowStart = 2, rightRowEnd = 7;
            int rowLine = 6;
            bool isNotPill = true;




            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = byte.Parse(Console.ReadLine());
                numbers[i] = Convert.ToString(nums[i], 2).PadLeft(8, '0');

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

            while (leftRowEnd <= 5)
            {
                lenLeftHalf = 0;
                lenRightHalf = 0;

                for (int row = 0; row < 8; row++)
                {
                    for (int col = leftRowStart; col <= leftRowEnd; col++)
                    {

                        if (grid[row, col] == '1')
                        {
                            lenLeftHalf++;
                        }

                    }
                }

                for (int row = 0; row < 8; row++)
                {
                    for (int col = rightRowStart; col <= rightRowEnd; col++)
                    {

                        if (grid[row, col] == '1')
                        {
                            lenRightHalf++;
                        }

                    }
                }

                if (lenRightHalf > lenLeftHalf)
                {
                    leftRowEnd++;
                    rightRowStart++;
                    rowLine--;
                }
                else if (lenRightHalf < lenLeftHalf)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(rowLine);
                    Console.WriteLine(lenRightHalf);
                    isNotPill = false;
                    break;
                }
            }

            if (isNotPill)
            {
                Console.WriteLine("No");
            }
        }
    }
}