using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public static class LanguageExtensionMethods
    {
        private static CultureInfo[] cultures;

        private static CultureInfo[] Cultures
        {
            get
            {
                cultures = cultures ?? CultureInfo.GetCultures(CultureTypes.AllCultures);
                return cultures;
            }
        }

        public static int GetLCIDFromLanguageCode(this string languageCode)
        {
            if (languageCode == "@@@")
                return 0;

            return Cultures.FirstOrDefault(c => c.ThreeLetterWindowsLanguageName == languageCode).LCID;
        }
    }
}