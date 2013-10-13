////

namespace TypesOfAnimalTest
{
    using System;
    using System.Linq;
    using H03TypesOfAnimals;

    public class Test
    {
        private static void Main(string[] args)
        {
            ISound[] animals = FillArray();

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.Sound());
            }

            double dogsAverigeAge = 0;
            int countDogs = 0;

            double frogsAverigeAge = 0;
            int countFrogs = 0;

            double kittenAverigeAge = 0;
            int countKitten = 0;

            double tomcatsAverigeAge = 0;
            int countTomcats = 0;

            foreach (Animal item in animals)
            {
                if (item is Dog)
                {
                    dogsAverigeAge += item.Age;
                    countDogs++;
                }
                else if (item is Frog)
                {
                    frogsAverigeAge += item.Age;
                    countFrogs++;
                }
                else if (item is Kitten)
                {
                    kittenAverigeAge += item.Age;
                    countKitten++;
                }
                else if (item is Tomcat)
                {
                    tomcatsAverigeAge += item.Age;
                    countTomcats++;
                }
            }

            Console.WriteLine(new string('-', 12));
            dogsAverigeAge /= countDogs;
            frogsAverigeAge /= countFrogs;
            kittenAverigeAge /= countKitten;
            tomcatsAverigeAge /= countTomcats;

            Console.WriteLine("Dogs averige age " + dogsAverigeAge);
            Console.WriteLine("Frogs averige age " + frogsAverigeAge);
            Console.WriteLine("Kittens averige age " + kittenAverigeAge);
            Console.WriteLine("Tomcats averige age " + tomcatsAverigeAge);
        }

        private static ISound[] FillArray()
        {
            ISound[] animals = new ISound[10];
            string[] namesF = { "Bella", "Lara", "Daisy", " Layla", "Lily" };
            string[] namesM = { "Rocco", "Buddy", "Rusty", "Scooter", "Spike" };

            Random randomGenerator = new Random();
            for (int i = 0; i < animals.Length; i++)
            {
                int nameIndex = randomGenerator.Next(0, 5);
                int age = randomGenerator.Next(0, 21);

                switch (i)
                {
                    case 0:
                    case 1:
                        animals[i] = new Dog(namesM[nameIndex], (sbyte)age, Sex.Male);
                        break;
                    case 2:
                    case 3:
                        animals[i] = new Dog(namesF[nameIndex], (sbyte)age, Sex.Female);
                        break;
                    case 4:
                        animals[i] = new Frog(namesM[nameIndex], (sbyte)age, Sex.Male);
                        break;
                    case 5:
                        animals[i] = new Frog(namesF[nameIndex], (sbyte)age, Sex.Female);
                        break;
                    case 6:
                    case 7:
                        animals[i] = new Tomcat(namesM[nameIndex], (sbyte)age);
                        break;
                    case 8:
                    case 9:
                        animals[i] = new Kitten(namesF[nameIndex], (sbyte)age);
                        break;
                    default:
                        break;
                }
            }

            return animals;
        }
    }
}
