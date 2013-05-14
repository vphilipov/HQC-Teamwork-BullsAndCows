namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Text;

    public class BullsAndCowsNumber
    {   
        public int Cheats
        {
            get;
            private set;
        }

        public int GuessesCount
        {
            get;
            private set;
        }

        public int FirstDigit
        {
            get;
            private set;
        }

        public int SecondDigit
        {
            get;
            private set;
        }

        public int ThirdDigit
        {
            get;
            private set;
        }

        public int FourthDigit
        {
            get;
            private set;
        }
        
        /* Constructor */
        public BullsAndCowsNumber()
        {   
            this.Cheats = 0;
            this.GuessesCount = 0;
            this.GenerateRandomNumbers();
        }

        public string GetCheat()
        {
            Random randPosGenerator = new Random();
            char[] cheatNumber = new char[4] { 'X', 'X', 'X', 'X' };

            if (this.Cheats < 4)
            {
                while (true)
                {
                    int randPossition = randPosGenerator.Next(0, 4);
                    if (cheatNumber[randPossition] == 'X')
                    {
                        switch (randPossition)
	                    {
                            case 0: cheatNumber[randPossition] = (char)(FirstDigit + '0'); break;
                            case 1: cheatNumber[randPossition] = (char)(SecondDigit + '0'); break;
                            case 2: cheatNumber[randPossition] = (char)(ThirdDigit + '0'); break;
                            case 3: cheatNumber[randPossition] = (char)(FourthDigit + '0'); break;
	                    }
                        break;
                    }
                }
                
                this.Cheats++;
            }

            return new String(cheatNumber);
        }

        /* Loose Couple issue fix: return an array[Bulls, Cows] matches found, instead of a Result Object */
        public int[] TryToGuess(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }

            int[] bullsAndCows = GetBullsAndCowsMatches(number[0] - '0', number[1] - '0', number[2] - '0', number[3] - '0');

            return bullsAndCows;
        }

        /* Loose Couple issue fix: return an array[Bulls, Cows] matches found, instead of a Result Object */
        private int[] GetBullsAndCowsMatches(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
        {
            if (firstDigit < 0 || firstDigit > 9)
            {
                throw new ArgumentException("Invalid first digit");
            }

            if (secondDigit < 0 || secondDigit > 9)
            {
                throw new ArgumentException("Invalid second digit");
            }

            if (thirdDigit < 0 || thirdDigit > 9)
            {
                throw new ArgumentException("Invalid third digit");
            }

            if (fourthDigit < 0 || fourthDigit > 9)
            {
                throw new ArgumentException("Invalid fourth digit");
            }

            this.GuessesCount++;
            int bulls = 0;

            // checks if firstDigit is a bull:
            bool isFirstDigitBullOrCow = false;            
            if (this.FirstDigit == firstDigit)
            {
                isFirstDigitBullOrCow = true;
                bulls++;
            }

            // checks if secondDigit is a bull:
            bool isSecondDigitBullOrCow = false;
            if (this.SecondDigit == secondDigit)
            {
                isSecondDigitBullOrCow = true;
                bulls++;
            }

            // checks if thirdDigit is a bull:
            bool isThirdDigitBullOrCow = false;            
            if (this.ThirdDigit == thirdDigit)
            {
                isThirdDigitBullOrCow = true;
                bulls++;
            }

            // checks if fourthDigit is a bull:
            bool isFourthDigitBullOrCow = false;            
            if (this.FourthDigit == fourthDigit)
            {
                isFourthDigitBullOrCow = true;
                bulls++;
            }

            int cows = 0;

            // checks if firstDigit is cow:
            if (!isSecondDigitBullOrCow && firstDigit == this.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && firstDigit == this.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && firstDigit == this.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if secondDigit is cow:
            if (!isFirstDigitBullOrCow && secondDigit == this.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && secondDigit == this.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && secondDigit == this.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if thirdDigit is cow:
            if (!isFirstDigitBullOrCow && thirdDigit == this.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && thirdDigit == this.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && thirdDigit == this.FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if fourthDigit is cow:
            if (!isFirstDigitBullOrCow && fourthDigit == this.FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && fourthDigit == this.SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && fourthDigit == this.ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }

            int[] bullsAndCowsResult = new int[2];
            
            //Result guessResult = new Result();
            //guessResult.Bulls = bulls;
            //guessResult.Cows = cows;
            //return guessResult;

            bullsAndCowsResult[0] = bulls;
            bullsAndCowsResult[1] = cows;

            return bullsAndCowsResult;
        }

        private void GenerateRandomNumbers()
        {
            Random randNumberGenerator = new Random();

            this.FirstDigit = randNumberGenerator.Next(0, 10);
            this.SecondDigit = randNumberGenerator.Next(0, 10);
            this.ThirdDigit = randNumberGenerator.Next(0, 10);
            this.FourthDigit = randNumberGenerator.Next(0, 10);
        }

        public override string ToString()
        {
            StringBuilder numberStringBuilder = new StringBuilder();

            numberStringBuilder.Append(this.FirstDigit);
            numberStringBuilder.Append(this.SecondDigit);
            numberStringBuilder.Append(this.ThirdDigit);
            numberStringBuilder.Append(this.FourthDigit);

            return numberStringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            BullsAndCowsNumber objectToCompare = obj as BullsAndCowsNumber;
            if (objectToCompare == null)
            {
                return false;
            }

            // Removed unnessesary else
            return (this.FirstDigit == objectToCompare.FirstDigit &&
                    this.SecondDigit == objectToCompare.SecondDigit &&
                    this.ThirdDigit == objectToCompare.ThirdDigit &&
                    this.FourthDigit == objectToCompare.FourthDigit);
            
        }

        public override int GetHashCode()
        {
            int hashCode = this.FirstDigit.GetHashCode() ^ this.SecondDigit.GetHashCode() ^ this.ThirdDigit.GetHashCode() ^ this.FourthDigit.GetHashCode();
            return hashCode;
        }
    }
}
