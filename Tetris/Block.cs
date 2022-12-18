using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool IsDownCheck()
        {
            if (Field.GetBlock(x,(byte)(y+1)).Equals(blocks.block) ||
                Field.GetBlock(x, (byte)(y+1)).Equals(blocks.floor))
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
