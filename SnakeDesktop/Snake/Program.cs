using System;
using System.Windows.Forms;
using System.Configuration;

namespace Snake
{
    static class Program 
    {
        /// <summary>
        /// Mechanika i interface aplikacji s¹ w pozosta³ych klasach
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSnake());
            
            // Wczytywanie nowych konfiguracji
            ReadAllSettings();
            ReadSetting("Setting1");
            ReadSetting("Setting2");
            ReadAllSettings();
        }

       
        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("Brak konfiguracji.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("B³¹d wczytywania app settings");
            }
        }

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Nie znaleziony.";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("B³¹d wczytywania app settings");
            }
        }
        
    }
}
