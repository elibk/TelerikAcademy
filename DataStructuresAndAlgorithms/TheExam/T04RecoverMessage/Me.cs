using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04RecoverMessage
{
    class Me
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                if (!set.Contains(str))
                {
                    set.Add(str);
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in set)
            {
                Console.Write(item);
            }
        }
    }
}
