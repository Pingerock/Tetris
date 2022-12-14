using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Blocks
{
    public class Block : Field
    {
        protected bool is_Down;
        public bool Is_Down
        {
            get 
            {
                return is_Down;
            }
        }

        protected byte x;
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

        protected byte y;
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

        protected Enum type;
        public Enum Type
        {
            get
            {
                return type;
            }
        }

        public Block(byte x, byte y)
        {
            this.x = x;
            this.y = y;
            type = blocks.block;
            is_Down = false;
        }

        public void Fall()
        {
            if (!is_Down)
            {
                if (Field.IsDown(this))
                {
                    is_Down = true;
                }
                if (Field.IsCollide(this))
                {
                    
                }
                Field.SetBlock(x, y, blocks.empty);
                Y++;
                Field.SetBlock(this);
            }
        }

        public void CreateBlock()
        {
            Field.SetCurrentBlock(this);
            Field.SetBlock(this);
        }

        public void Left()
        {
            if (x > 1 || !(Field.GetBlock((byte)(x - 1),y).Equals(blocks.block)))
            {
                Field.SetBlock(x, y, blocks.empty);
                x--;
            }
        }

        public void Right()
        {
            if (x < 8 || !(Field.GetBlock((byte)(x+1),y).Equals(blocks.block)))
            {
                Field.SetBlock(x, y, blocks.empty);
                x++;
            }
        }
    }
}
