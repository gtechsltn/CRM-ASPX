using System;

namespace WebApplication1.Business
{
    public interface IConverterService
    {
        DateTime GetDate(string doBInStr);

        string MakeGenderInScreen(string gender);

        string MakeGenderInDB(string gender);

        string ShowDateOnly(DateTime doB);
    }
}