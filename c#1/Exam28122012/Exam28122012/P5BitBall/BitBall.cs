using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5BitBall
{
    class BitBall
    {
        static void Main(string[] args)
        {
            long[] tops = new long[8];
            long[] bottoms = new long[8];
            string[] topsString = new string[8];
            string[] bottomsString = new string[8];
            char[,] grid = new char[8, 8];

            for (int i = 0; i < tops.Length; i++)
            {
                tops[i] = long.Parse(Console.ReadLine());
                topsString[i] = Convert.ToString(tops[i], 2).PadLeft(8, '0');
            }
            for (int i = 0; i < bottoms.Length; i++)
            {
                bottoms[i] = long.Parse(Console.ReadLine());
                bottomsString[i] = Convert.ToString(bottoms[i], 2).PadLeft(8, '0');
            }

            for (int row = 0; row < tops.Length; row++)
            {
                int col = 7;
                foreach (var item in topsString[row])
                {
                    if (item == '1')
                    {
                        grid[row, col] = 'T';
                    }
                    else
                    {
                        grid[row, col] = item;
                    }
                    col--;
                }
            }


            //for (int row = 0; row < 8; row++)
            //{

            //    for (int col = 7; col >= 0; col--)
            //    {
            //        Console.Write("{0,-5}", grid[row, col]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();



            for (int row = 0; row < bottoms.Length; row++)
            {
                int col = 7;
                foreach (var item in bottomsString[row])
                {
                    if (item == '1')
                    {
                        if (grid[row, col] == 'T')
                        {
                            grid[row, col] = '0';  
                        }
                        else
                        {
                            grid[row, col] = 'B';
                        }                  
                    }
                    
                                    
                    col--;
                }
            }

            ////grid[0, 0] = '5';
            ////
            //for (int row = 0; row < 8; row++)
            //{

            //    for (int col = 7; col >= 0; col--)
            //    {
            //        Console.Write("{0,-5}", grid[row, col]);
            //    }
            //    Console.WriteLine();
            //}

            int bottomsGols = 0,
                topsGols = 0;

            for (int col = 0; col < 8; col++)
            {

                for (int row = 7; row >= 0; row--)
                {
                    if (grid[row,col] == 'B')
                    {
                        if (row == 0)
                        {
                            bottomsGols++;
                        }
                        else
                        {
                            int attak = row - 1;
                            for (int botAttak = attak; botAttak >= 0; botAttak--)
                            {
                                if (botAttak == 0 && grid[botAttak,col] == '0')
                                {
                                    bottomsGols++;
                                }
                                else if (grid[botAttak,col] != '0')
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (grid[row,col] == 'T')
                    {
                        if (grid[row, col] == 'T')
                        {
                            if (row == 7)
                            {
                                topsGols++;
                            }
                            else
                            {
                                int attak = row + 1;
                                for (int topAttak = attak; topAttak <= 7; topAttak++)
                                {
                                    if (topAttak == 7 && grid[topAttak, col] == '0')
                                    {
                                        topsGols++;
                                    }
                                    else if (grid[topAttak, col] != '0')
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(topsGols + ":" + bottomsGols);
        }
    }
}
