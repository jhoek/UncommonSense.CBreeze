using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class EventParameters : Parameters
    {
        internal EventParameters(Event @event)
        {
            Event = @event;
        }

        public Event Event { get; protected set; }
        public override IEnumerable<int> ExistingIDs => this.Select(p => p.ID).Concat(Event.Variables.Select(v => v.ID));
        public override INode ParentNode => Event;
    }
}