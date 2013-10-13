using System;

class DeclareASCII
{
    static void Main()
    {
        byte symbol = 0;
        byte position =0;
  
        while (symbol < 127)
        {
            symbol++;
            position++;
            Console.WriteLine("Under position {0} is symbol {1}",position,(char)symbol);
            if (position == 7)
            {
                Console.WriteLine("\"bell ring\"");
            }
            if (position == 8)
            {
                Console.WriteLine("\"BS\"");
            }
            if (position == 9)
            {
                Console.WriteLine("\"TAB\"");
            }
            if (position == 10)
            {
                Console.WriteLine("\"New line\"");
            }
            if (position == 13)
            {
                Console.WriteLine("\"carriage return\"");
            }  
        }
    }
}