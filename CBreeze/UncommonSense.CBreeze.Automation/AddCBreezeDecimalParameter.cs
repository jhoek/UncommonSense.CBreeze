using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDecimalParameter")]
    public class AddCBreezeDecimalParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var decimalParameter = Parameters.AddDecimalParameter(Var, ID, Name);
                decimalParameter.Dimensions = Dimensions;
                yield return decimalParameter;
            }
        }
    }
}
