using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class TagListProperty : ReferenceProperty<TagList>
    {
        internal TagListProperty(string name)
            : base(name) { }

        public override bool HasValue => Value.Any();
    }
}
