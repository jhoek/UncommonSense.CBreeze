using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class CSideWriterExtensionMethods
    {
        public static void WriteIf(this CSideWriter writer, bool condition, string text)
        {
            if (condition)
                writer.Write(text);
        }

        public static void WriteIf(this CSideWriter writer, bool condition, string format, params object[] args)
        {
            if (condition)
                writer.Write(format, args);
        }

        public static void WriteLineIf(this CSideWriter writer, bool condition, string text)
        {
            if (condition)
                writer.WriteLine(text);
        }

        public static void WriteLineIf(this CSideWriter writer, bool condition, string format, params object[] args)
        {
            if (condition)
                writer.WriteLine(format, args);
        }
    }
}
