using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class Convert
    {
        public static ScriptWriter ToScript(this Application application, ScriptWriter writer)
        {
            writer.StartInvocation(Cmdlets.NewCBreezeApplication);
            writer.StartScriptBlockParameter();

            application.Tables.ForEach(t => t.ToScript(writer));

            //writer.EndScriptBLockParam();
            writer.EndInvocation();

            return writer;
        }

        public static ScriptWriter ToScript(this Table table, ScriptWriter writer)
        {
            writer.StartInvocation(Cmdlets.NewCBreezeTable);

            return writer;
        }
    }
}