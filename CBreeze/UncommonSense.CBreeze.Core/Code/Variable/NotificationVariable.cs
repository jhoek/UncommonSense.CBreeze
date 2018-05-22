﻿using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2017
    public class NotificationVariable : Variable,IHasDimensions
    {
        public NotificationVariable(string name) : this(0, name) { }
        public NotificationVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.Notification;
    }
#endif
}
