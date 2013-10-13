////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public class Manager : Staff
    {
        public Manager(string firstName, string lastName, byte age, int employeeID) : base(firstName, lastName, age, employeeID)
        { 
        }

        public override string ToString()
        {
            return base.ToString() + "|" + GetType().Name;
        }

        public override string ToTableView()
        {
            return base.ToTableView();
        }
    }
}
