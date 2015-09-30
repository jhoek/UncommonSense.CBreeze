﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeActionParameter")]
    public class AddCBreezeActionParameter : AddCBreezeParameter<ActionParameter>
    {
        protected override ActionParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new ActionParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
