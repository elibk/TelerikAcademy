using System;

class BankAccountVariables 
{
    static void Main()
    {
        Console.WriteLine("Holder first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Holder middle name:");
        string middleName = Console.ReadLine();
        Console.WriteLine("Holder last name:");
        string lastName = Console.ReadLine();
        string bankName = "DSK";
        Console.WriteLine("IBAN:");
        string IBAN =Console.ReadLine();
        string BIC = "STSABGSF";
        Console.WriteLine("Numbers of tree credit cards associated with the account:");
        int firstCreditcard = int.Parse(Console.ReadLine());
        int secondCreditcard = int.Parse(Console.ReadLine());
        int tuirtCreditcard = int.Parse(Console.ReadLine());
        Console.WriteLine("Balance:");
        decimal balance = decimal.Parse(Console.ReadLine());
        Console.Write(
            " Bank account of:{0} {1} {2}\n Available amount of money:{3:C2} \n {4} (BIC: {5}) IBAN: {6}", firstName, middleName, lastName, balance, bankName, BIC, IBAN);

        Console.Write(
            "\n Credit card numbers associated with the account: {0}; {1}; {2};\n",firstCreditcard,secondCreditcard,tuirtCreditcard);
    }
}

