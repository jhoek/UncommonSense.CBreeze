using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Meta
{
    public class SubsidiaryEntityTypePattern : EntityTypePattern
    {
        private string pluralName;
        private List<Table> subsidiaryTo = new List<Table>();

        public SubsidiaryEntityTypePattern(Application application, IEnumerable<int> range, string name, params Table[] subsidiaryTo)
            : base(application, range, name)
        {
            SubsidiaryToFields = new MappedResults<Core.Table, TableField>();
            DifferentiatorType = DifferentiatorType.None;
            this.subsidiaryTo.AddRange(subsidiaryTo);
        }

        protected override void VerifyRequirements()
        {
            if (!SubsidiaryTo.Any())
                throw new ArgumentOutOfRangeException("SubsidiaryTo");

            foreach (var subsidiaryTo in SubsidiaryTo)
            {
                GetSubsidiaryToPrimaryKeyField(subsidiaryTo);
            }
        }

        protected override void CreateObjects()
        {
            Table = Application.Tables.Add(new Table(Range.GetNextTableID(Application), Name).AutoCaption());
            Page = Application.Pages.Add(new Page(Range.GetNextPageID(Application), PluralName).AutoCaption());

            Page.Properties.PageType = PageType.List;
        }

        protected override void LinkObjects()
        {
            Page.Properties.SourceTable = Table.ID;
            Table.Properties.LookupPageID = Page.ID;
            Table.Properties.DrillDownPageID = Page.ID;
        }

        protected override void CreateFields()
        {
            var myPrimaryKey = Table.Keys.Add();
            myPrimaryKey.Properties.Clustered = true;

            foreach (var subsidiaryTo in SubsidiaryTo)
            {
                var theirPrimaryKeyField = GetSubsidiaryToPrimaryKeyField(subsidiaryTo);
                var myPrimaryKeyField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), string.Format("{0} {1}", subsidiaryTo.Name, theirPrimaryKeyField.Name), theirPrimaryKeyField.DataLength).AutoCaption());
                myPrimaryKeyField.Properties.TableRelation.Add(subsidiaryTo.Name);
                myPrimaryKeyField.Properties.NotBlank = true;

                CreateListPageControl(Page, Position.LastWithinContainer, myPrimaryKeyField.Name);

                myPrimaryKey.Fields.Add(myPrimaryKeyField.Name);
                SubsidiaryToFields.Add(subsidiaryTo, myPrimaryKeyField);     
            }

            switch (DifferentiatorType)
            {
                case Meta.DifferentiatorType.Code:
                    CodeField = Table.Fields.Add(new CodeTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Code", 10).AutoCaption());
                    myPrimaryKey.Fields.Add(CodeField.Name);

                    CreateListPageControl(Page, Position.LastWithinContainer, CodeField.Name);
                    break;
                case Meta.DifferentiatorType.LineNo:
                    LineNoField = Table.Fields.Add(new IntegerTableField(Range.GetNextPrimaryKeyFieldNo(Table), "Line No.").AutoCaption());
                    myPrimaryKey.Fields.Add(LineNoField.Name);

                    CreateListPageControl(Page, Position.LastWithinContainer, LineNoField.Name);
                    break;
            }
        }

        protected CodeTableField GetSubsidiaryToPrimaryKeyField(Table subsidiaryTo)
        {
            var primaryKey = subsidiaryTo.Keys.First();

            if (primaryKey.Fields.Count() != 1)
                throw new ArgumentOutOfRangeException("Primary key must consist of exactly one field of type Code with length 10 or 20.");

            var primaryKeyFieldName = primaryKey.Fields.First().FieldName;
            var primaryKeyField = subsidiaryTo.Fields[primaryKeyFieldName] as CodeTableField;

            if (primaryKeyField == null)
                throw new ArgumentOutOfRangeException("Primary key must consist of exactly one field of type Code with length 10 or 20.");

            if (primaryKeyField.DataLength != 10 && primaryKeyField.DataLength != 20)
                throw new ArgumentOutOfRangeException("Primary key must consist of exactly one field of type Code with length 10 or 20.");

            return primaryKeyField;
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

        public DifferentiatorType DifferentiatorType
        {
            get;
            set;
        }

        public IEnumerable<Table> SubsidiaryTo
        {
            get
            {
                return subsidiaryTo.AsEnumerable();
            }
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

        public MappedResults<Table, TableField> SubsidiaryToFields
        {
            get;
            protected set;
        }

        public IntegerTableField LineNoField
        {
            get;
            protected set;
        }

        public CodeTableField CodeField
        {
            get;
            protected set;
        }
    }
}
