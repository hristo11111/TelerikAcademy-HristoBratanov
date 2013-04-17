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
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            // 05.Trail object
            TrailObject tempObject = new TrailObject(new MatrixCoords(15, 15), new char[,] { { 'o' } }, 3);
            engine.AddObject(tempObject);

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // 01.Side and ceiling walls
            for (int i = startRow; i < WorldRows+1; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i - 1, 0));

                engine.AddObject(leftWall);
            }

            for (int i = startRow; i < WorldRows+1; i++)
            {
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i - 1, WorldCols - 1));

                engine.AddObject(rightWall);
            }

            for (int i = 0; i <= WorldCols-1; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(1, i));

                engine.AddObject(ceiling);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            // 07. Test meteroite ball
            //MeteroiteBall theBall = new MeteroiteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            // 09. Test UnstoppableBall
            //Ball theUnstopableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 4), new MatrixCoords(0, 3));
            //engine.AddObject(theUnstopableBall);

            //for (int i = 2; i < WorldCols/2; i+=4)
            //{
            //    engine.AddObject(new UnpassableBlock(new MatrixCoords(4, i)));
            //}
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock;
                if (i == 7)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                }
                else
                {
                    currBlock = new Block(new MatrixCoords(startRow, i));
                }

                engine.AddObject(currBlock);
            }


            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter level: ");

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();
            int sleep = int.Parse(Console.ReadLine());                        // 02.Sleep field

            Engine gameEngine = new Engine(renderer, keyboard, sleep);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            //13.
            //keyboard.OnActionPressed += (sender, eventInfo) =>
            //{
            //    gameEngine.ShootPlayerRacket();
            //};

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
