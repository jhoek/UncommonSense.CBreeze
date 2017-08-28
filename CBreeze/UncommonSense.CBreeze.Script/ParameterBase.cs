using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public abstract class ParameterBase
    {
        public ParameterBase(string name, bool isPositional)
        {
            Name = name;
            IsPositional = isPositional;
        }

        public bool IsPositional { get; protected set; }
        public string Name { get; protected set; }

        public abstract IEnumerable<string> ToScriptLines(int indentation = 0, bool useAlias = false, bool usePositionalParameters = false);
    }
}