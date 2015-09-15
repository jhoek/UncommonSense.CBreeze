using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class AddressBlockPattern : AddFieldsPattern
    {
        private Dictionary<Page, FieldPageControl> addressControls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> address2Controls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> postCodeControls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> cityControls = new Dictionary<Page, FieldPageControl>();
        private Dictionary<Page, FieldPageControl> countryRegionCodeControls = new Dictionary<Page, FieldPageControl>();

        public AddressBlockPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            GroupCaption = "General";
            CardPageGroupPosition = Position.LastWithinContainer;
            ListPageGroupPosition = Position.FirstWithinContainer;
        }

        protected override void MakeChanges()
        {
            CreateFields();
            AddTableRelations();
            AddValidationCode();
            CreateControls();
        }

        protected void CreateFields()
        {
            AddressField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Address", Prefix), 50).AutoCaption());
            Address2Field = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Address 2", Prefix), 50).AutoCaption());
            PostCodeField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Post Code", Prefix), 20).AutoCaption());
            CityField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}City", Prefix), 30).AutoCaption());
            CountyField = Table.Fields.Add(new TextTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}County", Prefix), 30).AutoCaption());
            CountryRegionCodeField = Table.Fields.Add(new CodeTableField(Range.GetNextTableFieldNo(Table), string.Format("{0}Country/Region Code", Prefix), 10).AutoCaption());
        }

        protected void AddTableRelations()
        {
            PostCodeField.Properties.TestTableRelation = false;
            PostCodeField.Properties.ValidateTableRelation = false;
            CityField.Properties.TestTableRelation = false;
            CityField.Properties.ValidateTableRelation = false;

            var tableRelation = PostCodeField.Properties.TableRelation.Set("Post Code", "Code");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, TableRelationConditionType.Const, "''");

            tableRelation = PostCodeField.Properties.TableRelation.Set("Post Code", "Code");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, TableRelationConditionType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableRelationTableFilterLineType.Field, CountryRegionCodeField.Name);

            tableRelation = CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, TableRelationConditionType.Const, "''");

            tableRelation = CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, TableRelationConditionType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableRelationTableFilterLineType.Field, CountryRegionCodeField.Name);

            CountryRegionCodeField.Properties.TableRelation.Add("Country/Region");
        }

        protected void AddValidationCode()
        {
            const string variableName = "PostCode";

            PostCodeField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));
            CityField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));

            PostCodeField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidatePostCode({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                CityField.Name.Quoted(),
                PostCodeField.Name.Quoted(),
                CountyField.Name.Quoted(),
                CountryRegionCodeField.Name.Quoted());

            CityField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidateCity({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                CityField.Name.Quoted(),
                PostCodeField.Name.Quoted(),
                CountyField.Name.Quoted(),
                CountryRegionCodeField.Name.Quoted());
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

            var addressControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            addressControl.Properties.SourceExpr = AddressField.Name.Quoted();
            addressControls.Add(page, addressControl);

            address2Controls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, Address2Field.Name));

            var postCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            postCodeControl.Properties.SourceExpr = PostCodeField.Name.Quoted();
            postCodeControl.Properties.Importance = Importance.Promoted;
            postCodeControls.Add(page, postCodeControl);

            var cityControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            cityControl.Properties.SourceExpr = CityField.Name.Quoted();
            cityControls.Add(page, cityControl);

            countryRegionCodeControls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, CountryRegionCodeField.Name));
        }

        protected void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, ListPageGroupPosition);

            var postCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            postCodeControl.Properties.SourceExpr = PostCodeField.Name.Quoted();
            postCodeControls.Add(page, postCodeControl);

            var countryRegionCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            countryRegionCodeControl.Properties.SourceExpr = CountryRegionCodeField.Name.Quoted();
            countryRegionCodeControls.Add(page, countryRegionCodeControl);
        }

        public TextTableField AddressField
        {
            get;
            protected set;
        }

        public TextTableField Address2Field
        {
            get;
            protected set;
        }

        public CodeTableField PostCodeField
        {
            get;
            protected set;
        }

        public TextTableField CityField
        {
            get;
            protected set;
        }

        public TextTableField CountyField
        {
            get;
            protected set;
        }

        public CodeTableField CountryRegionCodeField
        {
            get;
            protected set;
        }


        public ReadOnlyDictionary<Page, FieldPageControl> AddressControls
        {
            get
            {
                return addressControls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> Address2Controls
        {
            get
            {
                return address2Controls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> PostCodeControls
        {
            get
            {
                return postCodeControls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> CityControls
        {
            get
            {
                return cityControls.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<Page, FieldPageControl> CountryRegionCodeControls
        {
            get
            {
                return countryRegionCodeControls.AsReadOnly();
            }
        }
    }
}
