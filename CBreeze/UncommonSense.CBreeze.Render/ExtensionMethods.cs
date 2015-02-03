using System;
using System.Linq;
using System.Globalization;
using UncommonSense.CBreeze.Core;
using System.Collections.Generic;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    internal static class ExtensionMethods
    {
        internal static string MakeVariableName(this string text)
        {
            text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);

            return new string((from c in text
                               where Char.IsLetterOrDigit(c)
                               select c).ToArray());
        }

        internal static Table AutoCaption(this Table table)
        {
            table.Properties.CaptionML.Add("ENU", table.Name);
            return table;
        }

        internal static Page AutoCaption(this Page page)
        {
            page.Properties.CaptionML.Add("ENU", page.Name);
            return page;
        }

        internal static IntegerTableField AutoCaption(this IntegerTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static TextTableField AutoCaption(this TextTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static CodeTableField AutoCaption(this CodeTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static OptionTableField AutoCaption(this OptionTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static BooleanTableField AutoCaption(this BooleanTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static DateTableField AutoCaption(this DateTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static OptionTableField AutoOptionCaption(this OptionTableField field)
        {
            field.Properties.OptionCaptionML.Add("ENU", field.Properties.OptionString);
            return field;
        }

        internal static Table AutoObjectProperties(this Table table, RenderingContext renderingContext)
        {
            table.ObjectProperties.DateTime = renderingContext.DateTime;
            table.ObjectProperties.VersionList = renderingContext.VersionList;
            return table;
        }

        internal static Page AutoObjectProperties(this Page page, RenderingContext renderingContext)
        {
            page.ObjectProperties.DateTime = renderingContext.DateTime;
            page.ObjectProperties.VersionList = renderingContext.VersionList;
            return page;
        }

        internal static Codeunit AutoObjectProperties(this Codeunit codeunit, RenderingContext renderingContext)
        {
            codeunit.ObjectProperties.DateTime = renderingContext.DateTime;
            codeunit.ObjectProperties.VersionList = renderingContext.VersionList;
            return codeunit;
        }

        internal static IEnumerable<LedgerEntityType> LedgerEntityTypes(this MasterEntityType masterEntityType, RenderingContext renderingContext)
        {
            return renderingContext.EntityTypes.OfType<LedgerEntityType>().Where(l => l.MasterEntityType == masterEntityType);
        }

        internal static CodeTableField AddSearchDescription(this Table table, int fieldNo, CodeTableField noField, TextTableField descriptionField)
        {
            var searchDescriptionField = table.Fields.AddCodeTableField(fieldNo, string.Format("Search {0}", descriptionField.Name), descriptionField.DataLength).AutoCaption();
            
            descriptionField.Properties.OnValidate.CodeLines.Add("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", searchDescriptionField.Name.Quoted(), descriptionField.Name.Quoted());
            descriptionField.Properties.OnValidate.CodeLines.Add("  {0} := {1};", searchDescriptionField.Name.Quoted(), descriptionField.Name.Quoted());

            return searchDescriptionField;
        }

        internal static DateTableField AddLastDateModified(this Table table, int fieldNo)
        {
            var lastDateModifiedField = table.Fields.AddDateTableField(fieldNo, "Last Date Modified").AutoCaption();
            lastDateModifiedField.Properties.Editable = false;

            table.Properties.OnModify.CodeLines.Add("{0} := TODAY;", lastDateModifiedField.Name.Quoted());
            table.Properties.OnRename.CodeLines.Add("{0} := TODAY;", lastDateModifiedField.Name.Quoted());

            return lastDateModifiedField;
        }   
    }
}

