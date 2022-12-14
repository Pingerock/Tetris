using System;
using System.Collections.Generic;
using Tetris.Blocks;

namespace Tetris
{
    public class Field
    {
        //Field parts in Unicode
        public enum blocks
        {
            empty = '\u0020',
            block = '\u2588',
            wall = '\u2551',
            floor = '\u2550'
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

        private static Enum[,] blockField = new Enum[10, 17];

        private static Block currentBlock;
        private Random random = new Random();

        public void CreateField()
        {
            for (int x = 1; x < 9; x++)
            {
                blockField[x,16] = blocks.floor;
            }
            for (int y = 2; y < 17; y++)
            {
                blockField[0, y] = blocks.wall;
                blockField[9, y] = blocks.wall;
            }
            for (int x = 1; x < 9; x++)
            {
                for (int y = 2; y < 16; y++)
                {
                    blockField[x, y] = blocks.empty;
                }
            }
        }

        //Prints game field
        public void PrintField()
        {
            for (int y = 2; y < 17; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(Convert.ToChar(blockField[x,y]));
                    if (y == 8 && x == 9)
                    {
                        Console.Write("   Lines: " + lines);
                    }
                    if (y == 10 && x == 9)
                    {
                        Console.Write("   Score: " + score);
                    }
                }
                Console.WriteLine();
            }
        }

        //Checks if the current block reached the bottom of game field
        public static bool IsDown(Block block)
        {
            if (blockField[block.X, block.Y + 2].Equals(blocks.block) ||
                blockField[block.X, block.Y + 2].Equals(blocks.floor))
            {
                return true;
            }
            return false;
        }

        //Checks if the current block collides with other blocks
        public static bool IsCollide(Block block)
        {
            return false;
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

        public static void SetCurrentBlock(Block block)
        {
            currentBlock = block;
        }

        //Move current block down. If the block has fallen, it will create a new block 
        public void MoveBlock()
        {
            if (currentBlock.Is_Down)
            {
                byte blockX = (byte)random.Next(1, 8);
                Block block = new Block(blockX, 0);
                block.CreateBlock();
            }
            else
            {
                currentBlock.Fall();
            }
        }

        public void MoveBlocks_Left()
        {
            currentBlock.Left();
        }

        public void MoveBlocks_Right()
        {
            currentBlock.Right();
        }
    }
}
