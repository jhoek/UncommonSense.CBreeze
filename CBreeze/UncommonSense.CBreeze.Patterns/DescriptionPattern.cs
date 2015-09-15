using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class DescriptionPattern : AddFieldsPattern
    {
        public enum DescriptionStyle
        {
            Name,
            Description
        }

        private Dictionary<Page, FieldPageControl> descriptionControls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> description2Controls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> searchDescriptionControls = new Dictionary<Page, FieldPageControl>();

        public DescriptionPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            HasDescription2 = true;
            HasSearchDescription = true;
            CardPageGroupPosition = Position.LastWithinContainer;
        }

        protected override void MakeChanges()
        {
            CreateFields();
            AddValidationCode();
            CreateControls();
        }

        protected  void CreateFields()
        {
            DescriptionField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}{1}", Prefix, Style), 50).AutoCaption());

            if (HasDescription2)
            {
                Description2Field = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}{1} 2", Prefix, Style), 50).AutoCaption());
            }

            if (HasSearchDescription)
            {
                SearchDescriptionField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Search {1}", Prefix, Style), 50).AutoCaption());
            }
        }

        protected void AddValidationCode()
        {
            if (HasSearchDescription)
            {
                SearchDescriptionField.Properties.OnValidate.CodeLines.Add("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", SearchDescriptionField.Name.Quoted(), DescriptionField.Name.Quoted());
                SearchDescriptionField.Properties.OnValidate.CodeLines.Add("  {0} := {1};", SearchDescriptionField.Name.Quoted(), DescriptionField.Name.Quoted());
            }
        }

        protected void CreateControls()
        {
            foreach (var page in Pages)
            {
                switch (page.Properties.PageType)
                {
                    case PageType.Card:
                        CreateCardPageControls(page);
                        break;
                    case PageType.List:
                        CreateListPageControls(page);
                        break;
                }
            }
        }

        protected void CreateCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption(GroupCaption, Range, CardPageGroupPosition);

            var descriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            descriptionControl.Properties.SourceExpr = DescriptionField.Name.Quoted();
            descriptionControls.Add(page, descriptionControl);

            if (HasSearchDescription)
            {
                var searchDescriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                searchDescriptionControl.Properties.SourceExpr = SearchDescriptionField.Name.Quoted();
                searchDescriptionControls.Add(page, searchDescriptionControl);
            }
        }

        protected void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, ListPageGroupPosition);

            var descriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            descriptionControl.Properties.SourceExpr = DescriptionField.Name.Quoted();
            descriptionControls.Add(page, descriptionControl);

            if (HasSearchDescription)
            {
                var searchDescriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                searchDescriptionControl.Properties.SourceExpr = SearchDescriptionField.Name.Quoted();
                searchDescriptionControls.Add(page, searchDescriptionControl);
            }
        }

        public DescriptionStyle Style
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

        public TextTableField DescriptionField
        {
            get;
            internal set;
        }

        public TextTableField Description2Field
        {
            get;
            internal set;
        }

        public CodeTableField SearchDescriptionField
        {
            get;
            internal set;
        }

        public ReadOnlyDictionary<Page, FieldPageControl> DescriptionControls
        {
            get
            {
                return descriptionControls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> Description2Controls
        {
            get
            {
                return description2Controls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> SearchDescriptionControls
        {
            get
            {
                return searchDescriptionControls.AsReadOnly();
            }
        }
    }
}
