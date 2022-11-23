using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStart();
        }
        const int rows = 3;
        const int columns = 3;
        static void GameStart()
        {
            const char zero = 'O';
            const char crosses = 'X';
            
            
            while (true)
            {
                Random random = new Random();
                bool firstMove = random.Next(2) % 2 == 0 ? true : false;
                char symbol = firstMove ? crosses : zero;
                Console.WriteLine($"{symbol} moves first");
                char[,] table = new char[rows, columns];
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < columns; ++j)
                    {
                        table[i, j] = '_';
                    }
                }
                int counter = 0;
                while (true)
                {
                    if (counter == 9)
                    {
                        Console.WriteLine("No one won");
                        break;
                    }
                    Console.WriteLine($"Now it's {symbol} turn \n\n");
                    
                    for (int i = 0; i < rows; ++i)
                    {
                        for (int j = 0; j < columns; ++j)
                        {
                            Console.Write($" {table[i, j]}\t");
                        }
                        Console.WriteLine("\n\n");
                    }
                    Console.WriteLine($"When would you like to mark {symbol}?(Enter first (row) and second(column) number 0 to 2)");
                    int.TryParse(Console.ReadLine(), out int x);
                    int.TryParse(Console.ReadLine(), out int y);
                    if ( !(x >= 0 && x <= 2 && y >= 0 && y <= 2 && table[x,y] != zero && table[x,y] != crosses))
                    {
                        while (true)
                        {
                            Console.WriteLine("Incorrect data. Please, Try again:");
                            int.TryParse(Console.ReadLine(), out x);
                            int.TryParse(Console.ReadLine(), out y);
                            if (!(x >= 0 && x <= 2 && y >= 0 && y <= 2 && table[x, y] != zero && table[x, y] != crosses))
                            {
                                continue;
                            }
                            break;
                        }
                    }
                    table[x, y] = symbol;
                    if (IsWinner(symbol, table))
                    {
                        Console.WriteLine($"{symbol} has won ");
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
        static bool IsWinner(char symbol, char[,] table)
        {
            for (int i = 0; i < rows; ++i)
            {
                if ((table[i,0] == symbol && table[i,1] == symbol && table[i,2] == symbol ) || (table[0, i] == symbol && table[1, i] == symbol && table[2, i] == symbol))
                {
                    return true;
                }
            }
            if ((table[0,0] == symbol && table[1,1] == symbol && table[2,2] == symbol) || (table[2,0] == symbol && table[1,1] == symbol && table[0,2] == symbol))
            {
                return true;
            }
            return false;
        }
    }
}