using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class AddLastDateModifiedFieldExtensionMethods
    {
        public static AddLastDateModifiedFieldManifest AddLastDateModifiedField(this Table table, int fieldNoOffset = 0)
        {
            var manifest = new AddLastDateModifiedFieldManifest();

            fieldNoOffset = fieldNoOffset == 0 ? table.Fields.Max(f => f.ID) + 1 : fieldNoOffset;

            manifest.LastDateModifiedField = table.Fields.Add(new DateTableField(fieldNoOffset, "Last Date Modified")).AutoCaption();
            manifest.LastDateModifiedField.Properties.Editable = false;

            var codeLine = string.Format("{0} := TODAY;", manifest.LastDateModifiedField.Name.Quoted());
            table.Properties.OnModify.CodeLines.Add(codeLine);
            table.Properties.OnRename.CodeLines.Add(codeLine);

            return manifest;
        }
    }
}
