////A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). 
////A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.

using System;
using System.Linq;
using System.Threading;

public class FallingRocks
{
    private static readonly int windowHeight = 17;
    private static readonly int windowWidth = 25;

    private static readonly char[] rockTypes = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '"' };
    private static int playerPosition = 0;
    private static int result = 3;
    private static readonly Random randomGenerator = new Random();

    private static int indexRockType = randomGenerator.Next(0, rockTypes.Length);
    private static int indRT = randomGenerator.Next(0, rockTypes.Length);
    private static int indRT2 = randomGenerator.Next(0, rockTypes.Length);
    private static int indRT3 = randomGenerator.Next(0, rockTypes.Length);
    private static int indRT4 = randomGenerator.Next(0, rockTypes.Length);
    private static int indRT5 = randomGenerator.Next(0, rockTypes.Length);

    private static int rockPositionX = randomGenerator.Next(0, windowWidth - 1);
    private static int rockPosX = randomGenerator.Next(0, windowWidth - 1);
    private static int rockPosX2 = randomGenerator.Next(0, windowWidth - 2);
    private static int rockPosX3 = randomGenerator.Next(0, windowWidth - 1);
    private static int rockPosX4 = randomGenerator.Next(0, windowWidth - 1);
    private static int rockPosX5 = randomGenerator.Next(0, windowWidth - 3);
    
    private static int rockPositionY = 0;
    private static int rockPosY = 0;
    private static int rockPosY2 = 0;
    private static int rockPosY3 = 0;
    private static int rockPosY4 = 0;
    private static int rockPosY5 = 0;

   private static void RemoveScrollBars()
    {
        Console.SetWindowSize(windowWidth,windowHeight);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BufferHeight = windowHeight;
        Console.BufferWidth = windowWidth;
    }

   private static void ClearBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(); // clear buffer
        }
    }

   private static void Drowplayer()
    {
        PrintAtPosition(playerPosition, windowHeight - 2, "(0)");
    }

   private static void PrintAtPosition(int x, int y, string symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(symbol);
    }

   private static void SetInitialPositions()
    {
        playerPosition = windowWidth / 2;
    }

   private static void MovePlayerRight()
    {
        if (playerPosition < windowWidth - 1 - 3)
        {
            playerPosition++;
        }
    }

   private static void MovePlayerLeft()
    {
        if (playerPosition > 0)
        {
            playerPosition--;
        }
    }

   private static void PrintResult()
    {
        Console.SetCursorPosition((windowWidth / 2) - 1, 0);
        Console.Write(result);
    }

   private static void FallingAndHitting()
    {
        int chance = randomGenerator.Next(0, 10);

        if (rockPositionY < windowHeight - 2)
        {
            rockPositionY++;
            PrintAtPosition(rockPositionX, rockPositionY, rockTypes[indexRockType].ToString());
        }
        else
        {
                if (rockPositionX == playerPosition + 1)
                {
                    result--;
                    PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                    Console.Beep();
                }

            rockPositionY = 0;
            indexRockType = randomGenerator.Next(0, rockTypes.Length);
            rockPositionX = randomGenerator.Next(0, windowWidth - 1);
        }

        if (rockPosY < windowHeight - 2)
        {
            if (chance <= 5)
            {
                PrintAtPosition(rockPosX, rockPosY, rockTypes[indRT].ToString());
                rockPosY++;
            }
        }
        else
        {
            if (rockPosX == playerPosition + 1)
            {
                result = result--;
                PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                Console.Beep();
            }

            rockPosY = 0;
            indRT = randomGenerator.Next(0, rockTypes.Length);
            rockPosX = randomGenerator.Next(0, windowWidth - 1);
        }

        if (rockPosY2 < windowHeight - 2)
        {
            if (chance <= 8)
            {
                PrintAtPosition(rockPosX2, rockPosY2, rockTypes[indRT2].ToString() + rockTypes[indRT2]);
                rockPosY2++;
            }
        }
        else
        {
            if (rockPosX2 == playerPosition + 1 || rockPosX2 == playerPosition)
            {
                result--;
                PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                Console.Beep();
            }

            rockPosY2 = 0;
            indRT2 = randomGenerator.Next(0, rockTypes.Length);
            rockPosX2 = randomGenerator.Next(0, windowWidth - 2);
        }

        if (rockPosY3 < windowHeight - 2)
        {
            if (chance <= 7)
            {
                PrintAtPosition(rockPosX3, rockPosY3, rockTypes[indRT3].ToString());
                rockPosY3++;
            }
        }
        else
        {
            if (rockPosX3 == playerPosition + 1)
            {
                result--;
                PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                Console.Beep();
            }

            rockPosY3 = 0;
            indRT3 = randomGenerator.Next(0, rockTypes.Length);
            rockPosX3 = randomGenerator.Next(0, windowWidth - 1);
        }

        if (rockPosY4 < windowHeight - 2)
        {
            if (chance <= 3)
            {
                PrintAtPosition(rockPosX4, rockPosY4, rockTypes[indRT4].ToString());
                rockPosY4++;
            }
        }
        else
        {
            if (rockPosX4 == playerPosition + 1)
            {
                result--;
                PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                Console.Beep();
            }

            rockPosY4 = 0;
            indRT4 = randomGenerator.Next(0, rockTypes.Length);
            rockPosX4 = randomGenerator.Next(0, windowWidth - 1);
        }

        if (rockPosY5 < windowHeight - 2)
        {
            if (chance <= 3)
            {
                PrintAtPosition(rockPosX5, rockPosY5, rockTypes[indRT5].ToString() + rockTypes[indRT5] + rockTypes[indRT5]);
                rockPosY5++;
            }
        }
        else
        {
            if (rockPosX5 == playerPosition + 1 || rockPosX5 == playerPosition || rockPosX5 == playerPosition - 1)
            {
                result--;
                PrintAtPosition(playerPosition, windowHeight - 2, " X ");
                Console.Beep();
            }

            rockPosY5 = 0;
            indRT5 = randomGenerator.Next(0, rockTypes.Length);
            rockPosX5 = randomGenerator.Next(0, windowWidth - 3);
        }
    }

   private static void Main()
    {
        RemoveScrollBars();
        SetInitialPositions();
       
        while (true)
        {
            FallingAndHitting();
            //// Moving
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MovePlayerLeft();
                }

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MovePlayerRight();
                }
            }

            ClearBuffer();
            Thread.Sleep(150);
            Console.Clear();
            Drowplayer();
            PrintResult();

           //// CheckForGameOver
            if (result == 0)
            {
                PrintAtPosition((windowWidth / 2) - 8, windowHeight / 2, "G A M E  O V E R");
                PrintAtPosition(playerPosition, windowHeight - 2, "x_x");    
                Console.ReadKey();
                break;  
            }
        }
    }   
}
