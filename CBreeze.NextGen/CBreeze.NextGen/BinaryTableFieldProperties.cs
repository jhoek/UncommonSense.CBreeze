using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BinaryTableFieldProperties : Properties
	{
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");

		internal BinaryTableFieldProperties(Node parentNode)
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

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public Trigger OnLookup
        {
            get
            {
                return this.onLookup.Value;
            }
        }

        public Trigger OnValidate
        {
            get
            {
                return this.onValidate.Value;
            }
        }

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
                yield return captionML;
                yield return description;
                yield return onLookup;
                yield return onValidate;
			}
		}
	}
}

