using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public static class ExtensionMethods
    {
        public static void AutoCaptionIf(this Table table, bool condition)
        {
            if (condition)
            {
                table.Properties.CaptionML.Add("ENU", table.Name);
            }
        }

        public static void AutoCaptionIf(this Page page, bool condition)
        {
            if (condition)
            {
                page.Properties.CaptionML.Add("ENU", page.Name);
            }
        }

        public static void AutoCaptionIf(this Report report, bool condition)
        {
            if (condition)
            {
                report.Properties.CaptionML.Add("ENU", report.Name);
            }
        }

        public static void AutoCaptionIf(this XmlPort xmlPort, bool condition)
        {
            if (condition)
            {
                xmlPort.Properties.CaptionML.Add("ENU", xmlPort.Name);
            }
        }

        public static void AutoCaptionIf(this Query query, bool condition)
        {
            if (condition)
            {
                query.Properties.CaptionML.Add("ENU", query.Name);
            }
        }

        public static void AutoCaptionIf(this CodeTableField field, bool condition)
        {
            if (condition)
            {
                field.Properties.CaptionML.Add("ENU", field.Name);
            }
        }

        public static void AutoCaptionIf(this TextTableField field, bool condition)
        {
            if (condition)
            {
                field.Properties.CaptionML.Add("ENU", field.Name);
            }
        }
    }
}
