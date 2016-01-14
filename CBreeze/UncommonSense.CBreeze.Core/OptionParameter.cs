using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class OptionParameter : Parameter, IHasOptionString
    {
        public OptionParameter(bool var, int id, string name)
            : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Option;
            }
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
