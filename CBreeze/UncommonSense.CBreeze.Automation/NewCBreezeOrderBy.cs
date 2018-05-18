using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeOrderBy")]
    [OutputType(typeof(QueryOrderByLine))]
    [Alias("OrderBy")]
    public class NewCBreezeOrderBy : Cmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new QueryOrderByLine(Column, Direction));
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
    }
}