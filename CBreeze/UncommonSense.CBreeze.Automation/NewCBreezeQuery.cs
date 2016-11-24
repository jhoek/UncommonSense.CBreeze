using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeQuery")]
    public class NewCBreezeQuery : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        [Alias("Range")]
        public PSObject ID
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 2)]
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

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public ReadState? ReadState
        {
            get; set;
        }

        [Parameter()]
        [ValidateRange(0, int.MaxValue)]
        public int? TopNoOfRows
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var query = new Query(ID.GetID(null, 0), Name);

            query.ObjectProperties.DateTime = DateTime;
            query.ObjectProperties.Modified = Modified;
            query.ObjectProperties.VersionList = VersionList;

            query.Properties.Description = Description;
            query.Properties.ReadState = ReadState;
            query.Properties.TopNumberOfRows = TopNoOfRows;

            if (AutoCaption)
                query.AutoCaption();

            WriteObject(query);
        }
    }
}