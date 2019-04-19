using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTable", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Table))]
    [Alias("Table", "Add-CBreezeTable")]
    public class NewCBreezeTable : NewCBreezeObject<Table>
    {
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string[] DataCaptionFields { get; set; }
#if NAV2018
        [Parameter()] public DataClassification? DataClassification { get; set; }
#endif
        [Parameter()] public SwitchParameter DataPerCompany { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? DrillDownPageID { get; set; }
#if NAV2016
        [Parameter()] public string ExternalName { get; set; }
        [Parameter()] public string ExternalSchema { get; set; }
#endif
        [Parameter()] public SwitchParameter LinkedInTransaction { get; set; }
        [Parameter()] public SwitchParameter LinkedObject { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? LookupPageID { get; set; }
#if NAV2018
        [Parameter()] public String ObsoleteReason { get; set; }
        [Parameter()] public ObsoleteState? ObsoleteState { get; set; }
#endif
        [Parameter()] public ScriptBlock OnDelete { get; set; }
        [Parameter()] public ScriptBlock OnInsert { get; set; }
        [Parameter()] public ScriptBlock OnModify { get; set; }
        [Parameter()] public ScriptBlock OnRename { get; set; }
        [Parameter()] public SwitchParameter PasteIsValid { get; set; }
        [Parameter()] public Permission[] Permissions { get; set; }
#if NAVBC
        [Parameter()] public SwitchParameter ReplicateData { get; set; }
#endif
#if NAV2016
        [Parameter()] public TableType? TableType { get; set; }
#endif

        protected override void AddItemToInputObject(Table item, Application inputObject)
        {
            inputObject.Tables.Add(item);
        }

        protected override IEnumerable<Table> CreateItems()
        {
            var table = new Table(ID, Name);
            SetObjectProperties(table);

            table.Properties.CaptionML.Set(CaptionML);
            table.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
#if NAV2018
            table.Properties.DataClassification = DataClassification;
#endif
            table.Properties.DataPerCompany = NullableBooleanFromSwitch(nameof(DataPerCompany));
            table.Properties.Description = Description;
            table.Properties.DrillDownPageID = DrillDownPageID;
#if NAV2016
            table.Properties.ExternalName = ExternalName;
            table.Properties.ExternalSchema = ExternalSchema;
#endif
            table.Properties.LinkedInTransaction = NullableBooleanFromSwitch(nameof(LinkedInTransaction));
            table.Properties.LinkedObject = NullableBooleanFromSwitch(nameof(LinkedObject));
            table.Properties.LookupPageID = LookupPageID;
#if NAV2018
            table.Properties.ObsoleteState = ObsoleteState;
            table.Properties.ObsoleteReason = ObsoleteReason;
#endif
            table.Properties.OnInsert.Set(OnInsert);
            table.Properties.OnModify.Set(OnModify);
            table.Properties.OnDelete.Set(OnDelete);
            table.Properties.OnRename.Set(OnRename);
            table.Properties.PasteIsValid = NullableBooleanFromSwitch(nameof(PasteIsValid));
            table.Properties.Permissions.Set(Permissions);
#if NAVBC
            table.Properties.ReplicateData = NullableBooleanFromSwitch(nameof(ReplicateData));
#endif
#if NAV2016
            table.Properties.TableType = TableType;
#endif

            if (AutoCaption)
                table.AutoCaption();

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                table.Code.Documentation.CodeLines.AddRange(subObjects.OfType<string>());
                table.Fields.AddRange(subObjects.OfType<TableField>());
                table.FieldGroups.AddRange(subObjects.OfType<TableFieldGroup>());
                table.Keys.AddRange(subObjects.OfType<TableKey>());
                table.Code.Functions.AddRange(subObjects.OfType<Function>());
                table.Code.Variables.AddRange(subObjects.OfType<Variable>());
                table.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            yield return table;
        }
    }
}