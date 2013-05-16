using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("The number looks like {0}.", this.theNumber.GetCheat());
                            break;
                        }
                    default:
                        {
                            try
                            {
                                //Result guessResult = theNumber.TryToGuess(command);
                                // Loose couple issue fix: BullsAndCows.TryGuess not working directly with Result struct, but
                                // returns an array[Bulls, Cows] with found matches, and provide them to a new Result Object here
                                int[] bullsAndCowsResult = this.theNumber.TryToGuess(command);
                                Result guessResult = new Result();
                                guessResult.Bulls = bullsAndCowsResult[0];
                                guessResult.Cows = bullsAndCowsResult[1];

                                if (guessResult.Bulls == 4)
                                {
                                    if (this.theNumber.Cheats == 0)
                                    {
                                        Console.Write(NumberGuessedWithoutCheats, this.theNumber.GuessesCount, this.theNumber.GuessesCount == 1 ? "attempt" : "attempts");
                                        string name = Console.ReadLine();
                                        scoreBoard.AddScore(name, this.theNumber.GuessesCount);
                                    }
                                    else
                                    {
                                        Console.WriteLine(NumberGuessedWithCheats,
                                            this.theNumber.GuessesCount, this.theNumber.GuessesCount == 1 ? "attempt" : "attempts",
                                            theNumber.Cheats, this.theNumber.Cheats == 1 ? "cheat" : "cheats");
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
            return this.theNumber;
         }
    }
}
