using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class LastDateModifiedFieldsManifest
    {
        internal LastDateModifiedFieldsManifest()
        {
        }

        public DateTableField LastDateModifiedField
        {
            get;
            internal set;
        }
    }

    public class LastDateModifiedControlsManifest
    {
        internal LastDateModifiedControlsManifest()
        {
        }

        public FieldPageControl LastDateModifiedControl
        {
            get;
            internal set;
        }
    }

    public static class LastDateModifiedExtensionMethods
    {
        public static LastDateModifiedFieldsManifest AddLastDateModifiedFields(this Table table, IEnumerable<int> range)
        {
            var manifest = new LastDateModifiedFieldsManifest();

            manifest.LastDateModifiedField = table.Fields.Add(new DateTableField(range.GetNextTableFieldNo(table), "Last Date Modified")).AutoCaption();
            manifest.LastDateModifiedField.Properties.Editable = false;

            var codeLine = string.Format("{0} := TODAY;", manifest.LastDateModifiedField.Name.Quoted());
            table.Properties.OnModify.CodeLines.Add(codeLine);
            table.Properties.OnRename.CodeLines.Add(codeLine);

            return manifest;
        }

        public static LastDateModifiedControlsManifest AddLastDateModifiedControls(this Page page, LastDateModifiedFieldsManifest fieldsManifest, IEnumerable<int> range)
        {
            var manifest = new LastDateModifiedControlsManifest();
            var container = page.GetContentArea();

            switch (page.Properties.PageType)
            {
                case PageType.Card:
                    var cardGroup = container.GetGroupByCaption("General", range, Position.FirstWithinContainer);
                    manifest.LastDateModifiedControl = cardGroup.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                    manifest.LastDateModifiedControl.Properties.SourceExpr = fieldsManifest.LastDateModifiedField.Name.Quoted();
                    break;
                case PageType.List:
                    var listGroup = container.GetGroupByType(GroupType.Repeater, range, Position.LastWithinContainer);
                    manifest.LastDateModifiedControl = listGroup.AddChildPageControl(new FieldPageControl(range.GetNextPageControlID(page), 2), Position.LastWithinContainer);
                    manifest.LastDateModifiedControl.Properties.SourceExpr = fieldsManifest.LastDateModifiedField.Name.Quoted();
                    manifest.LastDateModifiedControl.Properties.Visible = "FALSE";
                    break;
            }

            return manifest;
        }
    }
}
