using System;
using System.Threading;

namespace TicTacToev2 {
    public class GamePlay {
        string[,] squareUsed = new string[3,3];

        public string endGame() {
            if (multiEquals(squareUsed[0,0], squareUsed[0,1], squareUsed[0,2])) {
                return squareUsed[0,0];
            } else if (multiEquals(squareUsed[1,0], squareUsed[1,1], squareUsed[1,2])) {
                return squareUsed[1,0];
            } else if (multiEquals(squareUsed[2,0], squareUsed[2,1], squareUsed[2,2])) {
                return squareUsed[2,0];
            } else if (multiEquals(squareUsed[0,0], squareUsed[1,1], squareUsed[2,2])) {
                return squareUsed[0,0];
            } else if (multiEquals(squareUsed[0,2], squareUsed[1,1], squareUsed[2,0])) {
                return squareUsed[0,2];
            } else if (multiEquals(squareUsed[0,0], squareUsed[1,0], squareUsed[2,0])) {
                return squareUsed[0,0];
            } else if (multiEquals(squareUsed[0,1], squareUsed[1,1], squareUsed[2,1])) {
                return squareUsed[0,1];
            } else if (multiEquals(squareUsed[0,2], squareUsed[1,2], squareUsed[2,2])) {
                return squareUsed[0,2];
            }

            foreach (string curr in squareUsed) {
                if (curr == null) {
                    return "";
                }
            }

            return "draw";
        }

        public void takeTurn(string player, int col = 0, int row = 0) {
            Console.SetCursorPosition(15, 20);
            Console.Write("Your Turn!");
            Console.WriteLine("\nPlease input the number for the column:");

            if (col > 0 && col < 4) {
                Console.WriteLine(col);
                Console.SetCursorPosition(0,23);
            } else {
                Utils.ClearCurrentConsoleLine();
                try {
                    col = Convert.ToInt32(Console.ReadLine());
                    if (col > 3 || col < 1) {
                        throw new Exception("Out Of Bounds");
                    }
                    Console.SetCursorPosition(0,23);
                    Utils.ClearCurrentConsoleLine();
                } catch (Exception) {
                    Console.WriteLine("ERROR! Please input a valid number");
                    takeTurn(player);
                    return;
                }
            }

            Console.SetCursorPosition(0,23);
            Console.Write("\nNow please input the number for the row:");
            Utils.ClearCurrentConsoleLine();
            try {
                row = Convert.ToInt32(Console.ReadLine());
                if (row > 3 || row < 1) {
                    throw new Exception("Out Of Bounds");
                }
                Console.SetCursorPosition(0,26);
                Utils.ClearCurrentConsoleLine();
            } catch (Exception) {
                Console.WriteLine("ERROR! Please input a valid number");
                takeTurn(player, col);
                return;
            }                

            Console.SetCursorPosition(0, 25);
            Utils.ClearCurrentConsoleLine();
            
            if (squareUsed[col-1, row-1] != null) {
                Console.WriteLine("This square has already been selected!");
                takeTurn(player);
                return;
            }

            Console.SetCursorPosition(0,22);
            Utils.ClearCurrentConsoleLine();

            Console.SetCursorPosition((6 * col) + 7, (4 * row) + 3);
            Console.Write(player);
            squareUsed[col-1, row-1] = player;
        }

        public void aiTurn(char difficulty, string symbol) {
            Console.SetCursorPosition(15, 20);
            Utils.ClearCurrentConsoleLine();
            Console.SetCursorPosition(15, 20);
            Console.Write("CPU's Turn!");
            
            Console.SetCursorPosition(0, 22);
            Random random = new Random();
            int col = 0, row = 0;
            switch (difficulty) {
                case 'E':
                    randomSquares(random, out col, out row);
                    break;
                case 'M':
                    if (random.Next(1, 101) > 75) {
                        randomSquares(random, out col, out row);
                    } else {
                        addedDifficulty(random, out col, out row);
                    }
                    break;
                case 'H':
                    if (random.Next(1, 101) > 90) {
                        randomSquares(random, out col, out row);
                    } else {
                        addedDifficulty(random, out col, out row);
                    }
                    break;
                default:
                    throw new Exception("Error! Unknown difficulty set");
            }
            Thread.Sleep(2500);
            Console.SetCursorPosition((6 * (col+1)) + 7, (4 * (row+1)) + 3);
            Console.Write(symbol);
            squareUsed[col, row] = symbol;
        }

        void randomSquares(Random ran, out int returnCol, out int returnRow) {
            do {
                returnCol = ran.Next(0, 3);
                returnRow = ran.Next(0, 3);
            } while (squareUsed[returnCol, returnRow] != null);
        }

