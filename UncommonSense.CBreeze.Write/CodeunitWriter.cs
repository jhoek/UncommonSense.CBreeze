using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class CodeunitWriter
    {
        public static void Write(this Codeunit codeunit, CSideWriter writer)
        {
            writer.BeginSection(codeunit.GetObjectSignature());
            codeunit.ObjectProperties.Write(writer);
            codeunit.Properties.Write(writer);
            codeunit.Code.Write(writer);
            writer.EndSection();
			writer.InnerWriter.WriteLine();
        }
    }
}
