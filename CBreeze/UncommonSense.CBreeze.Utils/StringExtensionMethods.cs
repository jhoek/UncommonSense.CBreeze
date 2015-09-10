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

            return ForceQuoted(text);
        }

        public static string QuotedExcept(this string text, params char[] exceptions)
        {
            // In e.g. CalcFormulas, table names containing no other special characters than a hyphen (e.g. "To-do") should not be quoted
            // In e.g. TableRelations, table names containing no other special characters than a slash (e.g. "Country/Region") should not be quoted
            // In e.g. TableRelations, field names containing no other special characters than a dot (e.g. "No.") should not be quoted
            if (text.All(c => char.IsLetterOrDigit(c) || exceptions.Contains(c)))
                return text;

            return text.ForceQuoted();
        }

        public static string ForceQuoted(this string text)
        {
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
