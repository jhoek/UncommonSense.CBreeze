using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public partial class RegisterEntityTypePattern
    {
        public Table Table
        {
            get;
            protected set;
        }

        public Page Page
        {
            get;
            protected set;
        }

        public IntegerTableField NoField
        {
            get;
            protected set;
        }

        public DateTableField CreationDateField
        {
            get;
            protected set;
        }

        public CodeTableField UserIDField
        {
            get;
            protected set;
        }

        public CodeTableField SourceCodeField
        {
            get;
            protected set;
        }
    }
}
