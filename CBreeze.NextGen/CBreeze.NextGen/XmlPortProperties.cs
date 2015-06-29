using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class XmlPortProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableValueProperty<bool> defaultFieldsValidation = new NullableValueProperty<bool>("DefaultFieldsValidation");
        private StringProperty defaultNamespace = new StringProperty("DefaultNamespace");

        internal XmlPortProperties(Node parentNode)
            : base(parentNode)
        {
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public bool? DefaultFieldsValidation
        {
            get
            {
                return this.defaultFieldsValidation.Value;
            }
            set
            {
                this.defaultFieldsValidation.Value = value;
            }
        }

        public string DefaultNamespace
        {
            get
            {
                return this.defaultNamespace.Value;
            }
            set
            {
                this.defaultNamespace.Value = value;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return captionML;
                yield return defaultFieldsValidation;
                yield return defaultNamespace;
                // FIXME: Rest
            }
        }
    }
}
