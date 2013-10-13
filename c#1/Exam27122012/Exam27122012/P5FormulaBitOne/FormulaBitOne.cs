using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5FormulaBitOne
{
    class FormulaBitOne
    {
        static void Main(string[] args)
        {
            long[] nums = new long[8];
            string[] numbersString = new string[8];
            char[,] grid = new char[8, 8];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = long.Parse(Console.ReadLine());
                numbersString[i] = Convert.ToString(nums[i], 2).PadLeft(8, '0');

            }

            for (int row = 0; row < nums.Length; row++)
            {
                int col = 7;
                foreach (var item in numbersString[row])
                {

                    grid[row, col] = item;
                    col--;
                }

            }
            //
            //grid[0, 0] = '5';
            ////
            //for (int row = 0; row < 8; row++)
            //{

            //    for (int col = 7; col >= 0; col--)
            //    {
            //        Console.Write("{0,-5}", grid[row, col]);
            //    }
            //    Console.WriteLine();
            //}

            int turns = 0,
                Y = 0,
                X = 0,
                len = 0,
                totalLen = 0,
                direction = 1;
            bool stop = false;

            while (true)
            {
                if (stop || (X == 7 && Y == 7))
                {
                    
                    break;
                }
                else
                {
                    stop = true;
                    
                    switch (direction)
                    {
                        case 1: // down
                            if (Y <= 7 && grid[Y,X] == '0' )
                            {
                                len = 0;
                                stop = false;                               
                                len++;
                                Y++;

                            }
                            else if (len > 0 && X <= 7)
                            {
                                len = 0;
                                stop = false;
                                direction = 2;
                                turns++;
                                X++;
                                Y--;
                            }
                            break;
                        case 2: // left from down
                            if (X <= 7 && grid[Y, X] == '0')
                            {
                                len = 0;
                                stop = false;
                                len++;
                                X++;
                                
                            }
                            else if (len > 0 && Y >= 0)
                            {
                                len = 0;
                                stop = false;
                                direction = 3;
                                turns++;
                                Y--;
                                X--;
                            }
                            break;
                        case 3: // up
                            if (Y >= 0 && grid[Y, X] == '0')
                            {
                                len = 0;
                                stop = false;
                                len++;
                                Y--;
                                
                            }
                            else if (len > 0 && X <= 7)
                            {
                                len = 0;
                                stop = false;
                                direction = 4;
                                turns++;
                                X++;
                                Y++;
                            }
                            break;
                        case 4: // left from up
                            if (X <= 7 && grid[Y, X] == '0')
                            {
                                len = 0;
                                stop = false;                               
                                len++;
                                X++;
                                
                            }
                            else if (len > 0 && Y <= 7)
                            {
                                len = 0;
                                stop = false;
                                direction = 1;
                                turns++;
                                Y++;
                                X--;
                            }
                            break;
                        default:
                            break;
                    }
                    totalLen += len;
                }
                
            }
            if (Y == 7 && X == 7 )
            {
                
                if (grid[7,7] == '1')
                {
                    Console.WriteLine("No "+totalLen);
                }
                else
                {
                    totalLen++;
                    Console.WriteLine(totalLen + " " + turns);
                }
            }
            else
            {
                Console.WriteLine("No " + totalLen);
                
            }
            
                
        }
    }
}
