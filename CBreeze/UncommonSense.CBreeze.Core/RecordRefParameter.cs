using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class RecordRefParameter : Parameter
    {
        public RecordRefParameter(bool var, int id, string name)
            : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.RecordRef;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }
    }
}
