using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePage")]
    public class AddCBreezePage : AddCBreezeObject
    {
        [Parameter()]
        public bool? AutoSplitKey
        {
            get;
            set;
        }

        [Parameter()]
        public string CardPageID
        {
            get;
            set;
        }

        [Parameter()]
        public string DataCaptionExpr
        {
            get;
            set;
        }

        [Parameter()]
        public string[] DataCaptionFields
        {
            get;
            set;
        }

        [Parameter()]
        public bool? DelayedInsert
        {
            get;
            set;
        }

        [Parameter()]
        public bool? DeleteAllowed
        {
            get;
            set;
        }

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Editable
        {
            get;
            set;
        }

        [Parameter()]
        public bool? InsertAllowed
        {
            get;
            set;
        }

        [Parameter()]
        public bool? LinksAllowed
        {
            get;
            set;
        }

        [Parameter()]
        public bool? ModifyAllowed
        {
            get;
            set;
        }

        [Parameter()]
        public bool? MultipleNewLines
        {
            get;
            set;
        }

        [Parameter()]
        public PageType PageType
        {
            get;
            set;
        }

        [Parameter()]
        public bool? PopulateAllFields
        {
            get;
            set;
        }

        [Parameter()]
        public bool? RefreshOnActivate
        {
            get;
            set;
        }

        [Parameter()]
        public bool? SaveValues
        {
            get;
            set;
        }

        [Parameter()]
        public bool? ShowFilter
        {
            get;
            set;
        }

        [Parameter()]
        public int? SourceTable
        {
            get;
            set;
        }

        [Parameter()]
        public bool? SourceTableTemporary
        {
            get;
            set;
        }

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                var page = Application.Pages.Add(new Page(GetID(), Name));

                page.ObjectProperties.DateTime = DateTime;
                page.ObjectProperties.Modified = Modified;
                page.ObjectProperties.VersionList = VersionList;

                page.Properties.AutoSplitKey = AutoSplitKey;
                page.Properties.CardPageID = CardPageID;
                page.Properties.DataCaptionExpr = DataCaptionExpr;
                page.Properties.DataCaptionFields.AddRange(DataCaptionFields);
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

                yield return page;
            }
        }

        protected override IEnumerable<int> GetExistingIDs()
        {
            return Application.Pages.Select(p => p.ID);
        }
    }
}
