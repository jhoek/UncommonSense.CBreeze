using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Meta.PageDefinitions;

namespace UncommonSense.CBreeze.Meta.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "CardPageDefinition")]
    [Alias(new string[] {"CardPage"})]
    [OutputType(new Type[] {typeof(CardPageDefinition)})]
    public class NewCardPageDefinitionCmdlet : NewPageDefinitionCmdlet<CardPageDefinition>
    {
        protected override void EndProcessing()
        {
            
        }
    }
}
