////
namespace JustBank
{
    using System;
    using System.Linq;

    public class LoanAccount : BankAccount, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public void DepositeMoney(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterestAmount(uint periodInMonths)
        {
            if (this.Customer is ResidentialCustomer)
            {
                if (periodInMonths <= 3)
                {
                    return 0;
                }

                return base.CalculateInterestAmount(periodInMonths - 3);
            }
            else if (this.Customer is BusinessCutomer)
            {
                if (periodInMonths <= 2)
                {
                    return 0;
                }

                return base.CalculateInterestAmount(periodInMonths - 2);
            }

            throw new InvalidOperationException("You work with unrecodnise type of cutomer.");
        }
    }
}
