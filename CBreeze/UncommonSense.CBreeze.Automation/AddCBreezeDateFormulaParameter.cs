using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

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

                var dateFormulaParameter = Parameters.Add(new DateFormulaParameter(Var, ID, Name));
                dateFormulaParameter.Dimensions = Dimensions;
                yield return dateFormulaParameter;
            }
        }
    }
}
