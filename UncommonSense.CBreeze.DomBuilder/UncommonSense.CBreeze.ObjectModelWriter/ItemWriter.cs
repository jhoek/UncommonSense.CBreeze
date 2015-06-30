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

            @class.WriteTo(Path.Combine(folderName, @class.FileName));
        }
    }
}
