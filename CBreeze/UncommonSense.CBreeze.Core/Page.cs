using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Page : Object, IHasCode, IPage
    {
        public Page(string name) : this(0, name)
        {
        }

        public Page(int id, string name)
            : base(id, name)
        {
            Properties = new PageProperties(this);
            Properties.ActionList.Page = this;
            Controls = new PageControls(this);
            Code = new Code(this);
        }

        public ActionList Actions => Properties.ActionList;
        public override Properties AllProperties => Properties;
        public Application Application => Container?.Application;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
                yield return Code;
            }
        }

        public Code Code
        {
            get;
            protected set;
        }

        public Pages Container { get; internal set; }

        public PageControls Controls
        {
            get;
            protected set;
        }

        public int ObjectID
        {
            get
            {
                return ID;
            }
        }

        public override INode ParentNode => Container;

        public PageProperties Properties
        {
            get;
            protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Page;
            }
        }
    }
}