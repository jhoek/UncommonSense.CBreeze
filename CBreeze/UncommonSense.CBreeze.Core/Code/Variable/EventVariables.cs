using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class EventVariables : LocalVariables
    {
        internal EventVariables(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; protected set; }
        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID).Concat(Event.Parameters.Select(p => p.ID));
        public override INode ParentNode => Event;
    }
}