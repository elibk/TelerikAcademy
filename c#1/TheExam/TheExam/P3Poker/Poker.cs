using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Poker
{
    class Poker
    {
        static void Main(string[] args)
        {
            int[] cardsWhithAce14 = new int[5];
            int[] cardsWhithAce1 = new int[5];
            string result = "Two Pairs";
            int count = 0;

            string currentInput = "Nothing";

            for (int i = 0; i < cardsWhithAce14.Length; i++)
            {
                currentInput = Console.ReadLine();
                switch (currentInput)
                {
                    case "J":
                        cardsWhithAce14[i] = 11;
                        cardsWhithAce1[i] = 11;
                        break;
                    case "Q":
                        cardsWhithAce14[i] = 12;
                        cardsWhithAce1[i] = 12;
                        break;
                    case "K":
                        cardsWhithAce14[i] = 13;
                        cardsWhithAce1[i] = 13;
                        break;
                    case "A":
                        cardsWhithAce14[i] = 14;
                        cardsWhithAce1[i] = 1;
                        break;
                    default:
                        cardsWhithAce14[i] = int.Parse(currentInput);
                        cardsWhithAce1[i] = int.Parse(currentInput);
                        break;
                }
            }
            Array.Sort(cardsWhithAce1);
            Array.Sort(cardsWhithAce14);

            if (cardsWhithAce1[4] == cardsWhithAce1[3] &&
                cardsWhithAce1[3] == cardsWhithAce1[2] &&
                cardsWhithAce1[2] == cardsWhithAce1[1] &&
                cardsWhithAce1[1] == cardsWhithAce1[0])
            {
                result = "Impossible";
            }
            else if (cardsWhithAce1[0] == 1 && cardsWhithAce1[4] == 13 && (cardsWhithAce1[1] == 2 || cardsWhithAce1[1] == 10))
            {
                result = "Straight";
            }
            else if (cardsWhithAce1[4] == cardsWhithAce1[3] + 1 &&
                cardsWhithAce1[3] == cardsWhithAce1[2] + 1 &&
                cardsWhithAce1[2] == cardsWhithAce1[1] + 1 &&
                cardsWhithAce1[1] == cardsWhithAce1[0] + 1)
            {
                result = "Straight";
            }
            else if (cardsWhithAce14[4] == cardsWhithAce14[3] + 1 &&
                    cardsWhithAce14[3] == cardsWhithAce14[2] + 1 &&
                    cardsWhithAce14[2] == cardsWhithAce14[1] + 1 &&
                    cardsWhithAce14[1] == cardsWhithAce14[0] + 1)
            {
                result = "Straight";
            }
            else
            {
                if (cardsWhithAce1[0] == cardsWhithAce1[1])
                {
                    count++;
                }
                if (cardsWhithAce1[1] == cardsWhithAce1[2])
                {
                    count++;
                }
                if (cardsWhithAce1[2] == cardsWhithAce1[3])
                {
                    count++;
                }
                if (cardsWhithAce1[3] == cardsWhithAce1[4])
                {
                    count++;
                }

                switch (count)
                {
                    case 0:                       
                            result = "Nothing";
                        break;
                    case 1:
                        result = "One Pair";
                        break;
                    case 4:
                        result = "Impossible";
                        break;
                    case 3:
                        if (cardsWhithAce1[0] == cardsWhithAce1[1] && cardsWhithAce1[0] == cardsWhithAce1[2] && cardsWhithAce1[0] == cardsWhithAce1[3])
                        {
                            result = "Four of a Kind";
                        }
                        else if (cardsWhithAce1[1] == cardsWhithAce1[2] && cardsWhithAce1[1] == cardsWhithAce1[3] && cardsWhithAce1[1] == cardsWhithAce1[4])
                        {
                            result = "Four of a Kind";
                        }
                        else
                        {
                            result = "Full House";
                        }
                        
                        break;
                    case 2:
                        if (cardsWhithAce1[0] == cardsWhithAce1[1] && cardsWhithAce1[0] == cardsWhithAce1[2])
                        {
                            if (cardsWhithAce1[3] == cardsWhithAce1[0] || cardsWhithAce1[4] == cardsWhithAce1[0])
                            {
                                result = "Four of a Kind";
                            }
                            else
                            {
                                result = "Three of a Kind";
                            }
                        }
                        else if (cardsWhithAce1[1] == cardsWhithAce1[2] && cardsWhithAce1[1] == cardsWhithAce1[3])
                        {
                            if (cardsWhithAce1[1] == cardsWhithAce1[0] || cardsWhithAce1[1] == cardsWhithAce1[4])
                            {
                                result = "Four of a Kind";
                            }
                            else
                            {
                                result = "Three of a Kind";
                            }
                        }
                        else if (cardsWhithAce1[2] == cardsWhithAce1[3] && cardsWhithAce1[2] == cardsWhithAce1[4])
                        {
                            if (cardsWhithAce1[2] == cardsWhithAce1[1] || cardsWhithAce1[2] == cardsWhithAce1[0])
                            {
                                result = "Four of a Kind";
                            }
                            else
                            {
                                result = "Three of a Kind";
                            }
                        }
                        else
                        {
                            result = "Two Pairs";
                        }


                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(result);
        }

    }
}