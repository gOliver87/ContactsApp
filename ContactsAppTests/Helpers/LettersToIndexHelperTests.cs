using ContactsApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppTests.NewFolder
{
    internal class LettersToIndexHelperTests
    {
        [TestCase('a', 1)]
        [TestCase('b', 2)]
        [TestCase('A', 1)]
        [TestCase('Z', 26)]
        [TestCase(' ', 0)]
        [TestCase('5', 0)]
        [TestCase('%', 0)]
        public void PositionInAlphabet_ShouldPass(char input, int expected)
        {
            var actual = LettersToIndexHelper.PositionInAlphabet(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase('a', 'a', 10, 2)]
        [TestCase('z', 'z', 10, 2)]
        [TestCase('m', 'm', 7, 5)]
        [TestCase(' ', 'z', 10, 6)]
        public void LettersToIndex_ShouldPass(char firstLetter, char secondLetter, int count, int expected)
        {
            var actual = LettersToIndexHelper.LettersToIndex(firstLetter, secondLetter, count);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
