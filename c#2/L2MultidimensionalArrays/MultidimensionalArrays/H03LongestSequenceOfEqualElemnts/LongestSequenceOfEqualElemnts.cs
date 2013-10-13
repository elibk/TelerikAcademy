////Check Matrix
namespace H03LongestSequenceOfEqualElemnts
{
    using System;
    using System.Linq;

    public class LongestSequenceOfEqualElemnts
    {
        private readonly static int cols = 4,
                            rows = 3;

        private static int count = 1;
        private static int len = 1;
        private static string element = string.Empty;
        private static string currentElement = string.Empty;

        private static void CheckHorizontal(string[,] array)
        {
            count = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < col - 1; col++)
                {
                    if (array[row, col] == array[row, col + 1])
                    {
                        count++;
                        currentElement = array[row, col];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }
        }

        private static void CheckVertical(string[,] array)
        {
            count = 1;

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows - 1; row++)
                {
                    if (array[row, col] == array[row + 1, col])
                    {
                        count++;
                        currentElement = array[row, col];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }         
        }
        
        private static void CheckLeftDiagonal(string[,] array)
        {
            count = 1;
            for (int row = rows - 1, col = 0; row >= 0; row--, col++)
            {
                for (int y = row, x = 0; x < col; y++, x++)
                {
                    if (array[y, x] == array[y + 1, x + 1])
                    {
                        count++;
                        currentElement = array[y, x];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }

            count = 1;

            for (int col = 1; col <= cols - 1; col++)
            {
                for (int y = 0, x = col; x < cols - 1; y++, x++)
                {
                    if (array[y, x] == array[y + 1, x + 1])
                    {
                        count++;
                        currentElement = array[y, x];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }
        }

        private static void CheckRightDiagonal(string[,] array)
        {
            count = 1;
            for (int row = rows - 1, col = cols-2; row >= 0; row--, col--)
            {
                for (int y = row, x = cols-2; x > col; y++, x--)
                {
                    if (array[y, x] == array[y + 1, x - 1])
                    {
                        count++;
                        currentElement = array[y, x];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }

            count = 1;

            for (int col = cols-2; col >= 0; col--)
            {
                for (int y = 0, x = col; x > 0; y++, x--)
                {
                    if (array[y, x] == array[y + 1, x - 1])
                    {
                        count++;
                        currentElement = array[y, x];
                    }
                    else
                    {
                        if (count > len)
                        {
                            len = count;
                            element = currentElement;
                        }

                        count = 1;
                    }
                }
            }

            if (count > len)
            {
                len = count;
                element = currentElement;
            }
        }

        private static void Main(string[] args)
        {
            string[,] array = 
                              { 
                                { "ha", "xx", "ho", "hh" },
                                { "xx", "xx", "hh", "ho" }, 
                                { "ho", "xx", "ho", "xx" } 
                              };

            CheckHorizontal(array);
            //Console.WriteLine(len + element);
            CheckVertical(array);
            //Console.WriteLine(len + element);
            CheckLeftDiagonal(array);
            //Console.WriteLine(len + element);
            CheckRightDiagonal(array);
            Console.WriteLine(len + " "+ element);
        }   
    }
}
