using System;

namespace GallowsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool game = true;
            while (game)
            {
                game = false;
                Color.ColorChange(ConsoleColor.Green);
                Console.WriteLine("Нажмите на любую кнопку, чтобы начать игру...");
                Console.ReadKey();
                Console.Clear();
                GallowsGame.Start();
                Console.Clear();
                Color.ColorChange(ConsoleColor.Green);
                Console.WriteLine("Хотите начать новую игру? (y/n): ");
                char choice;
                char.TryParse(Console.ReadLine(), out choice);
                if (choice == 'y' || choice == 'Y')
                    game = true;
            }
        }
    }
}
