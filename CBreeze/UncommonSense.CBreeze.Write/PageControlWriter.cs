﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class PageControlWriter
    {
        internal static string BuildControlPart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

        public static void Write(this PageControlBase pageControl, CSideWriter writer, int propertyIndentation)
        {
            TypeSwitch.Do(
                pageControl,
                TypeSwitch.Case<PageControlContainer>(c => c.Write(writer, propertyIndentation)),
                TypeSwitch.Case<PageControlGroup>(c => c.Write(writer, propertyIndentation)),
                TypeSwitch.Case<PageControlPart>(c => c.Write(writer, propertyIndentation)),
                TypeSwitch.Case<PageControl>(c => c.Write(writer, propertyIndentation)));
        }

        public static void Write(this PageControlContainer containerPageControl, CSideWriter writer, int propertyIndentation)
        {
            var debt = 0;
            var controlID = BuildControlPart(containerPageControl.ID.ToString(), 4, ref debt);
            var controlIndentation = BuildControlPart(containerPageControl.IndentationLevel.AsString(), 4, ref debt);
            var controlType = BuildControlPart("Container", 10, ref debt);
            var declaration = string.Format("{{ {0};{1};{2};", controlID, controlIndentation, controlType);

            writer.WriteLine(declaration);

            writer.Indent(propertyIndentation);
            containerPageControl.Properties.Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this PageControlGroup groupPageControl, CSideWriter writer, int propertyIndentation)
        {
            var debt = 0;
            var controlID = BuildControlPart(groupPageControl.ID.ToString(), 4, ref debt);
            var controlIndentation = BuildControlPart(groupPageControl.IndentationLevel.AsString(), 4, ref debt);
            var controlType = BuildControlPart("Group", 10, ref debt);
            var declaration = string.Format("{{ {0};{1};{2}", controlID, controlIndentation, controlType);

            writer.Write(declaration);

            if (groupPageControl.Properties.Any(p => p.HasValue))
            {
                writer.WriteLine(";");
                writer.Indent(propertyIndentation);
                groupPageControl.Properties.Write(PropertiesStyle.Field, writer);
                writer.Unindent();
            }
            else
            {
                writer.Write(" ");
            }

            //var idLength = Math.Max(groupPageControl.ID.ToString().Length, 4);
            //var id = groupPageControl.ID.ToString().PadRight(idLength);
            //var idAndIndentation = string.Format("{0};{1}", id, groupPageControl.IndentationLevel.ToString()).PadRight(9);
            //var idAndIndentationAndType = string.Format("{0};Group", idAndIndentation);

            //writer.WriteLine("{{ {0};", idAndIndentationAndType.PadRight(20));

            if (groupPageControl.Properties.Where(p => p.HasValue).LastOrDefault() is ActionListProperty)
                writer.Write(new string(' ', 13));

            writer.WriteLine("}");
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this PageControlPart partPageControl, CSideWriter writer, int propertyIndentation)
        {
            var debt = 0;
            var controlID = BuildControlPart(partPageControl.ID.ToString(), 4, ref debt);
            var controlIndentation = BuildControlPart(partPageControl.IndentationLevel.AsString(), 4, ref debt);
            var controlType = BuildControlPart("Part", 10, ref debt);
            var declaration = string.Format("{{ {0};{1};{2};", controlID, controlIndentation, controlType);
            writer.WriteLine(declaration);


            //var idLength = Math.Max(partPageControl.ID.ToString().Length, 4);
            //var id = partPageControl.ID.ToString().PadRight(idLength);
            //var idAndIndentation = string.Format("{0};{1}", id, partPageControl.IndentationLevel.ToString());
            //var idAndIndentationAndType = string.Format("{{ {0};Part", idAndIndentation.PadRight(9));

            //writer.WriteLine("{0};", idAndIndentationAndType.PadRight(22));

            writer.Indent(propertyIndentation);
            partPageControl.Properties.Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this PageControl fieldPageControl, CSideWriter writer, int propertyIndentation)
        {
            var debt = 0;
            var controlID = BuildControlPart(fieldPageControl.ID.ToString(), 4, ref debt);
            var controlIndentation = BuildControlPart(fieldPageControl.IndentationLevel.AsString(), 4, ref debt);
            var controlType = BuildControlPart("Field", 10, ref debt);
            var relevantProperties = fieldPageControl.Properties.Where(p => p.HasValue);

            switch (relevantProperties.Any())
            {
                case false:
                    writer.WriteLine("{{ {0};{1};{2} }}", controlID, controlIndentation, controlType);
                    break;
                default:
                    writer.WriteLine("{{ {0};{1};{2};", controlID, controlIndentation, controlType);

                    writer.Indent(propertyIndentation);
                    fieldPageControl.Properties.Write(PropertiesStyle.Field, writer);

                    var lastProperty = relevantProperties.LastOrDefault();
                    if (lastProperty != null)
                        if (lastProperty is TriggerProperty)
                            writer.Write(new string(' ', lastProperty.Name.Length + 2));

                    writer.WriteLine("}");
                    writer.Unindent();
                    break;
            }

            writer.InnerWriter.WriteLine();
        }
    }
}
