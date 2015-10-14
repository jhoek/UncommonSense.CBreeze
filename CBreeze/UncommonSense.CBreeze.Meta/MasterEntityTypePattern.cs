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
        public MasterEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range,name)
        {
            LastDateModifiedControls = new MappedResults<Page, FieldPageControl>();
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            CardPage = Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} Card", Name)).AutoCaption());
            ListPage = Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} List", Name)).AutoCaption());
            StatisticsPage = HasStatisticsPage ? Application.Pages.Add(new Page(Range.GetNextPageID(Application), string.Format("{0} Statistics", Name)).AutoCaption()) : null;
        }

        protected override void AfterCreateObjects()
        {
            Table.Properties.LookupPageID = ListPage.ID;
            Table.Properties.DrillDownPageID = ListPage.ID;

            CardPage.Properties.PageType = PageType.Card;
            CardPage.Properties.SourceTable = Table.ID;
            CardPage.Properties.RefreshOnActivate = true;

            ListPage.Properties.PageType = PageType.List;
            ListPage.Properties.SourceTable = Table.ID;
            ListPage.Properties.CardPageID = CardPage.Name;
            ListPage.Properties.Editable = false;

            if (HasStatisticsPage)
            {
                StatisticsPage.Properties.PageType = PageType.Card;
                StatisticsPage.Properties.SourceTable = Table.ID;
            }
        }

        protected override void CreateFields()
        {
            CreatePrimaryKeyField();
            CreateDescriptionFields();
            CreateLastDateModifiedField();

            Table.Properties.DataCaptionFields.AddRange(NoField.Name, DescriptionField.Name);
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

        protected void CreateLastDateModifiedField()
        {
            //if (HasLastDateModified)
            //{
            //    var lastDateModifiedPattern = new LastDateModifiedPattern(Range, Table, CardPage, ListPage);
            //    lastDateModifiedPattern.Apply();

            //    LastDateModifiedField = lastDateModifiedPattern.LastDateModifiedField;
            //    LastDateModifiedControls.AddRange(lastDateModifiedPattern.LastDateModifiedControls);
            //}
        }

        protected override void CreateDropDownFieldGroup()
        {
            var fieldGroup = Table.FieldGroups.Add(new TableFieldGroup(1, "DropDown"));
            fieldGroup.Fields.AddRange(NoField.Name, DescriptionField.Name);
        }

        protected override void CreateControls()
        {
            var factBoxArea = CardPage.GetFactboxArea(Range);
            factBoxArea.AddSystemPartPageControl(Range.GetNextPageControlID(CardPage), Position.LastWithinContainer, SystemPartID.RecordLinks).Hide();
            factBoxArea.AddSystemPartPageControl(Range.GetNextPageControlID(CardPage), Position.LastWithinContainer, SystemPartID.Notes).Hide();            
        }

        protected override void CreateActions()
        {
            AddActionsToPage(CardPage);
            AddActionsToPage(ListPage);
        }

        protected void AddActionsToPage(Page page)
        {
            var relatedInfo = page.GetRelatedInformation(Range);
            var routingChoices = relatedInfo.GetGroupByCaption(page, Name, Range, Position.FirstWithinContainer);

            if (HasStatisticsPage)
            {
                StatisticsAction = routingChoices.AddPageAction(Range.GetNextPageControlID(page), Position.LastWithinContainer, "Statistics", RunTime.Images.Statistics).Promote(false, PromotedCategory.Process);
                StatisticsAction.Properties.ShortCutKey = "F7";
                StatisticsAction.Properties.RunObject.Type = RunObjectType.Page;
                StatisticsAction.Properties.RunObject.ID = StatisticsPage.ID;
                StatisticsAction.Properties.RunPageLink.Add(NoField.Name, TableFilterType.Field, NoField.Name);
                // FIXME: RunPageLink: ook alle flowfilters
            }
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

        public MappedResults<Page, FieldPageControl> LastDateModifiedControls
        {
            get;protected set;
        }

        public PageAction StatisticsAction
        {
            get;
            protected set;
        }
    }
}
