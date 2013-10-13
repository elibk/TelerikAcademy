////

namespace H02TypesOfPeople
{
    using System;
    using System.Linq;
    using System.Text;

    public class Worker : Human
    {
        private readonly byte numberOfWorkDays = 5;
        private uint weekSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string secondName, uint weekSalary, float workHoursPerDay) : base(firstName, secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public byte NumberOfWorkDays
        {
            get
            {
                return this.numberOfWorkDays;
            }
        }

        public uint WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for weekSalary should be positive");
                }

                this.weekSalary = value;
            }
        }

        public float WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for workHoursPerDay should be positive");
                }

                if (value > 24)
                {
                    throw new ArgumentException("The value for workHoursPerDay should be less than 24");
                }

                this.workHoursPerDay = value;
            }
        }

        public double MoneyPerHour()
        {
            double moneyPerHour = (this.weekSalary / this.numberOfWorkDays) / this.workHoursPerDay;
            return moneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder("Worker:");
            info.Append(this.FirstName);
            info.Append(" ");
            info.Append(this.SecondName);
            info.Append(" WeekSalary:");
            info.Append(this.WeekSalary);
            info.Append(" Work Hours Per Day:");
            info.Append(this.WorkHoursPerDay);

            return info.ToString();
        }
    }
}
