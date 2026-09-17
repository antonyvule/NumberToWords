using NumberToWords.Converters;
using static NumberToWords.Constants.WordConverterConstants;

namespace NumberToWords.Tests
{
    public class WordConverterTests
    {
        [Theory]
        [InlineData(0.01, new string[] { OneWord, CentWord })]
        [InlineData(0.10, new string[] { TenWord, CentsWord })]
        [InlineData(0.17, new string[] { SeventeenWord, CentsWord })]
        [InlineData(0.34, new string[] { ThirtyWord + HyphenSeparator + FourWord, CentsWord })]
        [InlineData(0.70, new string[] { SeventyWord, CentsWord })]
        [InlineData(0.99, new string[] { NinetyWord + HyphenSeparator + NineWord, CentsWord })]
        public void ConvertDecimalPart_ValidNumber_ReturnsCorrectWords(decimal number, string[] expectedWords)
        {
            var actualWords = WordConverter.ConvertDecimalPart(number);
            Assert.Equal(expectedWords, actualWords);
        }

        [Theory]
        [InlineData(-0.01)]
        [InlineData(1.00)]
        [InlineData(0.001)]
        [InlineData(0.123)]
        [InlineData(0.9999)]
        public void ConvertDecimalPart_InvalidNumber_ReturnsEmptyList(decimal number)
        {
            var actualWords = WordConverter.ConvertDecimalPart(number);
            Assert.Empty(actualWords);
        }

        [Theory]
        [InlineData(1, new string[] { OneWord, DollarWord })]
        [InlineData(14, new string[] { FourteenWord, DollarsWord })]
        [InlineData(123, new string[] { OneWord, HundredWord, AndWord, TwentyWord + HyphenSeparator + ThreeWord, DollarsWord })]
        [InlineData(1001, new string[] { OneWord, ThousandWord, OneWord, DollarsWord })]
        [InlineData(1000000, new string[] { OneWord, MillionWord, DollarsWord })]
        [InlineData(7000009, new string[] { SevenWord, MillionWord, NineWord, DollarsWord })]
        [InlineData(1000000000, new string[] { OneWord, BillionWord, DollarsWord })]
        [InlineData(1234567890, new string[] { OneWord, BillionWord, TwoWord, HundredWord, AndWord, ThirtyWord + HyphenSeparator + FourWord, MillionWord, FiveWord, HundredWord, AndWord, SixtyWord + HyphenSeparator + SevenWord, ThousandWord, EightWord, HundredWord, AndWord, NinetyWord, DollarsWord })]
        public void ConvertIntegerPart_ValidNumber_ReturnsCorrectWords(decimal number, string[] expectedWords)
        {
            var actualWords = WordConverter.ConvertIntegerPart(number);
            Assert.Equal(expectedWords, actualWords);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1000000000000)]
        public void ConvertIntegerPart_InvalidNumber_ReturnsEmptyList(decimal number)
        {
            var actualWords = WordConverter.ConvertIntegerPart(number);
            Assert.Empty(actualWords);
        }

        [Theory]
        [InlineData(0, new string[] { ZeroWord, DollarWord })]
        [InlineData(1, new string[] { OneWord, DollarWord })]
        [InlineData(13, new string[] { ThirteenWord, DollarsWord })]
        [InlineData(543.21, new string[] { FiveWord, HundredWord, AndWord, FortyWord + HyphenSeparator + ThreeWord, DollarsWord, AndWord, TwentyWord + HyphenSeparator + OneWord, CentsWord })]
        [InlineData(1000000.99, new string[] { OneWord, MillionWord, DollarsWord, AndWord, NinetyWord + HyphenSeparator + NineWord, CentsWord })]
        [InlineData(1234567890.12, new string[] { OneWord, BillionWord, TwoWord, HundredWord, AndWord, ThirtyWord + HyphenSeparator + FourWord, MillionWord, FiveWord, HundredWord, AndWord, SixtyWord + HyphenSeparator + SevenWord, ThousandWord, EightWord, HundredWord, AndWord, NinetyWord, DollarsWord, AndWord, TwelveWord, CentsWord })]
        public void Convert_ValidNumber_ReturnsCorrectWords(decimal number, string[] expectedWords)
        {
            var response = WordConverter.Convert(number);
            var actualWords = response.Words.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(expectedWords, actualWords);
            Assert.True(string.IsNullOrEmpty(response.ErrorMessage));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0.123)]
        [InlineData(1000000000000)]
        public void Convert_InvalidNumber_ReturnsErrorMessage(decimal number)
        {
            var response = WordConverter.Convert(number);
            Assert.True(string.IsNullOrEmpty(response.Words));
            Assert.False(string.IsNullOrEmpty(response.ErrorMessage));
        }
    }
}
