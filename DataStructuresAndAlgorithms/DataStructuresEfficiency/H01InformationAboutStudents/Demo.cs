namespace H01InformationAboutStudents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Demo
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, OrderedBag<Student>> repository = new SortedDictionary<string, OrderedBag<Student>>();

            ReadInput("students.txt", repository);

            foreach (var item in repository)
            {
                Console.Write("{0} : ", item.Key);
                int count = 1;
                foreach (var student in item.Value)
                {
                    Console.Write("{0}", student);
                    if (count != item.Value.Count)
                    {
                        Console.Write(", ");
                    }

                    count++;
                }

                Console.WriteLine();
            }
        }

        private static void ReadInput(string path, SortedDictionary<string, OrderedBag<Student>> repository)
        {
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split('|');
                    data[0] = data[0].Trim();
                    data[1] = data[1].Trim();
                    data[2] = data[2].Trim();

                    OrderedBag<Student> currentCourse = null;
                    if (repository.TryGetValue(data[2], out currentCourse))
                    {
                        currentCourse.Add(new Student(data[0], data[1]));
                    }
                    else
                    {
                        repository.Add(data[2], new OrderedBag<Student> { new Student(data[0], data[1]) });
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
