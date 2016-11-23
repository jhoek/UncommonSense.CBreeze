using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeMenuSuite")]
    public class NewCBreezeMenuSuite : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Range")]
        public PSObject ID
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get; set;
        }

        [Parameter()]
        public string VersionList
        {
            get; set;
        }

        protected override void ProcessRecord()
        {

            var menusuite = new MenuSuite(ID.GetID(null, 0), Name);

            menusuite.ObjectProperties.DateTime = DateTime;
            menusuite.ObjectProperties.Modified = Modified;
            menusuite.ObjectProperties.VersionList = VersionList;

            WriteObject(menusuite);

        }
    }
}
