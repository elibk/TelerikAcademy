using System;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        int B = int.Parse(Console.ReadLine()); ;
        int N = int.Parse(Console.ReadLine());
        int nAndMask,bit;
        uint[] numbers = new uint[N];
        int[] pToStop = new int[N];
        int[] counts = new int[N];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        if (B == 0)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int position = 31; position > 0; position--)
                {
                    nAndMask = ((int)numbers[i]) & 1 << position;
                    bit = nAndMask >> position;
                    if (bit != 0)
                    {
                        pToStop[i] = position;
                        break;
                    }
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int position = 0; position < pToStop[i]; position++)
                {
                    nAndMask = ((int)numbers[i]) & 1 << position;
                    bit = nAndMask >> position;
                    if (bit == 0)
                    {
                        counts[i]++;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int position = 0; position < 32; position++)
                {
                    nAndMask = ((int)numbers[i]) & 1 << position;
                    bit = nAndMask >> position;
                    if (bit != 0)
                    {
                        counts[i]++;
                    }
                }
            }   
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(counts[i]);
        }
    }
}
