﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02RandomNumbers
{
    class RandomNumbers
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random{};

            for (int count = 1; count <= 10; count++)
            {
                Console.WriteLine("Random {1}: {0}",randomGenerator.Next(100,201),count);
            }
        }
    }
}
