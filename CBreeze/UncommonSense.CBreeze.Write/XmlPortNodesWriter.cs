using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Write
{
    public static class XmlPortNodesWriter
    {
        internal static string BuildNodePart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

        public static void Write(this XmlPortNodes xmlPortNodes, CSideWriter writer)
        {
            writer.BeginSection("ELEMENTS");

            foreach (var xmlPortNode in xmlPortNodes)
            {
                xmlPortNode.Write(writer);
            }

            writer.EndSection();
        }

        public static void Write(this XmlPortNode xmlPortNode, CSideWriter writer)
        {
            TypeSwitch.Do(
                xmlPortNode,
                TypeSwitch.Case<XmlPortTextElement>(n => n.Write(writer)),
                TypeSwitch.Case<XmlPortTextAttribute>(n => n.Write(writer)),
                TypeSwitch.Case<XmlPortTableElement>(n => n.Write(writer)),
                TypeSwitch.Case<XmlPortTableAttribute>(n => n.Write(writer)),
                TypeSwitch.Case<XmlPortFieldElement>(n => n.Write(writer)),
                TypeSwitch.Case<XmlPortFieldAttribute>(n => n.Write(writer))
                );
        }

        public static void WriteDeclaration(Guid id, string name, int? indentation, string nodeType, string sourceType, bool anyRelevantProperties, CSideWriter writer)
        {
            var debt = 0;

            var nodeID = BuildNodePart(id.ToString("B").ToUpper(), 38, ref debt);
            var nodeIndentation = BuildNodePart(indentation.AsString(), 2, ref debt);
            var nodeName = BuildNodePart(name, 20, ref debt);
            var nodeTypeText = BuildNodePart(nodeType, 8, ref debt);
            var sourceTypeText = BuildNodePart(sourceType, 8, ref debt);

            var declaration1 = string.Format("{{ [{0}];{1};", nodeID, nodeIndentation);
            var declaration2 = string.Format("{0};{1};{2}", nodeName, nodeTypeText, sourceTypeText);

            writer.Write(declaration1);
            writer.Indent(writer.Column);
            writer.Write(declaration2);
            writer.WriteLineIf(anyRelevantProperties, ";");
            writer.WriteIf(!anyRelevantProperties, " ");
        }

        public static string IndentationAfterLastTrigger(IEnumerable<Property> relevantProperties)
        {
            var result = string.Empty;
            var lastProperty = relevantProperties.LastOrDefault();

            if (lastProperty != null)
            {
                TypeSwitch.Do(
                    lastProperty,
                    TypeSwitch.Case<ScopedTriggerProperty>(p => result = new string(' ', p.ScopedName().Length + 2)),
                    TypeSwitch.Case<TriggerProperty>(p => result = new string(' ', p.Name.Length + 2)));
            }

            return result;
        }

        public static void Write(this XmlPortTextElement xmlPortTextElement, CSideWriter writer)
        {
            var relevantProperties = xmlPortTextElement.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortTextElement.ID, xmlPortTextElement.NodeName, xmlPortTextElement.IndentationLevel, "Element", "Text", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this XmlPortTextAttribute xmlPortTextAttribute, CSideWriter writer)
        {
            var relevantProperties = xmlPortTextAttribute.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortTextAttribute.ID, xmlPortTextAttribute.NodeName, xmlPortTextAttribute.IndentationLevel, "Attribute", "Text", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this XmlPortTableElement xmlPortTableElement, CSideWriter writer)
        {
            var relevantProperties = xmlPortTableElement.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortTableElement.ID, xmlPortTableElement.NodeName, xmlPortTableElement.IndentationLevel, "Element", "Table", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this XmlPortTableAttribute xmlPortTableAttribute, CSideWriter writer)
        {
            var relevantProperties = xmlPortTableAttribute.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortTableAttribute.ID, xmlPortTableAttribute.NodeName, xmlPortTableAttribute.IndentationLevel, "Attribute", "Table", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this XmlPortFieldElement xmlPortFieldElement, CSideWriter writer)
        {
            var relevantProperties = xmlPortFieldElement.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortFieldElement.ID, xmlPortFieldElement.NodeName, xmlPortFieldElement.IndentationLevel, "Element", "Field", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this XmlPortFieldAttribute xmlPortFieldAttribute, CSideWriter writer)
        {
            var relevantProperties = xmlPortFieldAttribute.Properties.Where(p => p.HasValue);
            WriteDeclaration(xmlPortFieldAttribute.ID, xmlPortFieldAttribute.NodeName, xmlPortFieldAttribute.IndentationLevel, "Attribute", "Field", relevantProperties.Any(), writer);
            relevantProperties.Write(PropertiesStyle.Field, writer);
            writer.Write(IndentationAfterLastTrigger(relevantProperties));
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }
    }
}
