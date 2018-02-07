using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class TableKey : INode
    {
        public TableKey(params string[] fieldNames)
        {
            Fields = new FieldList();
            Properties = new TableKeyProperties(this);

            Fields.AddRange(fieldNames);
        }

        public override string ToString()
        {
            return string.Join(",", Fields);
        }

        public TableKeys Container
        {
            get; internal set;
        }

        public bool? Enabled
        {
            get;
            set;
        }

        public FieldList Fields
        {
            get;
            protected set;
        }

        public TableKeyProperties Properties
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}
