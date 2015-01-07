using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class StringExtensionMethods
    {
        public static string Quoted(this string text)
        {
            // In e.g. CalcFormulas, table names containing no other special characters than a hyphen (e.g. "To-do") should not be quoted
            // In e.g. TableRelations, table names containing no other special characters than a slash (e.g. "Country/Region") should not be quoted
            // In e.g. TableRelations, field names containing no other special characters than a dot (e.g. "No.") should not be quoted
            if (text.All(c => char.IsLetterOrDigit(c) || c == '/' || c == '-' || c == '.'))
                return text;

            return text.ForceQuoted();
        }

        public static string ForceQuoted(this string text)
        {
            return string.Format("\"{0}\"", text);
        }

        public static string TextConstantValue(this string text, bool isComment, int noOfValues)
        {
            var needsQuotes = (text.Trim() != text) || (text.Contains(';') || text.Contains("=") || text.StartsWith("\""));

            if (isComment && noOfValues < 2)
                needsQuotes = false;

            switch (needsQuotes)
            {
                case true:
                    return string.Format("\"{0}\"", text);
                default:
                    return text;
            }
        }
    }
}
