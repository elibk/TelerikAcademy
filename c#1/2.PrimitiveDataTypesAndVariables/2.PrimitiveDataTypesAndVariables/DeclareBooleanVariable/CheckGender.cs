using System;

class CheckGender
{
    static void Main()
    {
        Console.WriteLine("Are you a woman(write \"f\"), or a man (write \"m\")?");
        char gender = Convert.ToChar(Console.ReadLine());

        bool isFemale = (gender == 'f');
        bool isMale = (gender =='m');
        if (isFemale == true) 
        {
            Console.WriteLine("Your gender is Female.");
        }
        else
        {
            if (isMale == true)
            {
                Console.WriteLine("Your gender is Male.");
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }

        }
    }
}
