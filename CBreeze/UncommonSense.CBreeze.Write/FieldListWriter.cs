using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class FieldListWriter
    {
        public static void Write(this FieldList fieldList, CSideWriter writer)
        {
            writer.Write(string.Join(",", fieldList).PadRight(40));
        }
    }
}
