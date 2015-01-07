using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

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
