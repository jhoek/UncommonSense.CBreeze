using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class MasterEntityTypePattern : EntityTypePattern
    {
        private Dictionary<Page, FieldPageControl> lastDateModifiedControls = new Dictionary<Page, FieldPageControl>();

        public MasterEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range)
        {
            Name = name;
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();

            if (string.IsNullOrEmpty(Name))
                throw new ArgumentOutOfRangeException("Name");

            // FIXME
        }

        protected override void MakeChanges()
        {
            CreateObjects();
            LinkObjects();

            CreatePrimaryKeyField();
            CreateDescriptionFields();
            CreateDropDownFieldGroup();
            CreateLastDateModifiedField();

            AddActionsToPages();

            FinalizeCardPage();
            FinalizeListPage();

            SetDataCaptionFields();
        }

        protected void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            CardPage = Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} Card", Name)).AutoCaption());
            ListPage = Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} List", Name)).AutoCaption());
            StatisticsPage = HasStatisticsPage ? Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} Statistics", Name)).AutoCaption()) : null;
        }

        protected void LinkObjects()
        {
            Table.Properties.LookupPageID = ListPage.ID;
            Table.Properties.DrillDownPageID = ListPage.ID;

            CardPage.Properties.SourceTable = Table.ID;
            
            ListPage.Properties.SourceTable = Table.ID;
            ListPage.Properties.CardPageID = CardPage.Name;

            if (HasStatisticsPage)
            {
                StatisticsPage.Properties.SourceTable = Table.ID;
            }
        }

        protected void CreatePrimaryKeyField()
        {
            var noSeriesPattern = new NoSeriesPattern(Range, Table, CardPage, ListPage);
            noSeriesPattern.SetupTable = SetupTable;
            noSeriesPattern.SetupPage = SetupPage;
            noSeriesPattern.Apply();

            NoField = noSeriesPattern.NoField;
            NoSeriesField = noSeriesPattern.NoSeriesField;
        }

        protected void CreateDescriptionFields()
        {
            var descriptionPattern = new DescriptionPattern(Range, Table, CardPage, ListPage);
            descriptionPattern.Style = DescriptionStyle;
            descriptionPattern.HasDescription2 = HasDescription2;
            descriptionPattern.HasSearchDescription = HasSearchDescription;
            descriptionPattern.Apply();

            DescriptionField = descriptionPattern.DescriptionField;
            Description2Field = descriptionPattern.Description2Field;
            SearchDescriptionField = descriptionPattern.SearchDescriptionField;
        }

        protected void CreateDropDownFieldGroup()
        {
            var fieldGroup = Table.FieldGroups.Add(new TableFieldGroup(1, "DropDown"));
            fieldGroup.Fields.AddRange(NoField.Name, DescriptionField.Name);
        }

        protected void CreateLastDateModifiedField()
        {
            if (HasLastDateModified)
            {
                var lastDateModifiedPattern = new LastDateModifiedPattern(Range, Table, CardPage, ListPage);
                lastDateModifiedPattern.Apply();

                LastDateModifiedField = lastDateModifiedPattern.LastDateModifiedField;
                lastDateModifiedControls.FromReadOnly(lastDateModifiedPattern.LastDateModifiedControls);
            }
        }

        protected void AddActionsToPages()
        {
            AddActionsToPage(CardPage);
            AddActionsToPage(ListPage);
        }

        protected void AddActionsToPage(Page page)
        {
            var relatedInfo = page.GetRelatedInformation(Range);
            // var group = relatedInfo.
        }

        protected void FinalizeCardPage()
        {
            CardPage.Properties.RefreshOnActivate = true;

            var factBoxArea = CardPage.GetFactboxArea(Range);

            RecordLinksControl = factBoxArea.AddSystemPartPageControl(Range.GetNextPageControlID(CardPage), Position.LastWithinContainer, SystemPartID.RecordLinks);
            RecordLinksControl.Properties.Visible = false.ToString();

            NotesControl = factBoxArea.AddSystemPartPageControl(Range.GetNextPageControlID(CardPage), Position.LastWithinContainer, SystemPartID.Notes);
            NotesControl.Properties.Visible = false.ToString();
        }

        protected void FinalizeListPage()
        {
            ListPage.Properties.Editable = false;

        }

        protected void SetDataCaptionFields()
        {
            Table.Properties.DataCaptionFields.AddRange(NoField.Name, DescriptionField.Name);
        }

        public string Name
        {
            get;
            set;
        }

        public Table SetupTable
        {
            get;
            set;
        }

        public Page SetupPage
        {
            get;
            set;
        }

        public DescriptionStyle DescriptionStyle
        {
            get;
            set;
        }

        public bool HasDescription2
        {
            get;
            set;
        }

        public bool HasSearchDescription
        {
            get;
            set;
        }

        public bool HasLastDateModified
        {
            get;
            set;
        }

        public bool HasStatisticsPage
        {
            get;
            set;
        }

        public Table Table
        {
            get;
            protected set;
        }

        public Page CardPage
        {
            get;
            protected set;
        }

        public Page ListPage
        {
            get;
            protected set;
        }

        public Page StatisticsPage
        {
            get;
            protected set;
        }

        public CodeTableField NoField
        {
            get;
            protected set;
        }

        public CodeTableField NoSeriesField
        {
            get;
            protected set;
        }

        public TextTableField DescriptionField
        {
            get;
            protected set;
        }

        public TextTableField Description2Field
        {
            get;
            protected set;
        }

        public CodeTableField SearchDescriptionField
        {
            get;
            protected set;
        }

        public DateTableField LastDateModifiedField
        {
            get;
            protected set;
        }

        public ReadOnlyDictionary<Page, FieldPageControl> LastDateModifiedControls
        {
            get
            {
                return lastDateModifiedControls.AsReadOnly();
            }
        }

        public PartPageControl RecordLinksControl
        {
            get;
            protected set;
        }

        public PartPageControl NotesControl
        {
            get;
            protected set;
        }
    }
}
