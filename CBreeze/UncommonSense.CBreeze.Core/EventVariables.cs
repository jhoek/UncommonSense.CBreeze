using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class EventVariables : LocalVariables
    {
        internal EventVariables(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; protected set; }
        public override INode ParentNode => Event;
    }
}