using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableFieldGroup", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(TableFieldGroup))]
    [Alias("FieldGroup")]
    public class NewCBreezeTableFieldGroup : NewItemWithIDAndNameCmdlet<TableFieldGroup, int, Table>
    {
        [Parameter()]
        public string Caption
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        public string[] FieldNames
        {
            get;
            set;
        }

        protected override void AddItemToInputObject(TableFieldGroup item, Table inputObject)
        {
            inputObject.FieldGroups.Add(item);
        }

        protected override IEnumerable<TableFieldGroup> CreateItems()
        {
            var tableFieldGroup = new TableFieldGroup(ID, Name);

            tableFieldGroup.Properties.CaptionML.Set("ENU", Caption);
            tableFieldGroup.Fields.AddRange(FieldNames);

            yield return tableFieldGroup;
        }
    }
}