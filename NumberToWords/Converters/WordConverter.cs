using NumberToWords.Models;
using static NumberToWords.Constants.WordConverterConstants;

namespace NumberToWords.Converters;

internal static class WordConverter
{
    internal static WordConverterResponse Convert(decimal number)
    {
        if (number == 0) return new WordConverterResponse($"{ZeroWord} {DollarWord}", string.Empty);
        
        var errorMessage = WordConverterValidator.Validate(number);

        if (!string.IsNullOrEmpty(errorMessage)) return new WordConverterResponse(string.Empty, errorMessage);

        var wordList = ConvertIntegerPart(number).ToList();
        var decimalPartWordList = ConvertDecimalPart(number);

        if (wordList.Count > 0 && decimalPartWordList.Count > 0) wordList.Add(AndWord);

        wordList.AddRange(decimalPartWordList);

        return new WordConverterResponse(string.Join(" ", wordList), string.Empty);
    }

    internal static IList<string> ConvertIntegerPart(decimal number)
    {
        var wordList = new List<string>();
        var errorMessage = WordConverterValidator.Validate(number);

        if (!string.IsNullOrEmpty(errorMessage)) return wordList;

        var integerPart = (long)number;
        var dollarWord = integerPart > 1 
            ? DollarsWord 
            : DollarWord;

        if (integerPart < 1) dollarWord = string.Empty;

        var billionPart = integerPart / OneBillion;
        integerPart %= OneBillion;
        AddNumberUnderThousandAndWordToWordList(wordList, (int)billionPart, BillionWord);

        var millionPart = integerPart / OneMillion;
        integerPart %= OneMillion;
        AddNumberUnderThousandAndWordToWordList(wordList, (int)millionPart, MillionWord);

        var thousandPart = integerPart / OneThousand;
        integerPart %= OneThousand;
        AddNumberUnderThousandAndWordToWordList(wordList, (int)thousandPart, ThousandWord);

        if (integerPart > 0)
        {
            wordList.AddRange(IntegerWordConverter.ConvertUnderThousand((int)integerPart));
        }

        if (!string.IsNullOrEmpty(dollarWord)) wordList.Add(dollarWord);

        return wordList;
    }

    internal static IList<string> ConvertDecimalPart(decimal number)
    {
        var wordList = new List<string>();
        var errorMessage = WordConverterValidator.Validate(number);

        if (!string.IsNullOrEmpty(errorMessage)) return wordList;

        var decimalPart = (number - Math.Truncate(number)) * OneHundred;

        if (decimalPart <= 0) return wordList;

        wordList.AddRange(IntegerWordConverter.ConvertUnderHundred((int)decimalPart));
        var centWord = decimalPart > 1 ? CentsWord : CentWord;
        wordList.Add(centWord);

        return wordList;
    }

    private static void AddNumberUnderThousandAndWordToWordList(List<string> wordList, int number, string word)
    {
        if (number <= 0) return;

        wordList.AddRange(IntegerWordConverter.ConvertUnderThousand(number));
        wordList.Add(word);
    }
}
