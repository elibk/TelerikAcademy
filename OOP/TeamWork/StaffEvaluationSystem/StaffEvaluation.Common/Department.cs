////
namespace StaffEvaluation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        private string name;
        private List<Worker> workers;
        private Manager departmentManager;

        public Department(string name, Manager manager, List<Worker> workers)
        {
            this.Name = name;
            this.Workers = workers;
            this.DepartmentManager = manager;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public List<Worker> Workers
        {
            get
            {
                return this.workers;
            }

            set
            {
                this.workers = value;
            }
        }

        public Manager DepartmentManager
        {
            get
            {
                return this.departmentManager;
            }

            set
            {
                this.departmentManager = value;
            }
        }
    }
}
