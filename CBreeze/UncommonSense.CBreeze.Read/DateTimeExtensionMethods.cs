using System;
using System.Globalization;

namespace UncommonSense.CBreeze.Read
{
	internal static class DateTimeExtensionMethods
	{
		internal static DateTime SetDateComponent(this DateTime dateTime, string text)
		{
			var time = dateTime.TimeOfDay;
			var date = DateTime.ParseExact(text, "dd-MM-yy", CultureInfo.InvariantCulture).Date;
			return date.Add(time);
		}

		internal static DateTime SetTimeComponent(this DateTime dateTime, string text)
		{
			var date = dateTime.Date;
			var time = TimeSpan.ParseExact(text, @"hh\:mm\:ss", CultureInfo.InvariantCulture);
			return date.Add(time);
		}
	}
}

