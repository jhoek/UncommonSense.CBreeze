using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuite")]
    public class AddCBreezeMenuSuite : NewCBreezeMenuSuite
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application { get; set; }

        [Parameter()]
        public SwitchParameter PassThru { get; set; } = true;

        protected override void ProcessRecord()
        {
            Application.MenuSuites.Add(CreateMenuSuite()).DoIf(PassThru, m => WriteObject(m));
        }
    }
}