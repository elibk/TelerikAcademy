using System;

class CardsFromAStandardDeck
{
    static void Main()
    {
        object cardValue = 0;
        char[] cardSuits = { '\u2660', '\u2665', '\u2666', '\u2663' };
        Console.WriteLine();

        for (int suit = 0; suit < 4; suit++)
        {
            
            switch (suit)
            {
                case 0:
                    Console.WriteLine("Spades\n");                 
                    break;
                case 1:
                    Console.WriteLine("Hearts\n");
                    break;
                case 2:
                    Console.WriteLine("Diamonds\n");
                    break;
                case 3:
                    Console.WriteLine("Clubs\n");
                    break;
                default:
                    break;
            }

            for (int i = 1; i <= 13; i++)
            {
                switch (i)
                {
                    case 1 :
                        cardValue = "Ace";
                        break;
                    case 2 :                      
                    case 3 :
                    case 4 :
                    case 5 :
                    case 6 :
                    case 7 :
                    case 8 :
                    case 9 :
                    case 10 :
                        cardValue = i;
                        break;
                    case 11 :
                        cardValue ="Jack";
                        break;
                    case 12 :
                        cardValue ="Qeen";
                        break;
                    case 13 :
                        cardValue ="King \n";
                        break;
                    default:
                        break;
                }
              Console.WriteLine("{0} {1}",cardSuits[suit],cardValue);
            }
        }
    }
}
