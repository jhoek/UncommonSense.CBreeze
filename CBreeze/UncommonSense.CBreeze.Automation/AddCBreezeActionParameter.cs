using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeActionParameter")]
    public class AddCBreezeActionParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var actionParameter = Parameters.AddActionParameter(Var, ID, Name);
                actionParameter.Dimensions = Dimensions;
                yield return actionParameter;
            }
        }
    }
}
