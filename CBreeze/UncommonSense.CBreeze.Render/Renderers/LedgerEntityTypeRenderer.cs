using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Render
{
	public static class LedgerEntityTypeRenderer
	{
        internal static LedgerEntityTypeManifest Allocate(this LedgerEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new LedgerEntityTypeManifest();

            manifest.Table = application.Tables.Add(renderingContext.GetNextTableID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.Page = application.Pages.Add(renderingContext.GetNextPageID(), entityType.PluralName).AutoObjectProperties(renderingContext).AutoCaption();

            var nextFieldNo = 1;
            manifest.EntryNoField = manifest.Table.Fields.Add(new IntegerTableField(nextFieldNo++, "Entry No.")).AutoCaption();
            manifest.MasterEntityTypeField = entityType.MasterEntityType != null ? manifest.Table.Fields.Add( new CodeTableField(nextFieldNo++, entityType.MasterEntityTypeFieldName(), 20)).AutoCaption() : null;
            manifest.DescriptionField = manifest.Table.Fields.Add(new TextTableField(nextFieldNo++, "Description", 50)).AutoCaption();
            manifest.PostingDateField = entityType.HasPostingDateField ? manifest.Table.Fields.Add(new DateTableField(nextFieldNo++, "Posting Date")).AutoCaption() : null;

            return manifest;
        }

        internal static void Finalize(this LedgerEntityType entityType, RenderingContext renderingContext, LedgerEntityTypeManifest manifest)
        {
            manifest.Table.Properties.LookupPageID = manifest.Page.ID;
            manifest.Table.Properties.DrillDownPageID = manifest.Page.ID;

            if (entityType.MasterEntityType != null)
            {
                manifest.MasterEntityTypeField.Properties.TableRelation.Add(entityType.MasterEntityType.Name);
            }

            manifest.Page.Properties.SourceTable = manifest.Table.ID;
        }

        private static string MasterEntityTypeFieldName(this LedgerEntityType entityType)
        {
            if (entityType.MasterEntityType != null)
                return string.Format("{0} No.", entityType.MasterEntityType.Name);

            return null;
        }
	}
}
