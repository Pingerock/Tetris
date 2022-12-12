using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Blocks
{
    public class Block : Field
    {
        protected bool Is_Collide;
        protected byte X;
        protected byte Y;
        protected Enum type = blocks.block;

        public Block(byte x, byte y)
        {
            X = x;
            Y = y;
            Is_Collide = false;
        }

        public void Fall()
        {
            if (!Is_Collide)
            {
                if (Field.IsCollide(this))
                {
                    Is_Collide = true;
                }
                Field.SetBlock(X, Y, blocks.empty);
                Y++;
                Field.SetBlock(this);
            }
        }

        public void CreateBlock()
        {
            Field.AddBlock(this);
            Field.SetBlock(this);
        }

        public byte GetX()
        {
            return X;
        }

        public void Left()
        {
            X--;
        }

        public void Right()
        {
            X++;
        }

        public byte GetY()
        {
            return Y;
        }

        public Enum GetType()
        {
            return type;
        }
    }
}
