using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeQueryOrderBy", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(QueryOrderByLine))]
    [Alias("OrderBy", "Add-CBreezeQueryOrderBy")]
    public class NewCBreezeQueryOrderBy : NewItemCmdlet<QueryOrderByLine, Query>
    {
        protected override void AddItemToInputObject(QueryOrderByLine item, Query inputObject)
        {
            inputObject.Properties.OrderBy.Add(item);
        }

        protected override IEnumerable<QueryOrderByLine> CreateItems()
        {
            yield return new QueryOrderByLine(Column, Direction);
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