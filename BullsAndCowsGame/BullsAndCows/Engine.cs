using System;
using System.Linq;

namespace BullsAndCows
{
    public class Engine
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";

        private GameNumber theNumber;
        private PlayerGuess playerGuess;
        private Cheat cheats;
        private ScoreBoard scoreBoard;
        private byte guessCount;

        public Engine(ScoreBoard board)
        {
            this.scoreBoard = board;
            this.guessCount = 0;
            this.cheats = new Cheat();
            this.theNumber = new GameNumber();
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    Console.WriteLine(GoodBuyMessage);
                    break;
                }
                switch (command)
                {
                    case "top":
                        {
                            Console.Write(scoreBoard);
                            break;
                        }
                    case "restart":
                        {
                            Console.WriteLine();
                            Console.WriteLine(WelcomeMessage);
                            this.theNumber = new GameNumber();
                            this.cheats.Count = 0;
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("The number looks like {0}.", cheats.GetCheat(theNumber));
                            break;
                        }
                    default:
                        {
                            try
                            {
                                playerGuess = PlayerGuess.TryToParse(command);
                                Result guessResult = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
                                this.guessCount++;

                                if (guessResult.Bulls == 4)
                                {
                                    if (this.cheats.Count == 0)
                                    {
                                        Console.Write(NumberGuessedWithoutCheats, this.guessCount, this.guessCount == 1 ? "attempt" : "attempts");
                                        string name = Console.ReadLine();
                                        scoreBoard.AddScore(name, this.guessCount);
                                    }
                                    else
                                    {
                                        Console.WriteLine(NumberGuessedWithCheats,
                                            this.guessCount, this.guessCount == 1 ? "attempt" : "attempts",
                                            this.cheats.Count, this.cheats.Count == 1 ? "cheat" : "cheats");
                                    }
                                    Console.Write(scoreBoard);
                                    Console.WriteLine();
                                    Console.WriteLine(WelcomeMessage);
                                    this.theNumber = new GameNumber();
                                }
                                else
                                {
                                    Console.WriteLine("{0} {1}", WrongNumberMessage, guessResult);
                                }
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine(InvalidCommandMessage);
                            }
                            break;
                        }
                }
            }
         }
    }
}
