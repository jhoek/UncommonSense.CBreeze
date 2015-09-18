using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.IO
{
    public static class StringBuilderExtensionMethods
    {
        public static void AppendIf(this StringBuilder stringBuilder, bool condition, string text)
        {
            if (condition)
            {
                stringBuilder.Append(text);
            }
        }

        public static void AppendFormatIf(this StringBuilder stringBuilder, bool condition, string format, params object[] args)
        {
            if (condition)
            {
                stringBuilder.AppendFormat(format, args);
            }
        }
    }
}
