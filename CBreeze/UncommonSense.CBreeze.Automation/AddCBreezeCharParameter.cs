using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCharParameter")]
    public class AddCBreezeCharParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var charParameter = Parameters.AddCharParameter(Var, ID, Name);
                charParameter.Dimensions = Dimensions;
                yield return charParameter;
            }
        }
    }
}
