using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.Field;

namespace Tetris
{
    public class Tetromino
    {
        private List<Block> tetrominoBlocks = new List<Block>();

        private Block centralBlock;
        public Block CentralBlock
        {
            get 
            {
                return centralBlock;
            }
        }

        private Enum type;
        public Enum Type
        {
            get
            {
                return type;
            }
        }

        //position of blocks during rotation(from 0-3)
        private byte position = 0;
        public byte Position 
        {
            get 
            { 
                return position; 
            }
        }

        private bool isDown;
        public bool IsDown
        {
            get
            {
                return isDown;
            }
        }

        public Tetromino(Enum tetrominos)
        {
            type = tetrominos;
            CreateBlocks();
        }

        private void CreateBlocks()
        {
            switch (type)
            {
                case Field.Tetrominos.I:
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    tetrominoBlocks.Add(new Block(5, 0));
                    centralBlock = tetrominoBlocks[0];
                    break;
                case Field.Tetrominos.J:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    centralBlock = tetrominoBlocks[1];
                    break;
                case Field.Tetrominos.L:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    centralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.O:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    centralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.T:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    centralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.Z:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    centralBlock = tetrominoBlocks[3];
                    break;
                case Field.Tetrominos.S:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    centralBlock = tetrominoBlocks[2];
                    break;
            }
        }

