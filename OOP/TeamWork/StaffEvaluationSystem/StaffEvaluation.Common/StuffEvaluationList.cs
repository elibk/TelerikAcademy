////
namespace StaffEvaluation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StaffEvaluationList<T> : List<T>, IEvaluetable
        where T : Department
    {
        public event EventHandler<StaffEventArgs> PromoteEvent; 

        public event EventHandler<StaffEventArgs> DemoteEvent;

        public event EventHandler<StaffEventArgs> NormalEvent;

        public void Evaluate(int id, int mark)
        {
            if (mark > 1 || mark < -1)
            {
                throw new EvaluationSystemException("Values for mark must be in range [-1,1].", new ArgumentOutOfRangeException());
            }

            Worker w = SearchInAllDepartments(id);

            if (w == null)
            {
                throw new EvaluationSystemException(string.Format("There is no such worker ID={0}.", id), new ArgumentNullException());
            }

            if (w.IsEvaluted)
            {
                throw new EvaluationSystemException("That worker is already evaluated.", new ArgumentException());
            }

            w.Rate += (sbyte)mark;
            w.IsEvaluted = true;

            if ((w.Rate == 3 && mark > 0) || (w.Rate == 8 && mark < 0))
            {
                NormalEvent(this, new StaffEventArgs { StaffEvaluationListID = id });
            }

            if (w.Rate < 3)
            {
                DemoteEvent(this, new StaffEventArgs { StaffEvaluationListID = id });
            }

            if (w.Rate > 8)
            {
                PromoteEvent(this, new StaffEventArgs { StaffEvaluationListID = id });
            }
        }

        public Worker SearchInAllDepartments(int id)
        {
            foreach (var item in this)
            {
                if ((item as Department).Workers.Exists(t => t.EmployeeID == id))
                {
                    return item.Workers.Find(t => t.EmployeeID == id);
                }
            }

            return null;
        }

        public List<Worker> ListOfWorkersInDepartment(string departmentName)
        {
            foreach (var item in this)
            {
                if ((item as Department).Name.ToLower() == departmentName.ToLower())
                {
                    return item.Workers;
                }
            }

            return null;
        }

        public List<Tuple<string, Manager>> ListOfManagersAndDeparments()
        {
            List<Tuple<string, Manager>> result = new List<Tuple<string, Manager>>();
            
            foreach (var department in this)
            {
                result.Add(new Tuple<string, Manager>(department.Name, department.DepartmentManager));
            }

            return result;
        }

        public List<Worker> ListOfAllWorkers()
        {
            List<Worker> resultList = new List<Worker>();

            foreach (var dep in this)
            {
                foreach (var worker in (dep as Department).Workers)
                {
                    resultList.Add(worker);
                }
            }

            return resultList;
        }
    }
}
