using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDateFormulaParameter")]
    public class AddCBreezeDateFormulaParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var dateFormulaParameter = Parameters.AddDateFormulaParameter(Var, ID, Name);
                dateFormulaParameter.Dimensions = Dimensions;
                yield return dateFormulaParameter;
            }
        }
    }
}
