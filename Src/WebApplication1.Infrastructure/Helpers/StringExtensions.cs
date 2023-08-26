using System;

namespace WebApplication1.Infrastructure
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string dest, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return source?.IndexOf(dest, comparison) >= 0;
        }
    }
}