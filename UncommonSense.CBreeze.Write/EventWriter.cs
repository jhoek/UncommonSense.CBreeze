using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class EventWriter
    {
        public static void Write(this Event @event, CSideWriter writer)
        {
            writer.InnerWriter.WriteLine();

            writer.Write("EVENT {0}@{1}::{2}@{3}(", @event.SourceName, @event.SourceID, @event.Name, @event.ID);
            @event.Parameters.Write(writer);
            writer.WriteLine(");");
            @event.Variables.Write(writer);
            writer.WriteLine("BEGIN");
            writer.Indent();
            @event.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");
        }
    }
}
