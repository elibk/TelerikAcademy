////
namespace StaffEvaluation.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class SuperFileLoader
    {
        public static StaffEvaluationList<Department> LoadData()
        {
            StreamReader reader;
            StaffEvaluationList<Department> result = new StaffEvaluationList<Department>();
            List<string> departmentsNames = new List<string>();
            try
            {
                reader = new StreamReader(".../.../.../Data/DepartmetsNames.txt");
                using (reader)
                {
                    string currrentLine = reader.ReadLine();

                    while (currrentLine != null)
                    {
                        departmentsNames.Add(currrentLine);
                        currrentLine = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The File DepartmetsNames.txt is missing.");
            }

            for (int i = 0; i < departmentsNames.Count; i++)
            {
                reader = new StreamReader(".../.../.../Data/" + departmentsNames[i] + ".txt");
                using (reader)
                {
                    string currrentLine = reader.ReadLine();
                    Manager manager = ReadManager(currrentLine);
                    List<string> workers = new List<string>();
                    currrentLine = reader.ReadLine();

                    while (currrentLine != null)
                    {
                        workers.Add(currrentLine);
                        currrentLine = reader.ReadLine();
                    }

                    result.Add(new Department(departmentsNames[i], manager, ReadWorkers(workers)));
                }
            }

            return result;
        }

        public static List<Client> LoadClients()
        {
            List<Client> resultList = new List<Client>();
            StreamReader reader;
            try
            {
                reader = new StreamReader(".../.../.../Data/Clients.txt");
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    resultList.Add(ReadClientLine(currentLine));
                    currentLine = reader.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The File Clients.txt is missing.");
            }

            return resultList;
        }

        public static List<Worker> ReadWorkers(List<string> workersList)
        {
            List<Worker> result = new List<Worker>();
            foreach (var item in workersList)
            {
                string[] arr;
                arr = item.Split('|');
                Worker worker = new Worker(arr[1], arr[2], byte.Parse(arr[3]), int.Parse(arr[0]), sbyte.Parse(arr[4]), (WorkerStatus)Enum.Parse(typeof(WorkerStatus), arr[5]));
                result.Add(worker);
            }

            return result;
        }

        private static Manager ReadManager(string managerStr)
        {
            string[] managerData = managerStr.Split('|');

            return new Manager(managerData[1], managerData[2], byte.Parse(managerData[3]), int.Parse(managerData[0]));
        }

        private static Client ReadClientLine(string clientstr)
        {
            string[] clientArr = clientstr.Split('|');
            return new Client(byte.Parse(clientArr[2]), clientArr[3], clientArr[0], clientArr[1]);
        }
    }
}
