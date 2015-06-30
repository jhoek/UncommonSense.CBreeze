using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CSharp;
using UncommonSense.CBreeze.ObjectModelBuilder;
using System.IO;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
    public static class EnumerationWriter
    {
        public static void WriteToFolder(this Enumeration enumeration, string folderName)
        {
            var @enum = new UncommonSense.CSharp.Enum(Visibility.Public, enumeration.Name, IntegralType.None);

            foreach (var value in enumeration.Values)
            {
                @enum.Values.Add(new EnumValue(value));
            }

            @enum.WriteTo(Path.Combine(folderName, @enum.FileName));
        }
    }
}
