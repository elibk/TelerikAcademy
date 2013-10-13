using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 15;
        const int GameSpeed = 150;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 5;
            int endCol = WorldCols - 5;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));

                engine.AddObject(currBlock);
            }

            for (int i = 8; i < 10; i++)
            {
                Block currBlock = new ExplodingBlock(new MatrixCoords(startRow + 5, i));

                engine.AddObject(currBlock);
            }

            for (int col = 0, row = 0; col < WorldCols; col++)
            {
                Block currBlock = new UnpassableBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            for (int col = 1, row = 1; col < WorldCols - 1; col++)
            {
                Block currBlock = new IndestructibleBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            for (int col = WorldCols / 2, row = startRow + 1; col < WorldCols - 1; col++)
            {
                Block currBlock = new IndestructibleBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            for (int col = 0, row = WorldRows - 1; row >= 0; row--)
            {
                Block currBlock = new UnpassableBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            for (int col = 1, row = WorldRows -1; row > 0; row--)
            {
                Block currBlock = new IndestructibleBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            for (int col = WorldCols - 1, row = WorldRows - 1; row >= 0; row--)
            {
                Block currBlock = new UnpassableBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }
            for (int col = WorldCols - 2, row = WorldRows - 1; row > 0; row--)
            {
                Block currBlock = new IndestructibleBlock(new MatrixCoords(row, col));

                engine.AddObject(currBlock);
            }

            Ball theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 3, WorldCols / 2), RacketLength);
            Racket theRack = new Racket(new MatrixCoords(WorldRows - 1, 0), RacketLength);
            
            engine.AddObject(theRack);
            engine.AddObject(theRacket);

        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, GameSpeed);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
