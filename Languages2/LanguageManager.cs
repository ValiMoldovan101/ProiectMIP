using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languages2
{
    public class LanguageManager
    {

        public static List<Languages> AvailableLanguages =
            new List<Languages>
            {
                new Languages
                {
                    LanguageName = "English",
                    LanguageCultureName = "en"
                },

                new Languages
                {
                    LanguageName = "Romana",
                    LanguageCultureName = "ro"
                }
            };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a =>
            a.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageCultureName;
        }

    }

    public class Languages
    {
        public string LanguageName { get; set; }

        public string LanguageCultureName { get; set; }
    }
}
