using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01Frames
{
    class Program
    {

        private static SortedSet<string> combinations;
        private static List<List<string>> frames;
        private static string[] currentCombination;
        private static bool[] used;
        private static int n;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            combinations = new SortedSet<string>();
            currentCombination = new string[n];
            frames = new List<List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(new char[]{' '}, 2);
                var current = new List<string>();
                frames.Add(current);
                current.Add(string.Format("({0}, {1})", data[0], data[1]));
                

                if (data[1] != data[0])
                {
                    current.Add(string.Format("({0}, {1})", data[1], data[0]));
                }
            }

            used = new bool[frames.Count];

            GenerateVariationsNoRepetitions(0);

            Console.WriteLine(combinations.Count);
            int index = 1;
            foreach (var item in combinations)
            {
                //Console.WriteLine(index++);
                Console.WriteLine(item);
            }
        }

        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= n)
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in currentCombination)
                {str.Append(' ');
                    str.Append(item);
                    str.Append(' ');
                    str.Append('|');
                }
                
                str.Length--;
                str.AppendLine();

                string result = str.ToString().Trim();
                if (!combinations.Contains(result))
                {
                    combinations.Add(result);
                }
 
            }
            else
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentCombination[index] = frames[i][0];
                        GenerateVariationsNoRepetitions(index + 1);
                        if (frames[i].Count > 1)
                        {
                            currentCombination[index] = frames[i][1];
                            GenerateVariationsNoRepetitions(index + 1);
                        }
                        
                        used[i] = false;
                    }
                }
            }
        }
    }
}
