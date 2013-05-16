using System;
using System.Linq;

namespace BullsAndCows
{
    public static class GuessChecker
    {
        public static Result GetBullsAndCowsMatches(PlayerGuess playerGuess, GameNumber gameNumber)
        {
            int bulls = 0;

            // checks if playerGuess.FirstDigit is a bull:
            bool isFirstDigitBullOrCow = false;
            if (gameNumber.FirstDigit == playerGuess.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                bulls++;
            }

            // checks if playerGuess.SecondDigit is a bull:
            bool isSecondDigitBullOrCow = false;
            if (gameNumber.SecondDigit == playerGuess.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                bulls++;
            }

            // checks if playerGuess.ThirdDigit is a bull:
            bool isThirdDigitBullOrCow = false;
            if (gameNumber.ThirdDigit == playerGuess.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                bulls++;
            }

            // checks if playerGuess.FourthDigit is a bull:
            bool isFourthDigitBullOrCow = false;
            if (gameNumber.FourthDigit == playerGuess.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                bulls++;
            }

            int cows = 0;

            // checks if playerGuess.playerGuess.FirstDigit is cow:
            if (!isSecondDigitBullOrCow && playerGuess.FirstDigit == gameNumber.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && playerGuess.FirstDigit == gameNumber.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && playerGuess.FirstDigit == gameNumber.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if playerGuess.SecondDigit is cow:
            if (!isFirstDigitBullOrCow && playerGuess.SecondDigit == gameNumber.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && playerGuess.SecondDigit == gameNumber.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && playerGuess.SecondDigit == gameNumber.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if playerGuess.ThirdDigit is cow:
            if (!isFirstDigitBullOrCow && playerGuess.ThirdDigit == gameNumber.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && playerGuess.ThirdDigit == gameNumber.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && playerGuess.ThirdDigit == gameNumber.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if playerGuess.FourthDigit is cow:
            if (!isFirstDigitBullOrCow && playerGuess.FourthDigit == gameNumber.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && playerGuess.FourthDigit == gameNumber.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && playerGuess.FourthDigit == gameNumber.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }

            Result guessResult = new Result(bulls, cows);
            return guessResult;
        }
    }
}
