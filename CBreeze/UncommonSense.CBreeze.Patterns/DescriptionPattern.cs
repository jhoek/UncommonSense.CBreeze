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
        public DescriptionPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            DescriptionControls = new MappedResults<Page, FieldPageControl>();
            Description2Controls = new MappedResults<Page, FieldPageControl>();
            SearchDescriptionControls = new MappedResults<Page, FieldPageControl>();

            HasDescription2 = true;
            HasSearchDescription = true;
            CreateKeyOnSearchDescription = true;
            CardPageGroupPosition = Position.LastWithinContainer;
        }

        protected override void CreateFields()
        {
            DescriptionField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}{1}", Prefix, Style), 50).AutoCaption());

            if (HasDescription2)
            {
                Description2Field = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}{1} 2", Prefix, Style), 50).AutoCaption());
            }

            if (HasSearchDescription)
            {
                SearchDescriptionField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Search {1}", Prefix, Style), 50).AutoCaption());
                SearchDescriptionField.Properties.OnValidate.CodeLines.Add("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", SearchDescriptionField.Name.Quoted(), DescriptionField.Name.Quoted());
                SearchDescriptionField.Properties.OnValidate.CodeLines.Add("  {0} := {1};", SearchDescriptionField.Name.Quoted(), DescriptionField.Name.Quoted());

                if (CreateKeyOnSearchDescription)
                {
                    KeyOnSearchDescription = Table.Keys.Add();
                    KeyOnSearchDescription.Fields.Add(SearchDescriptionField.Name);
                }
            }
        }

        protected override void CreateCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption(GroupCaption, Range, CardPageGroupPosition);

            var descriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            descriptionControl.Properties.SourceExpr = DescriptionField.Name.Quoted();
            DescriptionControls.Add(page, descriptionControl);

            if (HasSearchDescription)
            {
                var searchDescriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                searchDescriptionControl.Properties.SourceExpr = SearchDescriptionField.Name.Quoted();
                SearchDescriptionControls.Add(page, searchDescriptionControl);
            }
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, ListPageGroupPosition);

            var descriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            descriptionControl.Properties.SourceExpr = DescriptionField.Name.Quoted();
            DescriptionControls.Add(page, descriptionControl);

            if (HasSearchDescription)
            {
                var searchDescriptionControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                searchDescriptionControl.Properties.SourceExpr = SearchDescriptionField.Name.Quoted();
                SearchDescriptionControls.Add(page, searchDescriptionControl);
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

        public bool CreateKeyOnSearchDescription
        {
            get;
            set;
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

        public TableKey KeyOnSearchDescription
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> DescriptionControls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> Description2Controls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> SearchDescriptionControls
        {
            get;
            protected set;
        }
    }
}
