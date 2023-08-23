using System;
using System.Configuration;
using System.Diagnostics;

namespace WebApplication1.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection secureAppSection = config.GetSection("ADAccountSettings");

                if (!secureAppSection.SectionInformation.IsProtected)
                {
                    secureAppSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    secureAppSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
