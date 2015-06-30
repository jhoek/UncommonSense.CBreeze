using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
    public static class ItemWriter
    {
        public static void WriteToFolder(this Item item, string folderName)
        {
            var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName);
            @class.AddConstructor(item);
            @class.OverrideToString(item);
            @class.WriteTo(Path.Combine(folderName, @class.FileName));
        }

        public static void AddConstructor(this Class @class, Item item)
        {
            var ctor = new Constructor(Visibility.Public, item.Name, null, null);

            foreach (var childNode in item.Attributes.OfType<ChildNode>())
            {
                ctor.CodeBlock.Statements.AddFormat("{0} = new {1}(this);", childNode.Name, childNode.TypeName);
            }

            @class.Constructors.Add(ctor);
        }

        public static void OverrideToString(this Class @class, Item item)
        {
            var method = new Method(Visibility.Public, "ToString", "string", null);
            method.CodeBlock.Statements.AddFormat("return \"{0}\";", item.Name);
            @class.Methods.Add(method);
        }
    }
}
