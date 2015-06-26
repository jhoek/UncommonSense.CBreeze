using System;

namespace CBreeze.NextGen
{
	// Normally, names for derived types are formed by prefixing the base type
	// name with it's specialisation description, e.g. Parameter -> IntegerParameter.
	// In case of page actions, the base class would be called PageAction, from
	// which e.g. ContainerPageAction would be derived. However, that would make
	// normal page actions ActionPageAction. Instead we'll call the base class
	// PageActionBase, and the derived classes PageActionContainer, PageActionGroup
	// PageActionSeparator and PageAction.

	public abstract class PageActionBase : Node, IKeyedValue<int>, IEquatable<PageActionBase>
	{
		public PageActionBase(int id, string name, int? indentationLevel)
		{
			ID = id;
			Name = name;
		}

		public int ID
		{
			get;
			internal set;
		}

		public string Name
		{
			get;
			internal set;
		}

		public abstract PageActionType Type
		{
			get;
		}

		public override string ToString()
		{
			return string.Format("Action {0} of type {1}", ID, Type);
		}

		public int GetKey()
		{
			return ID;
		}

		public bool Equals(PageActionBase other)
		{
			if (other == null)
				return false;

			if (other.ID == ID)
				return true;

			if (other.Name == Name)
				return true;

			return false;
		}
	}
}

