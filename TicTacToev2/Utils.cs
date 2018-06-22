using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToev2 {
    public class Utils {
        public static void ClearCurrentConsoleLine() {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}