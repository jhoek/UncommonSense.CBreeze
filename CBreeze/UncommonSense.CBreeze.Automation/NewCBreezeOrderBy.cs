using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeOrderBy")]
    [OutputType(typeof(QueryOrderByLine))]
    public class NewCBreezeOrderBy : Cmdlet
    {
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
            WriteObject(new QueryOrderByLine(Column, Direction));
        }
    }
}
