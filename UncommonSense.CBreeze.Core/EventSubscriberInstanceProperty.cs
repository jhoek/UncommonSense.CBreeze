using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
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
