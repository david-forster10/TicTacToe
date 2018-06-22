using System;

namespace TicTacToev2 {
    public class GameBoard {
        private static int time = 0;
        private static string[,] highScorers = new string[10,3];

        public char handleDifficulty() {
            Console.Clear();
            Console.SetCursorPosition(9, 0);
            Console.WriteLine("Welcome to Tic Tac Toe");

            Console.WriteLine("\nPlease Select Your Difficulty: \n'E'. Easy \n'M'. Medium \n'H'. Hard\n");
            string sDifficulty = Console.ReadLine();

            while (sDifficulty.ToLower() != "e" && sDifficulty.ToLower() != "m" && sDifficulty.ToLower() != "h") {
                Console.Clear();
                Console.SetCursorPosition(9, 0);
                Console.WriteLine("Welcome to Tic Tac Toe");

                Console.WriteLine("\nPlease Select Your Difficulty: \n'E'. Easy \n'M'. Medium \n'H'. Hard!\nPlease input a valid Character:");
                sDifficulty = Console.ReadLine();
            }

            return sDifficulty.ToUpper()[0];
        }

        private static System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        public void drawBoard(string team) {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Console.Clear();
            Console.SetCursorPosition(9, 0);
            Console.WriteLine("Welcome to Tic Tac Toe");

            Console.SetCursorPosition(7, 1);
            Console.Write("You are playing as {0}!", team);

            Console.WriteLine();
            for (int j = 0; j < 15; j++) {
                Console.SetCursorPosition(9, j+4);

                for (int i = 0; i < 21; i++) {
                    if (i == 1 || i == 7 || i == 13 || i == 19)
                        Console.Write("|");
                    else if (i == 0 && j == 3)
                        Console.Write("1");
                    else if (i == 0 && j == 7)
                        Console.Write("2");
                    else if (i == 0 && j == 11)
                        Console.Write("3");
                    else if (j == 1 || j == 13 || j == 5 || j == 9)
                        Console.Write("-");
                    else if (j == 0 && i == 4)
                        Console.Write("1");
                    else if (j == 0 && i == 10)
                        Console.Write("2");
                    else if (j == 0 && i == 16)
                        Console.Write("3");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
                Console.SetCursorPosition(9, j+4);
            }

            if (aTimer.Enabled != true) {
                aTimer = new System.Timers.Timer(1000);

                aTimer.Elapsed += OnTimedEvent;

                aTimer.AutoReset = true;

                aTimer.Enabled = true;
            }
        }
        
        void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
            int iCursorLeft = Console.CursorLeft;
            int iCursorTop = Console.CursorTop;

            time += 1;

            Console.SetCursorPosition(24, 3);
            if (time > 1) 
                Console.Write("Time: {0} secs", time);
            else
                Console.Write("Time: {0} sec", time);
            
            Console.SetCursorPosition(iCursorLeft, iCursorTop);
        }

        public void endScreen(string winner, string player) {
            
            if (aTimer.Enabled == true) {
                aTimer.Enabled = false;
            }

            Console.Clear();
            Console.SetWindowSize(30, 20);
            Console.SetBufferSize(30, 20);

            if (winner == "draw") {
                Console.SetCursorPosition(8, 7);
                Console.Write("It was a Draw!");
            } else if (winner == player) {
                Console.SetCursorPosition(11, 7);
                Console.Write("You Win!");
            } else {
                Console.SetCursorPosition(10, 7);
                Console.Write("You Lose!");
            }

            Console.SetCursorPosition(1, 9);
            Console.Write("Return To The Main Menu? Y/N");
            Console.SetCursorPosition(14, 10);
 
            string input = Console.ReadLine().ToUpper();
            if (input != "Y" && input != "N") {
                endScreen(winner, player);
            }

            if (input == "Y") {
                Menu mn = new Menu();
                mn.buildMenu();
            } else if (input == "N") {
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
                    endScreen(winner, player);
                }
            }
        }

        public int getTime() {
            return time;
        }

        public void setTime(int newTime) {
            time = newTime;
        }

        public string[,] getHighScorers() {
            return highScorers;
        }

        public void setHighScorers(string[,] newScorers) {
            highScorers = newScorers;
        }

        // public void highScores() {
        //     Console.Clear();
        //     Console.SetCursorPosition(9, 0);
        //     Console.WriteLine("Highscores");

        //     Console.SetCursorPosition(0, 3);
        //     Console.WriteLine("Username:");
        //     Console.SetCursorPosition(16, 3);
        //     Console.Write("Time(s):");
        //     Console.SetCursorPosition(28, 3);
        //     Console.Write("Difficulty:");

        //     Console.SetCursorPosition(0, 5);
        //     for (int iCount = 1; iCount < 11; iCount++) {
        //         if (GlobalVariables.sHighScoreNames[iCount] != null)
        //             if (iCount == 10)
        //                 Console.WriteLine(iCount + ". " + GlobalVariables.sHighScoreNames[iCount]);
        //             else
        //                 Console.WriteLine(iCount + ".  " + GlobalVariables.sHighScoreNames[iCount]);
        //         else
        //             if (iCount == 10)
        //                 Console.WriteLine(iCount + ". " + "No User");
        //             else
        //                 Console.WriteLine(iCount + ".  " + "No User");
        //     }

        //     iLine = 5;
        //     for (int iCount = 1; iCount < 11; iCount++) {
        //         Console.SetCursorPosition(16, iLine);
        //         if (GlobalVariables.iHighScoreTime[iCount] != 0)
        //             Console.WriteLine(GlobalVariables.iHighScoreTime[iCount]);
        //         else
        //             Console.WriteLine("");
        //         iLine += 1;
        //     }

        //     iLine = 5;
        //     for (int iCount = 1; iCount < 11; iCount++) {
        //         Console.SetCursorPosition(28, iLine);
        //         if (GlobalVariables.sHighScoreDifficulty[iCount] != null)
        //             switch (GlobalVariables.sHighScoreDifficulty[iCount]) {
        //                 case "E":
        //                     Console.WriteLine("Easy");
        //                     break;
        //                 case "M":
        //                     Console.WriteLine("Medium");
        //                     break;
        //                 case "H":
        //                     Console.WriteLine("Hard");
        //                     break;
        //             }
        //         else
        //             Console.WriteLine("");
        //         iLine += 1;
        //     }
        //     Console.Write("Press Enter to continue!\n");
        // }
    }
}