        public void Rotate()
        {
            switch (type)
            {
                case Field.Tetrominos.I:
                    if (position % 2 == 0)
                    {
                        tetrominoBlocks[1].X = centralBlock.X;
                        tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[2].X = centralBlock.X;
                        tetrominoBlocks[2].Y = (byte)(centralBlock.Y + 2);
                        tetrominoBlocks[3].X = centralBlock.X;
                        tetrominoBlocks[3].Y = (byte)(centralBlock.Y + 3);
                    }
                    else 
                    {
                        tetrominoBlocks[1].X = (byte)(centralBlock.X + 1);
                        tetrominoBlocks[1].Y = centralBlock.Y;
                        tetrominoBlocks[2].X = (byte)(centralBlock.X + 2);
                        tetrominoBlocks[2].Y = centralBlock.Y;
                        tetrominoBlocks[3].X = (byte)(centralBlock.X + 3);
                        tetrominoBlocks[3].Y = centralBlock.Y;
                    }
                    break;
                case Field.Tetrominos.J:
                    switch (position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[2].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[2].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y - 1);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[2].X = (byte)(centralBlock.X);
                            tetrominoBlocks[2].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y - 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[2].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[2].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y + 1);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[2].X = (byte)(centralBlock.X);
                            tetrominoBlocks[2].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.L:
                    switch (position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y + 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.O:
                    break;
                case Field.Tetrominos.T:
                    switch (position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y + 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(centralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(centralBlock.Y);
                            tetrominoBlocks[1].X = (byte)(centralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(centralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(centralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.Z:
                    if (position % 2 == 0)
                    {
                        tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(centralBlock.Y);
                        tetrominoBlocks[1].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[2].X = (byte)(centralBlock.X);
                        tetrominoBlocks[2].Y = (byte)(centralBlock.Y - 1);
                    }
                    else
                    {
                        tetrominoBlocks[0].X = (byte)(centralBlock.X);
                        tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[1].X = (byte)(centralBlock.X + 1);
                        tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[2].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[2].Y = (byte)(centralBlock.Y);
                    }
                    break;
                case Field.Tetrominos.S:
                    if (position % 2 == 0)
                    {
                        tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[1].X = (byte)(centralBlock.X);
                        tetrominoBlocks[1].Y = (byte)(centralBlock.Y + 1);
                        tetrominoBlocks[3].X = (byte)(centralBlock.X + 1);
                        tetrominoBlocks[3].Y = (byte)(centralBlock.Y);
                    }
                    else
                    {
                        tetrominoBlocks[0].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(centralBlock.Y - 1);
                        tetrominoBlocks[1].X = (byte)(centralBlock.X - 1);
                        tetrominoBlocks[1].Y = (byte)(centralBlock.Y);
                        tetrominoBlocks[3].X = (byte)(centralBlock.X);
                        tetrominoBlocks[3].Y = (byte)(centralBlock.Y + 1);
                    }
                    break;
            }
            if (position == 4)
            {
                position = 0;
            }
            else
            {
                position++;
            }
        }

        public void Right()
        {
            switch (type)
            {
                case Field.Tetrominos.I:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckRight(tetrominoBlocks[3]))
                        {
                            for (byte x = 3; x > 0; x--)
                            {
                                tetrominoBlocks[x].Right();
                            }
                            tetrominoBlocks[0].Right();
                        }
                    }
                    else
                    {
                        bool rightCheck = true;
                        foreach (Block block in tetrominoBlocks)
                        {
                            rightCheck = Block.CheckRight(block);
                        }
                        if (rightCheck)
                        {
                            foreach (Block block in tetrominoBlocks)
                            {
                                block.Right();
                            }
                        }
                    }
                    break;
                case Field.Tetrominos.J:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckRight(tetrominoBlocks[2]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                            {
                                for (byte x = 3; x > 0; x--)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                                tetrominoBlocks[0].Right();
                            }
                            break;
                        case 1:
                            if (Block.CheckRight(tetrominoBlocks[3]) &&
                                Block.CheckRight(tetrominoBlocks[1]) &&
                                Block.CheckRight(tetrominoBlocks[2]))
                            {
                                tetrominoBlocks[3].Right();
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                        case 2:
                            if (Block.CheckRight(tetrominoBlocks[3]) &&
                               Block.CheckRight(tetrominoBlocks[0]))
                            {
                                tetrominoBlocks[3].Right();
                                for (byte x = 2; x >= 0; x--)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                        case 3:
                            bool rightCheck = true;
                            for (byte x = 0; x < 3; x++)
                            {
                                rightCheck = Block.CheckRight(tetrominoBlocks[x]);
                            }
                            if (rightCheck)
                            {
                                foreach (Block block in tetrominoBlocks)
                                {
                                    block.Right();
                                }
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.L:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                            {
                                for (byte x = 3; x > 0; x--)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                                tetrominoBlocks[0].Right();
                            }
                            break;
                        case 1:
                            bool rightCheck = true;
                            for (byte x = 1; x < 4; x++)
                            {
                                rightCheck = Block.CheckRight(tetrominoBlocks[x]);
                            }
                            if (rightCheck)
                            {
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                                tetrominoBlocks[0].Right();
                            }
                            break;
                        case 2:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                               Block.CheckRight(tetrominoBlocks[1]))
                            {
                                tetrominoBlocks[0].Right();
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                        case 3:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                                Block.CheckRight(tetrominoBlocks[2]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                            {
                                tetrominoBlocks[0].Right();
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.O:
                    if (Block.CheckRight(tetrominoBlocks[1]) && Block.CheckRight(tetrominoBlocks[3]))
                    {
                        for (byte x = 3; x > 0; x--)
                        {
                            tetrominoBlocks[x].Right();
                        }
                        tetrominoBlocks[0].Right();
                    }
                    break;
                case Field.Tetrominos.T:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                            {
                                for (byte x = 3; x > 0; x--)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                                tetrominoBlocks[0].Right();
                            }
                            break;
                        case 1:
                            bool rightCheck = true;
                            for (byte x = 1; x < 4; x++)
                            {
                                rightCheck = Block.CheckRight(tetrominoBlocks[x]);
                            }
                            if (rightCheck)
                            {
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                                tetrominoBlocks[0].Right();
                            }
                            break;
                        case 2:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                               Block.CheckRight(tetrominoBlocks[1]))
                            {
                                tetrominoBlocks[0].Right();
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                        case 3:
                            if (Block.CheckRight(tetrominoBlocks[0]) &&
                                Block.CheckRight(tetrominoBlocks[1]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                            {
                                tetrominoBlocks[0].Right();
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Right();
                                }
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.Z:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckRight(tetrominoBlocks[1]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                        {
                            tetrominoBlocks[1].Right();
                            tetrominoBlocks[0].Right();
                            tetrominoBlocks[3].Right();
                            tetrominoBlocks[2].Right();
                        }
                    }
                    else
                    {
                        if (Block.CheckRight(tetrominoBlocks[1]) &&
                                Block.CheckRight(tetrominoBlocks[2]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                        {
                            for (byte x = 1; x < 4; x++)
                            {
                                tetrominoBlocks[x].Right();
                            }
                            tetrominoBlocks[0].Right();
                        }
                    }
                    break;
                case Field.Tetrominos.S:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckRight(tetrominoBlocks[1]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                        {
                            tetrominoBlocks[1].Right();
                            tetrominoBlocks[3].Right();
                            tetrominoBlocks[0].Right();
                            tetrominoBlocks[2].Right();
                        }
                    }
                    else
                    {
                        if (Block.CheckRight(tetrominoBlocks[0]) &&
                                Block.CheckRight(tetrominoBlocks[2]) &&
                                Block.CheckRight(tetrominoBlocks[3]))
                        {
                            tetrominoBlocks[0].Right();
                            tetrominoBlocks[2].Right();
                            tetrominoBlocks[3].Right();
                            tetrominoBlocks[1].Right();
                        }
                    }
                    break;
            }
        }

        public void Left()
        {
            switch (type)
            {
                case Field.Tetrominos.I:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckLeft(centralBlock))
                        {
                            foreach (Block block in tetrominoBlocks)
                            {
                                block.Left();
                            }
                        }
                    }
                    else
                    {
                        bool leftCheck = true;
                        foreach (Block block in tetrominoBlocks)
                        {
                            leftCheck = Block.CheckLeft(block);
                        }
                        if (leftCheck)
                        {
                            foreach (Block block in tetrominoBlocks)
                            {
                                block.Left();
                            }
                        }
                    }
                    break;
                case Field.Tetrominos.J:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[3]))
                            {
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                                tetrominoBlocks[3].Left();
                            }
                            break;
                        case 1:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[1]) &&
                                Block.CheckLeft(tetrominoBlocks[2]))
                            {
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                                tetrominoBlocks[3].Left();
                            }
                            break;
                        case 2:
                            if (Block.CheckLeft(tetrominoBlocks[2]) &&
                               Block.CheckLeft(tetrominoBlocks[3]))
                            {
                                tetrominoBlocks[3].Left();
                                for (byte x = 2; x >= 0; x--)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                        case 3:
                            if (Block.CheckLeft(tetrominoBlocks[3]) &&
                                Block.CheckLeft(tetrominoBlocks[1]) &&
                                Block.CheckLeft(tetrominoBlocks[2]))
                            {
                                tetrominoBlocks[3].Left();
                                for (byte x = 0; x < 3; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.L:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[1]))
                            {
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                                tetrominoBlocks[0].Left();
                            }
                            break;
                        case 1:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[2]) &&
                                Block.CheckLeft(tetrominoBlocks[3]))
                            {
                                for (byte x = 0; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                        case 2:
                            if (Block.CheckLeft(tetrominoBlocks[2]) &&
                               Block.CheckLeft(tetrominoBlocks[0]))
                            {
                                tetrominoBlocks[0].Left();
                                for (byte x = 3; x >= 0; x--)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                        case 3:
                            if (Block.CheckLeft(tetrominoBlocks[3]) &&
                                Block.CheckLeft(tetrominoBlocks[1]) &&
                                Block.CheckLeft(tetrominoBlocks[2]))
                            {
                                for (byte x = 3; x >= 0; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.O:
                    if (Block.CheckLeft(tetrominoBlocks[0]) && Block.CheckLeft(tetrominoBlocks[2]))
                    {
                        foreach (Block block in tetrominoBlocks)
                        {
                            block.Left();
                        }
                    }
                    break;
                case Field.Tetrominos.T:
                    switch (position)
                    {
                        case 0:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[1]))
                            {
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                                tetrominoBlocks[0].Left();
                            }
                            break;
                        case 1:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[1]) &&
                                Block.CheckLeft(tetrominoBlocks[3]))
                            {
                                tetrominoBlocks[0].Left();
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                        case 2:
                            if (Block.CheckLeft(tetrominoBlocks[0]) &&
                               Block.CheckLeft(tetrominoBlocks[3]))
                            {
                                tetrominoBlocks[0].Left();
                                for (byte x = 3; x >= 0; x--)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                            }
                            break;
                        case 3:
                            bool leftCheck = true;
                            for (byte x = 1; x < 4; x++)
                            {
                                leftCheck = Block.CheckLeft(tetrominoBlocks[x]);
                            }
                            if (leftCheck)
                            {
                                for (byte x = 1; x < 4; x++)
                                {
                                    tetrominoBlocks[x].Left();
                                }
                                tetrominoBlocks[0].Left();
                            }
                            break;
                    }
                    break;
                case Field.Tetrominos.Z:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckLeft(tetrominoBlocks[2]) &&
                                Block.CheckLeft(tetrominoBlocks[0]))
                        {
                            tetrominoBlocks[2].Left();
                            tetrominoBlocks[0].Left();
                            tetrominoBlocks[3].Left();
                            tetrominoBlocks[1].Left();
                        }
                    }
                    else
                    {
                        if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[2]) &&
                                Block.CheckLeft(tetrominoBlocks[1]))
                        {
                            for (byte x = 0; x < 3; x++)
                            {
                                tetrominoBlocks[x].Left();
                            }
                            tetrominoBlocks[3].Left();
                        }
                    }
                    break;
                case Field.Tetrominos.S:
                    if (position % 2 == 0)
                    {
                        if (Block.CheckLeft(tetrominoBlocks[2]) &&
                                Block.CheckLeft(tetrominoBlocks[0]))
                        {
                            tetrominoBlocks[0].Left();
                            tetrominoBlocks[2].Left();
                            tetrominoBlocks[1].Left();
                            tetrominoBlocks[3].Left();
                        }
                    }
                    else
                    {
                        if (Block.CheckLeft(tetrominoBlocks[0]) &&
                                Block.CheckLeft(tetrominoBlocks[2]) &&
                                Block.CheckLeft(tetrominoBlocks[3]))
                        {
                            tetrominoBlocks[0].Left();
                            tetrominoBlocks[2].Left();
                            tetrominoBlocks[3].Left();
                            tetrominoBlocks[1].Left();
                        }
                    }
                    break;
            }
        }

        public void Fall()
        {
            if (!IsDownCheck())
            {
                foreach (Block block in tetrominoBlocks)
                {
                    block.Fall();
                }
            }
            else 
            {
                isDown = true;
            }
        }

        private bool IsDownCheck()
        {
            bool fallCheck = false;
            switch (type)
            {
                case Field.Tetrominos.I:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 1);
                    break;
                case Field.Tetrominos.J:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 2);
                    break;
                case Field.Tetrominos.L:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 3);
                    break;
                case Field.Tetrominos.O:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 4);
                    break;
                case Field.Tetrominos.T:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 5);
                    break;
                case Field.Tetrominos.Z:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 6);
                    break;
                case Field.Tetrominos.S:
                    fallCheck = centralBlock.CheckBlocksNearby(position, 7);
                    break;
            }
            return fallCheck;
        }

        /*switch (type)
            {
                case Field.Tetrominos.I:
                    break;
                case Field.Tetrominos.J:
                    break;
                case Field.Tetrominos.L:
                    break;
                case Field.Tetrominos.O:
                    break;
                case Field.Tetrominos.T:
                    break;
                case Field.Tetrominos.Z:
                    break;
                case Field.Tetrominos.S:
                    break;
            }*/
}
}
