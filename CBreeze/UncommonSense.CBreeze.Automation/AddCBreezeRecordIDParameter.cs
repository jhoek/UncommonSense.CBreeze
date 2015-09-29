using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeRecordIDParameter")]
    public class AddCBreezeRecordIDParameter : AddCBreezeParameter<RecordIDParameter>
    {
        protected override RecordIDParameter CreateParameter()
        {
            return Parameters.Add(new RecordIDParameter(Var, GetParameterID(), Name));
        }
    }
}
