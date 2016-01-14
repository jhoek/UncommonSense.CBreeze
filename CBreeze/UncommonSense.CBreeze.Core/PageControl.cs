using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public abstract partial class PageControl : KeyedItem<int>, IHasName, IHasProperties
	{
		internal PageControl(int id, int? indentationLevel)
		{
			ID = id;
			IndentationLevel = indentationLevel;
		}

		public PageControls Container
		{
			get;
			internal set;
		}

		public abstract PageControlType Type
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

		public IEnumerable<PageControl> DescendantPageControls
		{
			get
			{
				return Container.Skip(Index + 1).TakeWhile(c => c.IndentationLevel > IndentationLevel);
			}
		}

		public IEnumerable<PageControl> ChildPageControls
		{
			get
			{
				return DescendantPageControls.Where(c => c.IndentationLevel == IndentationLevel + 1);
			}
		}

		public PageControl ParentPageControl
		{
			get
			{
				return Container.Where(c => c.IndentationLevel == IndentationLevel - 1).Where(c => c.Index < Index).Last();
			}
		}

		public T AddChildPageControl<T>(T child, Position position) where T : PageControl
		{
			switch (position)
			{
				case Position.FirstWithinContainer:
					Container.Insert(Index + 1, child);
					break;
				case Position.LastWithinContainer:
					var descendantPageControls = DescendantPageControls;
					var lastIndex = descendantPageControls.Any() ? descendantPageControls.Last().Index : Index;
					Container.Insert(lastIndex + 1, child);
					break;
			}

			return child;
		}
	}
}
