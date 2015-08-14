using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeByteParameter")]
    public class AddCBreezeByteParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var byteParameter = Parameters.AddByteParameter(Var, ID, Name);
                byteParameter.Dimensions = Dimensions;
                yield return byteParameter;
            }
        }
    }
}
