using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class MenuSuites : KeyedContainer<int, MenuSuite>
    {
        internal MenuSuites(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "MenuSuites";
        }
    }
}
