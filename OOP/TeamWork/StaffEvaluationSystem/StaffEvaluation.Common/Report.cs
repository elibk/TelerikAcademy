////
namespace StaffEvaluation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Report
    {
        public static List<Worker> ReturnWorkersSortedById(List<Worker> staffList, bool descendingOrder)
        {
            List<Worker> orderedList = new List<Worker>();
            if (descendingOrder)
            {
                orderedList.AddRange(from staff in staffList orderby staff.EmployeeID descending select staff);
            }
            else
            {
                orderedList.AddRange(from staff in staffList orderby staff.EmployeeID select staff);
            }

            return orderedList;
        }

        public static List<Worker> ReturnWorkersSortedByRate(List<Worker> workersList, bool descendingOrder)
        {
            List<Worker> orderedList = new List<Worker>();
            if (descendingOrder)
            {
                orderedList.AddRange(from worker in workersList orderby worker.Rate descending select worker);
            }
            else
            {
                orderedList.AddRange(from worker in workersList orderby worker.Rate select worker);
            }

            return orderedList;
        }

        public static List<Worker> ReturnWorkersSortedByFirstName(List<Worker> personList, bool descendingOrder)
        {
            List<Worker> orderedList = new List<Worker>();
            if (descendingOrder)
            {
                orderedList.AddRange(from person in personList orderby person.FirstName, person.LastName descending select person);
            }
            else
            {
                orderedList.AddRange(from person in personList orderby person.FirstName, person.LastName select person);
            }

            return orderedList;
        }

        public static List<Worker> ReturnWorkersSortedByLastName(List<Worker> personList, bool descendingOrder)
        {
            List<Worker> orderedList = new List<Worker>();
            if (descendingOrder)
            {
                orderedList.AddRange(from person in personList orderby person.LastName, person.FirstName descending select person);
            }
            else
            {
                orderedList.AddRange(from person in personList orderby person.LastName, person.FirstName select person);
            }

            return orderedList;
        }

        public static List<Worker> ReturnWorkersSortedByAge(List<Worker> personList, bool descendingOrder)
        {
            List<Worker> orderedList = new List<Worker>();
            if (descendingOrder)
            {
                orderedList.AddRange(from person in personList orderby person.Age descending select person);
            }
            else
            {
                orderedList.AddRange(from person in personList orderby person.Age select person);
            }

            return orderedList;
        }
    }
}
