using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeQueryLink", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("QueryLink", "Add-CBreezeQueryLink")]
    [OutputType(typeof(QueryDataItemLinkLine))]
    public class NewCBreezeQueryLink : NewItemCmdlet<QueryDataItemLinkLine, DataItemQueryElement>
    {
        protected override void AddItemToInputObject(QueryDataItemLinkLine item, DataItemQueryElement inputObject)
        {
            inputObject.Properties.DataItemLink.Add(item);
        }

        protected override IEnumerable<QueryDataItemLinkLine> CreateItems()
        {
            yield return new QueryDataItemLinkLine(FieldName, ReferenceTableName, ReferenceFieldName);
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string FieldName { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        public string ReferenceFieldName { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string ReferenceTableName { get; set; }
    }
}