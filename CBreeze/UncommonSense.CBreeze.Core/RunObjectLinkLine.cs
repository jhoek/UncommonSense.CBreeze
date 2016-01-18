using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class RunObjectLinkLine
    {
        public RunObjectLinkLine(string fieldName, TableFilterType type, string value)
        {
            FieldName = fieldName;
            Type = type;
            Value = value;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public bool? OnlyMaxLimit
        {
            get;
            set;
        }

        public TableFilterType? Type
        {
            get;
            protected set;
        }

        public string Value
        {
            get;
            protected set;
        }

        public bool? ValueIsFilter
        {
            get;
            set;
        }
    }
}
