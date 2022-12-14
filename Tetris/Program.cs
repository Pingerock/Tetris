using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Blocks;
using System.Windows.Input;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.ReadLine();
        }

        static void Start()
        {
            Field field = new Field();
            field.CreateField();
            field.PrintField();
            Block testBlock = new Block(2, 0);
            testBlock.CreateBlock();
            Console.CursorVisible = false;
            Update(field);
        }

        static void Update(Field field)
        {
            Thread thread = new Thread(() => ReadInput(field));
            thread.Start();
            while (true)
            {
                System.Threading.Thread.Sleep(750);
                field.MoveBlock();
                Console.SetCursorPosition(0, 0);
                field.PrintField();
            }
        }

        public static void ReadInput(Field field)
        {
            while (true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        field.MoveBlocks_Left();
                        break;
                    case ConsoleKey.RightArrow:
                        field.MoveBlocks_Right();
                        break;
                }
            }
        }
    }
}
