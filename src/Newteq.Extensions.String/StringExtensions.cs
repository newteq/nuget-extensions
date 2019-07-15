using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a byte[] converted from string data that is in base64 format
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>A base64 byte[]</returns>
        public static byte[] BytesFromBase64(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Convert.FromBase64String(input);
        }

        /// <summary>
        /// Converts a string to base enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="input">The string input.</param>
        /// <returns>The enum value as a base Enum</returns>
        public static Enum ConvertToBaseEnum<TEnum>(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            return (Enum)Convert.ChangeType(Enum.Parse(typeof(TEnum), input), typeof(TEnum));
        }

        /// <summary>
        /// Converts a string to an enum of a specific type
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="input">The string input.</param>
        /// <returns>the enum value</returns>
        public static TEnum ConvertToTypedEnum<TEnum>(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            return (TEnum)Convert.ChangeType(Enum.Parse(typeof(TEnum), input), typeof(TEnum));
        }

        /// <summary>
        /// Gets the bytes for the string.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The byte array for the input</returns>
        public static byte[] GetBytes(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Determines whether the input is completely empty by checking if it is null, empty or only whitespace.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the input is null or empty; otherwise, <c>false</c>.</returns>
        public static bool IsCompletelyEmpty(this string input)
        {
            return input.IsNullOrEmpty() && input.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Determines whether the input is null or only whitespace.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the input is null or empty; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Determines whether the input is null or empty.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>true</c> if the input is null or empty; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Reverses the string provided.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>the reversed string</returns>
        public static string Reverse(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                return input;
            }

            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Converts a base64 string to normal string data.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>string from base 64</returns>
        public static string StringFromBase64(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            var data = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Converts a string to base64 format.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The base 64 version of the input</returns>
        public static string ToBase64(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Convert.ToBase64String(input.GetBytes());
        }

        /// <summary>
        /// This method cases a word to a camel case (i.e. so that it starts with a lower case
        /// letter, does not change anything else
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The input with the first letter as a lower case</returns>
        public static string ToCamelCase(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                return input;
            }

            return char.ToLowerInvariant(input[0]) + input.Substring(1);
        }

        /// <summary>
        /// Creates a "Title" of the string provided.
        /// It will make each letter of a seperate word start with a capital letter
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The "title'd" value</returns>
        public static string ToTitle(this string input)
        {
            if (input.IsCompletelyEmpty())
            {
                return input;
            }

            var inputWords = input.Split(' ');
            var outputWords = new string[inputWords.Length];
            for(var i = 0; i < inputWords.Length; i++)
            {
                var resultWord = new StringBuilder();

                var currentWord = inputWords[i];
                var firstUpper = char.ToUpperInvariant(currentWord[0]);
                resultWord.Append(firstUpper);

                if (currentWord.Length > 1)
                {
                    resultWord.Append(currentWord.Substring(1));
                }
                outputWords[i] = resultWord.ToString();
            }

            return string.Join(" ", outputWords);
        }

        /// <summary>
        /// This joins a string array of items in a natural english way.
        /// For example, and array with the following contents: ["Nick", "John", "Albert", "Sarah"]
        /// Will result in a string result as: "Nick, John, Albert, and Sarah"
        /// </summary>
        /// <param name="input">The string array to combine</param>
        /// <returns>A string that is joined by natural english</returns>
        public static string NaturalJoin(this string[] input)
        {
            return $"{string.Join(", ", input, 0, input.Length - 2)}, and {input[input.Length - 1]}";
        }

        /// <summary>
        /// This joins a string array of items in a natural english way.
        /// For example, and array with the following contents: ["Nick", "John", "Albert", "Sarah"]
        /// Will result in a string result as: "Nick, John, Albert, and Sarah"
        /// </summary>
        /// <param name="input">The string array to combine</param>
        /// <returns>A string that is joined by natural english</returns>
        public static string NaturalJoin(this IEnumerable<string> input)
        {
            return input.ToArray().NaturalJoin();
        }
    }
}
