using NumberToWords.Converters;

namespace NumberToWords.Tests
{
    public class WordConverterValidatorTests
    {
        [Theory]
        [InlineData(123)]
        [InlineData(123.4)]
        [InlineData(123.45)]
        public void IsValidMoneyAmount_AmountWithNoMoreThanTwoDecimalPlace_ReturnsValid(decimal number)
        {
            Assert.True(WordConverterValidator.IsValidMoneyAmount(number));
        }

        [Theory]
        [InlineData(123.456)]
        [InlineData(123.4567)]
        public void IsValidMoneyAmount_AmountWithMoreThanTwoDecimalPlaces_ReturnsInvalid(decimal number)
        {
            Assert.False(WordConverterValidator.IsValidMoneyAmount(number));
        }

        [Fact]
        public void Validate_NumberLessThanZero_ReturnsNumberLessThanZeroErrorMessage()
        {
            var errorMessage = WordConverterValidator.Validate(-1);
            Assert.Equal(Constants.WordConverterConstants.NumberLessThanZeroErrorMessage, errorMessage);
        }

        [Fact]
        public void Validate_NumberGreaterThanMaxNumberAllowed_ReturnsNumberGreaterThanMaxNumberAllowedErrorMessage()
        {
            var errorMessage = WordConverterValidator.Validate(Constants.WordConverterConstants.MaxNumberAllowed + 1);
            Assert.Equal(Constants.WordConverterConstants.NumberGreaterThanMaxNumberAllowedErrorMessage, errorMessage);
        }

        [Theory]
        [InlineData(123)]
        [InlineData(123.4)]
        [InlineData(123.45)]
        public void Validate_ValidMoneyAmount_ReturnsEmptyString(decimal number)
        {
            var errorMessage = WordConverterValidator.Validate(number);
            Assert.Equal(string.Empty, errorMessage);
        }

        [Theory]
        [InlineData(123.456)]
        [InlineData(123.4567)]
        public void Validate_InvalidMoneyAmount_ReturnsNumberIsInvalidMoneyAmountErrorMessage(decimal number)
        {
            var errorMessage = WordConverterValidator.Validate(number);
            Assert.Equal(Constants.WordConverterConstants.NumberIsInvalidMoneyAmountErrorMessage, errorMessage);
        }
    }
}