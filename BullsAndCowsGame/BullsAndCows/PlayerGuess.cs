using System;

namespace BullsAndCows
{
    public class PlayerGuess : Number
    {
        public PlayerGuess(byte firstDigit, byte secondDigit, byte thirdDigit, byte fourthDigit)
            : base(firstDigit, secondDigit, thirdDigit, fourthDigit)
        {
        }
    }
}