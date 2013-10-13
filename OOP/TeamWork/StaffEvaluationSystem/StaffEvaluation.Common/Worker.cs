////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public class Worker : Staff
    {
        private sbyte rate;
        private bool isEvaluted;
        private WorkerStatus status;
    
        public Worker(string firstName, string lastName, byte age, int employeeID, sbyte rate, WorkerStatus status) : base(firstName, lastName, age, employeeID)
        {
            this.Rate = rate;           
            this.Status = status;
            this.IsEvaluted = false;
        }

        public sbyte Rate
        {
            get
            {
                return this.rate;
            }

            set
            {
                if (value < 0 || value > 10)
                {
                    throw new EvaluationSystemException("The value for 'Rate' must be in range [0:10] ", new ArgumentException());
                }

                this.rate = value;
            }
        }

        public bool IsEvaluted
        {
            get
            {
                return this.isEvaluted;
            }

            set
            {
                this.isEvaluted = value;
            }
        }

        public WorkerStatus Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + this.Rate + "|" + this.Status + "|";
        }

        public override string ToTableView()
        {
            return string.Format("{0}|{1,5}|{2,15}|", base.ToTableView(), this.Rate, this.Status);
        }
    }
}
