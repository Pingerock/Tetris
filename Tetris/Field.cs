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

        private int score;
        private int lines;
        private static List<Block> tetrisBlocks;
        private static Enum[,] blockField = new Enum[10,17];


        public Field()
        {
            score = 0;
            lines = 0;
            tetrisBlocks = new List<Block>();
            createField();
        }

        private void createField()
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

        public void PrintField()
        {
            for (int y = 2; y < 17; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(Convert.ToChar(blockField[x,y]));
                }
                Console.WriteLine();
            }
        }

        public static bool IsCollide(Block block)
        {
            if (blockField[block.GetX(), block.GetY() + 2].Equals(blocks.block) ||
                blockField[block.GetX(), block.GetY() + 2].Equals(blocks.floor))
            {
                return true;
            }
            return false;
        }

        public static void SetBlock(Block block)
        {
            blockField[block.GetX(), block.GetY()] = block.GetType();
        }

        public static void SetBlock(byte x, byte y, Enum type)
        {
            blockField[x, y] = type;
        }

        public static void AddBlock(Block block)
        {
            tetrisBlocks.Add(block);
        }

        public void MoveBlocks()
        {
            foreach (Block block in tetrisBlocks)
            {
                block.Fall();
            }
        }

        public void MoveBlocks_Left()
        {
            foreach (Block block in tetrisBlocks)
            {
                block.Left();
            }
        }

        public void MoveBlocks_Right()
        {
            foreach (Block block in tetrisBlocks)
            {
                block.Right();
            }
        }
    }
}
