using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe {
    class Program {
        public static class GlobalVariables {
            public static string[] sHighScoreNames = new string[11];
            public static string[] sHighScoreDifficulty = new string[11];
            public static int[] iHighScoreTime = new int[11];
            public static bool bError = false;
            public static string sInput = "";
            public static bool[,] aCoordinates = new bool[4, 4];
            public static int[] aInput = new int[2];
            public static bool[,] aCPU = new bool[4,4];
            public static Random random = new Random();
            public static bool bBeginning = false;
            public static bool bInvert = false;
            public static int iTime = 0;
        }
        private static System.Timers.Timer aTimer;
        static void Main(string[] args) {
        Beginning:
            Console.Clear();
            Console.SetWindowSize(40, 25);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Assign();
            Random random = new Random();
            string sDifficulty = "";
            int iInput = 0;
            int iLine = 0;
            bool bGo = false;

                    Console.Clear();

                    if (sDifficulty == "") {
                        Console.SetCursorPosition(9, 0);
                        Console.WriteLine("Welcome to Tic Tac Toe");

                        Console.WriteLine("\nPlease Select Your Difficulty: 'E' for  Easy, 'M' for Medium, 'H' for Hard!\n");
                        sDifficulty = Console.ReadLine();

                        while (sDifficulty != "E" && sDifficulty != "M" && sDifficulty != "H") {
                            Console.SetCursorPosition(9, 0);
                            Console.WriteLine("Welcome to Tic Tac Toe");

                            Console.WriteLine("\nPlease Select Your Difficulty: 'E' for  Easy, 'M' for Medium, 'H' for Hard!\nERROR! Please input a valid number (it  is cap sensitive)");
                            sDifficulty = Console.ReadLine();
                        }
                    }

                    Console.Clear();
                    Console.SetCursorPosition(9, 0);
                    Console.WriteLine("Welcome to Tic Tac Toe");

                    Console.SetCursorPosition(7, 1);
                    Console.Write("You are playing as Naughts!");

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

                    if (GlobalVariables.aCoordinates[1, 1] == true) {
                        Console.SetCursorPosition(13, 6);

                        if (GlobalVariables.aCPU[1, 1] == true)
                            Console.Write("X");
                        else
                            Console.Write("0"); 
                    }

                    if (GlobalVariables.aCoordinates[1, 2] == true) {
                        Console.SetCursorPosition(13, 10);

                        if (GlobalVariables.aCPU[1,2] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }
                    
                    if (GlobalVariables.aCoordinates[1, 3] == true) {
                        Console.SetCursorPosition(13, 14);

                        if (GlobalVariables.aCPU[1,3] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }
                    
                    if (GlobalVariables.aCoordinates[2, 1] == true) {
                        Console.SetCursorPosition(19, 6);

                        if (GlobalVariables.aCPU[2,1] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (GlobalVariables.aCoordinates[2, 2] == true) {
                        Console.SetCursorPosition(19, 10);

                        if (GlobalVariables.aCPU[2,2] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (GlobalVariables.aCoordinates[2, 3] == true) {
                        Console.SetCursorPosition(19, 14);

                        if (GlobalVariables.aCPU[2,3] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (GlobalVariables.aCoordinates[3, 1] == true) {
                        Console.SetCursorPosition(25, 6);

                        if (GlobalVariables.aCPU[3,1] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (GlobalVariables.aCoordinates[3, 2] == true) {
                        Console.SetCursorPosition(25, 10);

                        if (GlobalVariables.aCPU[3,2] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (GlobalVariables.aCoordinates[3, 3] == true) {
                        Console.SetCursorPosition(25, 14);

                        if (GlobalVariables.aCPU[3,3] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    }

                    if (aTimer.Enabled != true) {
                        aTimer = new System.Timers.Timer(1000);

                        aTimer.Elapsed += OnTimedEvent;

                        aTimer.AutoReset = true;

                        aTimer.Enabled = true;
                    }

                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("\nPlease input the number for the column:");
                    if (GlobalVariables.aInput[0] != 0)
                        Console.WriteLine(GlobalVariables.aInput[0]);
                    else {
                        try {
                            GlobalVariables.aInput[0] = Convert.ToInt32(Console.ReadLine());
                        } catch (SystemException) {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            goto Naughts;
                        }
                    }

                    if (GlobalVariables.aInput[0] == 1 || GlobalVariables.aInput[0] == 2 || GlobalVariables.aInput[0] == 3) {
                        Console.WriteLine("\nNow please input the number for the row:");

                        try {
                            GlobalVariables.aInput[1] = Convert.ToInt32(Console.ReadLine());
                        } catch (SystemException) {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            goto Naughts;
                        }

                        if (GlobalVariables.aInput[1] == 1 || GlobalVariables.aInput[1] == 2 || GlobalVariables.aInput[1] == 3) {
                            if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                Console.Clear();

                                Console.SetWindowSize(40, 10);
                                Console.SetBufferSize(40, 10);

                                Console.SetCursorPosition(2, 4);
                                Console.Write("ERROR: This square has already been ");
                                Console.SetCursorPosition(4, 5);
                                Console.Write("selected! Please select another!");
                                Console.ReadKey();

                                Console.SetWindowSize(40, 30);
                                Console.SetBufferSize(40, 30);

                                GlobalVariables.aInput[0] = 0;
                                GlobalVariables.aInput[1] = 0;
                                goto Naughts;
                            } else {
                                ValidateSquare();

                                ValidateWin();

                                if (GlobalVariables.bBeginning == true)
                                    goto Beginning;

                                switch (sDifficulty) {
                                    case "E":
                                        GlobalVariables.aInput[0] = random.Next(1, 4);
                                        GlobalVariables.aInput[1] = random.Next(1, 4);
                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();
                                        break;
                                    case "M":
                                        GlobalVariables.aInput[0] = 0;
                                        GlobalVariables.aInput[1] = 0;

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 1] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[1, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 3] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 3] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 3] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aInput[0] == 0 && GlobalVariables.aInput[1] == 0) {
                                            GlobalVariables.aInput[0] = random.Next(1, 4);
                                            GlobalVariables.aInput[1] = random.Next(1, 4);
                                        }

                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();

                                        if (GlobalVariables.bBeginning == true)
                                            goto Beginning;
                                        break;
                                    case "H":
                                        GlobalVariables.aInput[0] = 0;
                                        GlobalVariables.aInput[1] = 0;

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 1] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 3] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aInput[0] == 0 && GlobalVariables.aInput[1] == 0) {
                                            GlobalVariables.aInput[0] = random.Next(1, 4);
                                            GlobalVariables.aInput[1] = random.Next(1, 4);
                                        }

                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();

                                        if (GlobalVariables.bBeginning == true)
                                            goto Beginning;
                                        break;
                                }

                                GlobalVariables.aInput[0] = 0;
                                GlobalVariables.aInput[1] = 0;
                                goto Naughts;
                            }
                        } else {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            GlobalVariables.aInput[1] = 0;
                            goto Naughts;
                        }
                    } else {
                        Console.WriteLine("ERROR! Please input a valid number");
                        Console.ReadKey();
                        GlobalVariables.aInput[0] = 0;
                        goto Naughts;
                    }
                case 2:
                    Console.SetWindowSize(40, 30);
                    Console.SetBufferSize(40, 30);
                    GlobalVariables.bInvert = true;
                Crosses:
                    Console.Clear();

                    if (sDifficulty == "") {
                        Console.SetCursorPosition(9, 0);
                        Console.WriteLine("Welcome to Tic Tac Toe");

                        Console.WriteLine("\nPlease Select Your Difficulty: 'E' for  Easy, 'M' for Medium, 'H' for Hard!\n");
                        sDifficulty = Console.ReadLine();

                        while (sDifficulty != "E" && sDifficulty != "M" && sDifficulty != "H") {
                            Console.SetCursorPosition(9, 0);
                            Console.WriteLine("Welcome to Tic Tac Toe");

                            Console.WriteLine("\nPlease Select Your Difficulty: 'E' for  Easy, 'M' for Medium, 'H' for Hard!\nERROR! Please input a valid number (it  is cap sensitive)");
                            sDifficulty = Console.ReadLine();
                        }
                    }

                    Console.Clear();
                    Console.SetCursorPosition(9, 0);
                    Console.WriteLine("Welcome to Tic Tac Toe");

                    Console.SetCursorPosition(7, 1);
                    Console.Write("You are playing as Crosses!");

                    Console.WriteLine();
                    for (int j = 0; j < 15; j++) {
                        Console.SetCursorPosition(9, j + 3);

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
                        Console.SetCursorPosition(9, j + 3);
                    }

                    if (GlobalVariables.aCoordinates[1, 1] == true) {
                        Console.SetCursorPosition(13, 6);

                        if (GlobalVariables.aCPU[1, 1] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[1, 2] == true) {
                        Console.SetCursorPosition(13, 10);

                        if (GlobalVariables.aCPU[1, 2] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[1, 3] == true) {
                        Console.SetCursorPosition(13, 14);

                        if (GlobalVariables.aCPU[1, 3] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[2, 1] == true) {
                        Console.SetCursorPosition(19, 6);

                        if (GlobalVariables.aCPU[2, 1] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[2, 2] == true) {
                        Console.SetCursorPosition(19, 10);

                        if (GlobalVariables.aCPU[2, 2] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[2, 3] == true) {
                        Console.SetCursorPosition(19, 14);

                        if (GlobalVariables.aCPU[2, 3] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[3, 1] == true) {
                        Console.SetCursorPosition(25, 6);

                        if (GlobalVariables.aCPU[3, 1] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[3, 2] == true) {
                        Console.SetCursorPosition(25, 10);

                        if (GlobalVariables.aCPU[3, 2] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    if (GlobalVariables.aCoordinates[3, 3] == true) {
                        Console.SetCursorPosition(25, 14);

                        if (GlobalVariables.aCPU[3, 3] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("\nPlease input the number for the column:");
                    
                    if (GlobalVariables.aInput[0] != 0)
                        Console.WriteLine(GlobalVariables.aInput[0]);
                    else {
                        try {
                            GlobalVariables.aInput[0] = Convert.ToInt32(Console.ReadLine());
                        } catch (SystemException) {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            goto Crosses;
                        }
                    }

                    if (GlobalVariables.aInput[0] == 1 || GlobalVariables.aInput[0] == 2 || GlobalVariables.aInput[0] == 3) {
                        Console.WriteLine("\nNow please input the number for the row:");

                        try {
                            GlobalVariables.aInput[1] = Convert.ToInt32(Console.ReadLine());
                        } catch (SystemException) {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            goto Crosses;
                        }

                        if (GlobalVariables.aInput[1] == 1 || GlobalVariables.aInput[1] == 2 || GlobalVariables.aInput[1] == 3) {
                            if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                Console.Clear();

                                Console.SetWindowSize(40, 10);
                                Console.SetBufferSize(40, 10);

                                Console.SetCursorPosition(2, 4);
                                Console.Write("ERROR: This square has already been ");
                                Console.SetCursorPosition(4, 5);
                                Console.Write("selected! Please select another!");
                                Console.ReadKey();

                                Console.SetWindowSize(40, 30);
                                Console.SetBufferSize(40, 30);

                                GlobalVariables.aInput[0] = 0;
                                GlobalVariables.aInput[1] = 0;
                                goto Crosses;
                            } else {
                                ValidateSquare();

                                ValidateWin();

                                if (GlobalVariables.bBeginning == true)
                                    goto Beginning;

                                switch (sDifficulty) {
                                    case "E":
                                        GlobalVariables.aInput[0] = random.Next(1, 4);
                                        GlobalVariables.aInput[1] = random.Next(1, 4);
                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();
                                        break;
                                    case "M":
                                        GlobalVariables.aInput[0] = 0;
                                        GlobalVariables.aInput[1] = 0;

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 1] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[1, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 3] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 3] == true && GlobalVariables.aCPU[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 3] == true && GlobalVariables.aCPU[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aInput[0] == 0 && GlobalVariables.aInput[1] == 0) {
                                            GlobalVariables.aInput[0] = random.Next(1, 4);
                                            GlobalVariables.aInput[1] = random.Next(1, 4);
                                        }

                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();

                                        if (GlobalVariables.bBeginning == true)
                                            goto Beginning;
                                        break;
                                    case "H":
                                        GlobalVariables.aInput[0] = 0;
                                        GlobalVariables.aInput[1] = 0;

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 1] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 1] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 1] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 1] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 1;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 2] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }
                                        
                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 2] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 2] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 2;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 2] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 3] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                                            if (GlobalVariables.aCoordinates[1, 3] == false) {
                                                GlobalVariables.aInput[0] = 1;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[2, 3] == false) {
                                                GlobalVariables.aInput[0] = 2;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 2] == true) {
                                            if (GlobalVariables.aCoordinates[3, 3] == false) {
                                                GlobalVariables.aInput[0] = 3;
                                                GlobalVariables.aInput[1] = 3;
                                            }
                                        }

                                        if (GlobalVariables.aInput[0] == 0 && GlobalVariables.aInput[1] == 0) {
                                            GlobalVariables.aInput[0] = random.Next(1, 4);
                                            GlobalVariables.aInput[1] = random.Next(1, 4);
                                        }

                                        if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) { 
                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true; 
                                        } else {
                                            while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                                                GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                                                GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                                            }

                                            GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                                        }

                                        ValidateSquare();

                                        ValidateWin();

                                        if (GlobalVariables.bBeginning == true)
                                            goto Beginning;
                                        break;
                                }

                                GlobalVariables.aInput[0] = 0;
                                GlobalVariables.aInput[1] = 0;
                                goto Crosses;
                            }
                        } else {
                            Console.WriteLine("ERROR! Please input a valid number");
                            Console.ReadKey();
                            GlobalVariables.aInput[1] = 0;
                            goto Crosses;
                        }
                    } else {
                        Console.WriteLine("ERROR! Please input a valid number");
                        Console.ReadKey();
                        GlobalVariables.aInput[0] = 0;
                        goto Crosses;
                    }
                case 3:
                        Console.Clear();
                        Console.SetCursorPosition(9, 0);
                        Console.WriteLine("High Scorers");

                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine("Username:");
                        Console.SetCursorPosition(16, 3);
                        Console.Write("Time(s):");
                        Console.SetCursorPosition(28, 3);
                        Console.Write("Difficulty:");

                        Console.SetCursorPosition(0, 5);
                        for (int iCount = 1; iCount < 11; iCount++) {
                            if (GlobalVariables.sHighScoreNames[iCount] != null)
                                if (iCount == 10)
                                    Console.WriteLine(iCount + ". " + GlobalVariables.sHighScoreNames[iCount]);
                                else
                                    Console.WriteLine(iCount + ".  " + GlobalVariables.sHighScoreNames[iCount]);
                            else
                                if (iCount == 10)
                                    Console.WriteLine(iCount + ". " + "No User");
                                else
                                    Console.WriteLine(iCount + ".  " + "No User");
                        }

                        iLine = 5;
                        for (int iCount = 1; iCount < 11; iCount++) {
                            Console.SetCursorPosition(16, iLine);
                            if (GlobalVariables.iHighScoreTime[iCount] != 0)
                                Console.WriteLine(GlobalVariables.iHighScoreTime[iCount]);
                            else
                                Console.WriteLine("");
                            iLine += 1;
                        }

                        iLine = 5;
                        for (int iCount = 1; iCount < 11; iCount++) {
                            Console.SetCursorPosition(28, iLine);
                            if (GlobalVariables.sHighScoreDifficulty[iCount] != null)
                                switch (GlobalVariables.sHighScoreDifficulty[iCount]) {
                                    case "E":
                                        Console.WriteLine("Easy");
                                        break;
                                    case "M":
                                        Console.WriteLine("Medium");
                                        break;
                                    case "H":
                                        Console.WriteLine("Hard");
                                        break;
                                }
                            else
                                Console.WriteLine("");
                            iLine += 1;
                        }
                        Console.Write("Press Enter to continue!\n");
                    ValidateKey:
                        ConsoleKeyInfo c = Console.ReadKey();
                        if (c.Key == ConsoleKey.Enter)
                            bGo = true;

                        if (bGo != true) {
                            ClearCurrentConsoleLine();
                            goto ValidateKey;
                        }

                        Console.Clear();
                        goto Beginning;
                case 4:
                    Console.Clear();

                    Console.SetWindowSize(40, 10);
                    Console.SetBufferSize(40, 10);

                    Console.SetCursorPosition(2, 4);
                    Console.Write("Are You Sure You Wish To Exit? Y/N");
                    Console.SetCursorPosition(20, 5);
                    GlobalVariables.sInput = Console.ReadLine();

                    switch (GlobalVariables.sInput) {
                        case "Y":
                            Console.Clear();
                            Console.WriteLine("Goodbye");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        case "N":
                            Console.Clear();
                            goto Beginning;
                        default:
                        Console.Clear();
                        Console.WriteLine("Are You Sure You Wish To Exit? Y/N");
                        Console.WriteLine("Please input a valid response.");

                        while (GlobalVariables.sInput != "Y" && GlobalVariables.sInput != "N") {
                            Console.Clear();
                            Console.WriteLine("Are You Sure You Wish To Exit? Y/N");
                            Console.WriteLine("Please input a valid response.");
                            GlobalVariables.sInput = Console.ReadLine();
                        }

                        switch (GlobalVariables.sInput) {
                            case "Y":
                                Console.Clear();
                                Console.WriteLine("Goodbye");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;
                            case "N":
                                Console.Clear();
                                goto Beginning;
                        }
                        break;
                    }
                break;
            }
        }
        
        static void Assign() {
            GlobalVariables.bError = false;
            GlobalVariables.sInput = "";
            GlobalVariables.aCoordinates[1, 1] = false;
            GlobalVariables.aCoordinates[1, 2] = false;
            GlobalVariables.aCoordinates[1, 3] = false;
            GlobalVariables.aCoordinates[2, 1] = false;
            GlobalVariables.aCoordinates[2, 2] = false;
            GlobalVariables.aCoordinates[2, 3] = false;
            GlobalVariables.aCoordinates[3, 1] = false;
            GlobalVariables.aCoordinates[3, 2] = false;
            GlobalVariables.aCoordinates[3, 3] = false;
            GlobalVariables.aInput[0] = 0;
            GlobalVariables.aInput[1] = 0;
            GlobalVariables.aCPU[1, 1] = false;
            GlobalVariables.aCPU[1, 2] = false;
            GlobalVariables.aCPU[1, 3] = false;
            GlobalVariables.aCPU[2, 1] = false;
            GlobalVariables.aCPU[2, 2] = false;
            GlobalVariables.aCPU[2, 3] = false;
            GlobalVariables.aCPU[3, 1] = false;
            GlobalVariables.aCPU[3, 2] = false;
            GlobalVariables.aCPU[3, 3] = false;
            GlobalVariables.bBeginning = false;
    
            string file_name = @"C:\Users\Owner\Documents\DOCUMENTS!!!!\College\Software\Tic Tac Toe\Highscores.txt";
            int iCount = 1;

            if (System.IO.File.Exists(file_name) == true) {
                System.IO.StreamReader objReader = new System.IO.StreamReader(file_name);

                do {
                    GlobalVariables.sHighScoreNames[iCount] = objReader.ReadLine();
                    try {
                        GlobalVariables.iHighScoreTime[iCount] = Convert.ToInt32(objReader.ReadLine());
                    } catch (SystemException) {
                        GlobalVariables.bError = true;
                    }

                    GlobalVariables.sHighScoreDifficulty[iCount] = objReader.ReadLine();

                    iCount += 1;
                } while (objReader.Peek() != -1);

                objReader.Close();
            }
        }

        static void ValidateSquare() {
            if (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == false) {
                if (GlobalVariables.aInput[0] == 1 && GlobalVariables.aInput[1] == 1) {
                    Console.SetCursorPosition(13, 6);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 1 && GlobalVariables.aInput[1] == 2) {
                    Console.SetCursorPosition(13, 10);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 1 && GlobalVariables.aInput[1] == 3) {
                    Console.SetCursorPosition(13, 14);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 2 && GlobalVariables.aInput[1] == 1) {
                    Console.SetCursorPosition(19, 6);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 2 && GlobalVariables.aInput[1] == 2) {
                    Console.SetCursorPosition(19, 10);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 2 && GlobalVariables.aInput[1] == 3) {
                    Console.SetCursorPosition(19, 14);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 3 && GlobalVariables.aInput[1] == 1) {
                    Console.SetCursorPosition(25, 6);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 3 && GlobalVariables.aInput[1] == 2) {
                    Console.SetCursorPosition(25, 10);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                } else if (GlobalVariables.aInput[0] == 3 && GlobalVariables.aInput[1] == 3) {
                    Console.SetCursorPosition(25, 14);

                    if (GlobalVariables.bInvert == false) {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("X");
                        else
                            Console.Write("0");
                    } else {
                        if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true)
                            Console.Write("0");
                        else
                            Console.Write("X");
                    }

                    GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] = true;
                }
            } else if (GlobalVariables.aCPU[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                while (GlobalVariables.aCoordinates[GlobalVariables.aInput[0], GlobalVariables.aInput[1]] == true) {
                    GlobalVariables.aInput[0] = GlobalVariables.random.Next(1, 4);
                    GlobalVariables.aInput[1] = GlobalVariables.random.Next(1, 4);
                }
            }
        }

        static void ValidateWin() {
            if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                if (GlobalVariables.aCPU[1, 1] == false && GlobalVariables.aCPU[1, 2] == false && GlobalVariables.aCPU[1, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[2, 3] == true) {
                if (GlobalVariables.aCPU[2, 1] == false && GlobalVariables.aCPU[2, 2] == false && GlobalVariables.aCPU[2, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if(GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[2, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                if (GlobalVariables.aCPU[3, 1] == false && GlobalVariables.aCPU[3, 2] == false && GlobalVariables.aCPU[3, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[3, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[3, 1] == true) {
                if (GlobalVariables.aCPU[1, 1] == false && GlobalVariables.aCPU[2, 1] == false && GlobalVariables.aCPU[3, 1] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 1] == true && GlobalVariables.aCPU[3, 1] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 2] == true) {
                if (GlobalVariables.aCPU[1, 2] == false && GlobalVariables.aCPU[2, 2] == false && GlobalVariables.aCPU[3, 2] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[1, 2] == true && GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 2] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[2, 3] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                if (GlobalVariables.aCPU[1, 3] == false && GlobalVariables.aCPU[2, 3] == false && GlobalVariables.aCPU[3, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[1, 3] == true && GlobalVariables.aCPU[2, 3] == true && GlobalVariables.aCPU[3, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }
            
            if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                if (GlobalVariables.aCPU[1, 1] == false && GlobalVariables.aCPU[2, 2] == false && GlobalVariables.aCPU[3, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[1, 1] == true && GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[3, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[1, 3] == true) {
                if (GlobalVariables.aCPU[3, 1] == false && GlobalVariables.aCPU[2, 2] == false && GlobalVariables.aCPU[1, 3] == false) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU WIN!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                } else if (GlobalVariables.aCPU[3, 1] == true && GlobalVariables.aCPU[2, 2] == true && GlobalVariables.aCPU[1, 3] == true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU LOSE!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }

            if (GlobalVariables.aCoordinates[1, 1] == true && GlobalVariables.aCoordinates[1, 2] == true && GlobalVariables.aCoordinates[1, 3] == true && GlobalVariables.aCoordinates[2, 1] == true && GlobalVariables.aCoordinates[2, 2] == true && GlobalVariables.aCoordinates[2, 3] == true && GlobalVariables.aCoordinates[3, 1] == true && GlobalVariables.aCoordinates[3, 2] == true && GlobalVariables.aCoordinates[3, 3] == true) {
                if (GlobalVariables.bBeginning != true) {
                    Console.Clear();
                    Console.SetWindowSize(30, 20);
                    Console.SetBufferSize(30, 20);

                    Console.SetCursorPosition(10, 7);
                    Console.Write("YOU DREW!!");
                    Console.WriteLine("\nReturn To The Main Menu? Y/N");
                    GlobalVariables.sInput = Console.ReadLine();

                    if (GlobalVariables.sInput == "Y") {
                        GlobalVariables.bBeginning = true;
                    } else if (GlobalVariables.sInput == "N") {
                        Console.Clear();

                        Console.SetWindowSize(40, 10);
                        Console.SetBufferSize(40, 10);

                        Console.SetCursorPosition(2, 4);
                        Console.Write("Are You Sure You Wish To Exit? Y/N");
                        Console.SetCursorPosition(20, 5);
                        GlobalVariables.sInput = Console.ReadLine();

                        if (GlobalVariables.sInput == "Y") {
                            Console.Clear();
                            Console.WriteLine("GoodBye!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        } else if (GlobalVariables.sInput == "N") {
                            ValidateWin();
                        }
                    }
                    Console.Clear();
                }
            }
        }

        public static void ClearCurrentConsoleLine() {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
            int iCursorLeft = Console.CursorLeft;
            int iCursorTop = Console.CursorTop;

            GlobalVariables.iTime += 1;

            Console.SetCursorPosition(24, 3);
            Console.Write("Time: " + GlobalVariables.iTime + " sec(s)");
            Console.SetCursorPosition(iCursorLeft, iCursorTop);
        }
    }
}