using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class BooleanVariable : Variable
    {
        public BooleanVariable(int uid, string name) : base(uid, name)
        {
        }

        public bool? IncludeInDataset
        {
            get;
            set;
        }
    }
}
