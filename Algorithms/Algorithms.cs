using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Invalid input, n cannot be negative");
            }
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            switch (items.Length)
            {
                case 0:
                    return "";
                case 1:
                    return items[0];
                case 2:
                    return items[0] + " and " + items[1];
                default:
                    var formatted = string.Join(", ", items.Take(items.Length - 1));
                    formatted += " and " + items[items.Length - 1];
                    return formatted;
            }
        }
    }
}
