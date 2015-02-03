using System;
using System.Linq;
using System.Globalization;
using UncommonSense.CBreeze.Core;
using System.Collections.Generic;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
	internal static class ExtensionMethods
	{
        internal static string MakeVariableName(this string text)
        {
            text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);

            return new string((from c in text
                               where Char.IsLetterOrDigit(c)
                               select c).ToArray());
        }

        internal static Table AutoCaption(this Table table)
        {
            table.Properties.CaptionML.Add("ENU", table.Name);
            return table;
        }

        internal static Page AutoCaption(this Page page)
        {
            page.Properties.CaptionML.Add("ENU", page.Name);
            return page;
        }

        internal static IntegerTableField AutoCaption(this IntegerTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static TextTableField AutoCaption(this TextTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static CodeTableField AutoCaption(this CodeTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static OptionTableField AutoCaption(this OptionTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static BooleanTableField AutoCaption(this BooleanTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static DateTableField AutoCaption(this DateTableField field)
        {
            field.Properties.CaptionML.Add("ENU", field.Name);
            return field;
        }

        internal static OptionTableField AutoOptionCaption(this OptionTableField field)
        {
            field.Properties.OptionCaptionML.Add("ENU", field.Properties.OptionString);
            return field;
        }

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

        internal static IEnumerable<LedgerEntityType> LedgerEntityTypes(this MasterEntityType masterEntityType, RenderingContext renderingContext)
        {
            return renderingContext.EntityTypes.OfType<LedgerEntityType>().Where(l=>l.MasterEntityType == masterEntityType);
        }
	}
}

