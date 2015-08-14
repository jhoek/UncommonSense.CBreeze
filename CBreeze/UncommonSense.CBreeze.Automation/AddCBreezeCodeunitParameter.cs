using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeunitParameter")]
    public class AddCBreezeCodeunitParameter : AddCBreezeParameter
    {
        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var codeunitParameter = Parameters.AddCodeunitParameter(Var, ID, Name, SubType);
                codeunitParameter.Dimensions = Dimensions;
                yield return codeunitParameter;
            }
        }
    }
}
