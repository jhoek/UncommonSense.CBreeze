using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(Table))]
    public class AddCBreezeTable : NewCBreezeObject<Table>
    {
        [Parameter()]
        public string[] DataCaptionFields
        {
            get; set;
        }

        [Parameter()]
        public bool? DataPerCompany
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? DrillDownPageID
        {
            get; set;
        }

#if NAV2016

        [Parameter()]
        public string ExternalName
        {
            get; set;
        }

        [Parameter()]
        public string ExternalSchema
        {
            get; set;
        }

#endif

        [Parameter()]
        public bool? LinkedInTransaction
        {
            get; set;
        }

        [Parameter()]
        public bool? LinkedObject
        {
            get; set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? LookupPageID
        {
            get; set;
        }

        [Parameter()]
        public bool? PasteIsValid
        {
            get;
            set;
        }

#if NAV2016

        [Parameter()]
        public TableType? TableType
        {
            get; set;
        }

#endif

        protected override Table CreateItem()
        {
            var table = new Table(ID, Name);
            SetObjectProperties(table);

            table.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
            table.Properties.DataPerCompany = DataPerCompany;
            table.Properties.Description = Description;
            table.Properties.DrillDownPageID = DrillDownPageID;
#if NAV2016
            table.Properties.ExternalName = ExternalName;
            table.Properties.ExternalSchema = ExternalSchema;
#endif
            table.Properties.LinkedInTransaction = LinkedInTransaction;
            table.Properties.LinkedObject = LinkedObject;
            table.Properties.LookupPageID = LookupPageID;
            table.Properties.PasteIsValid = PasteIsValid;
#if NAV2016
            table.Properties.TableType = TableType;
#endif

            if (AutoCaption)
                table.AutoCaption();

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                table.Fields.AddRange(subObjects.OfType<TableField>());
                table.FieldGroups.AddRange(subObjects.OfType<TableFieldGroup>());
                table.Keys.AddRange(subObjects.OfType<TableKey>());
                table.Code.Functions.AddRange(subObjects.OfType<Function>());
                table.Code.Variables.AddRange(subObjects.OfType<Variable>());
                table.Code.Events.AddRange(subObjects.OfType<Event>());
            }

            return table;
        }

        protected override void AddItemToInputObject(Table item, Application inputObject)
        {
            inputObject.Tables.Add(item);
        }
    }
}