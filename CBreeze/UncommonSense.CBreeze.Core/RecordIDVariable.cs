using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class RecordIDVariable : Variable
    {
        public RecordIDVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.RecordID;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
