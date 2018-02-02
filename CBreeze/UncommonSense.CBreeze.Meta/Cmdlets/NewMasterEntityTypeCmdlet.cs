using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Meta.EntityTypes;
using UncommonSense.CBreeze.Meta.PageDefinitions;

namespace UncommonSense.CBreeze.Meta.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "MasterEntityType")]
    [Alias("MasterEntityType")]
    public class NewMasterEntityTypeCmdlet : NewSingleTableEntityTypeCmdlet
    {
        protected override void EndProcessing()
        {
            WriteObject(new MasterEntityType(Name)
            {
                PluralName = PluralName,
                CustomPages = Pages.ToEnumerable<PageDefinition>()
            }.Render(), true);
        }
    }
}
