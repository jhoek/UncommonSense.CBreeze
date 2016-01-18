using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ReportParameter : Parameter
    {
        public ReportParameter(bool var, int id, string name, int subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Report;
            }
        }

        public int SubType
        {
            get;
            protected set;
        }
    }
}
