using System;

namespace TicTacToev2 {
    public class Menu {
        public void buildMenu() {
            Console.Clear();
            Console.SetWindowSize(40, 25);
            Console.SetBufferSize(40, 25);
            int iInput = 0;

            Console.SetCursorPosition(9, 0);
            Console.WriteLine("Welcome to Tic Tac Toe");

            Console.SetCursorPosition(0, 3);
            Console.WriteLine("1. Play as Naughts");

            Console.SetCursorPosition(0, 6);
            Console.WriteLine("2. Play as Crosses");

            Console.SetCursorPosition(0, 9);
            Console.WriteLine("3. View Highscores");

            Console.SetCursorPosition(0, 12);
            Console.WriteLine("4. Exit");

            int[] inputs = {1,2,3,4};
            while (Array.IndexOf(inputs, iInput) == -1) {
                Console.SetCursorPosition(0, 14);
                try {
                    iInput = Convert.ToInt32(Console.ReadLine());
                } catch (SystemException) {
                    Console.Clear();

                    Console.SetCursorPosition(9, 0);
                    Console.WriteLine("Welcome to Tic Tac Toe");

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("1. Play as Naughts");

                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("2. Play as Crosses");

                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("3. View Highscores");

                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("4. Exit");

                    Console.WriteLine("Please input a valid number");
                }
            }

            switch (iInput) {
                case 1:
                    game("Noughts", "O", "X");
                break;
                case 2:
                    game("Crosses", "X", "O");
                break;
                case 3:

                break;
                case 4:
                    Exit ex = new Exit();
                    if (ex.handleExit() == "Y") {
                        Console.Clear();
                        Console.SetCursorPosition(15, 4);
                        Console.Write("Goodbye");
                        Console.ReadKey();
                        Console.Clear();
                        Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
                        Console.SetBufferSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
                        Environment.Exit(0);
                    } else {
                        buildMenu();
                    }
                break;
            }
        }

        private void game (string team, string symbol, string aiSymbol) {
            GameBoard gb = new GameBoard();
            GamePlay gp = new GamePlay();
            char difficulty;
            bool playerTurn = true;
            string endGame = "";

            difficulty = gb.handleDifficulty();
            gb.drawBoard(team);
            gb.setTime(0);
            while (endGame == "") {
                if (playerTurn == true) {
                    gp.takeTurn(symbol, 0, 0);
                    playerTurn = false;
                }
                else {
                    gp.aiTurn(difficulty, aiSymbol);
                    playerTurn = true;
                }
                endGame = gp.endGame();
            }

            gb.endScreen(endGame, symbol);
        }
    }
}