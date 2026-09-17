using static NumberToWords.Constants.WordConverterConstants;

namespace NumberToWords.Converters;

internal static class IntegerWordConverter
{
    internal static IList<string> ConvertUnderThousand(int number)
    {
        var wordList = new List<string>();

        if (number == 0 || number >= 1000) return wordList;

        var hundredValue = number / OneHundred;

        if (hundredValue > 0)
        {
            number %= OneHundred;
            wordList.Add(ConvertUniqueWord(hundredValue));
            wordList.Add(HundredWord);

            if (number > 0) wordList.Add(AndWord);
        }

        if (number == 0) return wordList;

        wordList.AddRange(ConvertUnderHundred(number));

        return wordList;
    }

    internal static IList<string> ConvertUnderHundred(int number)
    {
        var wordList = new List<string>();

        if (number == 0 || number >= 100) return wordList;

        if (UniqueWordNumbers.Contains(number))
        {
            wordList.Add(ConvertUniqueWord(number));
            return wordList;
        }

        var tenPart = number / 10 * 10;

        number %= 10;
        wordList.Add(ConvertUniqueWord(tenPart) + HyphenSeparator + ConvertUniqueWord(number));

        return wordList;
    }

    internal static string ConvertUniqueWord(int number)
    {
        if (!UniqueWordNumbers.Contains(number)) return string.Empty;

        return number switch
        {
            1 => OneWord,
            2 => TwoWord,
            3 => ThreeWord,
            4 => FourWord,
            5 => FiveWord,
            6 => SixWord,
            7 => SevenWord,
            8 => EightWord,
            9 => NineWord,
            10 => TenWord,
            11 => ElevenWord,
            12 => TwelveWord,
            13 => ThirteenWord,
            14 => FourteenWord,
            15 => FifteenWord,
            16 => SixteenWord,
            17 => SeventeenWord,
            18 => EighteenWord,
            19 => NineteenWord,
            20 => TwentyWord,
            30 => ThirtyWord,
            40 => FortyWord,
            50 => FiftyWord,
            60 => SixtyWord,
            70 => SeventyWord,
            80 => EightyWord,
            90 => NinetyWord,
            _ => string.Empty
        };
    }
}
