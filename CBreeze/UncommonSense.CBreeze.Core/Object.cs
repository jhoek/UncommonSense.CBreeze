// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public abstract partial class Object : KeyedItem<int>, IHasName, IHasProperties
	{
		private ObjectProperties objectProperties = new ObjectProperties();

		internal Object(int id, string name)
		{
			ID = id;
			Name = name;
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
			get
			{
				return this.objectProperties;
			}
		}

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Type, ID, Name);
        }

		public  string GetName()
		{
			return Name;
		}

		public abstract Properties AllProperties
		{
			get;
		}
	}
}
