using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Page.Action
{
    // Normally, names for derived types are formed by prefixing the base type
    // name with it's specialisation description, e.g. Parameter -> IntegerParameter.
    // In case of page actions, the base class would be called PageAction, from
    // which e.g. ContainerPageAction would be derived. However, that would make
    // normal page actions ActionPageAction. Instead we'll call the base class
    // PageActionBase, and the derived classes PageActionContainer, PageActionGroup
    // PageActionSeparator and PageAction.

    public abstract class PageActionBase : KeyedItem<int>, IHasName, IHasProperties, INode
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

        public abstract PageActionType Type
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

        public IEnumerable<PageActionBase> Descendants => 
            Container.Skip(Index + 1).TakeWhile(a => a.IndentationLevel > (IndentationLevel ?? 0));

        public IEnumerable<PageActionBase> Children => 
            Descendants.Where(a => a.IndentationLevel == (IndentationLevel ?? 0) + 1);

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }

        public T AddChildPageAction<T>(T child, Position position) where T : PageActionBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantPageActions = Descendants;
                    var lastIndex = descendantPageActions.Any() ? descendantPageActions.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
