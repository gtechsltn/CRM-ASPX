using System;

namespace WebApplication1.Helpers
{
    public static class StringExtensions
    {
        public static string MakeGender(this string gender)
        {
            if (gender == null)
            {
                return "Không biết";
            }
            switch (gender)
            {
                case "M":
                    return "Nam";

                case "F":
                    return "Nữ";

                default:
                    return "Không biết";
            }
        }

        public static string ShowDateOnly(this DateTime dob)
        {
            return dob.ToString("dd-MMM-yy");
        }
    }
}