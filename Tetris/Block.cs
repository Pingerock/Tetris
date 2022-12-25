using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Block : Field
    {

        public bool IsDown { get; private set; } = false;

        public byte X { get; set; }

        public byte Y { get; set; }

        public Blocks Type { get; } = Blocks.block;

        private Random random = new Random();

        public Block()
        {
            
        }

        public Block(byte X, byte Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //Checks if the block can fall
        public void Fall()
        {
            if (!IsDownCheck())
            {
                Field.SetBlock(X, Y, Blocks.empty);
                Y++;
                Field.SetBlock(this);
            }
            else
            {
                IsDown = true;
            }
        }

        //Checks if the current block reached the bottom of game field
        //true - if block collided with other block/floor, otherwise - false
        public bool IsDownCheck()
        {
            if (Field.GetBlock(X,(byte)(Y+1)) == Blocks.block ||
                Field.GetBlock(X, (byte)(Y+1)) == Blocks.floor)
            {
                return true;
            }
            return false;
        }

        // Checks if the tetromino can fall
        // true - if block collided with other block/floor, otherwise - false
        // Note: I feel terrified by just looking at this. How can I make it shorter?
        public bool CheckBlocksNearby(byte position, byte type)
        {
            switch (type)
            {
                case 1:
                    if (position % 2 != 0)
                    {
                        return IsDownCheck();
                    }
                    else 
                    {
                        for (byte a = 0; a < 3; a++)
                        {
                            if (Field.GetBlock((byte)(X+a), (byte)(Y + 1)) == Blocks.block ||
                                Field.GetBlock((byte)(X+a), (byte)(Y + 1)) == Blocks.floor)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                case 2:
                    switch (position)
                    {
                        case 0:
                            for (int a = -1; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(X + 1), Y) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), Y) == Blocks.floor)
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            if (Field.GetBlock((byte)(X + 1), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                    }
                    break;
                case 3:
                    switch (position)
                    {
                        case 0:
                            if (Field.GetBlock((byte)(X - 1), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            for (int a = 0; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(X + 1), Y) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), Y) == Blocks.floor)
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            for (int a = -1; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                    }
                    break;
                case 4:
                    for (byte a = 0; a < 2; a++)
                    {
                        if (Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.block ||
                            Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.floor)
                        {
                            return true;
                        }
                    }
                    return false;
                case 5:
                    switch (position)
                    {
                        case 0:
                            if (Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.floor)
                            {
                                return true;
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.floor)
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            for (int a = -1; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 1)) == Blocks.floor)
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.floor)
                            {
                                return true;
                            }
                            return false;
                    }
                    break;
                case 6:
                    if (position % 2 == 0)
                    {
                        if (Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.floor)
                        {
                            return true;
                        }
                        for (byte a = 0; a < 2; a++)
                        {
                            if (Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (Field.GetBlock(X, (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 1)) == Blocks.floor)
                        {
                            return true;
                        }
                        if (Field.GetBlock((byte)(X - 1), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 2)) == Blocks.floor)
                        {
                            return true;
                        }
                    }
                    return false;
                case 7:
                    if (position % 2 == 0)
                    {
                        if (Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + 1), (byte)(Y + 1)) == Blocks.floor)
                        {
                            return true;
                        }
                        for (int a = 0; a > -2; a--)
                        {
                            if (Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock((byte)(X + a), (byte)(Y + 2)) == Blocks.floor)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (Field.GetBlock(X, (byte)(Y + 2)) == Blocks.block ||
                                    Field.GetBlock(X, (byte)(Y + 2)) == Blocks.floor)
                        {
                            return true;
                        }
                        if (Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.block ||
                                    Field.GetBlock((byte)(X - 1), (byte)(Y + 1)) == Blocks.floor)
                        {
                            return true;
                        }
                    }
                    return false;
            }
            return false;
        }

        //Checks if the block can move left
        public static bool CheckLeft(Block block)
        {
            if (block.X > 1 && !(Field.GetBlock((byte)(block.X - 1), block.Y) == Blocks.block))
            {
                return true;
            }
            return false;
        }

        //Checks if the block can move right
        public static bool CheckRight(Block block)
        {
            if (block.X < 8 && !(Field.GetBlock((byte)(block.X + 1), block.Y) == Blocks.block))
            {
                return true;
            }
            return false;
        }

        //Moves block left 
        public void Left()
        {
            if (X > 1 && !(Field.GetBlock((byte)(X-1),Y) == Blocks.block))
            {
                Field.SetBlock(X, Y, Blocks.empty);
                X--;
                Field.SetBlock(this);
            }
        }

        //Moves block left 
        public void Right()
        {
            if (X < 8 && !(Field.GetBlock((byte)(X+1),Y) == Blocks.block))
            {
                Field.SetBlock(X, Y, Blocks.empty);
                X++;
                Field.SetBlock(this);
            }
        }
    }
}
