using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ContactsApp.Helpers
{
    /// <summary>
    /// Converts 2 letters into an index of an array of a given size
    /// </summary>
    public class LettersToIndexHelper
    {
        public static int PositionInAlphabet(char letter)
        {
            try
            {
                if (char.IsLetter(letter))
                    return char.ToUpper(letter) - 64;
            }
            catch (Exception)
            {
                //Should be logged
            }
            return 0;
        }

        public static int LettersToIndex(string firstLetter, string secondLetter, int count)
        {
            try
            {
                if (firstLetter.Length > 0 && secondLetter.Length > 0)
                {
                    var firstChar = firstLetter.ToCharArray()[0];
                    var secondChar = secondLetter.ToCharArray()[0];
                    return LettersToIndex(firstChar, secondChar, count);
                }
                
            }
            catch (Exception)
            {
                //Should be logged
            }
            return 0;
        }

        public static int LettersToIndex(char firstLetter, char secondLetter, int count)
        {
            if (count == 0)
                return 0;

            var number = PositionInAlphabet(firstLetter) + PositionInAlphabet(secondLetter);
            return number % count;
        }
    }
}
