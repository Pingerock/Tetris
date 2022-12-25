using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Field
    {
        //Field parts in Unicode
        public enum Blocks
        {
            empty = '\u0020',
            block = '\u2591',
            wall = '\u2551',
            floor = '\u2550'
        }

        //Codenames of tetorminos(Tetris figures)
        public enum Tetrominos
        {
            O,
            I,
            J,
            L,
            T,
            Z,
            S
        }

        //Game state booleans
        public bool IsPaused { get; set; } = false;
        public bool IsRotated { get; set; } = false;
        public bool IsLost { get; private set; } = false;
        public bool IsMovedLeft { get; set; } = false;
        public bool IsMovedRight { get; set; } = false;
        
        //Game stats
        private int Score { get; set; } = 0;
        private int Lines { get; set; } = 0;

        private static Blocks[,] blockField = new Blocks[10, 26];
        private static Tetromino currentTetromino;

        private Random random = new Random();

        //Filling blockField with Blocks enums
        public void CreateField()
        {
            for (byte x = 1; x < 9; x++)
            {
                blockField[x,25] = Blocks.floor;
            }
            for (byte y = 0; y < 26; y++)
            {
                blockField[0, y] = Blocks.wall;
                blockField[9, y] = Blocks.wall;
            }
            for (byte x = 1; x < 9; x++)
            {
                for (byte y = 0; y < 25; y++)
                {
                    blockField[x, y] = Blocks.empty;
                }
            }
        }

        //Printing game field based on Blocks enums
        public void PrintField()
        {
            for (byte y = 2; y < 26; y++)
            {
                for (byte x = 0; x < 11; x++)
                {
                    if (x == 10)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.Write(Convert.ToChar(blockField[x,y]));
                    if (y == 8 && x == 9 && IsLost)
                    {
                        Console.Write("   Game Over!");
                        IsPaused = true;
                    }
                    if (y == 8 && x == 9 && IsPaused && !IsLost)
                    {
                        Console.Write("   Paused!");
                    }
                    // Clears "Paused!" part of field if it's not paused.
                    if (y == 8 && x == 9 && !IsPaused)
                    {
                        Console.Write("          ");
                    }
                    if (y == 13 && x == 9)
                    {
                        Console.Write("   Lines: " + Lines);
                    }
                    if (y == 15 && x == 9)
                    {
                        Console.Write("   Score: " + Score);
                    }
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Up arrow - to rotate");
            Console.WriteLine("Down arrow(hold) - fall faster");
            Console.WriteLine("Left/Right arrow - move");
            Console.WriteLine("SpaceBar - pause game");
        }

        public static void SetBlock(Block block)
        {
            blockField[block.X, block.Y] = block.Type;
        }

        public static void SetBlock(byte x, byte y, Blocks type)
        {
            blockField[x, y] = type;
        }

        public static Blocks GetBlock(byte x, byte y)
        {
            return blockField[x, y];
        }

        //Create class object Tetromino.
        public void CreateBlock()
        {
            Array values = Enum.GetValues(typeof(Tetrominos));
            Tetrominos randomTetromino = (Tetrominos)values.GetValue(random.Next(values.Length));
            Tetromino tetromino = new Tetromino(randomTetromino);
            currentTetromino = tetromino;
        }

        //Move current block based on the game states(left, right, rotate, paused, etc.)
        public void MoveBlock()
        {
            // Note: I don't like this tree of ifs and elses. At least it works.
            if (!IsPaused)
            {
                if (currentTetromino.IsDown && currentTetromino.CentralBlock.Y == 2)
                {
                    IsLost = true;
                }
                else
                {
                    if (currentTetromino.IsDown)
                    {
                        CreateBlock();
                    }
                    else
                    {
                        if (IsMovedLeft || IsMovedRight)
                        {
                            if (IsMovedLeft)
                            {
                                currentTetromino.Left();
                                IsMovedLeft = false;
                            }
                            if (IsMovedRight)
                            {
                                currentTetromino.Right();
                                IsMovedRight = false;
                            }
                        }
                        else
                        {
                            if (IsRotated)
                            {
                                currentTetromino.Rotate();
                                IsRotated = false;
                            }
                            else
                            {
                                currentTetromino.Fall();
                            }
                        }
                    }
                    DetectLines();
                }
            }
        }

        //Checks if the line was build 
        //If there is a line, the game will erase it and give player a score
        public void DetectLines()
        {
            byte count = 0;
            bool isBroken;
            for (byte y = 0; y < 25; y++)
            {
                isBroken = false;
                for (byte x = 1; x < 9; x++)
                {
                    if (blockField[x, y].Equals(Blocks.empty))
                    {
                        isBroken = true;
                        break;
                    }
                }
                if (!isBroken)
                {
                    count++;
                    ClearLine(y);
                }
            }
            switch (count)
            {
                case 1:
                    Score += 100;
                    break;
                case 2:
                    Score += 300;
                    break;
                case 3:
                    Score += 700;
                    break;
                case 4:
                    Score += 1500;
                    break;
            }
            Lines += count;
        }

        // I chose the Naive line clear gravity, because it was simple.
        public void ClearLine(byte y)
        {
            for (byte x = 1; x < 9; x++)
            {
                blockField[x, y] = Blocks.empty;
            }
        }
    }
}
