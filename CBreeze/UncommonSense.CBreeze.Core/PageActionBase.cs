using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
	// Normally, names for derived types are formed by prefixing the base type
	// name with it's specialisation description, e.g. Parameter -> IntegerParameter.
	// In case of page actions, the base class would be called PageAction, from
	// which e.g. ContainerPageAction would be derived. However, that would make
	// normal page actions ActionPageAction. Instead we'll call the base class
	// PageActionBase, and the derived classes PageActionContainer, PageActionGroup
	// PageActionSeparator and PageAction.

		public abstract class PageActionBase : KeyedItem<int>, IHasName, IHasProperties
	{
		internal PageActionBase(int id, int? indentationLevel)
		{
			ID = id;
			IndentationLevel = indentationLevel;
		}

		public ActionList Container
		{
			get;
			internal set;
		}

		public abstract PageActionBaseType Type
		{
			get;
		}

		public int? IndentationLevel
		{
			get;
			protected set;
		}

		public abstract string GetName();

		public abstract Properties AllProperties
		{
			get;
		}

		public int Index
		{
			get
			{
				return Container.IndexOf(this);
			}
		}

		public IEnumerable<PageActionBase> DescendantPageActions
		{
			get
			{
				return Container.Skip(Index + 1).TakeWhile(a => a.IndentationLevel > IndentationLevel);
			}
		}

		public IEnumerable<PageActionBase> ChildPageActions
		{
			get
			{
				return DescendantPageActions.Where(a => a.IndentationLevel == IndentationLevel + 1);
			}
		}

		public T AddChildPageAction<T>(T child, Position position) where T : PageActionBase
		{
			switch (position)
			{
				case Position.FirstWithinContainer:
					Container.Insert(Index + 1, child);
					break;
				case Position.LastWithinContainer:
					var descendantPageActions = DescendantPageActions;
					var lastIndex = descendantPageActions.Any() ? descendantPageActions.Last().Index : Index;
					Container.Insert(lastIndex + 1, child);
					break;
			}

			return child;
		}
	}
}
