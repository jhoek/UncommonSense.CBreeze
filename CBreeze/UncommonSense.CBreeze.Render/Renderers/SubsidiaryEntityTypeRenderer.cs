using System;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    public static class SubsidiaryEntityTypeRenderer
    {
        internal static SubsidiaryEntityTypeManifest Allocate(this SubsidiaryEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new SubsidiaryEntityTypeManifest();
            manifest.Table = application.Tables.Add(new Table(renderingContext.GetNextTableID(), entityType.Name)).AutoObjectProperties(renderingContext).AutoCaption();
            manifest.Page = application.Pages.Add(new Page(renderingContext.GetNextPageID(), entityType.PluralName)).AutoObjectProperties(renderingContext).AutoCaption();

            manifest.PrimaryKey = manifest.Table.Keys.Add();

            var nextControlID = 1000;
            var nextFieldNo = 1;

            manifest.PageContentAreaControl = manifest.Page.Controls.Add(new ContainerPageControl(nextControlID++, 0));
            manifest.PageRepeaterControl = manifest.Page.Controls.Add(new GroupPageControl(nextControlID++, 1));

            foreach (var subsidiaryToEntityType in entityType.SubsidiaryTo)
            {
                if (subsidiaryToEntityType is MasterEntityType)
                {
                    var masterEntityType = (subsidiaryToEntityType as MasterEntityType);
                    var field = manifest.AddReferenceField(manifest.Table.Fields.Add(new CodeTableField(nextFieldNo++, string.Format("{0} No.", masterEntityType.Name), 20)).AutoCaption(), masterEntityType);
                    manifest.Page.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = field.Name.Quoted();
                    manifest.PrimaryKey.Fields.Add(field.Name);
                }

                if (subsidiaryToEntityType is SupplementalEntityType)
                {
                    var supplementalEntityType = (subsidiaryToEntityType as SupplementalEntityType);
                    var field = manifest.AddReferenceField(manifest.Table.Fields.Add (new CodeTableField(nextFieldNo++, string.Format("{0} Code", supplementalEntityType.Name), 10)).AutoCaption(), supplementalEntityType);
                    manifest.Page.Controls.Add(new FieldPageControl(nextControlID++, 2)).Properties.SourceExpr = field.Name.Quoted();
                    manifest.PrimaryKey.Fields.Add(field.Name);
                }
            }

            manifest.LineNoField = entityType.DifferentiatorType == DifferentiatorType.LineNo ? manifest.Table.Fields.Add(new IntegerTableField(nextFieldNo++, "Line No.")).AutoCaption() : null;
            manifest.CodeField = entityType.DifferentiatorType == DifferentiatorType.Code ? manifest.Table.Fields.Add(new CodeTableField(nextFieldNo++, "Code", 10)).AutoCaption() : null;

            return manifest;
        }

        internal static void Finalize(this SubsidiaryEntityType entityType, RenderingContext renderingContext, SubsidiaryEntityTypeManifest manifest)
        {
            manifest.PageContentAreaControl.Properties.ContainerType = ContainerType.ContentArea;
            manifest.PageRepeaterControl.Properties.GroupType = GroupType.Repeater;
            manifest.PrimaryKey.Properties.Clustered = true;

            // Add table relations to reference fields
            foreach (var subsidiaryToEntityType in entityType.SubsidiaryTo)
            {
                if (subsidiaryToEntityType is MasterEntityType)
                {
                    var masterEntityType = (subsidiaryToEntityType as MasterEntityType);
                    var masterEntityTypeManifest = (renderingContext.GetManifest(masterEntityType) as MasterEntityTypeManifest);

                    manifest.ReferenceFields[masterEntityType].Properties.TableRelation.Add(masterEntityTypeManifest.Table.Name);
                }

                if (subsidiaryToEntityType is SupplementalEntityType)
                {
                    var supplementalEntityType = (subsidiaryToEntityType as SupplementalEntityType);
                    var supplementalEntityTypeManifest = (renderingContext.GetManifest(supplementalEntityType) as SupplementalEntityTypeManifest);

                    manifest.ReferenceFields[supplementalEntityType].Properties.TableRelation.Add(supplementalEntityTypeManifest.Table.Name);
                }
            }

            switch (entityType.DifferentiatorType)
            {
                case DifferentiatorType.LineNo:
                    manifest.PrimaryKey.Fields.Add(manifest.LineNoField.Name);
                    break;
                case DifferentiatorType.Code:
                    manifest.PrimaryKey.Fields.Add(manifest.CodeField.Name);
                    break;
            }
        }
    }
}

