using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
    public static class DocumentHistoryEntityTypeRenderer
    {
        internal static DocumentHistoryEntityTypeManifest Allocate(this DocumentHistoryEntityType entityType, RenderingContext renderingContext, Application application)
        {
            var manifest = new DocumentHistoryEntityTypeManifest();

            manifest.HeaderTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.HeaderName).AutoCaption();
            manifest.LineTable = application.Tables.Add(renderingContext.GetNextTableID(), entityType.LineName).AutoCaption();

            return manifest;
        }

        internal static void Finalize(this DocumentHistoryEntityType entityType, RenderingContext renderingContext, DocumentHistoryEntityTypeManifest manifest)
        {
        }
    }
}
