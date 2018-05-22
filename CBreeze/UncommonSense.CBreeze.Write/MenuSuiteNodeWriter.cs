using System;
using System.Linq;
using UncommonSense.CBreeze.Core;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class MenuSuiteNodeWriter
    {
        public static void Write(this MenuSuiteNode node, CSideWriter writer)
        {
            writer.Write("{ ");
            writer.Write(node.NodeTypeAsString());
            writer.Write(";");
            writer.Write("[{0}] ", node.ID.ToString("B").ToUpper());
            writer.Write(";");

            writer.Indent(writer.Column);

            IEnumerable<Property> properties = null;

            TypeSwitch.Do(
                node,
                TypeSwitch.Case<RootNode>(n => properties = n.Properties),
                TypeSwitch.Case<MenuNode>(n => properties = n.Properties),
                TypeSwitch.Case<GroupNode>(n => properties = n.Properties),
                TypeSwitch.Case<ItemNode>(n => properties = n.Properties),
                TypeSwitch.Case<DeltaNode>(n => properties = n.Properties)
                );

            var relevantProperties = properties.Where(p => p.HasValue);
            relevantProperties.Write(PropertiesStyle.Field, writer);

            writer.Unindent();
            writer.WriteLine("}");
        }

        public static string NodeTypeAsString(this MenuSuiteNode node)
        {
            string result = null;

            TypeSwitch.Do(
                node,
                TypeSwitch.Case<RootNode>(n => result = "Root".PadRight(15)),
                TypeSwitch.Case<MenuNode>(n => result = "Menu".PadRight(15)),
                TypeSwitch.Case<GroupNode>(n => result = "MenuGroup".PadRight(15)),
                TypeSwitch.Case<ItemNode>(n => result = "MenuItem".PadRight(15)),
                TypeSwitch.Case<DeltaNode>(n => result = string.Empty.PadRight(15))
            );

            return result;
        }
    }
}

