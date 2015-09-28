using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeByteParameter")]
    public class AddCBreezeByteParameter : AddCBreezeParameter
    {
        //protected override System.Collections.IEnumerable AddedObjects
        //{
        //    get
        //    {
        //        ID = AutoAssignID(ID);

        //        var byteParameter = Parameters.Add(new ByteParameter(Var, ID, Name));
        //        byteParameter.Dimensions = Dimensions;
        //        yield return byteParameter;
        //    }
        //}
    }
}
