using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03MostPopularFriend
{
    class Program
    {
        private const char friendSymbol = 'Y';
        private const char notFriendSymbol = 'N';

        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            char[][] friendsMap = new char[peopleCount][];

            for (int i = 0; i < friendsMap.Length; i++)
            {
                friendsMap[i] = Console.ReadLine().ToCharArray();
            }

            Console.WriteLine(GetMostDuoFriendsCount(friendsMap));
        }

        private static int GetMostDuoFriendsCount(char[][] friendsMap)
        {
            int mostDuoFriends = 0;

            for (int currentPerson = 0; currentPerson < friendsMap.Length; currentPerson++)
            {
                var currentDuoFriends = 0;
                for (int currentPersonFriends = 0; currentPersonFriends < friendsMap[currentPerson].Length; currentPersonFriends++)
                {
                    if (friendsMap[currentPerson][currentPersonFriends] == friendSymbol)
                    {
                        currentDuoFriends++;
                        for (int currentPersonFriendsFriends = 0; currentPersonFriendsFriends < friendsMap[currentPersonFriends].Length; currentPersonFriendsFriends++)
                        {
                            if (friendsMap[currentPersonFriends][currentPersonFriendsFriends] == friendSymbol)
                            {
                                if (currentPersonFriendsFriends != currentPerson && friendsMap[currentPerson][currentPersonFriendsFriends] == notFriendSymbol)
                                {
                                    friendsMap[currentPerson][currentPersonFriendsFriends] = 'D';
                                    currentDuoFriends++;
                                }
                                
                            }
                        }
                    }
                }

                if (currentDuoFriends > mostDuoFriends)
                {
                    mostDuoFriends = currentDuoFriends;
                }

                if (mostDuoFriends == friendsMap.Length -1)
                {
                    break;
                }
            }
            return mostDuoFriends;
        }
    }
}
