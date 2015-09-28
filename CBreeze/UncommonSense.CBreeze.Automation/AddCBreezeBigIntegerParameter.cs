using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerParameter")]
    public class AddCBreezeBigIntegerParameter : AddCBreezeParameter
    {
        //protected override System.Collections.IEnumerable AddedObjects
        //{
        //    get
        //    {
        //        var bigIntegerParameter = Parameters.Add(new BigIntegerParameter(Var, ID, Name));
        //        bigIntegerParameter.Dimensions = Dimensions;
        //        yield return bigIntegerParameter;
        //    }
        //}
    }
}
