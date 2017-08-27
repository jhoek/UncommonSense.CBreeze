using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class ScriptWriter
    {
        public ScriptWriter(TextWriter textWriter)
        {
            TextWriter = textWriter;
        }

        public TextWriter TextWriter { get; protected set; }
        public bool UseAliases { get; set; }
        public bool UsePositionalParams { get; set; }

        public ScriptWriter EndInvocation()
        {
            WriteLine();
            return this;
        }

        public ScriptWriter StartInvocation(string cmdletName) => StartInvocation(cmdletName, "");

        public ScriptWriter StartInvocation(string cmdletName, string alias)
        {
            Write(UseAliases ? alias : cmdletName);
            return this;
        }

        public ScriptWriter StartInvocation(CmdletInfo cmdletInfo) => StartInvocation(cmdletInfo.Name, cmdletInfo.Alias);

        public ScriptWriter StartScriptBlockParameter()
        {
            return this;
        }

        public ScriptWriter Write(object value)
        {
        }

        public ScriptWriter WriteLine() => WriteLine(null);

        public ScriptWriter WriteLine(object value)
        {
        }
    }
}