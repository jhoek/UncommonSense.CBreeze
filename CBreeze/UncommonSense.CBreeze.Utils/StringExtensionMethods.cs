using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Utils
{
    public static class StringExtensionMethods
    {
        public static string Quoted(this string text)
        {
            if (text.All(c => Char.IsLetterOrDigit(c)))
                return text;

            return string.Format("\"{0}\"", text);
        }

        public static string MakeVariableName(this string text)
        {
            text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);

            return new string((from c in text
                               where Char.IsLetterOrDigit(c)
                               select c).ToArray());
        }
    }
}
