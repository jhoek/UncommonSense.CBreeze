using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class DateTimeExtensionMethods
    {
        public static string ToShortDateString(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;
            
            return dateTime.Value.ToString("dd-MM-yy");
        }

        public static string ToShortTimeString(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;
            return dateTime.Value.ToString("HH:mm:ss");
        }
    }
}
