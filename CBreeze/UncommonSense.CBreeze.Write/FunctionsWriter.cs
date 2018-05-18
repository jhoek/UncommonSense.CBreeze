using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class FunctionsWriter
    {
        public static void Write(this Functions functions, CSideWriter writer)
        {
            foreach (Function function in functions)
            {
                function.Write(writer);
            }
        }
    }
}
