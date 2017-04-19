using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class OptionParameter : Parameter, IHasOptionString
    {
        public OptionParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public string OptionString
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.Option;

        public string GetOptionString()
        {
            return OptionString;
        }
    }
}