////
namespace H05ConvertHexadecimalNumbersToBinary
{
    using System;
    using System.Linq;

   public class ConvertHexadecimalNumbersToBinary
    {
       private static void Main(string[] args)
        {
            string hexNum = Console.ReadLine();
            string bunaryNum = string.Empty;

            for (int i = 0; i < hexNum.Length; i++)
            {
                switch (hexNum[i])
                {
                    case '1':
                        bunaryNum += "0001";
                        break;
                    case '2':
                        bunaryNum += "0010";
                        break;
                    case '3':
                        bunaryNum += "0011";
                        break;
                    case '4':
                        bunaryNum += "0100";
                        break;
                    case '5':
                        bunaryNum += "0101";
                        break;
                    case '6':
                        bunaryNum += "0110";
                        break;
                    case '7':
                        bunaryNum += "0111";
                        break;
                    case '8':
                        bunaryNum += "1000";
                        break;
                    case '9':
                        bunaryNum += "1100";
                        break;
                    case 'A':
                        bunaryNum += "1010";
                        break;
                    case 'B':
                        bunaryNum += "1011";
                        break;
                    case 'C':
                        bunaryNum += "1100";
                        break;
                    case 'D':
                        bunaryNum += "1101";
                        break;
                    case 'E':
                        bunaryNum += "1110";
                        break;
                    case 'F':
                        bunaryNum += "1111";
                        break;
                    default:
                        bunaryNum += "0000";
                        break;
                }
            }

            Console.WriteLine(bunaryNum.PadLeft(32, '0'));
        }
    }
}
