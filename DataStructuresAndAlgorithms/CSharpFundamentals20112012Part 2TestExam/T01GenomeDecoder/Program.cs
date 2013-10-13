using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01GenomeDecoder
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(' ');
            string encodedGenome = Console.ReadLine();
            encodedGenome = encodedGenome.Trim();
            int lineLenght = int.Parse(data[0]);
            int genomeMaxLenght = int.Parse(data[1]);

            string decodedGenome = DecodeGenome(encodedGenome);
            PrintResult(decodedGenome, lineLenght, genomeMaxLenght);
            
        }

        private static void PrintResult(string decodedGenome, int lineLenght, int genomeMaxLenght)
        {
            StringBuilder line = new StringBuilder();
            StringBuilder genome = new StringBuilder();
            int linesCount = (int)Math.Round(decodedGenome.Length / (double)lineLenght);
            lineLenght = lineLenght + lineLenght / genomeMaxLenght;
            string lineStr;
            int minLenghtOflineCounter = linesCount.ToString().Length;
            int lineNumber = 1;
           
            for (int i = 0; i < decodedGenome.Length; i++)
            {
                if (line.Length + genome.Length >= lineLenght)
                {
                    line.Append(genome);
                    genome.Clear();
                    lineStr = line.ToString().Trim();
                    Console.WriteLine("{0} {1}", lineNumber++.ToString().PadLeft(minLenghtOflineCounter), lineStr);
                    line.Clear();
                }

                genome.Append(decodedGenome[i]);
                if (genome.Length == genomeMaxLenght)
                {
                    line.Append(genome);
                    line.Append(" ");
                    genome.Clear();
                }
            }

            line.Append(genome);
            lineStr = line.ToString().Trim();
            Console.WriteLine("{0} {1}", lineNumber++, lineStr);

        }

        private static string DecodeGenome(string encodedGenome)
        {
            StringBuilder number = new StringBuilder();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < encodedGenome.Length; i++)
            {
                if (encodedGenome[i] >= '0' && encodedGenome[i] <= '9')
                {
                    number.Append(encodedGenome[i]);
                }
                else
                {
                    int currentGenomeLenght = 1;
                    if (number.Length > 0)
                    {
                        currentGenomeLenght = int.Parse(number.ToString());
                        number.Clear();
                    }

                    for (int j = 0; j < currentGenomeLenght; j++)
                    {
                        result.Append(encodedGenome[i]);
                    }
                }
            }
            return result.ToString();
        }
    }
}
