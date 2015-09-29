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

            foreach (TableField tableField in tableFields.OrderBy(f => f.ID))
            {
                tableField.Write(writer);
            }

            writer.EndSection();
        }
    }
}
