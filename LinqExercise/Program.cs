using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        public static bool StayActive { get; set; } = true;

        static void Main(string[] args)
        {
            RunApplication();
        
        }

        static void RunApplication()
        {
            while (StayActive)
            {
                Console.Clear();
                Console.WriteLine("Select an option.\n");
                Console.WriteLine("1) Sort through games.");
                Console.WriteLine("2) Check Total Number of games");
                Console.WriteLine("3) Find out the average year games were released.");
                Console.WriteLine("4) End Application");
                Console.WriteLine("");
                if (ValidateInput(new string[] { "1", "2", "3", "4" }, out int? input))
                {
                    switch (input)
                    {
                        case 0:
                            PullList();
                            break;
                        case 1:
                            PrintForCount();
                            break;
                        case 2:
                            PrintAverageYearReleased();
                            break;
                        case 3:

                        case 4:
                            StayActive = false;
                            break;

                        default:
                            Console.WriteLine("No option found for the input provided.");
                            break;
                    }
                }
                if (StayActive)
                {
                    Console.WriteLine("\n\nPress any key to return to the main menu.");
                    Console.ReadKey();
                }
            }

        }

        static int? GetGameCategory()
        {
            Console.Clear();
            Console.WriteLine("What games would you like to see?");
            Console.WriteLine("1) All");
            Console.WriteLine("2) Nintendo 64");
            Console.WriteLine("3) Gamecube");
            Console.WriteLine("4) Playstation");
            ValidateInput(new string[] { "1", "2", "3", "4" }, out int? input);
            return input;

        }
 
        static void PullList()
        {
            bool hasbeenPulled = false;
            IEnumerable<Game> gamesList = null;
            switch(GetGameCategory())
            {
                case 0:
                    gamesList = Game.All;
                    hasbeenPulled = true;
                    break;
                case 1:
                    gamesList = Game.All.Where(x => x is N64Game);
                    hasbeenPulled = true;
                    break;
                case 2:
                    gamesList = Game.All.Where(x => x is GamecubeGame);
                    hasbeenPulled = true;
                    break;
                case 3:
                    gamesList = Game.All.Where(x => x is PSGame);
                    hasbeenPulled = true;
                    break;
                default:
                case null:
                    Console.WriteLine("Invalid entry entered. Press any key to return.");
                    Console.ReadKey();
                    Console.Clear();
                    PullList();
                    break;
            }
            if (hasbeenPulled)
            {
                Console.Clear();
                ChooseSorting(gamesList);
            }
        }

        static void ChooseSorting(IEnumerable<Game> gamesToShow)
        {
            Console.WriteLine("How would you like to sort your list?");
            Console.WriteLine("1) By Name");
            Console.WriteLine("2) By Year Released");
            Console.WriteLine("3) By Console");
            ValidateInput(new string[] { "1", "2", "3", }, out int? input);


            switch (input)
            {
                case 0:
                    PrintDetails(gamesToShow.OrderBy(x => x.Name).ThenBy(x => x.GameConsole));
                    break;
                case 1:
                    PrintDetails(gamesToShow.OrderBy(x => x.YearReleased).ThenBy(x => x.Name));
                    break;
                case 2:
                    PrintDetails(gamesToShow.OrderBy(x => x.GameConsole).ThenBy(x => x.Name));
                    break;
                default:
                    break;
            }
        }

        static void PrintAverageYearReleased()
        {
            Console.Clear();
            Console.WriteLine("The average year that games were released was: " + Math.Ceiling(Game.All.Average(x => x.YearReleased)));
        }

        static void PrintForCount()
        {
            Console.Clear();
            var games = Game.All.OrderBy(x => x.Name).ThenBy(x => x.YearReleased).Select(x => x.Name + " - " + x.GameConsole);
            Console.WriteLine("All Games: \n");
            for (int i = 0; i < Game.All.Count - 1; i++)
            {

                Console.WriteLine(i + 1 + ") " + games.ElementAt(i));
            }
            Console.WriteLine($"\nTotal number of games: {Game.All.Count() - 1}");
        }

        public static bool ValidateInput(string[] options, out int? optionIndex)
        {
            var input = Console.ReadLine();
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].ToLower() == input.ToLower())
                {
                    optionIndex = i;
                    return true;
                }
            }
            optionIndex = null;
            return false;
        }

        static void PrintDetails(IEnumerable<Game> gamesToShow)
        {
            Console.Clear();
            foreach (var game in gamesToShow)
            {
                if(game != null)
                {
                    Console.WriteLine($"- {game.Name} - {game.GameConsole} Game - Released {game.YearReleased}\n");
                }
            }
        }


    }
}
