////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public abstract class Staff : Person
    {
        private int employeeID;
      
        public Staff(string firstName, string lastName, byte age, int employeeID) : base(firstName, lastName, age)
        {
            this.EmployeeID = employeeID;
        }

        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }

            protected set
            {
                this.employeeID = value;
            }
        }

        public override string ToString()
        {
            return this.EmployeeID + "|" + base.ToString();
        }

        public override string ToTableView()
        {
            return string.Format("|{0,6}{1}", this.EmployeeID, base.ToTableView());
        }
    }
}
