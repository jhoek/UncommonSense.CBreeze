using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public abstract class Parameter : KeyedItem<int>, IHasName
	{
		internal Parameter(bool var, int id, string name)
		{
			ID = id;
			Name = name;
			Var = var;
		}

		public abstract ParameterType Type
		{
			get;
		}

		public bool Var
		{
			get;
			protected set;
		}

		public string Dimensions
		{
			get;
			set;
		}

		public string Name
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
