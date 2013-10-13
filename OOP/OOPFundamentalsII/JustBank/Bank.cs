////
namespace JustBank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bank
    {
        private string name;
        private ICollection<BankAccount> accounts;

        public Bank(string name, ICollection<BankAccount> residentialCustomers)
        {
            this.Name = name;
            this.Accounts = residentialCustomers;
        }

        public ICollection<BankAccount> Accounts
        {
            get
            {
                return this.accounts;
            }

            set
            {
                this.accounts = value;
            }
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
    }
}
