using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePage")]
    public class NewCBreezePage : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        [Alias("Range")]
        public PSObject ID
        {
            get; set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get; set;
        }

        [Parameter()]
        public string VersionList
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter()]
        public bool? AutoSplitKey
        {
            get; set;
        }

        [Parameter()]
        public string CardPageID
        {
            get; set;
        }

        [Parameter()]
        public string DataCaptionExpr
        {
            get; set;
        }

        [Parameter()]
        public string[] DataCaptionFields
        {
            get; set;
        }

        [Parameter()]
        public bool? DelayedInsert
        {
            get; set;
        }

        [Parameter()]
        public bool? DeleteAllowed
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public bool? Editable
        {
            get; set;
        }

        [Parameter()]
        public bool? InsertAllowed
        {
            get; set;
        }

        [Parameter()]
        public bool? LinksAllowed
        {
            get; set;
        }

        [Parameter()]
        public bool? ModifyAllowed
        {
            get; set;
        }

        [Parameter()]
        public bool? MultipleNewLines
        {
            get; set;
        }

        [Parameter()]
        public PageType? PageType
        {
            get; set;
        }

        [Parameter()]
        public bool? PopulateAllFields
        {
            get; set;
        }

        [Parameter()]
        public bool? RefreshOnActivate
        {
            get; set;
        }

        [Parameter()]
        public bool? SaveValues
        {
            get; set;
        }

        [Parameter()]
        public bool? ShowFilter
        {
            get; set;
        }

        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? SourceTable
        {
            get; set;
        }

        [Parameter()]
        public bool? SourceTableTemporary
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var page = new Page(ID.GetID(null, 0), Name);

            page.ObjectProperties.DateTime = DateTime;
            page.ObjectProperties.Modified = Modified;
            page.ObjectProperties.VersionList = VersionList;

            page.Properties.AutoSplitKey = AutoSplitKey;
            page.Properties.CardPageID = CardPageID;
            page.Properties.DataCaptionExpr = DataCaptionExpr;
            page.Properties.DataCaptionFields.AddRange(DataCaptionFields ?? new string[] { });
            page.Properties.DelayedInsert = DelayedInsert;
            page.Properties.DeleteAllowed = DeleteAllowed;
            page.Properties.Description = Description;
            page.Properties.Editable = Editable;
            page.Properties.InsertAllowed = InsertAllowed;
            page.Properties.LinksAllowed = LinksAllowed;
            page.Properties.ModifyAllowed = ModifyAllowed;
            page.Properties.MultipleNewLines = MultipleNewLines;
            page.Properties.PageType = PageType;
            page.Properties.PopulateAllFields = PopulateAllFields;
            page.Properties.RefreshOnActivate = RefreshOnActivate;
            page.Properties.SaveValues = SaveValues;
            page.Properties.ShowFilter = ShowFilter;
            page.Properties.SourceTable = SourceTable;
            page.Properties.SourceTableTemporary = SourceTableTemporary;

            if (AutoCaption)
                page.AutoCaption();

            WriteObject(page);
        }
    }
}

