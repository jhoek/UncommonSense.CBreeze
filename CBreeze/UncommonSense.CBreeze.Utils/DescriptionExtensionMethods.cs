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

    public class DescriptionFieldsManifest
    {
        internal DescriptionFieldsManifest()
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

    public class DescriptionControlsManifest
    {
        internal DescriptionControlsManifest()
        {
        }

        public FieldPageControl DescriptionControl
        {
            get;
            internal set;
        }

        public FieldPageControl Description2Control
        {
            get;
            internal set;
        }

        public FieldPageControl SearchDescriptionControl
        {
            get;
            internal set;
        }
    }

    public static class DescriptionExtensionMethods
    {
        public static DescriptionFieldsManifest AddDescriptionFields(this Table table, IEnumerable<int> range, DescriptionStyle descriptionStyle = DescriptionStyle.Description, bool description2 = true, bool searchDescription = true, string prefix = null)
        {
            var manifest = new DescriptionFieldsManifest();

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

        public static DescriptionControlsManifest AddDescriptionControls(this Page page, DescriptionFieldsManifest fieldsManifest, string groupCaption, IEnumerable<int> range, Position position)
        {
            var manifest = new DescriptionControlsManifest();
            var group = GetGroup(page, range, groupCaption, position);

            manifest.DescriptionControl = group.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
            manifest.DescriptionControl.Properties.SourceExpr = fieldsManifest.DescriptionField.Name.Quoted();

            if (fieldsManifest.Description2Field != null)
            {
                manifest.Description2Control = group.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                manifest.Description2Control.Properties.SourceExpr = fieldsManifest.Description2Field.Name.Quoted();
            }

            if (fieldsManifest.SearchDescriptionField != null)
            {
                manifest.SearchDescriptionControl = group.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                manifest.SearchDescriptionControl.Properties.SourceExpr = fieldsManifest.SearchDescriptionField.Name.Quoted();
            }

            return manifest;
        }

        private static GroupPageControl GetGroup(this Page page, IEnumerable<int> range, string groupCaption, Position position)
        {
            var contentArea = page.GetContentArea(range);

            switch (page.Properties.PageType)
            {
                case PageType.Card:
                    return contentArea.GetGroupByCaption(groupCaption, range, position);
                case PageType.List:
                    return contentArea.GetGroupByType(GroupType.Repeater, range, position);
                default:
                    return null;
            }
        }
    }
}
