using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016

    public class TextEncodingVariable : Variable,IHasDimensions
    {
        public TextEncodingVariable(string name) : this(0, name)
        {
        }

        public TextEncodingVariable(int id, string name) : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TextEncoding;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }

#endif
}