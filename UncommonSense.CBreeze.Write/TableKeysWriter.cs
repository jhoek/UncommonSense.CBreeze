using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class TableKeysWriter
    {
        public static void Write(this TableKeys tableKeys, CSideWriter writer)
        {
            writer.BeginSection("KEYS");

            foreach (var tableKey in tableKeys)
            {
                tableKey.Write(writer);
            }

            writer.EndSection();
        }
    }
}
