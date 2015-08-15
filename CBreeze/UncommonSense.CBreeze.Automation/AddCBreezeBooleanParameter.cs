using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBooleanParameter")]
    public class AddCBreezeBooleanParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var booleanParameter = Parameters.Add(new BooleanParameter(Var, ID, Name));
                booleanParameter.Dimensions = Dimensions;
                yield return booleanParameter;
            }
        }
    }
}
