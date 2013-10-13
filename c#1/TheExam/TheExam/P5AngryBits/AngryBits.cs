using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5AngryBits
{
    class AngryBits
    {
        static void Main(string[] args)
        {
            long[] nums = new long[8];
            string[] numbersString = new string[8];
            char[,] grid = new char[8, 16];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = long.Parse(Console.ReadLine());
                numbersString[i] = Convert.ToString(nums[i], 2).PadLeft(16, '0');

            }

            for (int row = 0; row < nums.Length; row++)
            {
                int col = 15;
                foreach (var item in numbersString[row])
                {

                    grid[row, col] = item;
                    col--;
                }

            }
            //
            // grid[0, 0] = '5';
            ////
            //for (int row = 0; row < 8; row++)
            //{

            //    for (int col = 15; col >= 0; col--)
            //    {
            //        Console.Write("{0,-5}", grid[row, col]);
            //    }
            //    Console.WriteLine();
            //}

            int len = 0,
                pigs = 0,
                direction = 1,
                totalScore = 0;
            bool hit = false;
            string result = "Yes";

            for (int col = 8; col <= 15; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    len = 0;
                    pigs = 0;
                    hit = false;


                    if (grid[row, col] == '1')
                    {
                        grid[row, col] = '@';
                        direction = 1;
                        hit = false;

                        int birdX = col,
                            birdY = row;

                        while (birdX > 0 && hit == false)
                        {
                            birdX--;

                            switch (direction)
                            {
                                case 1:
                                    if (birdY > 0)
                                    {
                                        birdY--;
                                        len++;
                                        if (grid[birdY, birdX] == '1')
                                        {
                                            grid[birdY, birdX] = '@';
                                            hit = true;
                                            pigs++;

                                            if (birdX > 0 && birdX < 7)
                                            {
                                                if (grid[birdY, birdX - 1] == '1')
                                                {
                                                    grid[birdY, birdX - 1] = '@';
                                                    pigs++;

                                                }
                                                if (grid[birdY, birdX + 1] == '1')
                                                {
                                                    grid[birdY, birdX + 1] = '@';
                                                    pigs++;
                                                }
                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }

                                            }
                                            else if (birdX == 0)
                                            {
                                                if (grid[birdY, birdX + 1] == '1')
                                                {
                                                    grid[birdY, birdX + 1] = '@';
                                                    pigs++;
                                                }
                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }

                                                    if (grid[birdY - 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }

                                                    if (grid[birdY + 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }

                                            }
                                            else if (birdX == 7)
                                            {
                                                if (grid[birdY, birdX - 1] == '1')
                                                {
                                                    grid[birdY, birdX - 1] = '@';
                                                    pigs++;

                                                }

                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }

                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                }


                                            }
                                        }
                                    }
                                    else
                                    {
                                        birdX++;                                      
                                        direction = 2;

                                    }
                                    break;
                                case 2:
                                    if (birdY < 7)
                                    {
                                        birdY++;
                                        len++;
                                        if (grid[birdY, birdX] == '1')
                                        {
                                            grid[birdY, birdX] = '@';
                                            hit = true;
                                            pigs++;

                                            if (birdX > 0 && birdX < 7)
                                            {
                                                if (grid[birdY, birdX - 1] == '1')
                                                {
                                                    grid[birdY, birdX - 1] = '@';
                                                    pigs++;

                                                }
                                                if (grid[birdY, birdX + 1] == '1')
                                                {
                                                    grid[birdY, birdX + 1] = '@';
                                                    pigs++;
                                                }
                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }

                                            }
                                            else if (birdX == 0)
                                            {
                                                if (grid[birdY, birdX + 1] == '1')
                                                {
                                                    grid[birdY, birdX + 1] = '@';
                                                    pigs++;
                                                }
                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }

                                                    if (grid[birdY - 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }

                                                    if (grid[birdY + 1, birdX + 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX + 1] = '@';
                                                        pigs++;
                                                    }
                                                }

                                            }
                                            else if (birdX == 7)
                                            {
                                                if (grid[birdY, birdX - 1] == '1')
                                                {
                                                    grid[birdY, birdX - 1] = '@';
                                                    pigs++;

                                                }

                                                if (birdY > 0)
                                                {
                                                    if (grid[birdY - 1, birdX] == '1')
                                                    {
                                                        grid[birdY - 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY - 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY - 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }

                                                }
                                                if (birdY < 7)
                                                {
                                                    if (grid[birdY + 1, birdX] == '1')
                                                    {
                                                        grid[birdY + 1, birdX] = '@';
                                                        pigs++;
                                                    }
                                                    if (grid[birdY + 1, birdX - 1] == '1')
                                                    {
                                                        grid[birdY + 1, birdX - 1] = '@';
                                                        pigs++;
                                                    }
                                                }


                                            }
                                        }
                                    }
                                    else // bird reaches bottom
                                    {
                                        break;
                                    }
                                    break;

                                default:
                                    break;
                            }

                        }
                    }
                    totalScore += (len * pigs);
                }
            }

            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (grid[row, col] == '1')
                    {
                        result = "No";
                        break;
                    }
                }

            }
            Console.WriteLine(totalScore + " " + result);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            ////for (int row = 0; row < 8; row++)
            ////{

            ////    for (int col = 15; col >= 0; col--)
            ////    {
            ////        Console.Write("{0,-5}", grid[row, col]);
            ////    }
            ////    Console.WriteLine();
            ////}
        }
    }
}