using System;
using System.Linq;

namespace BullsAndCows
{
    public struct Result
    {
        private int bulls;
        private int cows;

        public Result(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;
        }

        public int Bulls;
        public int Cows;

        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
