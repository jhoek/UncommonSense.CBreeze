using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Patterns
{
    public abstract class Pattern
    {
        public abstract void VerifyRequirements();

        public virtual void Apply()
        {
            VerifyRequirements();
        }
    }
}
