using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeQuery")]
    public class AddCBreezeQuery : AddCBreezeObject
    {
        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public ReadState? ReadState
        {
            get;
            set;
        }

        [Parameter()]
        public int? TopNumberOfRows
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                var query = application.Queries.Add(new Query(GetObjectID(application), Name));

                query.ObjectProperties.DateTime = DateTime;
                query.ObjectProperties.Modified = Modified;
                query.ObjectProperties.VersionList = VersionList;

                query.Properties.Description = Description;
                query.Properties.ReadState = ReadState;
                query.Properties.TopNumberOfRows = TopNumberOfRows;

                if (AutoCaption)
                    query.AutoCaption();

                if (PassThru)
                    WriteObject(query);
            }
        }

        protected override IEnumerable<int> GetExistingObjectIDs(Application application)
        {
            return application.Queries.Select(q => q.ID);
        }
    }
}
