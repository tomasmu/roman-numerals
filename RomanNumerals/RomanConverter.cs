using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public static class RomanConverter
    {
        static RomanConverter()
        {
            InitDictionaries();
        }

        public static string Convert(int number) => _decimalToRoman.GetValueOrDefault(number);
        public static int Convert(string number) => _romanToDecimal.GetValueOrDefault(number);

        private static Dictionary<int, string> _decimalToRoman = new Dictionary<int, string>();
        private static Dictionary<string, int> _romanToDecimal = new Dictionary<string, int>();

        private static Dictionary<int, string> _baseNumerals = new Dictionary<int, string>()
        {
            [1] = "I",
            [4] = "IV",
            [5] = "V",
            [9] = "IX",

            [10] = "X",
            [40] = "XL",
            [50] = "L",
            [90] = "XC",

            [100] = "C",
            [400] = "CD",
            [500] = "D",
            [900] = "CM",

            [1000] = "M",
        };

        const int _maxRomanNumber = 3999;
        private static void InitDictionaries()
        {
            var baseDescending = _baseNumerals.OrderByDescending(pair => pair.Key);
            for (int i = 1; i <= _maxRomanNumber; i++)
            {
                var number = i;
                var roman = String.Empty;
                foreach (var basePair in baseDescending)
                {
                    while (number >= basePair.Key)
                    {
                        roman += basePair.Value;
                        number -= basePair.Key;
                    }
                }

                _decimalToRoman.Add(i, roman);
                _romanToDecimal.Add(roman, i);
            }
        }
    }


    public static class ExtensionMethods
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key) =>
            dict.TryGetValue(key, out TValue result)
                ? result
                : default(TValue);
    }
}
