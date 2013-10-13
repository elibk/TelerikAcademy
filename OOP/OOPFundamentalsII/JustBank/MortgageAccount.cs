////
namespace JustBank
{
    using System;
    using System.Linq;

    public class MortgageAccount : BankAccount, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate) 
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
                if (periodInMonths <= 6)
                {
                    return 0;
                }

                return base.CalculateInterestAmount(periodInMonths - 6);
            }
            else if (this.Customer is BusinessCutomer)
            {
                if (periodInMonths <= 12)
                {
                    return base.CalculateInterestAmount(periodInMonths / 2);
                }

                return base.CalculateInterestAmount(periodInMonths / 2) + base.CalculateInterestAmount(periodInMonths - 12);
            }

            throw new InvalidOperationException("You work with unrecodnise type of cutomer.");
        }
    }
}
