using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDialogParameter")]
    public class AddCBreezeDialogParameter : AddCBreezeParameter
    {
        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var dialogParameter = Parameters.Add(new DialogParameter(Var, ID, Name));
                dialogParameter.Dimensions = Dimensions;
                yield return dialogParameter;
            }
        }
    }
}
