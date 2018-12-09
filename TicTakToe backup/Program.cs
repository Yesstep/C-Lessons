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

        static string[] board = 
                {
                    "1", "2", "3", "4", "5", "6", "7", "8", "9"
                };

        public static void Main(string[] args)
        {
            do
            {
                PrintField();

                WinCheck();

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

                    Console.WriteLine("\nPlayer {0}: chosse a field.", player);

                    string input = Console.ReadLine();

                    isNum = int.TryParse(input, out int position);

                    if (isNum && position < 10 && position > 0)
                    {
                        if (board[position - 1] != "X" && board[position - 1] != "O")
                        {
                            board[position - 1] = token;
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
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[6], board[7], board[8]);
            Console.WriteLine("     |     |    ");
        }

        public static bool WinCheck()
        {
            bool hasWon = false;
            int playerNum;
            switch (token)
            {
                case "X":
                    playerNum = 1; break;
                case "O":
                    playerNum = 2; break;
            }

            if((board[0] == token && board[1] == token && board[2] == token) 
                || (board[3] == token && board[4] == token && board[5] == token) 
                || (board[6] == token && board[7] == token && board[8] == token) 
                || (board[0] == token && board[3] == token && board[6] == token) 
                || (board[1] == token && board[4] == token && board[7] == token) 
                || (board[2] == token && board[5] == token && board[8] == token) 
                || (board[0] == token && board[4] == token && board[8] == token) 
                || (board[2] == token && board[4] == token && board[6] == token))
            {
                hasWon = true;
                Console.WriteLine("Player {0} Wins!!!", player);
                Console.WriteLine("Press any key to replay.");
                Console.ReadLine();
                ResetGame();
            }
            return hasWon;
        }

        public static void ResetGame()
        {
            string[] boardInitial =
                {
                    "1", "2", "3", "4", "5", "6", "7", "8", "9"
                };

            board = boardInitial;
            playerInput = 0;
            PrintField();
        }
    }
}
