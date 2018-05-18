using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class CodeWriter
    {
        public static void Write(this Code code, CSideWriter writer)
        {
            writer.BeginSection("CODE");
            code.Variables.Write(writer);
            code.Functions.Write(writer);
            code.Events.Write(writer);
            code.Documentation.Write(writer);
            writer.EndSection();
        }
    }
}
