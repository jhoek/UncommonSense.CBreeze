using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;

namespace UncommonSense.CBreeze.Meta
{
    public partial class DocumentEntityTypePattern
    {
        public Table HeaderTable
        {
            get;
            protected set;
        }

        public Table LineTable
        {
            get;
            protected set;
        }

        public MappedResults<string, Page> CardPages
        {
            get;protected set;
        }

        public MappedResults<string, Page> ListPages
        {
            get;protected set;
        }
    }
}
