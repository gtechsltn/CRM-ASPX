using System;
using System.Globalization;
using WebApplication1.Infrastructure;

namespace WebApplication1.Business
{
    public class ConverterService : IConverterService
    {
        private readonly IStringExtensions _stringExtensions;

        public ConverterService(IStringExtensions stringExtensions)
        {
            _stringExtensions = stringExtensions;
        }

        public DateTime GetDate(string doB)
        {
            DateTime date = DateTime.ParseExact(doB, AppConstants.DateFormatCS, CultureInfo.InvariantCulture);
            return date;
        }

        public string MakeGenderInDB(string gender)
        {
            string genderString = string.Empty;

            if (gender == null)
            {
                genderString = "U";
            }
            else if (_stringExtensions.Contains(gender, "Nam", StringComparison.OrdinalIgnoreCase))
            {
                genderString = "M";
            }
            else if (_stringExtensions.Contains(gender, "Nữ", StringComparison.OrdinalIgnoreCase))
            {
                genderString = "F";
            }
            else
            {
                genderString = "U";
            }
            return genderString;
        }

        public string MakeGenderInScreen(string gender)
        {
            string genderString = string.Empty;
            if (gender == null)
            {
                genderString = "Không biết";
            }
            switch (gender)
            {
                case "M":
                    genderString = "Nam";
                    break;

                case "F":
                    genderString = "Nữ";
                    break;

                default:
                    genderString = "Không biết";
                    break;
            }

            return genderString;
        }

        public string ShowDateOnly(DateTime doB)
        {
            var dt = doB.ToString(AppConstants.DateFormatCS);
            return dt;
        }
    }
}