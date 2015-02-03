using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
	internal static class SetupEntityTypeRenderer
	{
		internal static SetupEntityTypeManifest Allocate(this SetupEntityType entityType, RenderingContext renderingContext, Application application)
		{
            var manifest = new SetupEntityTypeManifest();
			manifest.Table = application.Tables.Add(renderingContext.GetNextTableID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
			manifest.Page = application.Pages.Add(renderingContext.GetNextPageID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
            
			var nextFieldNo = 1;
			manifest.PrimaryKeyField = manifest.Table.Fields.AddCodeTableField(nextFieldNo++, "Primary Key", 10).AutoCaption();

			var nextControlID = 1000;
			manifest.PageContentAreaControl = manifest.Page.Controls.AddContainerPageControl(nextControlID++, 0);
			manifest.PageGeneralGroupControl = manifest.Page.Controls.AddGroupPageControl(nextControlID++, 1);

			if (entityType.HasNoSeriesFields())
			{
				manifest.PageNumberingGroupControl = manifest.Page.Controls.AddGroupPageControl(nextControlID++, 1);

				foreach (var masterEntityType in entityType.ApplicationDesign.OfType<MasterEntityType>())
				{
					AddNoSeriesField(string.Format("{0} Nos.", masterEntityType.Name), ref nextFieldNo, ref nextControlID, manifest);
				}

				foreach (var documentEntityType in entityType.ApplicationDesign.OfType<DocumentEntityType>())
				{
					if (string.IsNullOrEmpty(documentEntityType.DocumentTypeOptions))
					{
						AddNoSeriesField(string.Format("{0} Nos.", documentEntityType.HeaderName), ref nextFieldNo, ref nextControlID, manifest);
					}
					else
					{
						foreach (var documentType in documentEntityType.DocumentTypeOptions.Split(",".ToCharArray()))
						{
							AddNoSeriesField(string.Format("{0} {1} Nos.", documentEntityType.BaseName, documentType), ref nextFieldNo, ref nextControlID, manifest);
						}
					}
				}
			}

            return manifest;
		}

		internal static void Finalize(this SetupEntityType entityType, RenderingContext renderingContext, SetupEntityTypeManifest manifest)
		{
			CodeLines codeLines = null;

			manifest.Page.Properties.PageType = PageType.Card;
			manifest.Page.Properties.InsertAllowed = false;
			manifest.Page.Properties.DeleteAllowed = false;
			manifest.Page.Properties.SourceTable = manifest.Table.ID;

			manifest.PageContentAreaControl.Properties.ContainerType = ContainerType.ContentArea;
			manifest.PageGeneralGroupControl.Properties.CaptionML.Add("ENU", "General");

			if (entityType.HasNoSeriesFields())
			{
				manifest.PageNumberingGroupControl.Properties.CaptionML.Add("ENU", "Numbering");
			}

			codeLines = manifest.Page.Properties.OnOpenPage.CodeLines;
			codeLines.Add("RESET;");
			codeLines.Add("IF NOT GET THEN BEGIN");
			codeLines.Add("  INIT;");
			codeLines.Add("  INSERT;");
			codeLines.Add("END;");
		}

		private static bool HasNoSeriesFields(this SetupEntityType setupEntityType)
		{
			return setupEntityType.ApplicationDesign.Any(e => e is MasterEntityType || e is DocumentEntityType);
		}

		private static void AddNoSeriesField(string fieldName, ref int nextFieldNo, ref int nextControlID, SetupEntityTypeManifest manifest)
		{
			var field = manifest.Table.Fields.AddCodeTableField(nextFieldNo++, fieldName, 10);
			field.Properties.CaptionML.Add("ENU", field.Name);
			field.Properties.TableRelation.Add("No. Series");

			manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = field.Name.Quoted();
		}
	}
}
