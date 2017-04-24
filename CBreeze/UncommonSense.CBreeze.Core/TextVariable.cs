using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TextVariable : Variable
    {
        public TextVariable(string name, int? dataLength = null) : this(0, name, dataLength)
        {
        }

        public TextVariable(int id, string name, int? dataLength = null)
            : base(id, name)
        {
            DataLength = dataLength;
        }

        public int? DataLength
        {
            get;
            protected set;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public bool? IncludeInDataset
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Text;
            }
        }
    }
}