namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you're working on improving yourself\n");
            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
                            V - View Previous Games
                            A - Addition
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            R - Random Game
                            Q - Quit the program");
                Console.WriteLine("---------------------------------------------");

                string gameSelected;
                bool isValidInput = false;

                while (!isValidInput)
                {
                    gameSelected = Console.ReadLine()?.Trim().ToLower();

                    switch (gameSelected)
                    {
                        case "v":
                            Helpers.GetGames();
                            isValidInput = true;
                            break;
                        case "a":
                            gameEngine.RunGame("Addition", false, Enums.GameOperation.Addition);
                            isValidInput = true;
                            break;
                        case "s":
                            gameEngine.RunGame("Subtraction", false, Enums.GameOperation.Subtraction);
                            isValidInput = true;
                            break;
                        case "m":
                            gameEngine.RunGame("Multiplication", true, Enums.GameOperation.Multiplication);
                            isValidInput = true;
                            break;
                        case "d":
                            gameEngine.RunGame("Division", true, Enums.GameOperation.Division);
                            isValidInput = true;
                            break;
                        case "q":
                            Console.WriteLine("Goodbye!");
                            isGameOn = false;
                            Environment.Exit(0);
                            isValidInput = true;
                            break;
                        case "r":
                            Random random = new();
                            var randomOperation = (Enums.GameOperation)random.Next(0, 4);
                            gameEngine.RunGame("Random Game", random.Next(0, 2) == 0, randomOperation);
                            isValidInput = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please enter a valid option (V, A, S, M, D, R, Q).");
                            break;
                    }
                }

            } while (isGameOn);
        }
    }
}
