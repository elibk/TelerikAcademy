////
namespace StaffEvaluation.Common
{
    using System;
    using System.IO;
    using System.Linq;

    public static class SuperFileWriter
    {
        ////Added by Ivailo
        public static void UpdateFiles(StaffEvaluationList<Department> listOfDepartments)
        {
            StreamWriter writer = new StreamWriter(".../.../.../Data/Updates.txt", false);
            using (writer)
            {
                for (int i = 0; i < listOfDepartments.Count; i++)
                {
                    if (listOfDepartments[i].Workers[i].EmployeeID < 2000)
                    {
                        StreamWriter CSWriter = new StreamWriter(".../.../.../Data/customer services.txt", false);
                        using (CSWriter)
                        {
                            CSWriter.WriteLine(listOfDepartments[i].DepartmentManager);
                            for (int index = 0; index < listOfDepartments[i].Workers.Count; index++)
                            {
                                CSWriter.WriteLine(listOfDepartments[i].Workers[index]);
                            }
                        }
                    }
                    else if (listOfDepartments[i].Workers[i].EmployeeID > 2000 && listOfDepartments[i].Workers[i].EmployeeID < 3000)
                    {
                        StreamWriter EWriter = new StreamWriter(".../.../.../Data/engineering.txt", false);
                        using (EWriter)
                        {
                            EWriter.WriteLine(listOfDepartments[i].DepartmentManager);
                            for (int index = 0; index < listOfDepartments[i].Workers.Count; index++)
                            {
                                EWriter.WriteLine(listOfDepartments[i].Workers[index]);
                            }
                        }
                    }
                    else
                    {
                        StreamWriter SWriter = new StreamWriter(".../.../.../Data/Sales.txt", false);
                        using (SWriter)
                        {
                            SWriter.WriteLine(listOfDepartments[i].DepartmentManager);
                            for (int index = 0; index < listOfDepartments[i].Workers.Count; index++)
                            {
                                SWriter.WriteLine(listOfDepartments[i].Workers[index]);
                            }
                        }
                    }
                }
            }
        }
    }
}
