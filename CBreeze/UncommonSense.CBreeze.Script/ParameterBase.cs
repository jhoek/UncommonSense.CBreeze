using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public abstract class ParameterBase
    {
        public ParameterBase(string name, bool positional)
        {
            Name = name;
            Positional = positional;
        }

        public string Name { get; protected set; }

        public bool Positional { get; protected set; }
    }
}