using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public abstract class TableField : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal TableField(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public TableFields Container { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0}@{1}:{2}", Name, ID, Type);
        }

        public abstract TableFieldType Type
        {
            get;
        }

        public string Name
        {
            get;
            set;
        }

        public string QuotedName
        {
            get
            {
                return Name.Quoted();
            }
        }

        public bool? Enabled
        {
            get;
            set;
        }

        public string GetName()
        {
            return Name;
        }

        public abstract Property.Properties AllProperties
        {
            get;
        }

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}
