using System;

namespace WebApplication1.Business
{
    public interface IStringExtensions
    {
        bool Contains(string source, string dest, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase);
    }
}