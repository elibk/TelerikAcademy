using System;

class SubsetSums
{
    static void Main()
    {
        int S = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int[] numbers = new int[N];
        int sum = new int { };
        int count = new int { };

        //bits
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }


        for (int i = 1, max = (int)(Math.Pow(2, N)); i < max; i++)
        {
            sum = 0;
            for (int position = 0; position < N; position++)
            {
                int mask = i & (1 << position);
                int bit = mask >> position;
                if (bit == 1)
                {
                    sum += numbers[position];
                }
            }
            if (sum == S)
            {
                count++;
            }

        }
        Console.WriteLine(count);
// Dinamichno optimirane
        //int S = 0;
        //int N = 5;
        //int[] numbers = new int[N];
        //int sum = new int { };
        //int count = new int { };
        //int bigPositiveArreySize = 0;
        //int bigNegativeArreySize = 0;

        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    numbers[i] = int.Parse(Console.ReadLine());
        //    if (numbers[i] >= 0)
        //    {
        //        bigPositiveArreySize += numbers[i];
        //    }
        //    else
        //    {
        //        bigNegativeArreySize += numbers[i];
        //    }
            
        //}

        //int[] countPArrey = new int[bigPositiveArreySize+1];
        //int[] countNArrey = new int[Math.Abs( bigNegativeArreySize) +1];

        //if (S >=0)
        //{
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        for (int j = countPArrey.Length -1; j >= 0; j--)
        //        {
        //            if (countPArrey[j] != 0)
        //            {
        //                if (numbers[i] + j >= 0 && numbers[i] + j < countPArrey.Length)
        //                {
        //                    countPArrey[numbers[i] + j]++;
        //                }
        //            }
        //        }
        //        for (int j = countNArrey.Length - 1; j >= 0; j--)
        //        {
        //            if (countNArrey[j] != 0)
        //            {
        //                if (numbers[i] + j * -1 >= 0 && numbers[i] + j * -1 < countPArrey.Length)
        //                {
        //                    countPArrey[numbers[i] + j*-1]++;
        //                }
        //                if (numbers[i] + j * -1 < 0 && numbers[i] + j * -1 < countNArrey.Length)
        //                {
        //                    countNArrey[Math.Abs(numbers[i] + j * -1)]++;
        //                }
        //            }

        //        }
        //        if (numbers[i] >=0)
        //        {
        //            countPArrey[numbers[i]]++;
        //        }

        //        if (numbers[i] < 0)
        //        {
        //            countNArrey[Math.Abs(numbers[i])]++;
        //        }               
        //    }
        //    Console.WriteLine(countPArrey[S]);
        //}
        //else
        //{
                
        //}

    }
}
