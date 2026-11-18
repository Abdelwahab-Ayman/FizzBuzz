using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzDetector
    {
        private const int MinLength = 7;
        private const int MaxLength = 100;

        // Length of the input string: 7 ≤ |s| ≤ 100
        // Input string cannot be null
        // Algorithm processes only alphanumeric words(other symbols and whitespaces are skipped)
        public FizzBuzzResult getOverlappings(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            if (input.Length < MinLength || input.Length > MaxLength)
            {
                throw new ArgumentException(
                    $"Length of the input string must be between {MinLength} and {MaxLength} characters inclusive. Current length: {input.Length}.",
                    nameof(input));
            }
            var sb = new StringBuilder();
            int wordNumber = 0;
            int replaced = 0;
            int i = 0;
            while (i < input.Length)
            {
                // spaces, punctuation etc. are copied as-is
                if (!char.IsLetterOrDigit(input[i]))
                {
                    sb.Append(input[i]);
                    i++;
                    continue;
                }

                int start = i;
                while (i < input.Length && (char.IsLetterOrDigit(input[i]) || IsInnerApostrophe(input, i)))
                    i++;

                wordNumber++;

                // multiples of 15 pick up both, giving "FizzBuzz"
                string replacement = "";
                if (wordNumber % 3 == 0) replacement += "Fizz";
                if (wordNumber % 5 == 0) replacement += "Buzz";

                if (replacement.Length > 0)
                {
                    sb.Append(replacement);
                    replaced++;
                }
                else
                {
                    sb.Append(input, start, i - start);
                }
            }

            return new FizzBuzzResult(sb.ToString(), replaced);
        }

        // true for an apostrophe sitting between two letters/digits, e.g. the one in "It's"
        private static bool IsInnerApostrophe(string s, int index)
        {
            if (s[index] != '\'' && s[index] != '’')
                return false;

            return index > 0 && index + 1 < s.Length
                && char.IsLetterOrDigit(s[index - 1])
                && char.IsLetterOrDigit(s[index + 1]);
        }
    }
}
    

