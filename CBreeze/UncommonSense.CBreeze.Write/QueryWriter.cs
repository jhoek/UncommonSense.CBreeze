using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Write
{
    public static class QueryWriter
    {
        public static void Write(this Query query, CSideWriter writer)
        {
            writer.BeginSection(query.GetObjectSignature());
            query.ObjectProperties.Write(writer);
            query.Properties.Write(writer);
            query.Elements.Write(writer);
            query.Code.Write(writer);
            writer.EndSection();
            writer.InnerWriter.WriteLine();
        }
    }
}
