using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Table : Object, IHasCode
    {
        public Table(int id, string name)
            : base(id, name)
        {
            Properties = new TableProperties(this);
            Fields = new TableFields(this);
            Keys = new TableKeys(this);
            FieldGroups = new TableFieldGroups(this);
            Code = new Code(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }

        public Tables Container { get; internal set; }

        public TableProperties Properties
        {
            get;
            protected set;
        }

        public TableFields Fields
        {
            get;
            protected set;
        }

        public TableKeys Keys
        {
            get;
            protected set;
        }

        public TableFieldGroups FieldGroups
        {
            get;
            protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override INode ParentNode
        {
            get
            {
                return Container;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Fields;
                yield return Keys;
                yield return FieldGroups;
                yield return Code;
            }
        }
    }
}
