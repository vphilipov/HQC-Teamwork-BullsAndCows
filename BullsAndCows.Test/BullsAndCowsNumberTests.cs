using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BullsAndCows.Test
{
    [TestClass]
    public class BullsAndCowsNumberTests
    {
        // test four bulls true 
        [TestMethod]
        public void TestTryToGuessBullsTrue()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(1, 2, 3, 4);

            int[] actual = number.TryToGuess("1234");
            int[] expected = new int[] { 4, 0 };

            bool equal = true;
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                {
                    equal = false;
                }
            }

            Assert.AreEqual(true, equal);
        }

        // test four bulls true 
        [TestMethod]
        public void TestTryToGuessBullsNumberContainZero()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(0, 2, 3, 4);

            int[] actual = number.TryToGuess("0234");
            int[] expected = new int[] { 4, 0 };

            bool equal = true;
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                {
                    equal = false;
                }
            }

            Assert.AreEqual(true, equal);
        }

        // test cows
        [TestMethod]
        public void TestTryToGuessCowsTrue()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(2, 5, 4, 3);

            int[] actual = number.TryToGuess("1234");
            int[] expected = new int[] { 0, 3 };

            bool equal = true;
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] == expected[i])
                {
                    equal = false;
                }
            }

            Assert.AreEqual(false, equal);
        }

        // test cows
        [TestMethod]
        public void TestTryToGuessCowsNumberContainZero()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(0, 5, 4, 3);

            int[] actual = number.TryToGuess("2034");
            int[] expected = new int[] { 0, 3 };

            bool equal = true;
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] == expected[i])
                {
                    equal = false;
                }
            }

            Assert.AreEqual(false, equal);
        }

        // test invalid string
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTryToGuessInvalidNumber()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber();

            int[] actual = number.TryToGuess("invalid");
        }

        /* GetBullsAndCowsMatches Tests */
        // test invalid string
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetBullsAndCowsMatchesFirstDigit()
        {
            BullsAndCowsNumber number = new BullsAndCowsNumber(10, 5, 4, 3);
            int[] actual = number.TryToGuess("1234");
        }
    }
}
