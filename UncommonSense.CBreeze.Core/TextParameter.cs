using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TextParameter : Parameter
    {
        public TextParameter(string name, bool var = false, int id = 0, int? dataLength = null) : base(name, var, id)
        {
            DataLength = dataLength;
        }

        public int? DataLength
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Text;

        public override string TypeName
        {
            get
            {
                var dataLength = DataLength.HasValue ? $"[{DataLength.Value}]" : string.Empty;
                return $"Text{dataLength}";
            }
        }
    }
}