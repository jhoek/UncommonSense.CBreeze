using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class EventParameters : Parameters
    {
        internal EventParameters(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; protected set; }

        public override INode ParentNode => Event;
    }
}