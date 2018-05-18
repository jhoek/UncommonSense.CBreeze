using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Write
{
    public static class QueryElementsWriter
    {
        public static void Write(this QueryElements queryElements, CSideWriter writer)
        {
            writer.BeginSection("ELEMENTS");

            foreach (var queryElement in queryElements)
            {
                queryElement.Write(writer);
            }

            writer.EndSection();
        }
    }
}
