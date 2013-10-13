////
namespace JustBank
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public abstract class BankAccount
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public BankAccount(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterestAmount(uint periodInMonths)
        {
            return periodInMonths * this.InterestRate;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(GetType().Name);
            info.Append(" ");
            info.Append(this.Customer);
            info.Append(" ");
            info.Append(string.Format(new CultureInfo("eu"), "Balance:{0:C}", this.Balance));
            info.Append(" ");
            info.Append(String.Format("Interest Rate:{0:P}", this.InterestRate));

            return info.ToString();
        }
    }
}
