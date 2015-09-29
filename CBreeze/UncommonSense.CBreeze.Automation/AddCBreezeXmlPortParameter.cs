using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortParameter")]
    public class AddCBreezeXmlPortParameter : AddCBreezeParameter<XmlPortParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        protected override XmlPortParameter CreateParameter()
        {
            return Parameters.Add(new XmlPortParameter(Var, GetParameterID(), Name, SubType));
        }
    }
}
