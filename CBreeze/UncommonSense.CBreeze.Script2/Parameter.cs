using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public abstract class Parameter
    {
        public Parameter(string name)
        {
            Name = name;
        }

        public abstract bool HasValue { get; }
        public string Name { get; protected set; }
        public abstract bool OnSameLine { get; }
    }
}