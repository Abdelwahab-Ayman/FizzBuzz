using System;
using FizzBuzz;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace FizzBuzzTests
{
    public class FizzBuzzDetectorTests
    {
        private readonly FizzBuzzDetector _detector = new();

        [Fact]
        public void MaryHadALittleLamb_ReplacesWordsAndCountsThem()
        {
            string input =
                "Mary had a little lamb\n" +
                "Little lamb, little lamb\n" +
                "Mary had a little lamb\n" +
                "It's fleece was white as snow";

            string expected =
                "Mary had Fizz little Buzz\n" +
                "Fizz lamb, little Fizz\n" +
                "Buzz had Fizz little lamb\n" +
                "FizzBuzz fleece was Fizz as Buzz";

            var result = _detector.getOverlappings(input);

            Assert.Equal(expected, result.Output);
            Assert.Equal(9, result.Count);
        }
        [Fact]
        public void NullInput_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.getOverlappings(null!));
        }
        [Theory]
        [InlineData("")]
        [InlineData("123456")]
        public void TooShort_Throws(string input)
        {
            Assert.Throws<ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Fact]
        public void TooLong_Throws()
        {
            string input = new string('a', 101);

            Assert.Throws<ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Fact]
        public void MinimumLength_IsAccepted()
        {
            var result = _detector.getOverlappings("one two"); // exactly 7 chars

            Assert.Equal("one two", result.Output);
            Assert.Equal(0, result.Count);
        }
        [Fact]
        public void MaximumLength_IsAccepted()
        {
            string input = new string('w', 100); // one long word, so nothing gets replaced

            var result = _detector.getOverlappings(input);

            Assert.Equal(input, result.Output);
            Assert.Equal(0, result.Count);
        }
        [Fact]
        public void PunctuationAndWhitespace_ArePreserved()
        {
            // word3 -> Fizz, word5 -> Buzz
            string input = "  word1, (word2) -> word3!! word4 #word5?  ";
            string expected = "  word1, (word2) -> Fizz!! word4 #Buzz?  ";

            var result = _detector.getOverlappings(input);

            Assert.Equal(expected, result.Output);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public void WordsWithDigits_CountAsWords()
        {
            // item3 -> Fizz, 456 -> Buzz, v6 -> Fizz
            string input = "item1 item2 item3 123 456 v6 end";
            string expected = "item1 item2 Fizz 123 Buzz Fizz end";

            var result = _detector.getOverlappings(input);

            Assert.Equal(expected, result.Output);
            Assert.Equal(3, result.Count);
        }
        [Fact]
        public void NoWords_ReturnsInputUnchanged()
        {
            string input = "--- !!! ??? ...";

            var result = _detector.getOverlappings(input);

            Assert.Equal(input, result.Output);
            Assert.Equal(0, result.Count);
        }



    }
}
