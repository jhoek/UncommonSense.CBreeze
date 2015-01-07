using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class FieldListWriter
    {
        public static void Write(this FieldList fieldList, CSideWriter writer)
        {
            writer.Write(string.Join(",", fieldList.Select(f=>f.FieldName)).PadRight(40));
        }
    }
}
