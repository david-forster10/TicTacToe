using System;

namespace TicTacToev2 {
    public class Exit {
        public string handleExit() {
            Console.Clear();

            Console.SetWindowSize(40, 10);
            Console.SetBufferSize(40, 10);

            Console.SetCursorPosition(2, 4);
            Console.Write("Are You Sure You Wish To Exit? Y/N");
            Console.SetCursorPosition(20, 5);
            string sInput = Console.ReadLine();

            while (sInput.ToLower() != "y" && sInput.ToLower() != "n") {
                Console.Clear();
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("Are You Sure You Wish To Exit? Y/N");
                Console.SetCursorPosition(4, 5);
                Console.WriteLine("Please input a valid response.");
                Console.SetCursorPosition(20, 6);
                sInput = Console.ReadLine();
            }

            return sInput.ToUpper();
        }
    }
}