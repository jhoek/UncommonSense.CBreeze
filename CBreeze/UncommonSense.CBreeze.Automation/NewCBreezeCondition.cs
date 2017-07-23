using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeCondition", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("Condition")]
    public class NewCBreezeCondition : NewItemCmdlet<TableRelationCondition, TableRelationLine>
    {
        protected override void AddItemToInputObject(TableRelationCondition item, TableRelationLine inputObject)
        {
            inputObject.Conditions.Add(item);
        }

        protected override IEnumerable<TableRelationCondition> CreateItems()
        {
            yield return new TableRelationCondition(FieldName, Type, Value);
        }

        [Parameter(Mandatory = true, Position = 0)]
        public string FieldName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public SimpleTableFilterType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
        public string Value
        {
            get;
            set;
        }
    }
}