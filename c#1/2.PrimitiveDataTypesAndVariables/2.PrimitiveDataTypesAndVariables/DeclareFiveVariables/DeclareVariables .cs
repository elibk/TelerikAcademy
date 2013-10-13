using System;

class DeclareVariables
{
    static void Main()
    {
        byte verySmallPositiveNum = 97;
        sbyte verySmallNum = -115;
        ushort smallPositiveNum = 52130;
        int regularNum = -100000;
        uint regularPostiveNum = 4825932;

        Console.WriteLine("This numbers be both positive and nagative:{0},{1}",verySmallNum,regularNum);
        Console.WriteLine("This numbers are only positive:{0},{1},{2}", verySmallPositiveNum, smallPositiveNum, regularPostiveNum);
    }

}