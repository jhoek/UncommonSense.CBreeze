using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBinaryParameter")]
    public class AddCBreezeBinaryParameter : AddCBreezeParameter
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

                if ((DataLength ?? 0) == 0)
                {
                    DataLength = 100;
                }

                var binaryParameter = Parameters.AddBinaryParameter(Var, ID, Name, DataLength.Value);
                binaryParameter.Dimensions = Dimensions;
                yield return binaryParameter;
            }
        }
    }
}
