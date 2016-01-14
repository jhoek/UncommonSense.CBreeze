using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class OptionVariable : Variable, IHasOptionString
    {
        public OptionVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Option;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string OptionString
        {
            get;
            set;
        }


        public string GetOptionString()
        {
            return OptionString;
        }
    }
}
