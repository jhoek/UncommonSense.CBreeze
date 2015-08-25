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
    public  class AddCBreezeQuery : AddCBreezeObject
    {
        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public ReadState ReadState
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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var query = Application.Queries.Add(new Query(ID, Name));

                query.ObjectProperties.DateTime = DateTime;
                query.ObjectProperties.Modified = Modified;
                query.ObjectProperties.VersionList = VersionList;

                query.Properties.Description = Description;
                query.Properties.ReadState = ReadState;
                query.Properties.TopNumberOfRows = TopNumberOfRows;

                if (AutoCaption)
                    query.AutoCaption();

                yield return query;
            }
        }
    }
}
