using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckSubset
{
    static void Main()
    {
        int[] numbers = new int [5];
        int sum = 1;
        bool check = false;
        Console.WriteLine("Enter 5 values to see is there a subset = 0, between them.");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Value:");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        if (numbers[0] <= 0 || numbers [1] <= 0 || numbers[2] <= 0 || numbers[3] <= 0 || numbers [4] <= 0 )
        {
            for (int i = 0; i < numbers.Length; i++)
            {
// Check for subset whit 2 members
                for (int p = i + 1; p < numbers.Length; p++)
                {
                    sum = numbers[i] + numbers[p];
                    if (sum == 0)
                    {
                        Console.WriteLine("{0} + {1} = {2}", numbers[i], numbers[p], sum);
                        check = true;
                    }
                }
 //End check
// Check for subset whit 4 members
                sum = numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] - numbers[i];
                if (sum == 0)
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine("{0} + {1} + {2} + {3} = {4}", numbers[1], numbers[2], numbers[3], numbers[4], sum);
                            break;
                        case 1:
                            Console.WriteLine("{0} + {1} + {2} + {3} = {4}", numbers[0], numbers[2], numbers[3], numbers[4], sum);
                            break;
                        case 2:
                            Console.WriteLine("{0} + {1} + {2} + {3} = {4}", numbers[0], numbers[1], numbers[3], numbers[4], sum);
                            break;
                        case 3:
                            Console.WriteLine("{0} + {1} + {2} + {3} = {4}", numbers[0], numbers[1], numbers[2], numbers[4], sum);
                            break;
                        case 4:
                            Console.WriteLine("{0} + {1} + {2} + {3} = {4}", numbers[0], numbers[1], numbers[2], numbers[3], sum);
                            break;
                        default:
                            break;
                    }
                    check = true;
                }
// End check
            }

// Check for subset whit 3 members
            for (int i = 0, p = i + 1; p < numbers.Length; i++, p++)
            {
                switch (i)
                {
                    case 0:
                        sum = numbers[i] + numbers[p] + numbers[2];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[2], sum);
                            check = true;
                        }
                        sum = numbers[i] + numbers[p] + numbers[3];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[3], sum);
                            check = true;
                        }
                        sum = numbers[i] + numbers[p] + numbers[4];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[4], sum);
                            check = true;
                        }
                        break;
                    case 1:
                        sum = numbers[i] + numbers[p] + numbers[3];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[3], sum);
                            check = true;
                        }
                        sum = numbers[i] + numbers[p] + numbers[4];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[4], sum);
                            check = true;
                        }
                        break;

                    case 2:
                         sum = numbers[i] + numbers[p] + numbers[0];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[0], sum);
                            check = true;
                        }   
                        break;
                    case 3:
                         sum = numbers[i] + numbers[p] + numbers[0];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[0], sum);
                            check = true;
                        }
                        sum = numbers[i] + numbers[p] + numbers[1];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[1], sum);
                            check = true;
                        }
                        sum = numbers[i] + numbers[p] + numbers[2];
                        if (sum == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = {3}", numbers[i], numbers[p],numbers[2], sum);
                            check = true;
                        }
                        break;
                    default:
                        break;
                }   
            }
// End check
            sum = numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4];
            if (sum == 0)
            {
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}", numbers[0], numbers[1], numbers[2], numbers[3],numbers[4], sum);
                check = true;
            }
        }
        if (!check)
        {
            Console.WriteLine("There are no subsets with sum 0.");
        }
    }  
}
