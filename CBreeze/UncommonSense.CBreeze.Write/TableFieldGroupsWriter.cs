using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class TableFieldGroupsWriter
    {
        public static void Write(this TableFieldGroups tableFieldGroups, CSideWriter writer)
        {
            writer.BeginSection("FIELDGROUPS");

            foreach (var tableFieldGroup in tableFieldGroups)
            {
                tableFieldGroup.Write(writer);
            }

            writer.EndSection();
        }
    }
}
