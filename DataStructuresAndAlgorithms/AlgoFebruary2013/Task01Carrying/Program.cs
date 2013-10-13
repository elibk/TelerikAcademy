using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01Carrying
{
    class Program
    {
        static void Main(string[] args)
        {
            int backpackVolume = int.Parse(Console.ReadLine());
            Console.ReadLine();
            char roomsSeperator = ' ';
            string rooms = Console.ReadLine() + ' ';
            Console.WriteLine(GetVisitedRoomsCount(backpackVolume, roomsSeperator, rooms)); 
        }

        private static int GetVisitedRoomsCount(int backpackVolume, char roomsSeperator, string rooms)
        {
            int visitedRooms = 0;
            var currentRoom = string.Empty;
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i] == roomsSeperator)
                {
                    var currentRoomValue = currentRoom;
                    if (currentRoomValue != "0")
                    {
                        backpackVolume -= int.Parse(currentRoomValue);

                        if (backpackVolume < 0)
                        {
                            break;
                        }
                    }

                    visitedRooms++;

                    currentRoom = string.Empty;
                }
                else
                {
                    currentRoom += rooms[i];
                }
            }

            return visitedRooms;
        }
    }
}
