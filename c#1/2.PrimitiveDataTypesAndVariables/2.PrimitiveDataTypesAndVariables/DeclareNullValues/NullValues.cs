using System;

class NullValues
{
    static void Main()
    {
        int? num = null;
        Console.WriteLine("This is a integer with  value \"null\" -> " + num);
        string text = null;
        Console.WriteLine("This is a string with value \"null\" -> " + text);
        Console.WriteLine("As you see there is no differences between \"nothing\" for text and for number :)");
    }
}