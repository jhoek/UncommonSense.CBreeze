using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableKeys : INode
    {
        private List<TableKey> innerList = new List<TableKey>();

        internal TableKeys(Node parentNode)
            : base(parentNode)
        {
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                foreach (var item in innerList)
                {
                    yield return item;
                }
            }
        }
    }
}
