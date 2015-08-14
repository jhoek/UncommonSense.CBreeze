using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeParameter")]
    public class AddCBreezeCodeParameter : AddCBreezeParameter
    {
        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? DataLength
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var codeParameter = Parameters.AddCodeParameter(Var, ID, Name, DataLength);
                codeParameter.Dimensions = Dimensions;
                yield return codeParameter;
            }
        }
    }
}
