using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TextVariable : Variable,IHasDimensions
    {
        public TextVariable(string name, int? dataLength = null) : this(0, name, dataLength)
        {
        }

        public TextVariable(int id, string name, int? dataLength = null)
            : base(id, name)
        {
            DataLength = dataLength;
        }

        public override string TypeName => DataLength.HasValue ? $"Text[{DataLength}]" : "Text";
        public int? DataLength { get; }
        public string Dimensions { get; set; }
        public bool? IncludeInDataset { get; set; }
        public override VariableType Type => VariableType.Text;
    }
}