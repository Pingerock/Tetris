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
                    break;
                case Field.Tetrominos.J:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    break;
                case Field.Tetrominos.L:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    break;
                case Field.Tetrominos.O:
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    break;
                case Field.Tetrominos.T:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    break;
                case Field.Tetrominos.Z:
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(4, 1));
                    tetrominoBlocks.Add(new Block(2, 0));
                    tetrominoBlocks.Add(new Block(3, 0));
                    break;
                case Field.Tetrominos.S:
                    tetrominoBlocks.Add(new Block(2, 1));
                    tetrominoBlocks.Add(new Block(3, 1));
                    tetrominoBlocks.Add(new Block(3, 0));
                    tetrominoBlocks.Add(new Block(4, 0));
                    break;
            }
        }

        public void Rotate()
        {
            
        }

        public void Right()
        {
            
        }

        public void Left()
        {
            
        }

        public void Fall()
        {
            bool fallCheck = true;
            foreach (Block block in tetrominoBlocks)
            {
                if (block.IsDownCheck())
                {
                    fallCheck = false;
                    isDown = true;
                    break;
                }
            }
            if (!fallCheck)
            {
                foreach (Block block in tetrominoBlocks)
                {
                    block.Fall();
                }
            }
        }

        public bool checkFall()
        {
            bool fallCheck = true;
            switch (type)
            {
                case Field.Tetrominos.I:
                    foreach (Block block in tetrominoBlocks)
                    {
                        if (block.IsDownCheck())
                        {
                            fallCheck = false;
                            isDown = true;
                            return fallCheck;
                        }
                    }
                    return fallCheck;
                case Field.Tetrominos.J:
                    for (byte x = 0; x < 3; x++)
                    {
                        if (tetrominoBlocks[x].IsDownCheck())
                        {
                            fallCheck = false;
                            isDown = true;
                            return fallCheck;
                        }
                    }
                    return fallCheck;
                case Field.Tetrominos.L:
                    for (byte x = 1; x < 4; x++)
                    {
                        if (tetrominoBlocks[x].IsDownCheck())
                        {
                            fallCheck = false;
                            isDown = true;
                            return fallCheck;
                        }
                    }
                    return fallCheck;
                case Field.Tetrominos.O:
                    for (byte x = 2; x < 4; x++)
                    {
                        if (tetrominoBlocks[x].IsDownCheck())
                        {
                            fallCheck = false;
                            isDown = true;
                            return fallCheck;
                        }
                    }
                    return fallCheck;
                case Field.Tetrominos.T:
                    
                    break;
                case Field.Tetrominos.Z:
                    
                    break;
                case Field.Tetrominos.S:
                    
                    break;
            }
        }
    }
}
