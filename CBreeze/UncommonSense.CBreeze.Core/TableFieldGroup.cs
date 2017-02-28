using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class TableFieldGroup : KeyedItem<int>, IHasName, INode
	{
		public TableFieldGroup(int id, string name)
		{
			ID = id;
			Name = name;
			Fields = new FieldList();
			Properties = new TableFieldGroupProperties(this);
		}

		public string Name
		{
			get;
			protected set;
		}

		public FieldList Fields
		{
			get;
			protected set;
		}

		public TableFieldGroupProperties Properties
		{
			get;
			protected set;
		}

        public TableFieldGroups Container { get; internal set; }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public string GetName()
		{
			return Name;
		}
	}
}
