﻿using System;

class TypeCasting
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object greeting = hello + " " + world+"!";
        string greetingString = (string)greeting;
        Console.WriteLine(greetingString);

    }
}
