using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableRelationFilter", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("TableRelationFilter", "Add-CBreezeTableRelationFilter")]
    [OutputType(typeof(TableRelationTableFilterLine))]
    public class NewCBreezeTableRelationFilter : NewItemCmdlet<TableRelationTableFilterLine, TableRelationLine>
    {
        protected override void AddItemToInputObject(TableRelationTableFilterLine item, TableRelationLine inputObject)
        {
            inputObject.TableFilter.Add(item);
        }

        protected override IEnumerable<TableRelationTableFilterLine> CreateItems()
        {
            yield return new TableRelationTableFilterLine(FieldName, Type, Value);
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string FieldName { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public TableFilterType Type { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        [AllowEmptyString()]
        public string Value { get; set; }
    }
}