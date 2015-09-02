using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public enum DescriptionStyle
    {
        Name,
        Description
    }

    public class AddDescriptionFieldsManifest
    {
        internal AddDescriptionFieldsManifest()
        {
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
    }

    public static class AddDescriptionFieldsExtensionMethods
    {
        public static AddDescriptionFieldsManifest AddDescriptionFields(this Table table, IEnumerable<int> range, Page[] pages, DescriptionStyle descriptionStyle = DescriptionStyle.Description,bool description2 = true, bool searchDescription = true, string prefix = null)
        {
            var manifest = new AddDescriptionFieldsManifest();

            manifest.DescriptionField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}{1}", prefix, descriptionStyle), 50)).AutoCaption();

            if (description2)
            {
                manifest.Description2Field = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}{1} 2", prefix, descriptionStyle), 50)).AutoCaption();
            }

            if (searchDescription)
            {
                manifest.SearchDescriptionField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), string.Format("{0}Search {1}", prefix, descriptionStyle), 50)).AutoCaption();
                manifest.DescriptionField.Properties.OnValidate.CodeLines.Add("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted());
                manifest.DescriptionField.Properties.OnValidate.CodeLines.Add("  {0} := {1};", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted());
            }

            return manifest;
        }
    }
}
