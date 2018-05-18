using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Page.Action
{
    public class PageActionContainer : PageActionBase
    {
        public PageActionContainer(int? indentationLevel = null, int id = 0, PageActionContainerType? containerType = PageActionContainerType.ActionItems)
            : base(id, indentationLevel)
        {
            Properties = new PageActionContainerProperties(this);
            Properties.ActionContainerType = containerType;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public PageActionContainerProperties Properties
        {
            get;
            protected set;
        }

        public override PageActionType Type
        {
            get
            {
                return PageActionType.ActionContainer;
            }
        }

        public PageActionGroup GetGroupByCaption(IPage page, string caption, Position position)
        {
            var pageActionGroup = Children.OfType<PageActionGroup>().FirstOrDefault(a => a.Properties.CaptionML["ENU"] == caption);

            if (pageActionGroup == null)
            {
                pageActionGroup = new PageActionGroup(indentationLevel: 1);
                pageActionGroup.Properties.CaptionML.Set("ENU", caption);
                AddChildPageAction(pageActionGroup, position);
            }

            return pageActionGroup;
        }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}