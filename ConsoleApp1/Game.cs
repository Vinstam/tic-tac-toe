using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        const int rows = 3;
        const int columns = 3;
        const char zero = 'O';
        const char crosses = 'X';
        static char[,] table = new char[rows, columns];
        static int firstPosition;
        static int secondPosition;
        public static void Start()
        {
            
            while (true)
            {
                
                Random random = new Random();
                int counter = 0;
                bool firstMove = random.Next(2) % 2 == 0 ? true : false;
                char symbol = firstMove ? crosses : zero;
                Console.WriteLine($"{symbol} moves first");
                
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < columns; ++j)
                    {
                        table[i, j] = '_';
                    }
                }
                while (true)
                {
                    if (counter == 9)
                    {

                        PrintMessage("No one won");
                        break;
                    }
                    Console.WriteLine($"Now it's {symbol} turn \n\n");

                    PrintTable();
                    
                    Console.WriteLine($"When would you like to mark {symbol}?(Enter first (row) and second(column) number 0 to 2)");
                    if(!IsCorrectData(out firstPosition,out  secondPosition))
                    {
                        while (true)
                        {
                            Console.WriteLine("Incorrect data. Please, Try again:");
                            if (!IsCorrectData(out firstPosition, out secondPosition))
                            {
                                continue;
                            }
                            break;
                        }
                    }
                    table[firstPosition, secondPosition] = symbol;
                    if (IsWinner(symbol, table))
                    {
                        PrintMessage($"{symbol} has won ");
                        break;
                    }

                    symbol = symbol == crosses ? zero : crosses;
                    counter += 1;
                    Console.Clear();
                }
                Console.WriteLine("Would you like to continue(Press Y for yes and other for no)");

                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine("Thanks for playing");
        }
        public static bool IsWinner(char symbol, char[,] table)
        {
            for (int i = 0; i < rows; ++i)
            {
                if ((table[i, 0] == symbol && table[i, 1] == symbol && table[i, 2] == symbol) || (table[0, i] == symbol && table[1, i] == symbol && table[2, i] == symbol))
                {
                    return true;
                }
            }
            if ((table[0, 0] == symbol && table[1, 1] == symbol && table[2, 2] == symbol) || (table[2, 0] == symbol && table[1, 1] == symbol && table[0, 2] == symbol))
            {
                return true;
            }
            return false;
        }
        public static bool IsCorrectData(out int firstPosition, out int secondPosition)
        {
            bool checkFirst = int.TryParse(Console.ReadLine(), out firstPosition);
            bool checkSecond = int.TryParse(Console.ReadLine(), out secondPosition);
            if (!(firstPosition >= 0 && firstPosition <= 2 && secondPosition >= 0 && secondPosition <= 2 && table[firstPosition, secondPosition] != zero && table[firstPosition, secondPosition] != crosses && checkFirst == true && checkSecond == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void PrintTable()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Console.Write($" {table[i, j]}\t");
                }
                Console.WriteLine("\n\n");
            }
        }
        public static void PrintMessage(string message)
        {
            Console.Clear();
            PrintTable();
            Console.WriteLine(message);
        }
    }
}
