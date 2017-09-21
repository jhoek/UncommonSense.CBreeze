using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class ReportVariable : Variable
    {
        public ReportVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public ReportVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Report {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Report;
            }
        }
    }
}