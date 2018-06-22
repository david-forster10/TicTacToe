using System;
using System.IO;
using System.Runtime.InteropServices;

namespace TicTacToev2 {
    class AppStart {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]

        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        static void Main(string[] args) {
            loadHighScores();

            Menu mn = new Menu();
            mn.buildMenu(); 
        }

        static string[,] loadHighScores() {
            string fileName = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/TicTacToe/Highscores.txt";
            if (File.Exists(fileName) == true) {
                MessageBox((IntPtr)0, "Exists", "My Message Box", 0);
            } 
            MessageBox((IntPtr)0, fileName, "My Message Box", 0);
            return new string[1,1];
        }
    }
}