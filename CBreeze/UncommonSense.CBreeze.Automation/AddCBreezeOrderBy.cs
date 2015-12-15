using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeOrderBy")]
    public class AddCBreezeOrderBy : Cmdlet
    {
        [Parameter(Mandatory=true, ValueFromPipeline=true)]
        public Query InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string Column
        {
            get;
            set;
        }

        [Parameter(Position = 1)]
        public QueryOrderByDirection Direction
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            InputObject.Properties.OrderBy.Add(new QueryOrderByLine(Column, Direction));
        }
    }
}
