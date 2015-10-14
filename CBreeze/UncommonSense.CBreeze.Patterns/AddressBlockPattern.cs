using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Patterns
{
    public class AddressBlockPattern : AddFieldsPattern
    {
        public AddressBlockPattern(IEnumerable<int> range, Table table, params Page[] pages)
            : base(range, table, pages)
        {
            AddressControls = new MappedResults<Page, FieldPageControl>();
            Address2Controls = new MappedResults<Page, FieldPageControl>();
            PostCodeControls = new MappedResults<Page, FieldPageControl>();
            CityControls = new MappedResults<Page, FieldPageControl>();
            CountryRegionCodeControls = new MappedResults<Page, FieldPageControl>();

            GroupCaption = "General";
            CardPageGroupPosition = Position.LastWithinContainer;
            ListPageGroupPosition = Position.FirstWithinContainer;
        }

        protected override void MakeChanges()
        {
            base.MakeChanges();

            AddTableRelations();
            AddValidationCode();
            AddFormatFunction();
        }

        protected override void CreateFields()
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
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, SimpleTableFilterType.Const, "''");

            tableRelation = PostCodeField.Properties.TableRelation.Set("Post Code", "Code");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, SimpleTableFilterType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableFilterType.Field, CountryRegionCodeField.Name);

            tableRelation = CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, SimpleTableFilterType.Const, "''");

            tableRelation = CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(CountryRegionCodeField.Name, SimpleTableFilterType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableFilterType.Field, CountryRegionCodeField.Name);

            CountryRegionCodeField.Properties.TableRelation.Add("Country/Region");
        }

        protected virtual void AddValidationCode()
        {
            const string variableName = "PostCode";

            PostCodeField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));
            CityField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));

            PostCodeField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidatePostCode({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                CityField.QuotedName,
                PostCodeField.QuotedName,
                CountyField.QuotedName,
                CountryRegionCodeField.QuotedName);

            CityField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidateCity({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                CityField.QuotedName,
                PostCodeField.QuotedName,
                CountyField.QuotedName,
                CountryRegionCodeField.QuotedName);
        }

        protected virtual void AddFormatFunction()
        {
            if (FormatAddressCodeunit != null)
            {
                FormatFunction = FormatAddressCodeunit.Code.Functions.Add(new Function(Range.GetNextFunctionID(FormatAddressCodeunit), FormatFunctionName()));

                var arrayParameter = FormatFunction.Parameters.Add(new TextParameter(true, Range.GetNextParameterID(FormatFunction), "AddrArray", 50));
                arrayParameter.Dimensions = "8";

                var recordParameter = FormatFunction.Parameters.Add(new RecordParameter(true, Range.GetNextParameterID(FormatFunction), Table.Name.MakeVariableName(), Table.ID));
                
                FormatFunction.CodeLines.Add("WITH {0} DO", recordParameter.Name);
                FormatFunction.CodeLines.Add("  FormatAddr(");
                FormatFunction.CodeLines.Add(
                    "    {0},{1},{2},{3},{4},{5},", 
                    arrayParameter.Name, 
                    string.Format("{0}Name", Prefix).Quoted(), 
                    string.Format("{0}Name 2", Prefix).Quoted(),
                    string.Format("{0}Contact", Prefix).Quoted(),
                    AddressField.QuotedName,
                    Address2Field.QuotedName);
                FormatFunction.CodeLines.Add(
                    "    {0},{1},{2},{3});",
                    CityField.QuotedName,
                    PostCodeField.QuotedName,
                    CountyField.QuotedName,
                    CountryRegionCodeField.QuotedName);
            }
        }

        protected virtual string FormatFunctionName()
        {
            return string.Format("{0} {1}", Table.Name, Prefix).MakeVariableName();
        }

        protected override void CreateCardPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByCaption(GroupCaption, Range, CardPageGroupPosition);

            var addressControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            addressControl.Properties.SourceExpr = AddressField.QuotedName;
            AddressControls.Add(page, addressControl);

            Address2Controls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, Address2Field.Name));

            var postCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            postCodeControl.Properties.SourceExpr = PostCodeField.QuotedName;
            postCodeControl.Properties.Importance = Importance.Promoted;
            PostCodeControls.Add(page, postCodeControl);

            var cityControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            cityControl.Properties.SourceExpr = CityField.QuotedName;
            CityControls.Add(page, cityControl);

            CountryRegionCodeControls.Add(page, group.AddFieldPageControl(Range.GetNextPageControlID(page), Position.LastWithinContainer, CountryRegionCodeField.Name));
        }

        protected override void CreateListPageControls(Page page)
        {
            var contentArea = page.GetContentArea(Range);
            var group = contentArea.GetGroupByType(GroupType.Repeater, Range, ListPageGroupPosition);

            var postCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            postCodeControl.Properties.SourceExpr = PostCodeField.QuotedName;
            PostCodeControls.Add(page, postCodeControl);

            var countryRegionCodeControl = group.AddChildPageControl(new FieldPageControl(Range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            countryRegionCodeControl.Properties.SourceExpr = CountryRegionCodeField.QuotedName;
            CountryRegionCodeControls.Add(page, countryRegionCodeControl);
        }

        public Codeunit FormatAddressCodeunit
        {
            get;
            set;
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


        public MappedResults<Page, FieldPageControl> AddressControls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> Address2Controls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> PostCodeControls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> CityControls
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> CountryRegionCodeControls
        {
            get;
            protected set;
        }

        public Function FormatFunction
        {
            get;
            protected set;
        }
    }
}
