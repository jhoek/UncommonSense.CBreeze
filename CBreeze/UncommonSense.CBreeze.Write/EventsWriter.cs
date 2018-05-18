using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code;

namespace UncommonSense.CBreeze.Write
{
    public static class EventsWriter
    {
        public static void Write(this Events events, CSideWriter writer)
        {
            foreach (var @event in events)
            {
                @event.Write(writer);
            }
        }
    }
}
