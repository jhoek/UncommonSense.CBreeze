using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class StringExtensionMethods
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

        public static string TextConstantValue(this string text, bool isComment, int noOfValues)
        {
            var needsQuotes = (text.Trim() != text) || (text.Contains(';') || text.Contains("=") || text.StartsWith("\""));

            if (isComment && noOfValues < 2)
                needsQuotes = false;

            switch (needsQuotes)
            {
                case true:
                    return text.ForceQuoted();

                default:
                    return text;
            }
        }
    }
}