using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Position[] positions = new Position[]
            {
                new Position(0 , 1), // move right
                new Position(0 , -1), // move left
                new Position(1 , 0), // down
                new Position(-1 , 0) // top


            };
            int directories = 0;
            Console.BufferHeight = Console.BufferHeight;
            Queue<Position> snake = new Queue<Position>();

            for (int i = 0; i <= 5; i++)
            {
                snake.Enqueue(new Position(0, i));
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        directories = 1;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        directories = 0;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        directories = 3;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        directories = 2;
                    }
                    if (userInput.Key == ConsoleKey.F1)
                    {
                        return;
                    }
                }

                foreach (Position position in snake)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write("*");
                }

                Position snakeHead = snake.Last();
                snake.Dequeue();
                Position nextDirection = positions[directories];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                snake.Enqueue(snakeNewHead);
                Console.Clear();

                foreach (Position position in snake)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write("*");
                }
                Thread.Sleep(200);
            }
        }
    }
}
