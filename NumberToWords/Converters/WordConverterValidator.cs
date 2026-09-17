namespace NumberToWords.Converters;
using static Constants.WordConverterConstants;

internal static class WordConverterValidator
{
    internal static string Validate(decimal number)
    {
        switch (number)
        {
            case < 0:
                return NumberLessThanZeroErrorMessage;
            case > MaxNumberAllowed:
                return NumberGreaterThanMaxNumberAllowedErrorMessage;
        }

        var isValidMoneyAmount = IsValidMoneyAmount(number);

        return isValidMoneyAmount ? string.Empty : NumberIsInvalidMoneyAmountErrorMessage;
    }

    internal static bool IsValidMoneyAmount(decimal number)
    {
        return number * OneHundred == Math.Truncate(number * OneHundred);
    }
}
