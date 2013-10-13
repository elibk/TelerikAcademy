using System;

class ExchangeBitsOfUint
{
    static void Main()
    {

        Console.Write("Enter an unsigned integer:");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine(
            "The bitwise representation of your number ({0}) is : {1}"
            , number, Convert.ToString(number, 2).PadLeft(32, '0'));
        uint bit3 = (number & (1 << 3)) >> 3;
        uint bit4 = (number & (1 << 4)) >> 4;
        uint bit5 = (number & (1 << 5)) >> 5;
        uint bit24 = (number & (1 << 24)) >> 24;
        uint bit25 = (number & (1 << 25)) >> 25;
        uint bit26 = (number & (1 << 26)) >> 26;
        number = (uint)(number & (~(1 << 3)) & (~(1 << 4)) & (~(1 << 5)) & (~(1 << 24)) & (~(1 << 25)) & (~(1 << 26)));
        number = number | (bit3 << 24) | (bit4 << 25) | (bit5 << 26) | (bit24 << 3) | (bit25 << 4) | (bit26 << 5);
        
        Console.WriteLine("After we exchanged bits 3,4,5 whit bits 24,25,26 the number now is ({0}) and its bitwise representation is : {1}", number, Convert.ToString(number, 2).PadLeft(32, '0')); 
    }
}
