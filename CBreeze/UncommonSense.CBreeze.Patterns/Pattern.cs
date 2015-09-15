using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Patterns
{
    public abstract class Pattern
    {
        protected abstract void VerifyRequirements();
        protected abstract void MakeChanges();

        public void Apply()
        {
            VerifyRequirements();
            MakeChanges();
        }
    }
}
