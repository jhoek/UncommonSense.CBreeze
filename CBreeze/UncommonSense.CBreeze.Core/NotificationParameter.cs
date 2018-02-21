﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2017
    public class NotificationParameter : Parameter
    {
        public NotificationParameter(string name, bool var = false, int id = 0)
            : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.Notification;
    }
#endif
}
