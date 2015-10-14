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

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), PluralName).AutoCaption());
        }

        protected override void AfterCreateObjects()
        {
            Table.Properties.DrillDownPageID = Page.ID;
            Table.Properties.LookupPageID = Page.ID;

            Page.Properties.SourceTable = Table.ID;
            Page.Properties.PageType = PageType.List;
            Page.Properties.Editable = false;
            
        }

        protected override void CreateFields()
        {
            AddEntryNo();
            AddMasterEntityTypeReference();
            AddPostingDate();
            AddDocumentTypeAndDocumentNo();
            AddDescription();            
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

                CreateListPageControl(Page, Position.LastWithinContainer, MasterEntityTypeField.Name);
            }
        }

        protected void AddPostingDate()
        {
            PostingDateField = Table.Fields.Add(new DateTableField(Range.GetNextTableFieldNo(Table), "Posting Date").AutoCaption());
            PostingDateField.Properties.ClosingDates = true;

            CreateListPageControl(Page, Position.FirstWithinContainer, PostingDateField.Name);
        }

        protected void AddDocumentTypeAndDocumentNo()
        {
            DocumentTypeField = Table.Fields.Add(new OptionTableField(Range.GetNextTableFieldNo(Table), "Document Type").AutoCaption());
            DocumentTypeField.Properties.OptionString = "";
            DocumentTypeField.AutoOptionCaption();

            DocumentNoField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), "Document No.", 20).AutoCaption());

            CreateListPageControl(Page, Position.LastWithinContainer, DocumentTypeField.Name);
            CreateListPageControl(Page, Position.LastWithinContainer, DocumentNoField.Name);
        }

        protected void AddDescription()
        {
            var descriptionPattern = new DescriptionPattern(Range, Table, Page);
            descriptionPattern.Style = DescriptionStyle.Description;
            descriptionPattern.HasDescription2 = false;
            descriptionPattern.HasSearchDescription = false;
            descriptionPattern.Apply();

            DescriptionField = descriptionPattern.DescriptionField;
            DescriptionControl = descriptionPattern.DescriptionControls.First().Value;
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
            var navigateAction = actionItems.AddPageAction(Range.GetNextPageControlID(Page), Position.LastWithinContainer, "&Navigate", RunTime.Images.Navigate).Promote(false, PromotedCategory.Process);
            var trigger = navigateAction.Properties.OnAction;
            var variable = trigger.Variables.Add(new PageVariable(Range.GetNextVariableID(trigger), "Navigate", BaseApp.PageIDs.Navigate));
            trigger.CodeLines.Add("{0}.SetDoc({1},{2});", variable.Name.Quoted(), PostingDateField.QuotedName, DocumentNoField.QuotedName);
            trigger.CodeLines.Add("{0}.RUN;", variable.Name.Quoted());
        }

        public string PluralName
        {
            get
            {
                return this.pluralName ?? Name.MakePlural();
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

        public DateTableField PostingDateField
        {
            get;
            protected set;
        }

        public OptionTableField DocumentTypeField
        {
            get;
            protected set;
        }

        public CodeTableField DocumentNoField
        {
            get;
            protected set;
        }

        public TextTableField DescriptionField
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

        public FieldPageControl DocumentTypeControl
        {
            get;
            protected set;
        }

        public FieldPageControl DocumentNoControl
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
