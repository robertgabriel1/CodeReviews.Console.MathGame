using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        static List<Game> games = new List<Game>{};
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-----------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                result = Console.ReadLine();
            }
            return result;
        }
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int[] GetNumbersByDifficulty(int difficultyChoosen, bool checkDivision)
        {
            switch (difficultyChoosen)
            {
                case 0:
                    return GenerateRandomNumbers(1, 9, checkDivision);
                case 1:
                    return GenerateRandomNumbers(10, 49, checkDivision);
                case 2:
                    return GenerateRandomNumbers(50, 99, checkDivision);
                default:
                    return GenerateRandomNumbers(1, 9, checkDivision);
            }
        }

        internal static int[] GenerateRandomNumbers(int min, int max, bool isForDivision)
        {
            var random = new Random();
            var firstNumber = random.Next(min, max);
            var secondNumber = random.Next(min, max);
            if (isForDivision)
            {
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(min, max);
                    secondNumber = random.Next(min, max);
                }
                return [firstNumber, secondNumber];
            }
            return [firstNumber, secondNumber];
        }

        internal static string GetOperator(Enums.GameOperation operation)
        {
            return operation switch
            {
                Enums.GameOperation.Addition => "+",
                Enums.GameOperation.Subtraction => "-",
                Enums.GameOperation.Multiplication => "*",
                Enums.GameOperation.Division => "/",
                _ => "?"
            };
        }
    }
}
