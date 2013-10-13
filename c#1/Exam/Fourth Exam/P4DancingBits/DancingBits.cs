using System;

class DancingBits
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int[] numbers = new int[N];
        string numberBits,check,bigSequenceOfBits = null;
//Dancing Bits
        string dancingBitZero = "1" + new string('0', K) + "1";
        string dancingBitOne = "0" + new string('1', K) + "0";
        string dancingBitZeroAtBeginning = new string('0', K) + "1";
        string dancingBitOneAtBeginning = new string('1', K) + "0";
        string dancingBitZeroAtEnd = "1" + new string('0', K);
        string dancingBitOneAtEnd = "0" + new string('1', K);

        int result = 0;
//Get numbers and their bits
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            numberBits = Convert.ToString(numbers[i], 2);
            bigSequenceOfBits += numberBits;
        }
//Check for Dancing bits
        if (K != bigSequenceOfBits.Length)
        {
            for (int i = 0; i < bigSequenceOfBits.Length - K; i++)
            {
                if (i > 0 && i < bigSequenceOfBits.Length - K)
                {
                    check = bigSequenceOfBits.Substring(i - 1, K + 2);
                    if (check == dancingBitZero || check == dancingBitOne)
                    {
                        result++;
                    }
                    if (i == bigSequenceOfBits.Length - K -1)
                    {
                        check = bigSequenceOfBits.Substring(i, K + 1);
                        if (check == dancingBitZeroAtEnd || check == dancingBitOneAtEnd)
                        {
                            result++;
                        }
                    }
                }
                else if (i == 0)
                {
                    check = bigSequenceOfBits.Substring(i, K + 1);
                    if (check == dancingBitZeroAtBeginning || check == dancingBitOneAtBeginning)
                    {
                        result++;
                    }
                }
            }
        }
        else
        {
            if (bigSequenceOfBits == new string('1', K) || bigSequenceOfBits == new string('0', K))
            {
                result = 1;
            }
        }
        Console.WriteLine(result);
    }
}