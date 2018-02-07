using System;
using System.Globalization;

namespace UncommonSense.CBreeze.Read
{
	internal static class DateTimeExtensionMethods
	{
		internal static DateTime? SetDateComponent(this DateTime? dateTime, string text)
		{
            if (!string.IsNullOrEmpty(text))
            {
                var time = dateTime.GetValueOrDefault(DateTime.MinValue).TimeOfDay;
                var date = DateTime.ParseExact(text, "dd-MM-yy", CultureInfo.InvariantCulture).Date;
                return date.Add(time);
            }

            return dateTime;
		}

		internal static DateTime? SetTimeComponent(this DateTime? dateTime, string text)
		{
            if (!string.IsNullOrEmpty(text))
            {
                var date = dateTime.GetValueOrDefault(DateTime.MinValue).Date;
                var time = TimeSpan.ParseExact(text, @"hh\:mm\:ss", CultureInfo.InvariantCulture);
                return date.Add(time);
            }

            return dateTime;
		}
	}
}

