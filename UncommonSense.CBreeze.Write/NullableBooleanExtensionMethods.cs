using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class NullableBooleanExtensionMethods
    {
        public static string AsString(this bool? value)
        {
            if (!value.HasValue)
                return string.Empty;

            return value.Value ? "Yes" : "No";
        }
    }
}
