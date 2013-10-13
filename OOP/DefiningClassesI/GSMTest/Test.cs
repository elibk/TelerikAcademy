////
namespace GSMTest
{
    using System;
    using System.Linq;
    using JustGSM.AllFunctions;

   public class Test
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Advertisment();

            GSM[] collection = FillCatalog();

            PrintCatalog(collection);
        }

        private static void PrintCatalog(GSM[] collection)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var gsm in collection)
            {
                Console.WriteLine(gsm);
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        private static GSM[] FillCatalog()
        {
            GSM[] collection = new GSM[5];

            for (int i = 0; i < collection.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        collection[i] = new GSM("Unknown", "Privileg", "Pesho");
                        break;
                    case 1:
                        collection[i] = new GSM("Galaxy", "Samsung");
                        break;
                    case 2:
                        collection[i] = new GSM("Galaxy", "Samsung");
                        collection[i].Battery = new Battery("NexusExtended");
                        break;
                    case 3:
                        collection[i] = new GSM("Asha", "Nokia", 300, "Gay Richi", 
                            new Battery("NexusExtended", 600, 40, BatteryType.LiIon), new Display("65K", 3.5));
                        break;
                    case 4:
                        collection[i] = new GSM("5800", "Nokia", 150.90m);
                        break;

                    default:
                        break;
                }
            }

            return collection;
        }

        private static void Advertisment()
        {
            Console.WriteLine("A D V E R T I S M E N T");
            Console.WriteLine("Special offer!!!");
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
