using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public abstract class Object : KeyedItem<int>, IHasName, IHasProperties
	{
		internal Object(int id, string name)
		{
			ID = id;
			Name = name;
			ObjectProperties = new ObjectProperties();
		}

		public string Name
		{
			get;
			set;
		}

		public string VariableName
		{
			get
			{
				return Name.MakeVariableName();
			}
		}

		public abstract ObjectType Type
		{
			get;
		}

		public ObjectProperties ObjectProperties
		{
			get;
			protected set;
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", Type, ID, Name);
		}

		public string GetName()
		{
			return Name;
		}

		public abstract Properties AllProperties
		{
			get;
		}
	}
}
