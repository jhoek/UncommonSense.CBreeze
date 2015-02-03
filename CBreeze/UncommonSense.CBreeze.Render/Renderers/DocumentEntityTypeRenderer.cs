using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
	public static class DocumentEntityTypeRenderer
	{
        internal static DocumentEntityTypeManifest Allocate(this DocumentEntityType entityType, RenderingContext renderingContext, Application application)
		{
            var manifest = new DocumentEntityTypeManifest();

			manifest.HeaderTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.HeaderName).AutoObjectProperties(renderingContext).AutoCaption();
			manifest.LineTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.LineName).AutoObjectProperties(renderingContext).AutoCaption();

			var nextFieldNo = 1;
			manifest.HeaderTableDocumentTypeField = !string.IsNullOrEmpty(entityType.DocumentTypeOptions) ? manifest.HeaderTable.Fields.AddOptionTableField(nextFieldNo++, "Document Type").AutoCaption() : null;
			manifest.HeaderTableNoField = manifest.HeaderTable.Fields.AddCodeTableField(nextFieldNo++, "No.", 20).AutoCaption();

			nextFieldNo = 1;
			manifest.LineTableDocumentTypeField = !string.IsNullOrEmpty(entityType.DocumentTypeOptions) ? manifest.LineTable.Fields.AddOptionTableField(nextFieldNo++, "Document Type").AutoCaption() : null;
			manifest.LineTableDocumentNoField = manifest.LineTable.Fields.AddCodeTableField(nextFieldNo++, "Document No.", 20).AutoCaption();
			manifest.LineTableLineNoField = manifest.LineTable.Fields.AddIntegerTableField(nextFieldNo++, "Line No.").AutoCaption();

            return manifest;
		}

		internal static void Finalize(this DocumentEntityType entityType, RenderingContext renderingContext, DocumentEntityTypeManifest manifest)
		{
			manifest.HeaderTablePrimaryKey = manifest.HeaderTable.Keys.Add();
			manifest.LineTablePrimaryKey = manifest.LineTable.Keys.Add();

			if (!string.IsNullOrEmpty(entityType.DocumentTypeOptions))
			{
				manifest.HeaderTableDocumentTypeField.Properties.OptionString = entityType.DocumentTypeOptions;
				manifest.HeaderTableDocumentTypeField.AutoOptionCaption();

				manifest.LineTableDocumentTypeField.Properties.OptionString = entityType.DocumentTypeOptions;
				manifest.LineTableDocumentTypeField.AutoOptionCaption();

				var tableRelationLine = manifest.LineTableDocumentNoField.Properties.TableRelation.Add(manifest.HeaderTable.Name);
				tableRelationLine.FieldName = manifest.HeaderTableNoField.Name;
				tableRelationLine.TableFilter.Add(manifest.HeaderTableDocumentTypeField.Name, TableRelationTableFilterLineType.Field, manifest.LineTableDocumentTypeField.Name);

				manifest.HeaderTablePrimaryKey.Fields.Add(manifest.HeaderTableDocumentTypeField.Name);
				manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableDocumentTypeField.Name);
			}

			manifest.HeaderTablePrimaryKey.Fields.Add(manifest.HeaderTableNoField.Name);

			manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableDocumentNoField.Name);
			manifest.LineTablePrimaryKey.Fields.Add(manifest.LineTableLineNoField.Name);
		}
	}
}
