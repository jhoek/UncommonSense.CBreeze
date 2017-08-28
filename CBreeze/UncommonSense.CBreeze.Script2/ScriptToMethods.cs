using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script2
{
    public static class ScriptToMethods
    {
        public static void ScriptTo(this Application application, IndentedTextWriter writer, bool useAliases = false, bool usePositionalParameters = false) => application.ToInvocation().ScriptTo(writer, useAliases, usePositionalParameters);
    }
}