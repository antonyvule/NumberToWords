using NumberToWords.Converters;
using static NumberToWords.Constants.WordConverterConstants;

namespace NumberToWords.Tests
{
    public class IntegerWordConverterTests
    {
        [Theory]
        [InlineData(1, OneWord)]
        [InlineData(2, TwoWord)]
        [InlineData(10, TenWord)]
        [InlineData(15, FifteenWord)]
        [InlineData(30, ThirtyWord)]
        [InlineData(90, NinetyWord)]
        public void ConvertUniqueWord_ValidNumber_ReturnsCorrectWord(int number, string expectedWord)
        {
            var actualWord = IntegerWordConverter.ConvertUniqueWord(number);
            Assert.Equal(expectedWord, actualWord);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(43)]
        [InlineData(100)]
        [InlineData(268)]
        public void ConvertUniqueWord_InvalidNumber_ReturnsEmptyString(int number)
        {
            var actualWord = IntegerWordConverter.ConvertUniqueWord(number);
            Assert.Equal(string.Empty, actualWord);
        }

        [Theory]
        [InlineData(5, new string[] { FiveWord })]
        [InlineData(16, new string[] { SixteenWord })]
        [InlineData(23, new string[] { TwentyWord + HyphenSeparator + ThreeWord })]
        [InlineData(50, new string[] { FiftyWord })]
        [InlineData(99, new string[] { NinetyWord + HyphenSeparator + NineWord })]
        public void ConvertUnderHundred_ValidNumber_ReturnsCorrectWords(int number, string[] expectedWords)
        {
            var actualWords = IntegerWordConverter.ConvertUnderHundred(number);
            Assert.Equal(expectedWords, actualWords);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(725)]
        public void ConvertUnderHundred_InvalidNumber_ReturnsEmptyList(int number)
        {
            var actualWords = IntegerWordConverter.ConvertUnderHundred(number);
            Assert.Empty(actualWords);
        }

        [Theory]
        [InlineData(123, new string[] { OneWord, HundredWord, AndWord, TwentyWord + HyphenSeparator + ThreeWord })]
        [InlineData(405, new string[] { FourWord, HundredWord, AndWord, FiveWord })]
        [InlineData(600, new string[] { SixWord, HundredWord })]
        [InlineData(876, new string[] { EightWord, HundredWord, AndWord, SeventyWord + HyphenSeparator + SixWord })]
        public void ConvertUnderThousand_ValidNumber_ReturnsCorrectWords(int number, string[] expectedWords)
        {
            var actualWords = IntegerWordConverter.ConvertUnderThousand(number);
            Assert.Equal(expectedWords, actualWords);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000)]
        [InlineData(3628)]
        public void ConvertUnderThousand_InvalidNumber_ReturnsEmptyList(int number)
        {
            var actualWords = IntegerWordConverter.ConvertUnderThousand(number);
            Assert.Empty(actualWords);
        }
    }
}
