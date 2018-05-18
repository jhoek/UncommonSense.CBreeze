using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class TableFieldGroup : KeyedItem<int>, IHasName, INode
    {
        public const string Brick = "Brick";
        public const string DropDown = "DropDown";

        public TableFieldGroup(string name) : this(0, name, new string[] { })
        {
        }

        public TableFieldGroup(int id, string name) : this(id, name, new string[] { })
        {
        }

        public TableFieldGroup(string name, params string[] fieldNames) : this(0, name, fieldNames)
        {
        }

        public TableFieldGroup(int id, string name, params string[] fieldNames)
        {
            ID = id;
            Name = name;
            Fields = new FieldList(fieldNames);
            Properties = new TableFieldGroupProperties(this);
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public TableFieldGroups Container { get; internal set; }

        public FieldList Fields
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;

        public TableFieldGroupProperties Properties
        {
            get;
            protected set;
        }

        public string GetName()
        {
            return Name;
        }
    }
}