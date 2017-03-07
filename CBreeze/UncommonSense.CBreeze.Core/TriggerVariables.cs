using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class TriggerVariables : LocalVariables
    {
        public TriggerVariables(Trigger trigger)
        {
            Trigger = trigger;
        }

        public override INode ParentNode => Trigger;
        public Trigger Trigger { get; protected set; }
        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Trigger.ID);
    }
}