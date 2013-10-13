using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02InnaBoyfriend
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMostLikedPersonName(peopleCount));
        }

        private static string GetMostLikedPersonName(int peopleCount)
        {
            string mostLikedPersonName = string.Empty;
            int mostLikedPersonLikes = 0;

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personAndLikes = Console.ReadLine().Split(new char[] { ' ' });

                int currentLikes = CountLikes(personAndLikes[1]);

                if (currentLikes == peopleCount)
                {
                    return personAndLikes[0];
                }

                if (currentLikes > mostLikedPersonLikes)
                {
                    mostLikedPersonLikes = currentLikes;
                    mostLikedPersonName = personAndLikes[0];
                }
            }

            return mostLikedPersonName;
        }

        private static int CountLikes(string currentLikes)
        {
            int likesCount = 0;
            for (int i = 0; i < currentLikes.Length; i++)
            {
                if (currentLikes[i] == '1')
                {
                    likesCount++;
                }
            }

            return likesCount;
        }
    }
}
