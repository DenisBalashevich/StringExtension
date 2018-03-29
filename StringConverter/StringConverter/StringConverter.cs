using System;
using System.Linq;

namespace StringConverter
{
    public static class StringConverter
    {
        public static int ToInt(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"{nameof(str)} is null, empty or whitespace");
            }

            int startPosition = FirstSymbolSign(str.First(), out var sign);
            int result = 0;

            try
            {
                checked
                {
                    foreach (var number in str.Substring(startPosition))
                    {
                        result = result * 10;
                        result += GetNumber(number) * sign;
                    }
                }
            }
            catch (OverflowException ex)
            {
                throw new OverflowException($"{str} is too big and cannot be stored in int type", ex);
            }

            return result;
        }

        private static int GetNumber(char charNumber)
        {
            if (!IsNumber(charNumber))
            {
                throw new FormatException($"The value '{charNumber}' should be number.");
            }

            return charNumber - '0';
        }

        private static int FirstSymbolSign(char firstSymbol, out int sign)
        {
            if (firstSymbol == '-')
            {
                sign = -1;
                return 1;
            }

            if (firstSymbol == '+')
            {
                sign = 1;
                return 1;
            }

            if (!IsNumber(firstSymbol))
                throw new FormatException($"The value '{firstSymbol}' has impossible format.");

            sign = 1;
            return 0;
        }

        private static bool IsNumber(char charNumber)
        {
            return charNumber >= '0' && charNumber <= '9';
        }
    }
}
