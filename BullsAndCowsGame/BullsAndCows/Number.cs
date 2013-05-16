using System;
using System.Linq;

namespace BullsAndCows
{
    public abstract class Number
    {
        protected const byte MinDigitValue = 0;
        protected const byte MaxDigitValue = 9;

        private byte firstDigit;
        private byte secondDigit;
        private byte thirdDigit;
        private byte fourthDigit;

        public Number()
        { }
        

        public Number(byte firstDigit, byte secondDigit, byte thirdDigit, byte fourthDigit)
        {
            this.FirstDigit = firstDigit;
            this.SecondDigit = secondDigit;
            this.ThirdDigit = thirdDigit;
            this.FourthDigit = fourthDigit;
        }

        public byte FirstDigit
        {
            get
            {
                return this.firstDigit;
            }
            private set
            {
                if (value < MinDigitValue || MaxDigitValue < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number's first digit is outside the permitted range!");
                }
                this.firstDigit = value;
            }
        }

        public byte SecondDigit
        {
            get
            {
                return this.secondDigit;
            }
            private set
            {
                if (value < MinDigitValue || MaxDigitValue < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number's second digit is outside the permitted range!");
                }
                this.secondDigit = value;
            }
        }

        public byte ThirdDigit
        {
            get
            {
                return this.thirdDigit;
            }
            private set
            {
                if (value < MinDigitValue || MaxDigitValue < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number's third digit is outside the permitted range!");
                }
                this.thirdDigit = value;
            }
        }

        public byte FourthDigit
        {
            get
            {
                return this.fourthDigit;
            }
            private set
            {
                if (value < MinDigitValue || MaxDigitValue < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number's first digit is outside the permitted range!");
                }
                this.fourthDigit = value;
            }
        }
    }
}
