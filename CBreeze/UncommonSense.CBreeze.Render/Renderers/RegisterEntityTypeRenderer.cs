using System;
using System.Linq;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Write;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Render
{
	public static class RegisterEntityTypeRenderer
	{
        internal static RegisterEntityTypeManifest Allocate(this RegisterEntityType entityType, RenderingContext renderingContext, Application application)
		{
            var manifest = new RegisterEntityTypeManifest();

			manifest.Table = application.Tables.Add(renderingContext.GetNextTableID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
			manifest.Page = application.Pages.Add(renderingContext.GetNextPageID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();

			var nextFieldNo = 1;

			manifest.NoField = manifest.Table.Fields.AddIntegerTableField(nextFieldNo++, "No.").AutoCaption();
			manifest.CreationDateField = manifest.Table.Fields.AddDateTableField(nextFieldNo++, "Creation Date").AutoCaption();
			manifest.UserIDField = manifest.Table.Fields.AddCodeTableField(nextFieldNo++, "User ID", 50).AutoCaption();
			manifest.SourceCodeField = entityType.HasSourceCodeField ? manifest.Table.Fields.AddCodeTableField(nextFieldNo++, "Source Code", 10).AutoCaption() : null;

			var nextControlID = 1;

			var actionList = manifest.Page.Properties.ActionList;
			actionList.AddPageActionContainer(nextControlID++, 0).Properties.ActionContainerType = ActionContainerType.RelatedInformation;
			actionList.AddPageActionGroup(nextControlID++, 1).Properties.CaptionML.Add("ENU", "&Register");

			manifest.Page.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.ContentArea;
			manifest.Page.Controls.AddGroupPageControl(nextControlID++, 1).Properties.GroupType = GroupType.Repeater;
			manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.NoField.Name.Quoted();
			manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.CreationDateField.Name.Quoted();
			manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.UserIDField.Name.Quoted();

			if (entityType.HasSourceCodeField)
			{
				manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = manifest.SourceCodeField.Name.Quoted();
			}

			foreach (var ledgerEntityType in entityType.LedgerEntityTypes)
			{
				var ledgerEntityTypeManifest = renderingContext.GetManifest(ledgerEntityType) as LedgerEntityTypeManifest;

				var fromEntryNoField = manifest.Table.Fields.AddIntegerTableField(nextFieldNo++, string.Format("From {0} No.", ledgerEntityType.Name));
				fromEntryNoField.Properties.CaptionML.Add("ENU", fromEntryNoField.Name);
				fromEntryNoField.Properties.TableRelation.Add(ledgerEntityTypeManifest.Table.Name);
				fromEntryNoField.Properties.TestTableRelation = false;

				var toEntryNoField = manifest.Table.Fields.AddIntegerTableField(nextFieldNo++, string.Format("To {0} No.", ledgerEntityType.Name));
				toEntryNoField.Properties.CaptionML.Add("ENU", toEntryNoField.Name);
				toEntryNoField.Properties.TableRelation.Add(ledgerEntityTypeManifest.Table.Name);
				toEntryNoField.Properties.TestTableRelation = false;

				manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = fromEntryNoField.Name.Quoted();
				manifest.Page.Controls.AddFieldPageControl(nextControlID++, 2).Properties.SourceExpr = toEntryNoField.Name.Quoted();

				var action = actionList.AddPageAction(nextControlID++, 2);
				var caption = ledgerEntityType.Name.EndsWith(" Entry") ? ledgerEntityType.Name.Substring(0, ledgerEntityType.Name.Length - " Entry".Length) : ledgerEntityType.Name;

				action.Properties.CaptionML.Add("ENU", caption);
				action.Properties.Promoted = true;
				action.Properties.PromotedIsBig = true;
				action.Properties.Image = "GLRegisters";
				action.Properties.PromotedCategory = PromotedCategory.Process;
				action.Properties.OnAction.CodeLines.Add("// Add logic here");
			}

			manifest.Page.Controls.AddContainerPageControl(nextControlID++, 0).Properties.ContainerType = ContainerType.FactBoxArea;

			var recordLinksPart = manifest.Page.Controls.AddPartPageControl(nextControlID++, 1);
			recordLinksPart.Properties.PartType = PartType.System;
			recordLinksPart.Properties.SystemPartID = SystemPartID.RecordLinks;
			recordLinksPart.Properties.Visible = false.ToString();

			var notesPart = manifest.Page.Controls.AddPartPageControl(nextControlID++, 1);
			notesPart.Properties.PartType = PartType.System;
			notesPart.Properties.SystemPartID = SystemPartID.Notes;
			notesPart.Properties.Visible = false.ToString();

            return manifest;
		}

		internal static void Finalize(this RegisterEntityType entityType, RenderingContext renderingContext, RegisterEntityTypeManifest manifest)
		{
			manifest.UserIDField.Properties.TableRelation.Add("User").FieldName = "User Name".Quoted();
			manifest.UserIDField.Properties.TestTableRelation = false;

			if (entityType.HasSourceCodeField)
			{
				manifest.SourceCodeField.Properties.TableRelation.Add("Source Code");
			}

			var onLookup = manifest.UserIDField.Properties.OnLookup;
			var userMgt = onLookup.Variables.AddCodeunitVariable(1000, "UserMgt", 418);
			onLookup.CodeLines.Add(string.Format("{0}.LookupUserID({1});", userMgt.Name.Quoted(), manifest.UserIDField.Name.Quoted()));

			manifest.Table.Properties.LookupPageID = manifest.Page.ID;
			manifest.Table.Keys.Add().Fields.Add(manifest.NoField.Name);
			manifest.Table.Keys.Add().Fields.Add(manifest.CreationDateField.Name);

			manifest.Page.Properties.SourceTable = manifest.Table.ID;
			manifest.Page.Properties.PageType = PageType.List;
			manifest.Page.Properties.Editable = false;
		}
	}
}

