using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class LedgerEntityTypePattern : EntityTypePattern
    {
        private string pluralName;

        public LedgerEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {
        }

        protected override void VerifyRequirements()
        {
            base.VerifyRequirements();
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), PluralName).AutoCaption());

            Page.Properties.PageType = PageType.List;
        }

        protected override void LinkObjects()
        {
            Table.Properties.DrillDownPageID = Page.ID;
            Table.Properties.LookupPageID = Page.ID;
            Page.Properties.SourceTable = Table.ID;
        }

        protected override void CreateFields()
        {
            AddEntryNo();
            AddMasterEntityTypeReference();
            AddDescription();
            AddPostingDate();
        }

        protected void AddEntryNo()
        {
            var entryNoPattern = new EntryNoPattern(Range, Table, Page);
            entryNoPattern.Apply();

            EntryNoField = entryNoPattern.EntryNoField;
            EntryNoControl = entryNoPattern.EntryNoControls.First().Value;
        }

        protected void AddMasterEntityTypeReference()
        {
            if (MasterEntityTypeTable != null)
            {
                MasterEntityTypeField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0} No.", MasterEntityTypeTable.Name), 20).AutoCaption());
                MasterEntityTypeField.Properties.TableRelation.Add(MasterEntityTypeTable.Name);

                var contentArea = Page.GetContentArea(Range);
                var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
                MasterEntityTypeControl= group.AddFieldPageControl(Range.GetNextPageControlID(Page), Position.LastWithinContainer, MasterEntityTypeField.Name);
            }
        }

        protected void AddDescription()
        {
            var descriptionPattern = new DescriptionPattern(Range, Table, Page);
            descriptionPattern.HasDescription2 = false;
            descriptionPattern.HasSearchDescription = false;
            descriptionPattern.Apply();

            DescriptionField = descriptionPattern.DescriptionField;
            DescriptionControl = descriptionPattern.DescriptionControls.First().Value;
        }

        protected void AddPostingDate()
        {
            PostingDateField = Table.Fields.Add(new DateTableField(Range.GetNextTableFieldNo(Table), "Posting Date").AutoCaption());
            PostingDateField.Properties.ClosingDates = true;

            var contentArea = Page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, Position.FirstWithinContainer);
            PostingDateControl = group.AddFieldPageControl(Range.GetNextPageControlID(Page), Position.FirstWithinContainer, PostingDateField.Name);
        }

        protected override void CreateDropDownFieldGroup()
        {
            var fieldGroup = Table.FieldGroups.Add(new TableFieldGroup(1, "DropDown"));
            fieldGroup.Fields.Add(EntryNoField.Name);
            fieldGroup.Fields.Add(DescriptionField.Name);

            if (MasterEntityTypeTable != null)
            {
                fieldGroup.Fields.Add(MasterEntityTypeField.Name);
            }
            
            fieldGroup.Fields.Add(PostingDateField.Name); // FIXME: Document Type,Document No. }
        }

        protected override void CreateControls()
        {
            var actionItems = Page.GetActionItems(Range);
            var navigateAction = actionItems.AddPageAction(Range.GetNextPageControlID(Page), Position.LastWithinContainer, "&Navigate", "Navigate").Promote(false, PromotedCategory.Process);
            var trigger = navigateAction.Properties.OnAction;
            var variable = trigger.Variables.Add(new PageVariable(Range.GetNextVariableID(trigger), "Navigate", BaseApp.PageIDs.Navigate);

            /*
                          OnAction=VAR
                                     Navigate@1000 : Page 344;
                                   BEGIN
                                     Navigate.SetDoc("Posting Date","Document No.");
                                     Navigate.RUN;
                                   END;
                                    }
            */
        }

        public string PluralName
        {
            get
            {
                return this.pluralName ?? string.Format("{0}s", Name);
            }
            set
            {
                this.pluralName = value;
            }
        }

        public Table MasterEntityTypeTable
        {
            get;
            set;
        }

        public Table Table
        {
            get;
            protected set;
        }

        public Page Page
        {
            get;
            protected set;
        }

        public IntegerTableField EntryNoField
        {
            get;
            protected set;
        }

        public CodeTableField MasterEntityTypeField
        {
            get;
            protected set;
        }

        public TextTableField DescriptionField
        {
            get;
            protected set;
        }

        public DateTableField PostingDateField
        {
            get;
            protected set;
        }

        public FieldPageControl EntryNoControl
        {
            get;
            protected set;
        }

        public FieldPageControl MasterEntityTypeControl
        {
            get;
            protected set;
        }

        public FieldPageControl DescriptionControl
        {
            get;
            protected set;
        }

        public FieldPageControl PostingDateControl
        {
            get;
            protected set;
        }
    }
}
