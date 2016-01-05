using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Read
{
    public static class StringExtensionMethods
    {
        public static T ToEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type.");

            if (normalize)
            {
                text = Regex.Replace(text, @"[\s-\.]", string.Empty);
            }

            return (T)Enum.Parse(typeof(T), text, ignoreCase);
        }

        public static Nullable<T> ToNullableEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
#if NAV2016
            // Handle eventing attributes
            if (text == "DEFAULT")
                return null;
#endif

            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToEnum<T>(ignoreCase, normalize);
        }

        public static bool IsValidEnumValue<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            try
            {
                var enumValue = text.ToEnum<T>(ignoreCase, normalize);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static AutoFormatType ToAutoFormatType(this string text)
        {
            return (AutoFormatType)text.ToInteger();
        }

        public static FormatEvaluate ToFormatEvaluate(this string text)
        {
            switch (text)
            {
                case "XML Format/Evaluate":
                    return FormatEvaluate.XmlFormatEvaluate;
                case "C/SIDE Format/Evaluate":
                    return FormatEvaluate.CSideFormatEvaluate;
                default:
                    throw new ArgumentOutOfRangeException(text);
            }
        }

        public static bool ToBoolean(this string text)
        {
            return text == "Yes";
        }

        public static int ToInteger(this string text)
        {
            return int.Parse(text);
        }

        public static bool? ToNullableBoolean(this string text)
        {
            switch (text.Trim().ToLowerInvariant())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    return null;
            }
        }

        public static decimal? ToNullableDecimal(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return decimal.Parse(text);
        }

        public static Guid? ToNullableGuid(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            text = ApplicationExtensionMethods.RemoveSurroundingSquareBrackets(text);

            return new Guid(text);
        }

        public static int? ToNullableInteger(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return int.Parse(text);
        }

        public static int? ToPageReference(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var match = Regex.Match(text, @"Page(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format("Invalid page reference: {0}.", text));

            return match.Groups[1].Value.ToInteger();
        }

        public static int? ToTableReference(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var match = Regex.Match(text, @"Table(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format("Invalid table reference: {0}.", text));

            return match.Groups[1].Value.ToInteger();
        }
    }
}
