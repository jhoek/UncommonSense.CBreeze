using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class MenuSuiteGroupNodeProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");
        private NullableBooleanProperty isDepartmentPage = new NullableBooleanProperty("IsDepartmentPage");
        private NullableGuidProperty memberOfMenu = new NullableGuidProperty("MemberOfMenu");
        private StringProperty name = new StringProperty("Name");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");
        private NullableGuidProperty parentNodeID = new NullableGuidProperty("ParentNodeID");
        private NullableBooleanProperty visible = new NullableBooleanProperty("Visible");

        internal MenuSuiteGroupNodeProperties(GroupNode node)
        {
            Node = node;

            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(memberOfMenu);
            innerList.Add(parentNodeID);
            innerList.Add(visible);
            innerList.Add(nextNodeID);
            innerList.Add(firstChild);
            innerList.Add(isDepartmentPage);
            innerList.Add(deleted);
        }

        public GroupNode Node { get; protected set; }

        public override INode ParentNode => Node;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public bool? Deleted
        {
            get => this.deleted.Value;
            set => this.deleted.Value = value;
        }

        public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }

        public bool? IsDepartmentPage
        {
            get
            {
                return this.isDepartmentPage.Value;
            }
            set
            {
                this.isDepartmentPage.Value = value;
            }
        }

        public System.Guid? MemberOfMenu
        {
            get
            {
                return this.memberOfMenu.Value;
            }
            set
            {
                this.memberOfMenu.Value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

        public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

        public System.Guid? ParentNodeID
        {
            get
            {
                return this.parentNodeID.Value;
            }
            set
            {
                this.parentNodeID.Value = value;
            }
        }

        public bool? Visible
        {
            get
            {
                return this.visible.Value;
            }
            set
            {
                this.visible.Value = value;
            }
        }
    }
}
