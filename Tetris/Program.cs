using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris
{
    internal class Program
    {
        static ushort waitTime = 500;

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
            field.CreateBlock();
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Update(field);
        }

        static void Update(Field field)
        {
            Thread thread = new Thread(() => ReadInput(field));
            thread.Start();
            while (true)
            {
                System.Threading.Thread.Sleep(waitTime);
                field.MoveBlock();
                Console.SetCursorPosition(0, 0);
                field.PrintField();
            }
        }

        public static void ReadInput(Field field)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey();
            while (true)
            {
                if (Console.KeyAvailable == false)
                {
                    input = Command(field, input);
                }
                else
                {
                    input = Console.ReadKey();
                }
            }
        }

        // Note: holding down button ruins the visual of field. How does it work?!
        public static ConsoleKeyInfo Command(Field field, ConsoleKeyInfo input)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(waitTime);
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        field.IsMovedLeft = true;
                        break;
                    case ConsoleKey.RightArrow:
                        field.IsMovedRight = true;
                        break;
                    // The program doesn't registry holding and unholding button fast. Need to do something with ReadInput method.
                    case ConsoleKey.DownArrow:
                        waitTime = 50;
                        break;
                    case ConsoleKey.Spacebar:
                        if(!field.IsLost)
                        {
                            if (!field.IsPaused)
                            {
                                field.IsPaused = true;
                            }
                            else
                            {
                                field.IsPaused = false;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        field.IsRotated = true;
                        break;
                    default:
                        waitTime = 500;
                        break;
                }
                input = default(ConsoleKeyInfo);
                return input;
            }
        }
    }
}
