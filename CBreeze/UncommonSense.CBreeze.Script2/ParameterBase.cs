using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public abstract class ParameterBase
    {
        public ParameterBase(string name)
        {
            Name = name;
        }

        public abstract bool HasValue { get; }
        public string Name { get; protected set; }

        public string Indentation(int indentation) => new string(' ', indentation * 2);

        public override string ToString() => ToString(0);

        public abstract string ToString(int indentation);
    }
}