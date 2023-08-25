using System;
using System.Configuration;
using System.Diagnostics;
using WebApplication1.Infrastructure;

namespace WebApplication1.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CryptoDemo();

            SecureAppSectionDemo();

            Console.WriteLine("DONE");
            Console.ReadKey();
        }

        private static void SecureAppSectionDemo()
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
                Console.WriteLine(ex);
                //throw;
            }
        }

        private static void CryptoDemo()
        {
            ICryptoService _cryptoService = new CryptoService();

            try
            {
                string passwordPlainText = "Abc@123$";
                string passwordEncrypted = _cryptoService.Encrypt(passwordPlainText);
                Console.WriteLine(passwordEncrypted); // => "LMANlCOGRZSajDZOn18GDA=="

                string password = _cryptoService.Decrypt(passwordEncrypted);
                Console.WriteLine(password); // => "Abc@123$"
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //throw;
            }
        }
    }
}