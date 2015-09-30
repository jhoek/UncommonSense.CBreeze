using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTransactionTypeParameter")]
    public class AddCBreezeTransactionTypeParameter : AddCBreezeParameter<TransactionTypeParameter>
    {
        protected override TransactionTypeParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new TransactionTypeParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
