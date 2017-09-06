using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public abstract class Statement
    {
        public string Indentation(int indentation) => new string(' ', indentation * 2);

        public abstract string ToString(int indentation);

        public override string ToString() => ToString(0);
    }
}