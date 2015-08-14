using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBigTextParameter")]
    public class AddCBreezeBigTextParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var bigTextParameter = Parameters.AddBigTextParameter(Var, ID, Name);
                bigTextParameter.Dimensions = Dimensions;
                yield return bigTextParameter;
            }
        }
    }
}
