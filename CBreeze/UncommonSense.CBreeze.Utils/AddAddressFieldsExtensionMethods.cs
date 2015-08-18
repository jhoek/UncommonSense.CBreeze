using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class AddAddressFieldsExtensionMethods
    {
        public static AddAddressFieldsManifest AddAddressFields(Table table, Page page = null, string prefix = null, int fieldNoOffset = 0)
        {
            var manifest = new AddAddressFieldsManifest();

            fieldNoOffset = fieldNoOffset == 0 ? table.Fields.Max(f=>f.No) + 1 : fieldNoOffset;

            manifest.AddressField = table.Fields.Add(new TextTableField(fieldNoOffset++, string.Format("{0}Address", prefix), 50).AutoCaption());
            manifest.Address2Field = table.Fields.Add(new TextTableField(fieldNoOffset++, string.Format("{0}Address 2", prefix), 50).AutoCaption());
            manifest.PostCodeField = table.Fields.Add(new CodeTableField(fieldNoOffset++, string.Format("{0}Post Code", prefix), 20).AutoCaption());
            manifest.CityField = table.Fields.Add(new TextTableField(fieldNoOffset++, string.Format("{0}City", prefix), 30).AutoCaption());
            manifest.CountyField = table.Fields.Add(new TextTableField(fieldNoOffset++, string.Format("{0}County", prefix), 30).AutoCaption());
            manifest.CountryRegionCodeField = table.Fields.Add(new CodeTableField(fieldNoOffset++, string.Format("{0}Country/Region Code", prefix), 10).AutoCaption());

            manifest.PostCodeField.Properties.TestTableRelation = false;
            manifest.PostCodeField.Properties.ValidateTableRelation = false;

            var variable = manifest.PostCodeField.Properties.OnValidate.Variables.Add(new RecordVariable(1000, "PostCode", 225));
            manifest.PostCodeField.Properties.OnValidate.CodeLines.Add(
                "{0}.ValidatePostCode({1},{2},{3},{4}, (CurrFieldNo <> 0) AND GUIALLOWED);", 
                variable.Name, 
                manifest.CityField.Name.Quoted(), 
                manifest.PostCodeField.Name.Quoted(),
                manifest.CountyField.Name.Quoted(), 
                manifest.CountryRegionCodeField.Name.Quoted()); 
            
            var tableRelation = manifest.PostCodeField.Properties.TableRelation.Add("Post Code");
            tableRelation.FieldName = "Code";
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Const, "''");

            tableRelation = manifest.PostCodeField.Properties.TableRelation.Add("Post Code");
            tableRelation.FieldName = "Code";
            tableRelation.Conditions.Add(manifest.CountryRegionCodeField.Name, TableRelationConditionType.Filter, "<>''");
            tableRelation.TableFilter.Add("Country/Region Code", TableRelationTableFilterLineType.Field, manifest.CountryRegionCodeField.Name);



            manifest.CityField.Properties.TestTableRelation = false;
            manifest.CityField.Properties.ValidateTableRelation = false;

            if (page != null)
            {

            }

            return manifest;
        }
    }
}
