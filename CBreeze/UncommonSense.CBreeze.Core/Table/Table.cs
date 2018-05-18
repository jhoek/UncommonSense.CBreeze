using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Key;

namespace UncommonSense.CBreeze.Core.Table
{
    public class Table : Object, IHasCode
    {
        public Table(string name) : this(0, name)
        {
        }

        public Table(int id, string name)
            : base(id, name)
        {
            Properties = new TableProperties(this);
            Fields = new TableFields(this);
            Keys = new TableKeys(this);
            FieldGroups = new TableFieldGroups(this);
            Code = new Code.Variable.Code(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public Application Application => Container?.Application;

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

        public Code.Variable.Code Code
        {
            get;
            protected set;
        }

        public Tables Container { get; internal set; }

        public TableFieldGroups FieldGroups
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

        public override INode ParentNode
        {
            get
            {
                return Container;
            }
        }

        public TableProperties Properties
        {
            get;
            protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }
    }
}