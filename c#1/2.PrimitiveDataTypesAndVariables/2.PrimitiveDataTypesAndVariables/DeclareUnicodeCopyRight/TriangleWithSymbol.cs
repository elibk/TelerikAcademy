using System;
using System.Text;

class TriangleWithSymbol
{
    static void Main()
    {
        char symbol = '\u00A9';
        // Console.OutputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("   {0}\n  {0} {0} \n {0} {0} {0}", symbol);

    }
}
//using System;
//using System.Text;

//class IsoscelesTriangle
//{
//    static void Main()
//    {
//   // Console.OutputEncoding = Encoding.Unicode;
//        Console.OutputEncoding = Encoding.UTF8;
//        char symbol = '\u00A9';
//    char space = ' ';
//    int spaceCount = 4;
//    int copyrightCount = 1;
//        for (int row = 1; row <= 4; row++)
//        {
//            for (int j = 1; j <= spaceCount; j++)
//            {
//                Console.Write(space);
//                if (j==spaceCount)
//                {
//                    for (int i = 1; i <= copyrightCount; i++)
//                    {
//                        Console.Write(symbol);
//                    }
//                    copyrightCount = copyrightCount + 2;
//                }
//            }
//            spaceCount--;
//            Console.WriteLine();
//        }
//    }
//}