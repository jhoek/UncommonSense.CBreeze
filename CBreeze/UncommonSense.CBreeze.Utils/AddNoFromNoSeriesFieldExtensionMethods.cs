using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class AddNoFromNoSeriesFieldExtensionMethods
    {
        public static AddNoFromNoSeriesFieldManifest AddNoFromNoSeriesField(this Table table, Table setupTable, Page setupPage, params Page[] pages)
        {
            var manifest = new AddNoFromNoSeriesFieldManifest();

            manifest.NoField = table.Fields.Add(new CodeTableField(table.NextFieldNo(), "No.", 20)).AutoCaption();


            manifest.NoSeriesField = table.Fields.Add(new CodeTableField(table.NextFieldNo(100), "No. Series", 10)).AutoCaption(); // FIXME: No.
            manifest.NoSeriesField.Properties.Editable = false;
            manifest.NoSeriesField.Properties.TableRelation.Add("No. Series");

            var primaryKey = table.Keys.Add();
            primaryKey.Fields.Add(manifest.NoField.Name);
            primaryKey.Properties.Clustered = true;

            return manifest;
        }
    }
}
