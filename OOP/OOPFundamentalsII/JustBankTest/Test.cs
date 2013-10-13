////
namespace JustBankTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using JustBank;

   public class Test
    {
       private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("eu");
            List<BankAccount> accounts = new List<BankAccount>();

            accounts.Add(new DepositAccount(new ResidentialCustomer("baba Tonka", "2904165534"), 1200, 0.025m));
            accounts.Add(new LoanAccount(new BusinessCutomer("Dalaveri OOD", "Pesho Dalaverata", "200300123"), 5000, 0.085m));
            accounts.Add(new LoanAccount(new ResidentialCustomer("Ivan Ivanov", "7503024434"), 7000, 0.095m));
            accounts.Add(new MortgageAccount(new BusinessCutomer("Dalaveri OOD", "Pesho Dalaverata", "200300123"), 45000, 0.07m));
            accounts.Add(new MortgageAccount(new ResidentialCustomer("Ivan Ivanov", "7503024434"), 65000, 0.08m));

            //// GDI - Grabim Dokato Ima
            Bank bank = new Bank("GDI", accounts);
            uint months = 6;
            foreach (var account in bank.Accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("InterestAmount for {0} months : {1:P}.", months, account.CalculateInterestAmount(months));
            }

            decimal someMoney = 200;

            Console.WriteLine(new string('-', Console.WindowWidth));

            DepositAccount deposit = new DepositAccount(new ResidentialCustomer("baba Tonka", "2904165534"), 1200, 0.025m);
            Console.WriteLine("{0} opened a deposit with balance {1:C}.", deposit.Customer, deposit.Balance);
            Console.WriteLine("{0} drows {1:C}.", deposit.Customer, someMoney);
            deposit.DrawMoney(someMoney);
            Console.WriteLine("Now the balance is {0:C}.", deposit.Balance);
            Console.WriteLine("Than she deposits {0:C}", someMoney);
            deposit.DepositeMoney(someMoney);
            Console.WriteLine("Now the balance is {0:C}.", deposit.Balance);

            Console.WriteLine(new string('-', Console.WindowWidth));

            LoanAccount loan = new LoanAccount(new ResidentialCustomer("Ivan Ivanov", "7503024434"), 7000, 0.095m);
            Console.WriteLine("{0} took loan with balance {1:C}.", loan.Customer, loan.Balance);
            Console.WriteLine("{0} deposits {1:C}.", loan.Customer, someMoney);
            loan.DepositeMoney(someMoney);
            Console.WriteLine("Now the balance is {0:C}.", loan.Balance);

            Console.WriteLine(new string('-', Console.WindowWidth));

            MortgageAccount mortage = new MortgageAccount(new BusinessCutomer("Dalaveri OOD", "Pesho Dalaverata", "200300123"), 45000, 0.07m);
            Console.WriteLine("{0} made mortage with balance {1:C}.", mortage.Customer, mortage.Balance);
            Console.WriteLine("{0} deposits {1:C}.", mortage.Customer, someMoney);
            mortage.DepositeMoney(someMoney);
            Console.WriteLine("Now the balance is {0:C}.", mortage.Balance);
        }
    }
}
