using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Page
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
            Code = new Code.Variable.Code(this);
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

        public Code.Variable.Code Code { get; }
        public Pages Container { get; internal set; }
        public PageControls Controls { get; }
        public int ObjectID => ID;
        public override INode ParentNode => Container;
        public PageProperties Properties { get; }
        public override ObjectType Type => ObjectType.Page;
    }
}