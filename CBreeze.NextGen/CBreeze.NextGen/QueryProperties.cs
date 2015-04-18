using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class QueryProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        internal QueryProperties(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Properties";
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return captionML;
            }
        }
    }
}
