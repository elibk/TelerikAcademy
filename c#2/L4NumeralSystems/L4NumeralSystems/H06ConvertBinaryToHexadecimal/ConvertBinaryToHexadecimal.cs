////
namespace H06ConvertBinaryToHexadecimal
{
    using System;
    using System.Linq;

   public class ConvertBinaryToHexadecimal
    {
       private static void Main(string[] args)
        {
            string binaryNum = Console.ReadLine();
            string hexadecimalNum = string.Empty;

            binaryNum = binaryNum.PadLeft(32, '0');

            for (int i = 0; i < binaryNum.Length; i += 4)
            {              
                switch (binaryNum.Substring(i, 4))
                {
                    case "0001":
                        hexadecimalNum += '1';
                        break;
                    case "0010":
                        hexadecimalNum += '2';
                        break;
                    case "0011":
                        hexadecimalNum += '3';
                        break;
                    case "0100":
                        hexadecimalNum += '4';
                        break;
                    case "0101":
                        hexadecimalNum += '5';
                        break;
                    case "0110":
                        hexadecimalNum += '6';
                        break;
                    case "0111":
                        hexadecimalNum += '7';
                        break;
                    case "1000":
                        hexadecimalNum += '8';
                        break;
                    case "1001":
                        hexadecimalNum += '9';
                        break;
                    case "1010":
                        hexadecimalNum += 'A';
                        break;
                    case "1011":
                        hexadecimalNum += 'B';
                        break;
                    case "1100":
                        hexadecimalNum += 'C';
                        break;
                    case "1101":
                        hexadecimalNum += 'D';
                        break;
                    case "1110":
                        hexadecimalNum += 'E';
                        break;
                    case "1111":
                        hexadecimalNum += 'F';
                        break;
                    default:
                        hexadecimalNum += '0';
                        break;
                }
            }

            bool isntZero = false;
            for (int i = 0; i < hexadecimalNum.Length; i++)
            {
                if (hexadecimalNum[i] != '0')
                {
                    isntZero = true;
                    hexadecimalNum = hexadecimalNum.Substring(i);
                    break;
                }
            }

            if (isntZero)
            {
              Console.WriteLine(hexadecimalNum);
            }
            else
            {
                hexadecimalNum = "0";
                Console.WriteLine(hexadecimalNum);
            }
        }
    }
}
