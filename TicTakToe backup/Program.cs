using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTakToe_backup
{
    class Program
    {
        static int player = 2;
        static int playerInput = 0;
        static bool isNum = true;
        static string token = "X";

        static string[,] board =
                {
                    { "1", "2", "3" },
                    { "4", "5", "6" },
                    { "7", "8", "9" }
                };

        public static void Main(string[] args)
        {
            do
            {
                PrintField();

                if (playerInput == 9)
                {
                    Console.WriteLine("We have a draw!");
                    Console.WriteLine("Press any key to replay.");
                    Console.ReadLine();
                    ResetGame();
                }

                if (player == 2)
                    player = 1;
                else if (player == 1)
                    player = 2;

                switch (player)
                {
                    case 1:
                        token = "X";
                        break;
                    case 2:
                        token = "O";
                        break;
                }

                do
                {

                    


                    Console.WriteLine("\nPlayer {0}: choose a field.", player);


                    string input = Console.ReadLine();

                    isNum = int.TryParse(input, out int position);

                    if (isNum && position < 10 && position > 0)
                    {
                        if (FieldCahange(input))
                        {
                            WinCheck();
                            playerInput++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease choose another field!");
                        }
                        
                    }
                    else if (!isNum)
                    {
                        Console.WriteLine("\nPlease enter a number!");
                    }
                    else
                    {
                        Console.WriteLine("\nNumber must be between 1 and 9!");
                    }
                } while (true);

            } while (true);

        }
        
        public static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0], board[0,1], board[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1,0], board[1,1], board[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2,0], board[2,1], board[2,2]);
            Console.WriteLine("     |     |    ");
        }

        public static void WinCheck()
        {
            if((board[0,0] == token && board[0,1] == token && board[0,2] == token) 
                || (board[1,0] == token && board[1,1] == token && board[1,2] == token) 
                || (board[2,0] == token && board[2,1] == token && board[2,2] == token) 
                || (board[0,0] == token && board[1,0] == token && board[2,0] == token) 
                || (board[0,1] == token && board[1,1] == token && board[2,1] == token) 
                || (board[0,2] == token && board[1,2] == token && board[2,2] == token) 
                || (board[0,0] == token && board[1,1] == token && board[2,2] == token) 
                || (board[0,2] == token && board[1,1] == token && board[2,0] == token))

            {
                Console.WriteLine("Player {0} Wins!!!", player);
                Console.WriteLine("Press any key to replay.");
                Console.ReadLine();
                ResetGame();
            }
        }

        public static void ResetGame()
        {
            string[,] boardInitial =
                {
                    { "1", "2", "3" },
                    { "4", "5", "6" },
                    { "7", "8", "9" }
                };

            board = boardInitial;
            playerInput = 0;
            PrintField();
        }

        public static bool FieldCahange(string input)
        { 
            bool hasChanged = false;
            for(int i = 0; i <= 2; i++)
            {
                for(int j = 0; j <= 2; j++)
                {
                    if (board[i, j] == input && board[i, j] != "X" && board[i, j] != "O")
                    {
                        board[i, j] = token;
                        hasChanged = true;
                    }
                }
            }
            return hasChanged;
        }
    }
}
