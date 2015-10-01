using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeObject")]
    public class AddCBreezeObject : CmdletWithDynamicParams
    {
        public AddCBreezeObject()
        {
            AutoSplitKey = new DynamicParameter<bool?>("AutoSplitKey", false);
            CardPageID = new DynamicParameter<string>("CardPageID", false);
            CFrontMayUsePermissions = new DynamicParameter<bool?>("CFrontMayUsePermissions", false);
            DataCaptionExpr = new DynamicParameter<string>("DataCaptionExpr", false);
            DataCaptionFields = new DynamicParameter<string[]>("DataCaptionFields", false);
            DataPerCompany = new DynamicParameter<bool?>("DataPerCompany", false);
            DelayedInsert = new DynamicParameter<bool?>("DelayedInsert", false);
            DeleteAllowed = new DynamicParameter<bool?>("DeleteAllowed", false);
            Description = new DynamicParameter<string>("Description", false);
            DrillDownPageID = new DynamicParameter<int?>("DrillDownPageID", false, 1, int.MaxValue);
            Editable = new DynamicParameter<bool?>("Editable", false);
            InsertAllowed = new DynamicParameter<bool?>("InsertAllowed", false);
            LinkedInTransaction = new DynamicParameter<bool?>("LinkedInTransaction", false);
            LinkedObject = new DynamicParameter<bool?>("LinkedObject", false);
            LinksAllowed = new DynamicParameter<bool?>("LinksAllowed", false);
            LookupPageID = new DynamicParameter<int?>("LookupPageID", false, 1, int.MaxValue);
            ModifyAllowed = new DynamicParameter<bool?>("ModifyAllowed", false);
            MultipleNewLines = new DynamicParameter<bool?>("MultipleNewLines", false);
            PageType = new DynamicParameter<Core.PageType?>("PageType", false);
            PasteIsValid = new DynamicParameter<bool?>("PasteIsValid", false);
            PopulateAllFields = new DynamicParameter<bool?>("PopulateAllFields", false);
            RefreshOnActivate = new DynamicParameter<bool?>("RefreshOnActivate", false);
            SaveValues = new DynamicParameter<bool?>("SaveValues", false);
            ShowFilter = new DynamicParameter<bool?>("ShowFilter", false);
            SingleInstance = new DynamicParameter<bool?>("SingleInstance", false);
            SourceTable = new DynamicParameter<int?>("SourceTable", false, 1, int.MaxValue);
            SourceTableTemporary = new DynamicParameter<bool?>("SourceTableTemporary", false);
            SubType = new DynamicParameter<CodeunitSubType?>("SubType", false);
            TableNo = new DynamicParameter<int?>("TableNo", false, 1, int.MaxValue);
            TestIsolation = new DynamicParameter<TestIsolation?>("TestIsolation", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application[] Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public ObjectType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Range")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter()]
        public string VersionList
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> AutoSplitKey
        {
            get;
            set;
        }

        protected DynamicParameter<string> CardPageID
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> CFrontMayUsePermissions
        {
            get;
            set;
        }

        protected DynamicParameter<string> DataCaptionExpr
        {
            get;
            set;
        }

        protected DynamicParameter<string[]> DataCaptionFields
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DataPerCompany
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DelayedInsert
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DeleteAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<string> Description
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DrillDownPageID
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Editable
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> InsertAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> LinkedInTransaction
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> LinkedObject
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> LinksAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<int?> LookupPageID
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ModifyAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> MultipleNewLines
        {
            get;
            set;
        }

        protected DynamicParameter<PageType?> PageType
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> PasteIsValid
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> PopulateAllFields
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> RefreshOnActivate
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> SaveValues
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ShowFilter
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> SingleInstance
        {
            get;
            set;
        }

        protected DynamicParameter<int?> SourceTable
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> SourceTableTemporary
        {
            get;
            set;
        }

        protected DynamicParameter<CodeunitSubType?> SubType
        {
            get;
            set;
        }

        protected DynamicParameter<int?> TableNo
        {
            get;
            set;
        }

        protected DynamicParameter<TestIsolation?> TestIsolation
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var application in Application)
            {
                switch (Type)
                {
                    case ObjectType.Table:
                        var table = application.Tables.Add(new Table(GetObjectID(application), Name));

                        table.ObjectProperties.DateTime = DateTime;
                        table.ObjectProperties.Modified = Modified;
                        table.ObjectProperties.VersionList = VersionList;

                        table.Properties.DataCaptionFields.AddRange(DataCaptionFields.Value ?? new string[] { });
                        table.Properties.DataPerCompany = DataPerCompany.Value;
                        table.Properties.Description = Description.Value;
                        table.Properties.DrillDownPageID = DrillDownPageID.Value;
                        table.Properties.LinkedInTransaction = LinkedInTransaction.Value;
                        table.Properties.LinkedObject = LinkedObject.Value;
                        table.Properties.LookupPageID = LookupPageID.Value;
                        table.Properties.PasteIsValid = PasteIsValid.Value;

                        if (AutoCaption)
                            table.AutoCaption();

                        if (PassThru)
                            WriteObject(table);

                        break;

                    case ObjectType.Page:
                        var page = application.Pages.Add(new Page(GetObjectID(application), Name));

                        page.ObjectProperties.DateTime = DateTime;
                        page.ObjectProperties.Modified = Modified;
                        page.ObjectProperties.VersionList = VersionList;

                        page.Properties.AutoSplitKey = AutoSplitKey.Value;
                        page.Properties.CardPageID = CardPageID.Value;
                        page.Properties.DataCaptionExpr = DataCaptionExpr.Value;
                        page.Properties.DataCaptionFields.AddRange(DataCaptionFields.Value ?? new string[] { });
                        page.Properties.DelayedInsert = DelayedInsert.Value;
                        page.Properties.DeleteAllowed = DeleteAllowed.Value;
                        page.Properties.Description = Description.Value;
                        page.Properties.Editable = Editable.Value;
                        page.Properties.InsertAllowed = InsertAllowed.Value;
                        page.Properties.LinksAllowed = LinksAllowed.Value;
                        page.Properties.ModifyAllowed = ModifyAllowed.Value;
                        page.Properties.MultipleNewLines = MultipleNewLines.Value;
                        page.Properties.PageType = PageType.Value;
                        page.Properties.PopulateAllFields = PopulateAllFields.Value;
                        page.Properties.RefreshOnActivate = RefreshOnActivate.Value;
                        page.Properties.SaveValues = SaveValues.Value;
                        page.Properties.ShowFilter = ShowFilter.Value;
                        page.Properties.SourceTable = SourceTable.Value;
                        page.Properties.SourceTableTemporary = SourceTableTemporary.Value;

                        if (AutoCaption)
                            page.AutoCaption();

                        if (PassThru)
                            WriteObject(page);

                        break;

                    case ObjectType.Codeunit:
                        var codeunit = application.Codeunits.Add(new Codeunit(GetObjectID(application), Name));

                        codeunit.ObjectProperties.DateTime = DateTime;
                        codeunit.ObjectProperties.Modified = Modified;
                        codeunit.ObjectProperties.VersionList = VersionList;

                        codeunit.Properties.CFRONTMayUsePermissions = CFrontMayUsePermissions.Value;
                        codeunit.Properties.SingleInstance = SingleInstance.Value;
                        codeunit.Properties.Subtype = SubType.Value;
                        codeunit.Properties.TableNo = TableNo.Value;
                        codeunit.Properties.TestIsolation = TestIsolation.Value;

                        if (PassThru)
                            WriteObject(codeunit);

                        break;
                }
            }
        }

        protected int GetObjectID(Application application)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetExistingObjectIDs(application)).First();
        }

        protected IEnumerable<int> GetExistingObjectIDs(Application application)
        {
            switch (Type)
            {
                case ObjectType.Table:
                    return application.Tables.Select(t => t.ID);
                case ObjectType.Page:
                    return application.Pages.Select(p => p.ID);
                case ObjectType.Codeunit:
                    return application.Codeunits.Select(c => c.ID);
                default:
                    throw new ArgumentOutOfRangeException("FIXME");
            }
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case ObjectType.Table:
                        yield return DataCaptionFields.RuntimeDefinedParameter;
                        yield return DataPerCompany.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return DrillDownPageID.RuntimeDefinedParameter;
                        yield return LinkedInTransaction.RuntimeDefinedParameter;
                        yield return LinkedObject.RuntimeDefinedParameter;
                        yield return LookupPageID.RuntimeDefinedParameter;
                        yield return PasteIsValid.RuntimeDefinedParameter;

                        break;

                    case ObjectType.Page:
                        yield return AutoSplitKey.RuntimeDefinedParameter;
                        yield return CardPageID.RuntimeDefinedParameter;
                        yield return DataCaptionExpr.RuntimeDefinedParameter;
                        yield return DataCaptionFields.RuntimeDefinedParameter;
                        yield return DelayedInsert.RuntimeDefinedParameter;
                        yield return DeleteAllowed.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return InsertAllowed.RuntimeDefinedParameter;
                        yield return LinksAllowed.RuntimeDefinedParameter;
                        yield return ModifyAllowed.RuntimeDefinedParameter;
                        yield return MultipleNewLines.RuntimeDefinedParameter;
                        yield return PageType.RuntimeDefinedParameter;
                        yield return PopulateAllFields.RuntimeDefinedParameter;
                        yield return RefreshOnActivate.RuntimeDefinedParameter;
                        yield return SaveValues.RuntimeDefinedParameter;
                        yield return ShowFilter.RuntimeDefinedParameter;
                        yield return SourceTable.RuntimeDefinedParameter;
                        yield return SourceTableTemporary.RuntimeDefinedParameter;

                        break;

                    case ObjectType.Codeunit:
                        yield return CFrontMayUsePermissions.RuntimeDefinedParameter;
                        yield return SingleInstance.RuntimeDefinedParameter;
                        yield return SubType.RuntimeDefinedParameter;
                        yield return TableNo.RuntimeDefinedParameter;
                        yield return TestIsolation.RuntimeDefinedParameter;

                        break;
                }
            }
        }
    }
}
