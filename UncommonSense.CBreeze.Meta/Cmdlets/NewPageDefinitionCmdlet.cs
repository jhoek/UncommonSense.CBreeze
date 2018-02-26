using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Meta.PageDefinitions;

namespace UncommonSense.CBreeze.Meta.Cmdlets
{
    public class NewPageDefinitionCmdlet<T> : Cmdlet where T : PageDefinition, new()
    {
        [Parameter(Position = 1)]
        public string Name { get; set; }

        [Parameter(Position = 2)]
        public Hashtable CaptionML { get; set; }

        protected override void EndProcessing()
        {
            WriteObject(new T() { Name = Name, CaptionML = CaptionML });
        }
    }
}
