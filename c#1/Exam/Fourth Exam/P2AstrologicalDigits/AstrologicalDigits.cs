using System;
class AstrologicalDigits
{
    static void Main(string[] args)
    {

        string number = Console.ReadLine();
        decimal astroNum = 0;
        bool result = decimal.TryParse(number,out astroNum);


        while (number.Length > 1)
        {               
            astroNum = 0;
            foreach (var item in number)
            {
                switch (item)
                {
                    case '-':
                    case '.':
                        break;
                    default:
                        astroNum += (item - '0');
                        break;
                }
            }
            number = Convert.ToString(astroNum);
        }
        Console.WriteLine(astroNum);
           
               
    }
}
