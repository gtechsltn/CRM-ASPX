using System;

namespace WebApplication1.Business
{
    public class StringExtensions : IStringExtensions
    {
        public bool Contains(string source, string dest, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return source?.IndexOf(dest, comparison) >= 0;
        }
    }
}