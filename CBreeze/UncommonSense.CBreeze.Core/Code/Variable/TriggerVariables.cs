using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class TriggerVariables : LocalVariables
    {
        public TriggerVariables(Trigger trigger)
        {
            Trigger = trigger;
        }

        public override INode ParentNode => Trigger;
        public Trigger Trigger { get; protected set; }
    }
}