////
namespace H02GetMaxNum
{
    using System;
    using System.Linq;

   public class GetMaxNum
    {
       private static int biggestNum;

       private static void GetMax(int firstNum, int secondNum) 
        {
            biggestNum = firstNum;

            if (firstNum < secondNum)
            {
                biggestNum = secondNum;
            }
        }

       private static void GetMax(int firstNum, int secondNum, int thirdNum)
        {
            biggestNum = firstNum;

            if (firstNum < secondNum)
            {
                if (thirdNum > secondNum)
                {
                    biggestNum = thirdNum;
                }
                else
                {
                    biggestNum = secondNum;
                }              
            }
        }

       private static void Main(string[] args)
        {
            Console.Write("Enter how many numbers you want to compare /2 or 3/:");
            int arrLen = int.Parse(Console.ReadLine());
            int[] nums = new int[arrLen];

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("Elemnt ({0}):", i);
                nums[i] = int.Parse(Console.ReadLine());
            }

            if (arrLen == 2)
            {
                GetMax(nums[0], nums[1]);
            }
            else
            {
                GetMax(nums[0], nums[1], nums[2]);
            }

            Console.WriteLine("Biggest number is: {0}.", biggestNum);
        }
    }
}
