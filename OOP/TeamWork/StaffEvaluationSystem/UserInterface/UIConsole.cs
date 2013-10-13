////
namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StaffEvaluation.Common;

    public class UIConsole : IUserIntarface
    {
       private Engine engine;

        public UIConsole()
        {
            this.engine = Engine.LoadEngine;
        }

        public void ShowStartScreen()
        {
            PrintHelp();
        }
        
        public void ProcessInput(string command)
        {
            switch (command.ToLower())
            {
                case "0":
                    PrintHelp();
                    break;
                case "1":
                    engine.SaveUpdates();
                    Environment.Exit(0);
                    break;

                case "2":
                    SearchByID();
                    break;

                case "3":
                    EvaluateByID();
                    break;

                case "4":
                    ShowAll();
                    break;

                case "5":
                    ShowAllManagers();
                    break;

                case "6":
                    ShowWorkersInDepartment();
                    break;

                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                    SortReports(command);
                    break;

                default:
                    Console.WriteLine("Please enter ONLY the number of the command you want.");
                    break;
            }

            Console.Write("Please enter the number of the command you want:");
        }

        #region ComamndsMethods
        private void SortByIDDes()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedById(engine.DepartmentList.ListOfAllWorkers(), true))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByIDAsc()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedById(engine.DepartmentList.ListOfAllWorkers(), false))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByAgeDes()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedByAge(engine.DepartmentList.ListOfAllWorkers(), true))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByAgeAsc()
        {
            UpperReportViewForSort();

            foreach (var worker in Report.ReturnWorkersSortedByAge(engine.DepartmentList.ListOfAllWorkers(), false))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByLastNameDes()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedByLastName(engine.DepartmentList.ListOfAllWorkers(), true))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByLastNameAsc()
        {
            UpperReportViewForSort();

            foreach (var worker in Report.ReturnWorkersSortedByLastName(engine.DepartmentList.ListOfAllWorkers(), false))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByFirstNameDes()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedByFirstName(engine.DepartmentList.ListOfAllWorkers(), true))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByFirstNameAsc()
        {
            UpperReportViewForSort();

            foreach (var worker in Report.ReturnWorkersSortedByFirstName(engine.DepartmentList.ListOfAllWorkers(), false))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByRateDes()
        {
            UpperReportViewForSort();
            foreach (var worker in Report.ReturnWorkersSortedByRate(engine.DepartmentList.ListOfAllWorkers(), true))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortByRateAsc()
        {
            UpperReportViewForSort();

            foreach (var worker in Report.ReturnWorkersSortedByRate(engine.DepartmentList.ListOfAllWorkers(), false))
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void SortReports(string command)
        {
            switch (command)
            {
                case "7":
                    SortByRateAsc();
                    break;

                case "8":
                    SortByRateDes();
                    break;

                case "9":
                    SortByFirstNameAsc();
                    break;

                case "10":
                    SortByFirstNameDes();
                    break;

                case "11":
                    SortByLastNameAsc();
                    break;

                case "12":
                    SortByLastNameDes();
                    break;
                case "13":
                    SortByAgeAsc();
                    break;

                case "14":
                    SortByAgeDes();
                    break;
                case "15":
                    SortByIDAsc();
                    break;

                case "16":
                    SortByIDDes();
                    break;
                default:
                    break;
            }
        }

        private void ShowWorkersInDepartment()
        {
            Console.Write("Enter Deparment Name: ");
            string departmentName = Console.ReadLine();
            List<Worker> result = engine.DepartmentList.ListOfWorkersInDepartment(departmentName);

            if (result != null)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("|{0,6}|{1,15}|{2,15}|{3,3}|{4,5}|{5,15}|", "ID", "First name", "Last name", "Age", "Rate", "Status");
                Console.WriteLine("------------------------------------------------------------------");

                foreach (var worker in result)
                {
                    Console.WriteLine(worker.ToTableView());
                }

                Console.WriteLine("------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Can not find deparment {0}.", departmentName);
            }
        }

        private void ShowAllManagers()
        {
            Console.WriteLine("-----------------------------Managers-----------------------------");
            Console.WriteLine("|{0,6}|{1,15}|{2,15}|{3,3}|{4,21}|", "ID", "First name", "Last name", "Age", "Department name");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var item in engine.DepartmentList.ListOfManagersAndDeparments())
            {
                Console.WriteLine("{0}|{1,21}|", item.Item2.ToTableView(), item.Item1);
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void ShowAll()
        {
            ShowAllManagers();

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("-----------------------------Workers------------------------------");
            Console.WriteLine("|{0,6}|{1,15}|{2,15}|{3,3}|{4,5}|{5,15}|", "ID", "First name", "Last name", "Age", "Rate", "Status");
            Console.WriteLine("------------------------------------------------------------------");

            foreach (var worker in engine.DepartmentList.ListOfAllWorkers())
            {
                Console.WriteLine(worker.ToTableView());
            }

            Console.WriteLine("------------------------------------------------------------------");
        }

        private void EvaluateByID()
        {
            Console.Write("Enter employee ID:");
            int id = int.Parse(Console.ReadLine());
            
            Worker evaluatedEmployer = engine.DepartmentList.SearchInAllDepartments(id);

            if (evaluatedEmployer != null)
            {
                Console.WriteLine("You are evaluating " + evaluatedEmployer.FirstName + " "
                                + evaluatedEmployer.LastName + " current rating " + evaluatedEmployer.Rate);
                Console.Write("Enter a mark (-1 or 1):");
                string mark = Console.ReadLine();
                try
                {
                    switch (mark)
                    {
                        case "-1":
                            engine.DepartmentList.Evaluate(id, -1);
                            Console.WriteLine("------------------------------------------------------------------");
                            Console.WriteLine("You just evaluated " + evaluatedEmployer.FirstName + " " + evaluatedEmployer.LastName
                                         + " with " + mark);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        case "1":
                            engine.DepartmentList.Evaluate(id, 1);
                            Console.WriteLine("------------------------------------------------------------------");
                            Console.WriteLine("You just evaluated " + evaluatedEmployer.FirstName + " " + evaluatedEmployer.LastName
                                        + " with " + mark);
                            Console.WriteLine("------------------------------------------------------------------");
                            break;
                        default:
                            Console.WriteLine("Invalid mark. The mark can be can be either 1 or -1.");
                            break;
                    } 
                }
                catch (EvaluationSystemException ex)
                {
                    if (evaluatedEmployer.IsEvaluted)
                    {
                        Console.WriteLine("You've already evaluated this woker.");
                    }
                    else
                    {
                        throw ex;
                    }
                }              
            }
            else
            {
                Console.WriteLine("Can not find worker with id {0}.", id);
            }
        }

        private void SearchByID()
        {
            Console.Write("Enter employee ID: ");
            int id = int.Parse(Console.ReadLine());
            Worker worker = engine.DepartmentList.SearchInAllDepartments(id);
           
            if (worker != null)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("|{0,6}|{1,15}|{2,15}|{3,3}|{4,5}|{5,15}|", "ID", "First name", "Last name", "Age", "Rate", "Status");
                Console.WriteLine("------------------------------------------------------------------");
                
                Console.WriteLine(worker.ToTableView());
                Console.WriteLine("------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Can not find worker with id {0}.", id);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("--------------------------Start-M E N U--------------------------");
            Console.WriteLine("(0) - help - show the menu");
            Console.WriteLine("(1) - exit - terminates the application");
            Console.WriteLine("(2) - search by ID - searches a specific employer by his unique id");
            Console.WriteLine("(3) - evaluate by ID - evaluates a specific employer by his unique id");

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("MenuReports-------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("(4) - shows all managers and workers");
            Console.WriteLine("(5) - shows all managers and their departments");
            Console.WriteLine("(6) - show all workers in chosen department");
            Console.WriteLine("(7) - sort workers by rate in ascending order");
            Console.WriteLine("(8) - sort workers by rate in descending order");
            Console.WriteLine("(9) - sort workers by name in ascending order");
            Console.WriteLine("(10) - sort workers by name in descending order");
            Console.WriteLine("(11) - sort workers by name in ascending order");
            Console.WriteLine("(12) - sort workers by name in descending order");
            Console.WriteLine("(13) - sort workers by age in ascending order");
            Console.WriteLine("(14) - sort workers by age in descending order");
            Console.WriteLine("(15) - sort workers by ID in ascending order");
            Console.WriteLine("(16) - sort workers by ID in descending order");

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Please enter the number of the command you want:");
        }
        #endregion

        private static void UpperReportViewForSort()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|{0,6}|{1,15}|{2,15}|{3,3}|{4,5}|{5,15}|", "ID", "First name", "Last name", "Age", "Rate", "Status");
            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}
