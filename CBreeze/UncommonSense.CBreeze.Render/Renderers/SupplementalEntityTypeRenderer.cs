using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    public static class SupplementalEntityTypeRenderer
    {
        internal static SupplementalEntityTypeManifest Allocate(this SupplementalEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new SupplementalEntityTypeManifest();
            manifest.Table = application.Tables.Add(renderingContext.GetNextTableID(), entityType.Name).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.Page = application.Pages.Add(renderingContext.GetNextPageID(), entityType.PluralName).AutoObjectProperties(renderingContext).AutoCaption();

            var nextFieldNo = 1;
            manifest.CodeField = manifest.Table.Fields.Add(new CodeTableField(nextFieldNo++, "Code", 10)).AutoCaption();
            manifest.DescriptionField = manifest.Table.Fields.Add(new TextTableField(nextFieldNo++, entityType.DescriptionFieldName(), entityType.DescriptionFieldLength())).AutoCaption();

            var nextControlID = 1000;
            manifest.ContentAreaControl = manifest.Page.Controls.Add(new ContainerPageControl(nextControlID++, 0));
            manifest.RepeaterControl = manifest.Page.Controls.Add(new GroupPageControl(nextControlID++, 1));
            manifest.CodeControl = manifest.Page.Controls.Add(new FieldPageControl(nextControlID++, 2));
            manifest.DescriptionControl = manifest.Page.Controls.Add(new FieldPageControl(nextControlID++, 2));
            manifest.FactBoxAreaControl = manifest.Page.Controls.Add(new ContainerPageControl(nextControlID++, 0));
            manifest.RecordLinksControl = manifest.Page.Controls.Add(new PartPageControl(nextControlID++, 1));
            manifest.NotesControl = manifest.Page.Controls.Add(new PartPageControl(nextControlID++, 1));

            return manifest;
        }

        internal static void Finalize(this SupplementalEntityType entityType, RenderingContext renderingContext, SupplementalEntityTypeManifest manifest)
        {
            manifest.Table.Properties.LookupPageID = manifest.Page.ID;

            manifest.CodeField.Properties.NotBlank = true;

            manifest.Page.Properties.SourceTable = manifest.Table.ID;
            manifest.Page.Properties.PageType = PageType.List;

            manifest.ContentAreaControl.Properties.ContainerType = ContainerType.ContentArea;
            manifest.RepeaterControl.Properties.GroupType = GroupType.Repeater;
            manifest.CodeControl.Properties.SourceExpr = manifest.CodeField.Name.Quoted();
            manifest.DescriptionControl.Properties.SourceExpr = manifest.DescriptionField.Name.Quoted();
            manifest.FactBoxAreaControl.Properties.ContainerType = ContainerType.FactBoxArea;

            manifest.RecordLinksControl.Properties.PartType = PartType.System;
            manifest.RecordLinksControl.Properties.SystemPartID = SystemPartID.RecordLinks;
            manifest.RecordLinksControl.Properties.Visible = false.ToString();

            manifest.NotesControl.Properties.Visible = false.ToString();
            manifest.NotesControl.Properties.PartType = PartType.System;
            manifest.NotesControl.Properties.SystemPartID = SystemPartID.Notes;
        }

        internal static string DescriptionFieldName(this SupplementalEntityType supplementalEntityType)
        {
            switch (supplementalEntityType.DescriptionStyle)
            {
                case DescriptionStyle.Name:
                    return "Name";
                default:
                    return "Description";
            }
        }

        internal static int DescriptionFieldLength(this SupplementalEntityType supplementalEntityType)
        {
            switch (supplementalEntityType.DescriptionLength)
            {
                case DescriptionLength.Long:
                    return 50;
                default:
                    return 30;
            }
        }
    }
}
