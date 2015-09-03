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

    public class AddDescriptionTableFieldsManifest
    {
        internal AddDescriptionTableFieldsManifest()
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

    public class AddDescriptionPageControlsManifest
    {
        internal AddDescriptionPageControlsManifest(){}

        public FieldPageControl DescriptionControl{get;internal set;}
    }

    public static class AddDescriptionFieldsExtensionMethods
    {
        public static AddDescriptionTableFieldsManifest AddDescriptionTableFields(this Table table, IEnumerable<int> range, DescriptionStyle descriptionStyle = DescriptionStyle.Description,bool description2 = true, bool searchDescription = true, string prefix = null)
        {
            var manifest = new AddDescriptionTableFieldsManifest();

            // Description
            manifest.DescriptionField = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}{1}", prefix, descriptionStyle), 50)).AutoCaption();

            // Description 2
            if (description2)
            {
                manifest.Description2Field = table.Fields.Add(new TextTableField(range.GetNextTableFieldNo(table), string.Format("{0}{1} 2", prefix, descriptionStyle), 50)).AutoCaption();
            }

            // Search Description
            if (searchDescription)
            {
                manifest.SearchDescriptionField = table.Fields.Add(new CodeTableField(range.GetNextTableFieldNo(table), string.Format("{0}Search {1}", prefix, descriptionStyle), 50)).AutoCaption();
                manifest.DescriptionField.Properties.OnValidate.CodeLines.Add("IF ({0} = UPPERCASE(xRec.{1})) OR ({0} = '') THEN", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted());
                manifest.DescriptionField.Properties.OnValidate.CodeLines.Add("  {0} := {1};", manifest.SearchDescriptionField.Name.Quoted(), manifest.DescriptionField.Name.Quoted());
            }

            return manifest;
        }

        public static AddDescriptionPageControlsManifest AddDescriptionPageControls(this GroupPageControl group, AddDescriptionTableFieldsManifest tableFieldsManifest, IEnumerable<int> range, Position position)
        {
            var manifest = new AddDescriptionPageControlsManifest();
            manifest.DescriptionControl = new FieldPageControl(range.GetNextPageControlID(group.Container.Page), group.IndentationLevel + 1);

            switch (position)
            {
                case Position.FirstWithinContainer:
                    break;
                case Position.LastWithinContainer:
                    break;
            }

            return manifest;
        }
    }
}
