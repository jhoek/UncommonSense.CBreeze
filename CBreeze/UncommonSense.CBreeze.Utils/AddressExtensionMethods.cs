using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddressFieldsManifest
    {
        internal AddressFieldsManifest()
        {
        }

        public TextTableField AddressField
        {
            get;
            internal set;
        }

        public TextTableField Address2Field
        {
            get;
            internal set;
        }

        public CodeTableField PostCodeField
        {
            get;
            internal set;
        }

        public TextTableField CityField
        {
            get;
            internal set;
        }

        public TextTableField CountyField
        {
            get;
            internal set;
        }

        public CodeTableField CountryRegionCodeField
        {
            get;
            internal set;
        }
    }

    public class AddressControlsManifest
    {
        internal AddressControlsManifest()
        {
        }
    }

    public static class AddressExtensionMethods
    {
        public static AddressFieldsManifest AddAddressFields(this Table table, string prefix, IEnumerable<int> range)
        {
            var manifest = new AddressFieldsManifest();

            // Create fields
            manifest.AddressField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Address", prefix), 50).AutoCaption());
            manifest.Address2Field = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}Address 2", prefix), 50).AutoCaption());
            manifest.PostCodeField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), string.Format("{0}Post Code", prefix), 20).AutoCaption());
            manifest.CityField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}City", prefix), 30).AutoCaption());
            manifest.CountyField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}County", prefix), 30).AutoCaption());
            manifest.CountryRegionCodeField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), string.Format("{0}Country/Region Code", prefix), 10).AutoCaption());

            // TestTableRelation/ValidateTableRelation
            manifest.PostCodeField.Properties.TestTableRelation = false;
            manifest.PostCodeField.Properties.ValidateTableRelation = false;
            manifest.CityField.Properties.TestTableRelation = false;
            manifest.CityField.Properties.ValidateTableRelation = false;

            // Variables in OnValidate
            const string variableName = "PostCode";
            manifest.PostCodeField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));
            manifest.CityField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, variableName, 225));

            // Codelines in OnValidate
            manifest.PostCodeField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidatePostCode({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                manifest.CityField.Name.Quoted(),
                manifest.PostCodeField.Name.Quoted(),
                manifest.CountyField.Name.Quoted(),
                manifest.CountryRegionCodeField.Name.Quoted());

            manifest.CityField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidateCity({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);",
                variableName,
                manifest.CityField.Name.Quoted(),
                manifest.PostCodeField.Name.Quoted(),
                manifest.CountyField.Name.Quoted(),
                manifest.CountryRegionCodeField.Name.Quoted());

            // Table relations
            var tableRelation = manifest.PostCodeField.Properties.TableRelation.Set("Post Code", "Code");
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Const, "''");

            tableRelation = manifest.PostCodeField.Properties.TableRelation.Set("Post Code", "Code");
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableRelationTableFilterLineType.Field, manifest.CountryRegionCodeField.Name);

            tableRelation = manifest.CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Const, "''");

            tableRelation = manifest.CityField.Properties.TableRelation.Set("Post Code", "City");
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableRelationTableFilterLineType.Field, manifest.CountryRegionCodeField.Name);

            manifest.CountryRegionCodeField.Properties.TableRelation.Add("Country/Region");

            return manifest;
        }

        public static AddressControlsManifest AddAddressControls(this Page page, AddressFieldsManifest fieldsManifest, IEnumerable<int> range)
        {
            var manifest = new AddressControlsManifest();
            var container = page.GetContentArea(range);

            switch (page.Properties.PageType)
            {
                case PageType.Card:
                    // FIXME: Parameter for group caption
                    // FIXME: Address, Address 2, Post Code (promoted), City, Country/Region Code
                    break;
                case PageType.List:
                    // FIXME: Post Code, Country/Region Code
                    break;
            }

            // FIXME: Conclusion: card pages and list pages require different parameters. Also, they might require different manifests.

            return manifest;
        }
    }
}
