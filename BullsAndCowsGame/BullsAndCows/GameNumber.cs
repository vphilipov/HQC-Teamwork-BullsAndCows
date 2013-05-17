using System;

namespace BullsAndCows
{
    public class GameNumber : Number
    {
        public GameNumber() : base()
        {
            this.FirstDigit = GenerateRandomDigit();
            this.SecondDigit = GenerateRandomDigit();
            this.ThirdDigit = GenerateRandomDigit();
            this.FourthDigit = GenerateRandomDigit();
        }

        public GameNumber(byte firstDigit, byte secondDigit, byte thirdDigit, byte fourthDigit)
            : base()
        {
            this.FirstDigit = firstDigit;
            this.SecondDigit = secondDigit;
            this.ThirdDigit = thirdDigit;
            this.FourthDigit = fourthDigit;
        }

        private byte GenerateRandomDigit()
        {
            Random randNumberGenerator = new Random();

            byte digit = (byte)randNumberGenerator.Next(Number.MinDigitValue, Number.MaxDigitValue + 1);
            return digit;
        }
    }
}