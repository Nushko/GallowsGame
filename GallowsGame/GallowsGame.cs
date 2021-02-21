using System;
using System.Collections.Generic;
using System.Text;

namespace GallowsGame
{
    public class GallowsGame
    {
        public static string[] WordsBase =
        {
            "shield",
            "bow",
            "sword",
            "lance",
            "crossbow",
            "dragon",
            "knight",
            "chainmail",
            "catsle",
            "princess",
            "witch",
            "king",
        };

        static int errorcnt = 0;
        static string targetWord, targetLetters;
        static Random rand = new Random();
        public static string allGuesses;
        public static string correctGuesses;

        public static void Start()
        {
            errorcnt = 0;
            targetWord = "";
            targetLetters = "";
            allGuesses = "";
            correctGuesses = "";

            bool game = true;
            targetWord = WordsBase[rand.Next(0, WordsBase.Length - 1)];
            AddTarget();
            while (game)
            {
                Color.ColorChange(ConsoleColor.Green);
                Console.WriteLine("" +
                    "Виселица (Medieval)\n" +
                    "----------------------------------------");
                ShowMan();
                ShowGuess();
                Color.ColorChange(ConsoleColor.Green);
                Console.WriteLine(
                    "----------------------------------------");

                Color.ColorChange(ConsoleColor.DarkYellow);
                Console.Write($"Ваши отгадки: {ShowLetters()}\n" +
                    $"У вас осталось {6 - errorcnt} попыток,\n"
                    );

                if (errorcnt == 6)
                {
                    Color.ColorChange(ConsoleColor.Red);
                    Console.WriteLine(
                        "Вы проиграли!\n" +
                        $"Слово: {targetWord},\n" +
                        $"Отдагано букв: {correctGuesses.Length}.\n");
                    game = false;
                    Console.ReadKey();
                }

                else if (correctGuesses.Length == targetLetters.Length)
                {
                    Color.ColorChange(ConsoleColor.Green);
                    Console.WriteLine(
                        "Вы выиграли!\n" +
                        $"Слово: {targetWord},\n" +
                        $"Попыток: {allGuesses.Length}.\n");
                    game = false;
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Введите вашу букву: ");
                    MakeGuess();
                }
                Console.Clear();
            }
        }

        private static void ShowGuess()
        {
            Color.ColorChange(ConsoleColor.Green);
            for (int i = 0; i < targetWord.Length; i += 1)
            {
                if (CheckCorrectGuess(targetWord[i]))
                    Console.Write(targetWord[i] + " ");

                else
                    Console.Write("_ ");
            }
            Console.WriteLine();
        }

        private static string ShowLetters()
        {
            string show = "";
            
            if (allGuesses.Length != 0)
            {
                foreach (var i in allGuesses)
                {
                    show += $"{i}, ";
                }
            }

            return show;
        }

        private static int MakeGuess()
        {
            char x;
            char.TryParse(Console.ReadLine(), out x);
            x = char.ToLower(x);

            if (CheckGuess(x))
            {
                Color.ColorChange(ConsoleColor.Red);
                Console.WriteLine("Вы уже использовали эту букву!");
                Console.ReadKey();
                return -1;
            }

            else if (!char.IsLetter(x) || x == ' ')
            {
                Color.ColorChange(ConsoleColor.Red);
                Console.WriteLine("Вы не ввели букву!");
                Console.ReadKey();
                return -1;
            }

            else
            {
                for (int i = 0; i < targetWord.Length; i += 1)
                {
                    if (x == targetWord[i])
                    {
                        Add(x, ref correctGuesses);
                        Add(x, ref allGuesses);
                        return 1;
                    }
                }
                errorcnt += 1;
                Add(x, ref allGuesses);
                return 0;
            }
        }

        private static bool CheckCorrectGuess(char x)
        {
            if (correctGuesses.Length == 0)
                return false;
            foreach (var i in correctGuesses)
            {
                if (x == i)
                    return true;
            }
            return false;
        }

        private static bool CheckGuess(char x)
        {
            foreach (var i in allGuesses)
            {
                if (x == i)
                {
                    return true;
                }
            }
            return false;
        }

        private static void ShowMan()
        {
            Color.ColorChange(ConsoleColor.Red);
            switch (errorcnt)
            {
                case 0:
                    {
                        Console.WriteLine("\n\n\n\n\n");
                    }
                    break;
                case 1:
                    {
                        Console.WriteLine("\n\n\n\n---");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("\n |");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine("---");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine(" _____");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine("---");
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine(" _____");
                        Console.WriteLine(" |   O");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine("---");
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine(" _____");
                        Console.WriteLine(" |   O");
                        Console.WriteLine(" |  -|-");
                        Console.WriteLine(" |");
                        Console.WriteLine("---");
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine(" _____");
                        Console.WriteLine(" |   O");
                        Console.WriteLine(" |  -|-");
                        Console.WriteLine(" |  / \\");
                        Console.WriteLine("---");
                    }
                    break;
                default:
                    break;
            }
        }

        private static void Add(char x, ref string box)
        {
            box += x;
        }

        private static void AddTarget()
        {
            bool temp;
            foreach (var i in targetWord)
            {
                temp = true;
                foreach (var j in targetLetters)
                {
                    if (j == i)
                    {
                        temp = false;
                        break;
                    }
                }
                if (temp)
                {
                    Add(i, ref targetLetters);
                }
            }
        }
    }

    public static class Color
    {
        public static void ColorChange(ConsoleColor x)
        {
            Console.ForegroundColor = x;
        }
    }
}
