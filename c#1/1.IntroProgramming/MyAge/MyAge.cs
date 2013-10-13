//Calculate what your age will be after 10 years.
using System;

class MyAge
{
    static void Main()
    {
        Console.WriteLine("Please enter your age:");
        byte age = byte.Parse(Console.ReadLine());
        Console.WriteLine("After 10 year you'll be {0}.", age + 10);
    }
}