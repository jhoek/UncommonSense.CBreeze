using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableKeyProperties : Properties
    {
        private NullableBoolProperty clustered = new NullableBoolProperty("Clustered");

        internal TableKeyProperties(Node parentNode)
            : base(parentNode)
        {

        }

        public override string ToString()
        {
            return "Properties";
        }

        public bool? Clustered
        {
            get
            {
                return this.clustered.Value;
            }
            set
            {
                this.clustered.Value = value;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return clustered;
            }
        }
    }
}
