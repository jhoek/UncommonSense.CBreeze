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

        public OptionTableField HeaderTableDocumentTypeField
        {
            get;
            protected set;
        }

        public CodeTableField HeaderTableNoField
        {
            get;
            protected set;
        }

        public OptionTableField LineTableDocumentTypeField
        {
            get;
            protected set;
        }

        public CodeTableField LineTableDocumentNoField
        {
            get;
            protected set;
        }

        public IntegerTableField LineTableLineNoField
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
