using System;

class Program
{
    static void Main()
    {
        string[] board = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string player = "X";
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe\n");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} \n");

            // Get player move
            Console.Write($"Player {player}, enter number (1-9): ");
            if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9 && board[move - 1] != "X" && board[move - 1] != "O")
            {
                board[move - 1] = player;

                // Check for winner
                if (CheckWin(board, player))
                {
                    Console.WriteLine($"\nPlayer {player} wins!");
                    gameOver = true;
                    continue;
                }

                // Check for draw
                if (board.All(cell => cell == "X" || cell == "O"))
                {
                    Console.WriteLine("\nIt's a draw!");
                    gameOver = true;
                    continue;
                }

                player = player == "X" ? "O" : "X";
            }
        }
    }

    static bool CheckWin(string[] board, string player)
    {
        // Check rows
        for (int i = 0; i < 9; i += 3)
            if (board[i] == player && board[i + 1] == player && board[i + 2] == player)
                return true;

        // Check columns
        for (int i = 0; i < 3; i++)
            if (board[i] == player && board[i + 3] == player && board[i + 6] == player)
                return true;

        // Check diagonals
        if (board[0] == player && board[4] == player && board[8] == player)
            return true;
        if (board[2] == player && board[4] == player && board[6] == player)
            return true;

        return false;
    }
}


