using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
    public static class ContainerWriter
    {
        public static void WriteToFolder(this Container container, string folderName)
        {
            var @class = new Class(Visibility.Public, container.Name); // FIXME: What should base class be?
            @class.WriteTo(Path.Combine(folderName, @class.FileName));
        }
    }
}
