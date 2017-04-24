using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewCBreezePageActionBase : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public int ID
        {
            get;
            set;
        }

        protected virtual int GetIndentation() => (int)GetVariableValue("Indentation", 0);
        protected virtual int GetID() => ID;
    }
}
