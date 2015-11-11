using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Parse
{
	internal static class StringExtensionMethods
	{
        public static T ToEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            if (!typeof(T).IsEnum)
                Exceptions.ThrowException(Exceptions.MustBeAnEnumeratedType, "T");

            if (normalize)
            {
                text = Regex.Replace(text, @"[\s-\.]", string.Empty);
            }

            return (T)Enum.Parse(typeof(T), text, ignoreCase);
        }

        public static Nullable<T> ToNullableEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToEnum<T>(ignoreCase, normalize);
        }

		internal static SectionType ToSectionType(this string text)
		{
			text = Regex.Replace(text, "[^A-Z]", string.Empty);

			return (SectionType)Enum.Parse(typeof(SectionType), text, true);
		}

        internal static MenuSuiteNodeType ToMenuSuiteNodeType(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return MenuSuiteNodeType.Delta;

            return text.ToEnum<MenuSuiteNodeType>();
        }

        internal static Guid ToGuid(this string text)
        {
            return new Guid(text);
        }

		internal static int ToInteger(this string text)
		{
			return int.Parse(text);
		}

		internal static bool? ToNullableBoolean(this string text)
		{
			switch (text.Trim())
			{
				case "Yes":
					return true;
				case "No":
					return false;
				default:
					return null;
			}
		}

        internal static int? ToNullableInteger(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToInteger();
        }

        internal static string UnIndent(this string text, int unindent)
        {
            switch (string.IsNullOrEmpty(text))
            {
                case true:
                    return text;
                default:
                    return text.Substring(unindent);
            }
        }
	}
}

