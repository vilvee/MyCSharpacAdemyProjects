using System.Numerics;

namespace Math_Game
{
    internal class Program
    {
        /* You need to create a Math game containing the 4 basic operations
         The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
         Users should be presented with a menu to choose an operation
         You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
         You don't need to record results on a database. Once the program is closed the results will be deleted.*/
        public static List<Game> Games = new List<Game>();

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();

            string choice = "";

            do
            {
                Console.WriteLine(@"
Choose an operation:

[A] ADDITION
[B] SUBSTARCTION
[C] DIVISION
[D] MULTIPLICATION
[E] DISPLAY SCORES
[Q] QUIT");

                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "a":
                        Console.Clear();
                        Addition();

                        break;
                    case "b":
                        Console.Clear();
                        Subtraction();
                        break;
                    case "c":
                        Console.Clear();
                        Division();
                        break;
                    case "d":
                        Console.Clear();
                        Multiplication();
                        break;
                    case "e":
                        Console.Clear();
                        DisplayPreviousScores();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            } while (choice != "q");


        }

        public static int RandomNumberGenerator()
        {
            const int MIN = 1;
            const int MAX = 100;
            Random rnd = new Random();
            int number = rnd.Next(MIN, MAX + 1);
            return number;
        }

        public static void DisplayPreviousScores()
        {
            foreach (Game game in Games)
            {
                Console.WriteLine(game.ToString());
            }
        }

        public static void Addition()
        {

            Game game = new Game();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                int number1 = RandomNumberGenerator();
                int number2 = RandomNumberGenerator();
                int correctAnswer = number1 + number2;
                int userAnswer;

                Console.WriteLine("Addition");
                Console.WriteLine($"{number1} + {number2}");

                int.TryParse(Console.ReadLine(), out userAnswer);

                if (correctAnswer == userAnswer)
                {
                    game.Score++;
                    continue;
                }
            }

            Console.WriteLine($"You finished the game with a score of {game.Score}");
            Games.Add(game);
        }


        public static void Subtraction()
        {
            Console.Clear();

            Game game = new Game();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                int number1 = RandomNumberGenerator();
                int number2 = RandomNumberGenerator();
                int correctAnswer = number1 - number2;
                int userAnswer;

                Console.WriteLine("Subtraction");
                Console.WriteLine($"{number1} - {number2}");

                int.TryParse(Console.ReadLine(), out userAnswer);

                if (correctAnswer == userAnswer)
                {
                    game.Score++;
                    continue;
                }

            }

            Console.WriteLine($"You finished the game with a score of {game.Score}");
            Games.Add(game);
        }

        public static void Division()
        {
            Console.Clear();

            Game game = new Game();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();

                int number1,
                    number2,
                    userAnswer;

                double correctAnswer;

                do
                {
                    number1 = RandomNumberGenerator();
                    number2 = RandomNumberGenerator();
                    correctAnswer = number1 / (double)number2;
                    Console.WriteLine(correctAnswer);
                } while ((correctAnswer % 1) != 0);

                Console.WriteLine("Division");
                Console.WriteLine($"{number1} / {number2}");
                int.TryParse(Console.ReadLine(), out userAnswer);

                if (correctAnswer == userAnswer)
                {
                    game.Score++;
                    continue;
                }

            }

            Console.WriteLine($"You finished the game with a score of {game.Score}");
            Games.Add(game);
        }

        public static void Multiplication()
        {
            Console.Clear();

            Game game = new Game();

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                int number1 = RandomNumberGenerator();
                int number2 = RandomNumberGenerator();
                int correctAnswer = number1 + number2;
                int userAnswer;

                Console.WriteLine("Multiplication");
                Console.WriteLine($"{number1} * {number2}");

                int.TryParse(Console.ReadLine(), out userAnswer);

                if (correctAnswer == userAnswer)
                {
                    game.Score++;
                    continue;
                }

            }

            Console.WriteLine($"You finished the game with a score of {game.Score}");
            Games.Add(game);
        }


    }
}
