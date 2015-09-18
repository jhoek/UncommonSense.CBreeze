using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Patterns;

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

        public MappedResults<Page, FieldPageControl> NoControls
        {
            get;
            protected set;
        }

        public MappedResults<Table, IntegerTableField> FromEntryNoFields
        {
            get;
            protected set;
        }

        public MappedResults<Table, FieldPageControl> FromEntryNoControls
        {
            get;
            protected set;
        }

        public MappedResults<Table, IntegerTableField> ToEntryNoFields
        {
            get;
            protected set;
        }

        public MappedResults<Table, FieldPageControl> ToEntryNoControls
        {
            get;
            protected set;
        }

        public DateTableField CreationDateField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> CreationDateControls
        {
            get;
            protected set;
        }

        public CodeTableField UserIDField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> UserIDControls
        {
            get;
            protected set;
        }

        public CodeTableField SourceCodeField
        {
            get;
            protected set;
        }

        public MappedResults<Page, FieldPageControl> SourceCodeControls
        {
            get;
            protected set;
        }

    }
}
