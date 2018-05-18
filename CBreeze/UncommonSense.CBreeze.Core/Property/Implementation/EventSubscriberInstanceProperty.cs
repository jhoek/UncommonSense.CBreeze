using UncommonSense.CBreeze.Core.Code.Function;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2016
    public class EventSubscriberInstanceProperty : NullableValueProperty<EventSubscriberInstance>
    {
        internal EventSubscriberInstanceProperty(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            switch (Value)
            {
                case EventSubscriberInstance.StaticAutomatic: return "Static-Automatic";
                default: return Value.ToString();
            }   
        }
    }
#endif
}
