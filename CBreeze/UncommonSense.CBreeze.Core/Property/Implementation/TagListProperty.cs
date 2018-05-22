using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2017
    public class TagListProperty : ReferenceProperty<TagList>
    {
        internal TagListProperty(string name)
            : base(name) { }

        public override bool HasValue => Value.Any();
    }
#endif
}
