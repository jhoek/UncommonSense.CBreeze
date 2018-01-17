using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RecordRefVariable : Variable,IHasDimensions
    {
        public RecordRefVariable(string name) : this(0, name)
        {
        }

        public RecordRefVariable(int id, string name)
            : base(id, name)
        {
        }

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

        public override VariableType Type
        {
            get
            {
                return VariableType.RecordRef;
            }
        }
    }
}