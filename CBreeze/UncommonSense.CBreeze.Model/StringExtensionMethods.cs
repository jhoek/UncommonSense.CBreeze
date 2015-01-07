using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public static class StringExtensionMethods
	{
		public static string TextConstantValue(this string text)
		{
			var needsQuotes = (text.Trim() != text) || (text.Contains(';'));

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
