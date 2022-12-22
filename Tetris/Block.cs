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

        private bool isDown = false;
        public bool IsDown
        {
            get 
            {
                return isDown;
            }
        }

        private byte x;
        public byte X
        {
            get
            {
                return x;
            }
            set 
            {
                x = value;
            }
        }

        private byte y;
        public byte Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        private Enum type = blocks.block;
        public Enum Type
        {
            get
            {
                return type;
            }
        }

        private Random random = new Random();

        public Block()
        {
            
        }

        public Block(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }

        public void Fall()
        {
            if (!IsDownCheck())
            {
                Field.SetBlock(x, y, blocks.empty);
                y++;
                Field.SetBlock(this);
            }
            else
            {
                isDown = true;
            }
        }

        //Checks if the current block reached the bottom of game field
        // true - if block collided with other block/floor, otherwise - false
        public bool IsDownCheck()
        {
            if (Field.GetBlock(x,(byte)(y+1)).Equals(blocks.block) ||
                Field.GetBlock(x, (byte)(y+1)).Equals(blocks.floor))
            {
                return true;
            }
            return false;
        }

        // Checks if the tetromino can fall
        // true - if block collided with other block/floor, otherwise - false
        // Note: I feel terrified by just looking at this.
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
                            if (Field.GetBlock((byte)(x+a), (byte)(y + 1)).Equals(blocks.block) ||
                                Field.GetBlock((byte)(x+a), (byte)(y + 1)).Equals(blocks.floor))
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
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.floor))
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(x + 1), y).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), y).Equals(blocks.floor))
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            if (Field.GetBlock((byte)(x + 1), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.floor))
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.floor))
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
                            if (Field.GetBlock((byte)(x - 1), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            for (int a = 0; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.floor))
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(x + 1), y).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), y).Equals(blocks.floor))
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            for (int a = -1; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.floor))
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            for (int a = -1; a < 1; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.floor))
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
                        if (Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.block) ||
                            Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.floor))
                        {
                            return true;
                        }
                    }
                    return false;
                case 5:
                    switch (position)
                    {
                        case 0:
                            if (Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            return false;
                        case 1:
                            if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            return false;
                        case 2:
                            for (int a = -1; a < 2; a++)
                            {
                                if (Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 1)).Equals(blocks.floor))
                                {
                                    return true;
                                }
                            }
                            return false;
                        case 3:
                            if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            if (Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.floor))
                            {
                                return true;
                            }
                            return false;
                    }
                    break;
                case 6:
                    if (position % 2 == 0)
                    {
                        if (Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.floor))
                        {
                            return true;
                        }
                        for (byte a = 0; a < 2; a++)
                        {
                            if (Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (Field.GetBlock(x, (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 1)).Equals(blocks.floor))
                        {
                            return true;
                        }
                        if (Field.GetBlock((byte)(x - 1), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 2)).Equals(blocks.floor))
                        {
                            return true;
                        }
                    }
                    return false;
                case 7:
                    if (position % 2 == 0)
                    {
                        if (Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + 1), (byte)(y + 1)).Equals(blocks.floor))
                        {
                            return true;
                        }
                        for (int a = 0; a > -2; a--)
                        {
                            if (Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x + a), (byte)(y + 2)).Equals(blocks.floor))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.block) ||
                                    Field.GetBlock(x, (byte)(y + 2)).Equals(blocks.floor))
                        {
                            return true;
                        }
                        if (Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.block) ||
                                    Field.GetBlock((byte)(x - 1), (byte)(y + 1)).Equals(blocks.floor))
                        {
                            return true;
                        }
                    }
                    return false;
            }
            return false;
        }

        public static bool CheckLeft(Block block)
        {
            if (block.X > 1 && !(Field.GetBlock((byte)(block.X - 1), block.Y).Equals(blocks.block)))
            {
                return true;
            }
            return false;
        }

        public static bool CheckRight(Block block)
        {
            if (block.X < 8 && !(Field.GetBlock((byte)(block.X + 1), block.Y).Equals(blocks.block)))
            {
                return true;
            }
            return false;
        }

        public void Left()
        {
            if (x > 1 && !(Field.GetBlock((byte)(x-1),y).Equals(blocks.block)))
            {
                Field.SetBlock(x, y, blocks.empty);
                x--;
                Field.SetBlock(this);
            }
        }
         
        public void Right()
        {
            if (x < 8 && !(Field.GetBlock((byte)(x+1),y).Equals(blocks.block)))
            {
                Field.SetBlock(x, y, blocks.empty);
                x++;
                Field.SetBlock(this);
            }
        }
    }
}
