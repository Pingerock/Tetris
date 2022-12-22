using System;
using System.Collections.Generic;

namespace Tetris
{
    public class Field
    {
        //Field parts in Unicode
        public enum blocks
        {
            empty = '\u0020',
            block = '\u2591',
            wall = '\u2551',
            floor = '\u2550'
        }

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

        private bool isPaused = false;
        public bool IsPaused
        {
            get 
            {
                return isPaused;
            }
            set 
            {
                isPaused = value;
            }
        }

        private bool isRotated = false;
        public bool IsRotated
        {
            get
            {
                return isRotated;
            }
            set
            {
                isRotated = value;
            }
        }

        private bool isLost = false;
        public bool IsLost
        {
            get
            {
                return isLost;
            }
        }

        private bool isMovedLeft = false;
        public bool IsMovedLeft
        {
            get
            {
                return isMovedLeft;
            }
            set
            {
                isMovedLeft = value;
            }
        }

        private bool isMovedRight = false;
        public bool IsMovedRight
        {
            get
            {
                return isMovedRight;
            }
            set
            {
                isMovedRight = value;
            }
        }

        private int score = 0;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        private int lines = 0;
        public int Lines
        {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
            }
        }

        private static Enum[,] blockField = new Enum[10, 26];

        private static Tetromino currentTetromino;
        private Random random = new Random();

        public void CreateField()
        {
            for (byte x = 1; x < 9; x++)
            {
                blockField[x,25] = blocks.floor;
            }
            for (byte y = 0; y < 26; y++)
            {
                blockField[0, y] = blocks.wall;
                blockField[9, y] = blocks.wall;
            }
            for (byte x = 1; x < 9; x++)
            {
                for (byte y = 0; y < 25; y++)
                {
                    blockField[x, y] = blocks.empty;
                }
            }
        }

        //Prints game field
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
                    if (y == 8 && x == 9 && isPaused)
                    {
                        Console.Write("   Paused!");
                    }
                    // Clears "Paused!" part of field if it's not paused. This is dumb.
                    if (y == 8 && x == 9 && !isPaused)
                    {
                        Console.Write("          ");
                    }
                    if (y == 13 && x == 9)
                    {
                        Console.Write("   Lines: " + lines);
                    }
                    if (y == 15 && x == 9)
                    {
                        Console.Write("   Score: " + score);
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

        public static void SetBlock(byte x, byte y, Enum type)
        {
            blockField[x, y] = type;
        }

        public static Enum GetBlock(byte x, byte y)
        {
            return blockField[x, y];
        }

        public void CreateBlock()
        {
            //Create class object Tetromino, that consists of 4 blocks.
            Array values = Enum.GetValues(typeof(Tetrominos));
            Tetrominos randomTetromino = (Tetrominos)values.GetValue(random.Next(values.Length));
            Tetromino tetromino = new Tetromino(randomTetromino);
            currentTetromino = tetromino;
        }

        //Move current block down. If the block has fallen, it will create a new block 
        public void MoveBlock()
        {
            // Note: I don't like this tree of ifs and elses. At least it works.
            if (!isPaused)
            {
                if (currentTetromino.IsDown)
                {
                    //byte blockX = (byte)random.Next(1, 8);
                    //Block block = new Block(blockX, 0);
                    //block.CreateBlock();
                    //SetCurrentBlock(block);
                    CreateBlock();
                }
                else
                {
                    if (isMovedLeft || isMovedRight)
                    {
                        if (isMovedLeft)
                        {
                            currentTetromino.Left();
                            isMovedLeft = false;
                        }
                        if (isMovedRight)
                        {
                            currentTetromino.Right();
                            isMovedRight = false;
                        }
                    }
                    else
                    {
                        if (isRotated)
                        {
                            currentTetromino.Rotate();
                            isRotated = false;
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

        public void DetectLines()
        {
            byte count = 0;
            bool isBroken;
            for (byte y = 0; y < 25; y++)
            {
                isBroken = false;
                for (byte x = 1; x < 9; x++)
                {
                    if (blockField[x, y].Equals(blocks.empty))
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
                    score += 100;
                    break;
                case 2:
                    score += 300;
                    break;
                case 3:
                    score += 700;
                    break;
                case 4:
                    score += 1500;
                    break;
            }
            lines += count;
        }

        // I chose the Naive line clear gravity, because it was simple.
        public void ClearLine(byte y)
        {
            for (byte x = 1; x < 9; x++)
            {
                blockField[x, y] = blocks.empty;
            }
        }
    }
}
