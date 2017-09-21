using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RecordVariable : Variable
    {
        public RecordVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public RecordVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Record {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public bool? Temporary
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Record;
            }
        }
    }
}