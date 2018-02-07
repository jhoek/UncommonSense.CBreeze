using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class RequestPage : IPage, INode
    {
        internal RequestPage(IHasRequestPage container)
        {
            Container = container;

            Properties = new RequestPageProperties(this);
            Properties.ActionList.Page = this;

            Controls = new PageControls(this);
        }

        public ActionList Actions => Properties.ActionList;
        public Application Application => Container.Application;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
            }
        }

        public IHasRequestPage Container { get; }
        public PageControls Controls { get; }
        public int ObjectID => Container.ID;
        public INode ParentNode => Container;
        public RequestPageProperties Properties { get; }
    }
}