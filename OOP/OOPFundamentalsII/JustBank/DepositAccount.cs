////
namespace JustBank
{
    using System;
    using System.Linq;

   public class DepositAccount : BankAccount, IDepositable, IDraw
    {
       public DepositAccount(Customer customer, decimal balance, decimal interestRate)
           : base(customer, balance, interestRate)
        {
        }

       public void DepositeMoney(decimal amount)
       {
           this.Balance += amount;
       }

       public void DrawMoney(decimal amount)
       {
           this.Balance -= amount;
       }

       public override decimal CalculateInterestAmount(uint periodInMonths)
       {
           if (this.Balance < 1000)
           {
               return 0;
           }

           return base.CalculateInterestAmount(periodInMonths);
       }
    }
}
