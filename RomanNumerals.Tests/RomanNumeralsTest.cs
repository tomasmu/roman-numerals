using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RomanNumerals;

namespace RomanNumerals.Tests
{
    public class RomanNumeralsTest
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("LXVII", 67)]
        [InlineData("CLXXVIII", 178)]
        [InlineData("DCCLXXXIV", 784)]
        [InlineData("MMMDCCCLXXXVIII", 3888)]
        [InlineData("MMMCMXCIX", 3999)]
        public void Convert_GivenValidRomanNumeral_ConvertsToNumber(string input, int expected)
        {
            var result = RomanConverter.Convert(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(67, "LXVII")]
        [InlineData(178, "CLXXVIII")]
        [InlineData(784, "DCCLXXXIV")]
        [InlineData(3888, "MMMDCCCLXXXVIII")]
        [InlineData(3999, "MMMCMXCIX")]
        public void Convert_GivenNumberInRange_ConvertsToRomanNumeral(int input, string expected)
        {
            var result = RomanConverter.Convert(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("IIII")]
        [InlineData("IIV")]
        [InlineData("VV")]
        [InlineData("VIV")]
        [InlineData("Horse")]
        [InlineData("IXL")]
        [InlineData("LC")]
        [InlineData("CDM")]
        public void Convert_GivenInvalidRomanNumeral_ConvertsToZero(string input)
        {
            var result = RomanConverter.Convert(input);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4000)]
        [InlineData(-1)]
        [InlineData(123456)]
        public void Convert_GivenNumberOutsideRange_ConvertsToNullString(int input)
        {
            var result = RomanConverter.Convert(input);

            Assert.Null(result);
        }
    }
}
