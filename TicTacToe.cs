using System;

class Program
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        bool gameRunning = true;

        while (gameRunning)
        {
            DrawBoard();
            Console.WriteLine("Player " + currentPlayer + ", enter your move (1-9):");

            int move;
            if (int.TryParse(Console.ReadLine(), out move))
            {
                if (IsValidMove(move))
                {
                    MakeMove(move);

                    if (CheckWin())
                    {
                        Console.WriteLine("Player " + currentPlayer + " wins!");
                        gameRunning = false;
                    }
                    else if (IsBoardFull())
                    {
                        Console.WriteLine("It's a tie!");
                        gameRunning = false;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2] + " ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5] + " ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8] + " ");
    }

    static bool IsValidMove(int move)
    {
        return (move >= 1 && move <= 9 && board[move - 1] == ' ');
    }

    static void MakeMove(int move)
    {
        board[move - 1] = currentPlayer;
    }

    static bool CheckWin()
    {
        // Check rows
        for (int i = 0; i <= 6; i += 3)
        {
            if (board[i] != ' ' && board[i] == board[i + 1] && board[i + 1] == board[i + 2])
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i <= 2; i++)
        {
            if (board[i] != ' ' && board[i] == board[i + 3] && board[i + 3] == board[i + 6])
            {
                return true;
            }
        }

        // Check diagonals
        if ((board[0] != ' ' && board[0] == board[4] && board[4] == board[8]) ||
            (board[2] != ' ' && board[2] == board[4] && board[4] == board[6]))
        {
            return true;
        }

        return false;
    }

    static bool IsBoardFull()
    {
        foreach (char cell in board)
        {
            if (cell == ' ')
            {
                return false;
            }
        }
        return true;
    }
}
