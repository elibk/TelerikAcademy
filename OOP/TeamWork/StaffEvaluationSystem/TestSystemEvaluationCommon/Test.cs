using StaffEvaluation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemEvaluationCommon
{
   public class Test
    {
       private static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            string[] firstNames = { "Atanas", "Anton", "Kiril", "Ivan", "Petko" };
            string[] lastNames = { "Atanasov", "Antonov", "Kirilov", "Ivanov", "Petkov" };
            string[] emails = { "rlalphonse@sault.com", "dpc31351@yahoo.com", "jamesw3300@aol.com", "rflynn-cv9@juno.com", "rbh1948@i-55.com" };

            List<Staff> staff = new List<Staff>();
            List<Client> clients = new List<Client>();

            for (int i = 0; i < 10; i++)
            {
                int randomName = RandomGenerator.Next(0,5);
                int randomAge = RandomGenerator.Next(18,120);
                int randomDep = RandomGenerator.Next(0,3);
                staff.Add(new Worker(firstNames[randomName], lastNames[randomName], (SByte)randomAge, 5, (Department)randomDep));
            }

            for (int i = 0, dep = 0; i < 3; i++,dep ++)
            {
                int randomName = RandomGenerator.Next(0, 5);
                int randomAge = RandomGenerator.Next(18, 120);

                staff.Add(new Manager(firstNames[randomName], lastNames[randomName], (SByte)randomAge, 5, (Department)dep));
            }

            for (int i = 0; i < 20; i++)
            {
                int randomName = RandomGenerator.Next(0, 5);
                int randomAge = RandomGenerator.Next(18, 120);
                int randomEmail = RandomGenerator.Next(0, 5);
                clients.Add(new Client(firstNames[randomName], lastNames[randomName], (SByte)randomAge, emails[randomEmail]));
            }

            foreach (var client in clients)
            {
                
                client.Evaluate(staff[0],2);
                
            }

            List<Person> people = new List<Person>();
            people.AddRange(staff);
            people.AddRange(clients);
            PrintOnConsole(people);
        }

        private static void PrintOnConsole(IEnumerable<Person> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
                
               
            }
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}
