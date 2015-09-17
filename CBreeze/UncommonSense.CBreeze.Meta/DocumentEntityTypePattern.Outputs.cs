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

        public ReadOnlyDictionary<string, Page> CardPages
        {
            get
            {
                return cardPages.AsReadOnly();
            }
        }

        public ReadOnlyDictionary<string, Page> ListPages
        {
            get
            {
                return listPages.AsReadOnly();
            }
        }
    }
}
