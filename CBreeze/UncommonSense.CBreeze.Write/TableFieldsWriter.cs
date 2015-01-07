using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class TableFieldsWriter
    {
        public static void Write(this TableFields tableFields, CSideWriter writer)
        {
            writer.BeginSection("FIELDS");

            //var fieldNoWidth = 0;

            //if (tableFields.Any())
            //    fieldNoWidth = Math.Max(tableFields.Max(f => f.No).ToString().Length, 4);

            foreach (TableField tableField in tableFields)
            {
                tableField.Write(writer);
            }

            writer.EndSection();
        }

        public static int RoundUpToNearestTen(this int value)
        {
            return ((value + 10 - 1) / 10) * 10;
        }
    }
}
