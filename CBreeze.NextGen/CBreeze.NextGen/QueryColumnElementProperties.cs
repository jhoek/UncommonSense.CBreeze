using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class QueryColumnElementProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        // FIXME: More properties!

        internal QueryColumnElementProperties(Node parentNode)
            : base(parentNode)
        {
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
            set
            {
                this.captionML.Value = value;
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
