using System.Buffers;

namespace MathGame
{
    internal class GameEngine
    {
        internal void RunGame(string message, bool isDivision, Enums.GameOperation operation)
        {
            Console.Clear();
            Console.WriteLine(message);

            Console.WriteLine("Choose difficulty level:\n 0 - Easy,\n 1 - Medium,\n 2 - Hard");
            var difficultyLevel = Convert.ToInt32(Console.ReadLine());
            while (difficultyLevel != 0 && difficultyLevel != 1 && difficultyLevel != 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid difficulty.");
                difficultyLevel = Convert.ToInt32(Console.ReadLine());
            }

            DateTime startTime = DateTime.Now;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var numbers = Helpers.GetNumbersByDifficulty(difficultyLevel, isDivision);
                var firstNumber = numbers[0];
                var secondNumber = numbers[1];
                Console.WriteLine($"{firstNumber} {Helpers.GetOperator(operation)} {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                int correctAnswer = operation switch
                {
                Enums.GameOperation.Addition => firstNumber + secondNumber,
                Enums.GameOperation.Subtraction => firstNumber - secondNumber,
                Enums.GameOperation.Multiplication => firstNumber * secondNumber,
                Enums.GameOperation.Division => firstNumber / secondNumber,
                _ => 0
                };

                if (int.Parse(result) == correctAnswer)
                {
                Console.WriteLine($"Your answer was correct.");
                score++;
                }
                else
                {
                    Console.WriteLine($"Your answer was incorrect.");
                }

                if (i == 4)
                {
                    TimeSpan timeTaken = DateTime.Now - startTime;
                    string time = $"{timeTaken.Minutes} min {timeTaken.Seconds} sec";
                    Console.WriteLine($"Game over. Your final score is {score}/5 and it took {time}. Press any key to go back to the menu!");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, (Models.GameType)operation);
        }
    }
}
