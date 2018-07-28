using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableKey", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(TableKey))]
    [Alias("Key", "Add-CBreezeTableKey")]
    public class NewCBreezeTableKey : NewItemCmdlet<TableKey, Table>
    {
        protected override void AddItemToInputObject(TableKey item, Table inputObject)
        {
            inputObject.Keys.Add(item);
        }

        protected override IEnumerable<TableKey> CreateItems()
        {
            var tableKey = new TableKey(Fields);

            tableKey.Enabled = NullableBooleanFromSwitch(nameof(Enabled));
            tableKey.Properties.Clustered = NullableBooleanFromSwitch(nameof(Clustered));
            tableKey.Properties.KeyGroups = KeyGroups;
            tableKey.Properties.MaintainSIFTIndex = NullableBooleanFromSwitch(nameof(MaintainSIFTIndex));
            tableKey.Properties.MaintainSQLIndex = NullableBooleanFromSwitch(nameof(MaintainSQLIndex));
#if NAV2018
            tableKey.Properties.ObsoleteState = ObsoleteState;
            tableKey.Properties.ObsoleteReason = ObsoleteReason;
#endif
            tableKey.Properties.SQLIndex.AddRange(SQLIndex ?? new string[] { });
            tableKey.Properties.SumIndexFields.AddRange(SumIndexFields ?? new string[] { });

            yield return tableKey;
        }

        [Parameter()] public SwitchParameter Clustered { get; set; }
        [Parameter()] public SwitchParameter Enabled { get; set; }
        [Parameter(Mandatory = true, Position = 0)] public string[] Fields { get; set; }
        [Parameter()] public string KeyGroups { get; set; }
        [Parameter()] public SwitchParameter MaintainSIFTIndex { get; set; }
        [Parameter()] public SwitchParameter MaintainSQLIndex { get; set; }
#if NAV2018
        [Parameter()] public ObsoleteState? ObsoleteState { get; set; }
        [Parameter()] public string ObsoleteReason { get; set; }
#endif
        [Parameter()] public string[] SQLIndex { get; set; }
        [Parameter()] public string[] SumIndexFields { get; set; }
    }
}