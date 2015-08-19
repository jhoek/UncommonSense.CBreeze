using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Utils
{
    public static class StringExtensionMethods
    {
        public static string QuotedVariableName(this string text)
        {
            if (text.All(c => Char.IsLetterOrDigit(c)))
                return text;

            return string.Format("\"{0}\"", text);
        }
    }
}
