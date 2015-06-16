using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class AutomationParameter : Parameter
    {
        public AutomationParameter(int uid, string name, string subType)
            : base(uid, name)
        {
            SubType = subType;
        }

        public string SubType
        {
            get;
            internal set;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Automation;
            }
        }
    }
}
