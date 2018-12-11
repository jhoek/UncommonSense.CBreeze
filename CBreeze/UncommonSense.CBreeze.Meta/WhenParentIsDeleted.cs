using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Meta
{
    public enum WhenParentIsDeleted
    {
        DoNothing,
        AlsoDeleteChildren,
        ErrorIfChildrenExist,
        ClearReferenceToParent
    }
}
