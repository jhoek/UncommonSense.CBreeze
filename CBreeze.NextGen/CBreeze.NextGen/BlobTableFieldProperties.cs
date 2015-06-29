using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BlobTableFieldProperties : Properties
	{
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableValueProperty<bool> compressed = new NullableValueProperty<bool>("Compressed");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty owner = new StringProperty("Owner");
        private NullableValueProperty<BlobSubType> subType = new NullableValueProperty<BlobSubType>("SubType");
        private NullableValueProperty<bool> @volatile = new NullableValueProperty<bool>("Volatile");

		internal BlobTableFieldProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
                yield return captionML;
                yield return compressed;
                yield return description;
                yield return onLookup;
                yield return onValidate;
                yield return owner;
                yield return subType;
                yield return @volatile;
			}
		}
	}
}

