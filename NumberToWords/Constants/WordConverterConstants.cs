namespace NumberToWords.Constants;

internal static class WordConverterConstants
{
    internal static readonly int[] UniqueWordNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 30, 40, 50, 60, 70, 80, 90
    ];

    internal const decimal MaxNumberAllowed = 999_999_999_999.99M;

    internal const int OneBillion = 1_000_000_000;
    internal const int OneMillion = 1_000_000;
    internal const int OneThousand = 1_000;
    internal const int OneHundred = 100;

    internal const string HyphenSeparator = "-";

    internal const string AndWord = "AND";

    internal const string BillionWord = "BILLION";
    internal const string MillionWord = "MILLION";
    internal const string ThousandWord = "THOUSAND";
    internal const string HundredWord = "HUNDRED";

    internal const string DollarsWord = "DOLLARS";
    internal const string DollarWord = "DOLLAR";
    internal const string CentsWord = "CENTS";
    internal const string CentWord = "CENT";

    internal const string ZeroWord = "ZERO";
    internal const string OneWord = "ONE";
    internal const string TwoWord = "TWO";
    internal const string ThreeWord = "THREE";
    internal const string FourWord = "FOUR";
    internal const string FiveWord = "FIVE";
    internal const string SixWord = "SIX";
    internal const string SevenWord = "SEVEN";
    internal const string EightWord = "EIGHT";
    internal const string NineWord = "NINE";
    internal const string TenWord = "TEN";
    internal const string ElevenWord = "ELEVEN";
    internal const string TwelveWord = "TWELVE";
    internal const string ThirteenWord = "THIRTEEN";
    internal const string FourteenWord = "FOURTEEN";
    internal const string FifteenWord = "FIFTEEN";
    internal const string SixteenWord = "SIXTEEN";
    internal const string SeventeenWord = "SEVENTEEN";
    internal const string EighteenWord = "EIGHTEEN";
    internal const string NineteenWord = "NINETEEN";
    internal const string TwentyWord = "TWENTY";
    internal const string ThirtyWord = "THIRTY";
    internal const string FortyWord = "FORTY";
    internal const string FiftyWord = "FIFTY";
    internal const string SixtyWord = "SIXTY";
    internal const string SeventyWord = "SEVENTY";
    internal const string EightyWord = "EIGHTY";
    internal const string NinetyWord = "NINETY";

    internal const string NumberLessThanZeroErrorMessage = "The number must be greater than 0.";
    internal const string NumberGreaterThanMaxNumberAllowedErrorMessage = "The number must be less than or equal to 999,999,999,999.99.";
    internal const string NumberIsInvalidMoneyAmountErrorMessage = "The number must have no more than 2 decimal places.";
}
