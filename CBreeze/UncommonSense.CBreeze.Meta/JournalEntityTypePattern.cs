using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class JournalEntityTypePattern : EntityTypePattern
    {
        public JournalEntityTypePattern(Application application, IEnumerable<int> range, string name)
            : base(application, range, name)
        {

        }
    }
}
