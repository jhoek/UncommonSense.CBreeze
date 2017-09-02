using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script3
{
    public abstract class Statement
    {
        public abstract void WriteTo(ScriptWriter writer);
    }
}