        bool multiEquals(string val1, string val2, string val3) {
            return (val1 == val2 && val2 == val3) && (val1 == "X" || val1 == "O");
        }

        void addedDifficulty(Random ran, out int returnCol, out int returnRow) {
            int col = -1, row = -1;
            if (squareUsed[0, 1] == squareUsed[0, 2] && squareUsed[0,1] != null && squareUsed[0, 0] == null) {
                col = 0;
                row = 0;
            }

            if (squareUsed[1, 0] == squareUsed[2, 0] && squareUsed[1,0] != null && squareUsed[0, 0] == null) {
                col = 0;
                row = 0;
            }

            if (squareUsed[1, 1] == squareUsed[2, 2] && squareUsed[1,1] != null && squareUsed[0, 0] == null) {
                col = 0;
                row = 0;
            }

            if (squareUsed[0, 0] == squareUsed[2, 0] && squareUsed[0,0] != null && squareUsed[1, 0] == null) {
                col = 1;
                row = 0;
            }

            if (squareUsed[1, 1] == squareUsed[1, 2] && squareUsed[1,1] != null && squareUsed[1, 0] == null) {
                col = 1;
                row = 0;
            }

            if (squareUsed[0, 0] == squareUsed[1, 0] && squareUsed[0,0] != null && squareUsed[2, 0] == null) {
                col = 2;
                row = 0;
            }

            if (squareUsed[2, 1] == squareUsed[2, 2] && squareUsed[2,1] != null && squareUsed[2, 0] == null) {
                col = 2;
                row = 0;
            }

            if (squareUsed[1, 1] == squareUsed[0, 2] && squareUsed[1,1] != null && squareUsed[2, 0] == null) {
                col = 2;
                row = 0;
            }

            if (squareUsed[0, 0] == squareUsed[0, 2] && squareUsed[0,0] != null && squareUsed[0, 1] == null) {
                col = 0;
                row = 1;
            }

            if (squareUsed[1, 1] == squareUsed[2, 1] && squareUsed[1,1] != null && squareUsed[0, 1] == null) {
                col = 0;
                row = 1;
            }

            if (squareUsed[0, 1] == squareUsed[2, 1] && squareUsed[0,1] != null && squareUsed[1, 1] == null) {
                col = 1;
                row = 1;
            }

            if (squareUsed[1, 0] == squareUsed[1, 2] && squareUsed[1,0] != null && squareUsed[1, 1] == null) {
                col = 1;
                row = 1;
            }

            if (squareUsed[0, 0] == squareUsed[2, 2] && squareUsed[0,0] != null && squareUsed[1, 1] == null) {
                col = 1;
                row = 1;
            }

            if (squareUsed[2, 0] == squareUsed[0, 2] && squareUsed[2,0] != null && squareUsed[1, 1] == null) {
                col = 1;
                row = 1;
            }

            if (squareUsed[2, 0] == squareUsed[2, 2] && squareUsed[2,0] != null && squareUsed[2, 1] == null) {
                col = 2;
                row = 1;
            }

            if (squareUsed[0, 1] == squareUsed[1, 1] && squareUsed[0,1] != null && squareUsed[2, 1] == null) {
                col = 2;
                row = 1;
            }

            if (squareUsed[0, 0] == squareUsed[0, 1] && squareUsed[0,0] != null && squareUsed[0, 2] == null) {
                col = 0;
                row = 2;
            }

            if (squareUsed[1, 2] == squareUsed[2, 2] && squareUsed[1,2] != null && squareUsed[0, 2] == null) {
                col = 0;
                row = 2;
            }

            if (squareUsed[1, 1] == squareUsed[2, 0] && squareUsed[1,1] != null && squareUsed[0, 2] == null) {
                col = 0;
                row = 2;
            }

            if (squareUsed[0, 2] == squareUsed[2, 2] && squareUsed[0,2] != null && squareUsed[1, 2] == null) {
                col = 1;
                row = 2;
            }

            if (squareUsed[1, 0] == squareUsed[1, 1] && squareUsed[1,0] != null && squareUsed[1, 2] == null) {
                col = 1;
                row = 2;
            }

            if (squareUsed[2, 0] == squareUsed[2, 1] && squareUsed[2,0] != null && squareUsed[2, 2] == null) {
                col = 2;
                row = 2;
            }

            if (squareUsed[0, 2] == squareUsed[1, 2] && squareUsed[0,2] != null && squareUsed[2, 2] == null) {
                col = 2;
                row = 2;
            }

            if (squareUsed[0, 0] == squareUsed[1, 1] && squareUsed[0,0] != null && squareUsed[2, 2] == null) {
                col = 2;
                row = 2;
            }

            if (col == -1 || row == -1) {
                randomSquares(ran, out col, out row);
            }

            returnCol = col;
            returnRow = row;
        }
    }
}