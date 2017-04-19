using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuite", DefaultParameterSetName = "ManualObjectProperties")]
    public class AddCBreezeMenuSuite : NewCBreezeMenuSuite
    {
        public AddCBreezeMenuSuite()
        {
            PassThru = true;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var menusuite = CreateMenuSuite();
            Application.MenuSuites.Add(menusuite);

            if (PassThru)
            {
                WriteObject(menusuite);
            }
        }
    }
}
