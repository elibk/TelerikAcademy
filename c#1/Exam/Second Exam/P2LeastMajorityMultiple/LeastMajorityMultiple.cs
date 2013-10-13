using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LeastMajorityMultiple
{
    static void Main(string[] args)
    {

        int[] numbers = new int[5];
        int maxLMM = 100 * 100 * 100;
        int dividers = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (int LMM = 4; LMM < maxLMM; LMM++)
        {
            dividers = 0;
            if (LMM % numbers[0] == 0)
            {
                dividers++;
            }
            if (LMM % numbers[1] == 0)
            {
                dividers++;
            }
            if (LMM % numbers[2] == 0)
            {
                dividers++;
            }
            if (LMM % numbers[3] == 0)
            {
                dividers++;
            }
            if (LMM % numbers[4] == 0)
            {
                dividers++;
            }
            if (dividers >=3)
            {
                Console.WriteLine(LMM);
                break;
            }
        }
    }
}
//        int[] dividers = { 2, 3, 5, 7 };
//        int LMM = 0;
//        int[] arreyForTreeNums = new int[3];
//        int placeInArreyForTreeNums = 0;
//        int smallestLMM = 0;

//        for (int i = 0; i < numbers.Length; i++)
//        {
//            numbers[i] = int.Parse(Console.ReadLine());
//        }
//        Console.WriteLine(DateTime.Now);
//        for (int i = 1, max = (int)(Math.Pow(2, 5)); i < max; i++)
//        {
//            for (int position = 0; position < 5; position++)
//            {
//                int mask = i & (1 << position);
//                int bit = mask >> position;
//                if (bit == 1)
//                {
//                    arreyForTreeNums[placeInArreyForTreeNums] = numbers[position];
//                }
//            }
//            for (int countDiv = 0; countDiv < dividers.Length; countDiv++)
//            {
//                while (arreyForTreeNums[0] % dividers[countDiv] == 0 || arreyForTreeNums[1] % dividers[countDiv] == 0 || arreyForTreeNums[2] % dividers[countDiv] == 0)
//                {
//                    LMM *= dividers[i];
//                    if (arreyForTreeNums[0] % dividers[i] == 0)
//                    {
//                        arreyForTreeNums[0] /= dividers[i];
//                    }
//                    if (arreyForTreeNums[1] % dividers[i] == 0)
//                    {
//                        arreyForTreeNums[1] /= dividers[i];
//                    }
//                    if (arreyForTreeNums[2] % dividers[i] == 0)
//                    {
//                        arreyForTreeNums[2] /= dividers[i];
//                    }

//                }
//            }
//            LMM = LMM * arreyForTreeNums[0] * arreyForTreeNums[1] * arreyForTreeNums[2];
//            if (i == 1)
//            {
//                smallestLMM = LMM;
//            }
//            if (LMM < smallestLMM)
//            {
//                smallestLMM = LMM;
//            }
//            LMM = 0;
//        }
//        Console.WriteLine(smallestLMM);
//        Console.WriteLine(DateTime.Now);
//    }
//}
// TODO: Count unique dividers
//int[] numbers = new int [5];
//int[] dividers = {2,3,5,7};
//int []LMP = {1,1,1,1,1,1,1,1,1};
//int [] div2Freq = new int [5] ;
//int[] div3Freq = new int[5];
//int[] div5Freq = new int[5];
//int[] div7Freq = new int[5];

//for (int i = 0; i < numbers.Length; i++)
//{
//    numbers[i] = int.Parse(Console.ReadLine());
//}
//for (int num = 0; num <numbers.Length; num++)
//{
//    for (int divider = 0,freq = 0; divider <dividers.Length; divider++,freq ++)
//    {
//        while (numbers[num] % dividers[divider] == 0)
//        {
//            numbers[num] /= dividers[divider];
//            switch (dividers[divider])
//            {
//                case 2:
//                    div2Freq[freq]++;
//                    break;
//                case 3:
//                    div3Freq[freq]++;
//                    break;
//                case 5:
//                    div5Freq[freq]++;
//                    break;
//                case 7:
//                    div7Freq[freq]++;
//                    break;
//                default:
//                    break;
//            }
//        }

//    }

//}
//if (div2Freq[0] >= div2Freq[1] && div2Freq[0] >= div2Freq[2])
//{
//    LMP[0] = (numbers[0] * numbers[1] * numbers[2]) * (2 * div2Freq[0]);
//}

//for (int i = 0; i < dividers.Length; i++)
//            {
//                if ((numbers[0] == 1 && numbers[1] == 1 && numbers[2] == 1) ||
//                    (numbers[0] == 1 && numbers[1] == 1 && numbers[3] == 1) ||
//                    (numbers[0] == 1 && numbers[1] == 1 && numbers[4] == 1) ||
//                    (numbers[1] == 1 && numbers[2] == 1 && numbers[3] == 1) ||
//                    (numbers[1] == 1 && numbers[2] == 1 && numbers[4] == 1) ||
//                    (numbers[2] == 1 && numbers[3] == 1 && numbers[0] == 1) ||
//                    (numbers[2] == 1 && numbers[3] == 1 && numbers[4] == 1) ||
//                    (numbers[3] == 1 && numbers[4] == 1 && numbers[0] == 1) ||
//                    (numbers[3] == 1 && numbers[4] == 1 && numbers[1] == 1))
//                {
//                    break;
//                }
//                while (numbers[0] % dividers[i] == 0 || numbers[1] % dividers[i] == 0 || numbers[2] % dividers[i] == 0 || numbers[3] % dividers[i] == 0 || numbers[4] % dividers[i] == 0)
//                {
//                    LMM *= dividers[i];
//                    if (numbers[0] % dividers[i] == 0)
//                    {
//                        numbers[0] /= dividers[i];
//                    }
//                    if (numbers[1] % dividers[i] == 0)
//                    {
//                        numbers[1] /= dividers[i];
//                    }
//                    if (numbers[2] % dividers[i] == 0)
//                    {
//                        numbers[2] /= dividers[i];
//                    }
//                    if (numbers[3] % dividers[i] == 0)
//                    {
//                        numbers[3] /= dividers[i];
//                    }
//                    if (numbers[4] % dividers[i] == 0)
//                    {
//                        numbers[4] /= dividers[i];
//                    }

//                }

//            }
//            Console.WriteLine(LMM);