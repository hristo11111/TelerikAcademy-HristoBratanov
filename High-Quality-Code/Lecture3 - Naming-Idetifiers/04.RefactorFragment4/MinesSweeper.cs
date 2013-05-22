using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesSweeper
{
    public class MinesSweeper
    {
        public class Player
        {
            public string Name { get; set; }

            public int Points { get; set; }

            public Player() 
            {
 
            }

            public Player(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        static void Main()
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] minesField = PlaceMines();
            int counter = 0;
            bool hasDetonation = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool startNewGame = true;
            const int MaxNumberOfTurns = 35;
            bool win = false;

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine("Let's play “MineSweeper”. Try to find all mines but do not step on them.\n" +
                    "Commands:\n- 'top' shows the classification\n- 'restart' starts new game\n- 'exit' exits the console");
                    DrawField(field);
                    startNewGame = false;
                }
                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        UpdateChart(champions);
                        break;
                    case "restart":
                        field = CreateField();
                        minesField = PlaceMines();
                        DrawField(field);
                        hasDetonation = false;
                        startNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Exit!");
                        break;
                    case "turn":
                        if (minesField[row, col] != '*')
                        {
                            if (minesField[row, col] == '-')
                            {
                                MakeYourTurn(field, minesField, row, col);
                                counter++;
                            }
                            if (MaxNumberOfTurns == counter)
                            {
                                win = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            hasDetonation = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Wrong command!\n");
                        break;
                }
                if (hasDetonation)
                {
                    DrawField(minesField);
                    Console.Write("\nYou lost and gain {0} points. " +
                        "Enter your nickname: ", counter);
                    string nickName = Console.ReadLine();
                    Player player = new Player(nickName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Player player1, Player player2) => player2.Name.CompareTo(player1.Name));
                    champions.Sort((Player player1, Player player2) => player2.Points.CompareTo(player1.Points));
                    UpdateChart(champions);

                    field = CreateField();
                    minesField = PlaceMines();
                    counter = 0;
                    hasDetonation = false;
                    startNewGame = true;
                }
                if (win)
                {
                    Console.WriteLine("\nCongratuations! You opened 35 empty cell without steping on a mine.");
                    DrawField(minesField);
                    Console.WriteLine("Enter your nickname: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, counter);
                    champions.Add(player);
                    UpdateChart(champions);
                    field = CreateField();
                    minesField = PlaceMines();
                    counter = 0;
                    win = false;
                    startNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Telerik Academy!");
            Console.WriteLine("Good luck!");
            Console.Read();
        }

        private static void UpdateChart(List<Player> points)
        {
            Console.WriteLine("\nChart:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The classification is empty!\n");
            }
        }

        private static void MakeYourTurn(char[,] field,
            char[,] minesField, int row, int col)
        {
            char bombsAroundThisPosition = BombsCount(minesField, row, col);
            minesField[row, col] = bombsAroundThisPosition;
            field[row, col] = bombsAroundThisPosition;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int cols = 0; cols < boardColumns; cols++)
                {
                    board[row, cols] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] minesField = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    minesField[row, col] = '-';
                }
            }

            List<int> bombCells = new List<int>();
            while (bombCells.Count < 15)
            {
                Random random = new Random();
                int cell = random.Next(50);
                if (!bombCells.Contains(cell))
                {
                    bombCells.Add(cell);
                }
            }

            foreach (int cell in bombCells)
            {
                int col = (cell / cols);
                int row = (cell % cols);
                if (row == 0 && cell != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                minesField[col, row - 1] = '*';
            }

            return minesField;
        }

        private static char BombsCount(char[,] minesField, int row, int col)
        {
            int bombsCount = 0;
            int rows = minesField.GetLength(0);
            int cols = minesField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (minesField[row - 1, col] == '*')
                {
                    bombsCount++;
                }
            }
            if (row + 1 < rows)
            {
                if (minesField[row + 1, col] == '*')
                {
                    bombsCount++;
                }
            }
            if (col - 1 >= 0)
            {
                if (minesField[row, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if (col + 1 < cols)
            {
                if (minesField[row, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (minesField[row - 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (minesField[row - 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (minesField[row + 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (minesField[row + 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }
            return char.Parse(bombsCount.ToString());
        }
    }
}
