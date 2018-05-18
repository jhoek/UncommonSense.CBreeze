﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class ActionWriter
    {
        public static void Write(this PageActionBase action, CSideWriter writer)
        {
            switch (action)
            {
                case PageActionContainer c: c.Write(writer); break;
                case PageActionGroup g: g.Write(writer); break;
                case PageAction a: a.Write(writer); break;
                case PageActionSeparator s: s.Write(writer); break;
            }
        }

        public static void Write(this PageActionContainer action, CSideWriter writer)
        {
            var idLength = Math.Max(action.ID.ToString().Length, 8);
            var id = action.ID.ToString().PadRight(idLength);
            var idAndIndentation = string.Format("{0};{1}", id, action.IndentationLevel.HasValue ? action.IndentationLevel.ToString() : string.Empty);

            writer.Write("{{ {0};", idAndIndentation.PadRight(13));
            writer.Indent(writer.Column);
            writer.WriteLine("ActionContainer;");
            action.Properties.Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
        }

        public static void Write(this PageActionGroup action, CSideWriter writer)
        {
            var idLength = Math.Max(action.ID.ToString().Length, 8);
            var id = action.ID.ToString().PadRight(idLength);
            var idAndIndentation = string.Format("{0};{1}", id, action.IndentationLevel.ToString());

            writer.Write("{{ {0};", idAndIndentation.PadRight(13));
            writer.Indent(writer.Column);
            writer.WriteLine("ActionGroup;");
            action.Properties.Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
        }

        public static void Write(this PageAction action, CSideWriter writer)
        {
            var idLength = Math.Max(action.ID.ToString().Length, 8);
            var id = action.ID.ToString().PadRight(idLength);
            var idAndIndentation = string.Format("{0};{1}", id, action.IndentationLevel.ToString());

            writer.Write("{{ {0};", idAndIndentation.PadRight(13));
            writer.Indent(writer.Column);
            writer.WriteLine("Action    ;");
            action.Properties.Write(PropertiesStyle.Field, writer);

            var relevantProperties = action.Properties.Where(p => p.HasValue);
            var lastProperty = relevantProperties.LastOrDefault();
            if (lastProperty != null)
                if (lastProperty is TriggerProperty)
                    writer.Write(new string(' ', 10));

            writer.WriteLine("}");
            writer.Unindent();
        }

        public static void Write(this PageActionSeparator action, CSideWriter writer)
        {
            var idLength = Math.Max(action.ID.ToString().Length, 8);
            var id = action.ID.ToString().PadRight(idLength);
            var idAndIndentation = string.Format("{0};{1}", id, action.IndentationLevel.ToString());

            writer.Write("{{ {0};", idAndIndentation.PadRight(13));
            writer.Indent(writer.Column);
            writer.Write("Separator ");

            var relevantProperties = action.Properties.Where(p => p.HasValue);

            if (relevantProperties.Any())
            {
                writer.WriteLine(";");
                action.Properties.Write(PropertiesStyle.Field, writer);
            }
            else
                writer.Write(" ");

            writer.WriteLine("}");
            writer.Unindent();
        }
    }
}