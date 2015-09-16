using System;
using System.Linq;
using System.Globalization;
using UncommonSense.CBreeze.Core;
using System.Collections.Generic;
using UncommonSense.CBreeze.Model;
using UncommonSense.CBreeze.Utils;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Render
{
    internal static class ExtensionMethods
    {
        internal static Table AutoObjectProperties(this Table table, RenderingContext renderingContext)
        {
            table.ObjectProperties.DateTime = renderingContext.DateTime;
            table.ObjectProperties.VersionList = renderingContext.VersionList;
            return table;
        }

        internal static Page AutoObjectProperties(this Page page, RenderingContext renderingContext)
        {
            page.ObjectProperties.DateTime = renderingContext.DateTime;
            page.ObjectProperties.VersionList = renderingContext.VersionList;
            return page;
        }

        internal static Codeunit AutoObjectProperties(this Codeunit codeunit, RenderingContext renderingContext)
        {
            codeunit.ObjectProperties.DateTime = renderingContext.DateTime;
            codeunit.ObjectProperties.VersionList = renderingContext.VersionList;
            return codeunit;
        }

    }
}

