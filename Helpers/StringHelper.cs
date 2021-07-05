using System;
using System.Linq;

namespace MetuljmaniaDatabase.Helpers
{
    public class StringHelper
    {
        private static readonly Random random = new();

        /// <summary>
        /// Generate random string.
        /// </summary>
        /// <param name="length">Length.</param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuvwxyzq0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
