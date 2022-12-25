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

        public Block CentralBlock { get; private set; }

        private Tetrominos Type;

        //Position of Blocks during rotation(from 0-3)
        public byte Position { get; private set; } = 0;

        public bool IsDown { get; private set; } = false;

        public Tetromino(Tetrominos tetrominos)
        {
            Type = tetrominos;
            CreateBlocks();
        }

        //Set Blocks Position based on tetromino type
        private void CreateBlocks()
        {
            switch (Type)
            {
                case Field.Tetrominos.I:
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    tetrominoBlocks.Add(new Block(5, 0));
                    CentralBlock = tetrominoBlocks[0];
                    break;
                case Field.Tetrominos.J:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    CentralBlock = tetrominoBlocks[1];
                    break;
                case Field.Tetrominos.L:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    CentralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.O:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    CentralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.T:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    CentralBlock = tetrominoBlocks[2];
                    break;
                case Field.Tetrominos.Z:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    CentralBlock = tetrominoBlocks[3];
                    break;
                case Field.Tetrominos.S:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    CentralBlock = tetrominoBlocks[2];
                    break;
            }
        }

        //Problem: It doesn't work!
        public void Rotate()
        {
            switch (Type)
            {
                case Field.Tetrominos.I:
                    if (Position % 2 == 0)
                    {
                        tetrominoBlocks[1].X = CentralBlock.X;
                        tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[2].X = CentralBlock.X;
                        tetrominoBlocks[2].Y = (byte)(CentralBlock.Y + 2);
                        tetrominoBlocks[3].X = CentralBlock.X;
                        tetrominoBlocks[3].Y = (byte)(CentralBlock.Y + 3);
                    }
                    else 
                    {
                        tetrominoBlocks[1].X = (byte)(CentralBlock.X + 1);
                        tetrominoBlocks[1].Y = CentralBlock.Y;
                        tetrominoBlocks[2].X = (byte)(CentralBlock.X + 2);
                        tetrominoBlocks[2].Y = CentralBlock.Y;
                        tetrominoBlocks[3].X = (byte)(CentralBlock.X + 3);
                        tetrominoBlocks[3].Y = CentralBlock.Y;
                    }
                    break;
                case Field.Tetrominos.J:
                    switch (Position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[2].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[2].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y - 1);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[2].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[2].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y - 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[2].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[2].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y + 1);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[2].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[2].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.L:
                    switch (Position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y + 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.O:
                    break;
                case Field.Tetrominos.T:
                    switch (Position)
                    {
                        case 0:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y);
                            break;
                        case 1:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y + 1);
                            break;
                        case 2:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y - 1);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X - 1);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y);
                            break;
                        case 3:
                            tetrominoBlocks[0].X = (byte)(CentralBlock.X + 1);
                            tetrominoBlocks[0].Y = (byte)(CentralBlock.Y);
                            tetrominoBlocks[1].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                            tetrominoBlocks[3].X = (byte)(CentralBlock.X);
                            tetrominoBlocks[3].Y = (byte)(CentralBlock.Y - 1);
                            break;
                    }
                    break;
                case Field.Tetrominos.Z:
                    if (Position % 2 == 0)
                    {
                        tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(CentralBlock.Y);
                        tetrominoBlocks[1].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[2].X = (byte)(CentralBlock.X);
                        tetrominoBlocks[2].Y = (byte)(CentralBlock.Y - 1);
                    }
                    else
                    {
                        tetrominoBlocks[0].X = (byte)(CentralBlock.X);
                        tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[1].X = (byte)(CentralBlock.X + 1);
                        tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[2].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[2].Y = (byte)(CentralBlock.Y);
                    }
                    break;
                case Field.Tetrominos.S:
                    if (Position % 2 == 0)
                    {
                        tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[1].X = (byte)(CentralBlock.X);
                        tetrominoBlocks[1].Y = (byte)(CentralBlock.Y + 1);
                        tetrominoBlocks[3].X = (byte)(CentralBlock.X + 1);
                        tetrominoBlocks[3].Y = (byte)(CentralBlock.Y);
                    }
                    else
                    {
                        tetrominoBlocks[0].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[0].Y = (byte)(CentralBlock.Y - 1);
                        tetrominoBlocks[1].X = (byte)(CentralBlock.X - 1);
                        tetrominoBlocks[1].Y = (byte)(CentralBlock.Y);
                        tetrominoBlocks[3].X = (byte)(CentralBlock.X);
                        tetrominoBlocks[3].Y = (byte)(CentralBlock.Y + 1);
                    }
                    break;
            }
            if (Position == 4)
            {
                Position = 0;
            }
            else
            {
                Position++;
            }
        }

        public void Right()
        {
            switch (Type)
            {
                case Field.Tetrominos.I:
                    if (Position % 2 == 0)
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
                    switch (Position)
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
                    switch (Position)
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
                    switch (Position)
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
                    if (Position % 2 == 0)
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
                    if (Position % 2 == 0)
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
            switch (Type)
            {
                case Field.Tetrominos.I:
                    if (Position % 2 == 0)
                    {
                        if (Block.CheckLeft(CentralBlock))
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
                    switch (Position)
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
                    switch (Position)
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
                    switch (Position)
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
                    if (Position % 2 == 0)
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
                    if (Position % 2 == 0)
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
                IsDown = true;
            }
        }

        private bool IsDownCheck()
        {
            bool fallCheck = false;
            switch (Type)
            {
                case Field.Tetrominos.I:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 1);
                    break;
                case Field.Tetrominos.J:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 2);
                    break;
                case Field.Tetrominos.L:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 3);
                    break;
                case Field.Tetrominos.O:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 4);
                    break;
                case Field.Tetrominos.T:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 5);
                    break;
                case Field.Tetrominos.Z:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 6);
                    break;
                case Field.Tetrominos.S:
                    fallCheck = CentralBlock.CheckBlocksNearby(Position, 7);
                    break;
            }
            return fallCheck;
        }
    }
}
