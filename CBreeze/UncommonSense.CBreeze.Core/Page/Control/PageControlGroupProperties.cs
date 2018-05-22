using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Page.Control
{
        public class PageControlGroupProperties : Properties
    {
        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty freezeColumnID = new StringProperty("FreezeColumnID");
        private PageControlGroupTypeProperty groupType = new PageControlGroupTypeProperty("GroupType");
        private StringProperty indentationColumnName = new StringProperty("IndentationColumnName");
        private ControlListProperty indentationControls = new ControlListProperty("IndentationControls");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private PageControlGroupLayoutProperty layout = new PageControlGroupLayoutProperty("Layout");
        private StringProperty name = new StringProperty("Name");
        private NullableBooleanProperty showAsTree = new NullableBooleanProperty("ShowAsTree");
        private StringProperty visible = new StringProperty("Visible");

        internal PageControlGroupProperties(PageControlGroup control)
        {
            Control = control;

            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(editable);
            innerList.Add(indentationColumnName);
            innerList.Add(indentationControls);
            innerList.Add(showAsTree);
            innerList.Add(groupType);
            innerList.Add(instructionalTextML);
            innerList.Add(freezeColumnID);
            innerList.Add(layout);
            innerList.Add(actionList);
        }

        public PageControlGroup Control { get; protected set; }

        public override INode ParentNode => Control;

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

      public string Editable
        {
            get
            {
                return this.editable.Value;
            }
            set
            {
                this.editable.Value = value;
            }
        }

      public string Enabled
        {
            get
            {
                return this.enabled.Value;
            }
            set
            {
                this.enabled.Value = value;
            }
        }

      public string FreezeColumnID
        {
            get
            {
                return this.freezeColumnID.Value;
            }
            set
            {
                this.freezeColumnID.Value = value;
            }
        }

        public PageControlGroupType? GroupType
        {
            get
            {
                return this.groupType.Value;
            }
            set
            {
                this.groupType.Value = value;
            }
        }

      public string IndentationColumnName
        {
            get
            {
                return this.indentationColumnName.Value;
            }
            set
            {
                this.indentationColumnName.Value = value;
            }
        }

        public ControlList IndentationControls
        {
            get
            {
                return this.indentationControls.Value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

        public PageControlGroupLayout? Layout
        {
            get
            {
                return this.layout.Value;
            }
            set
            {
                this.layout.Value = value;
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

      public bool? ShowAsTree
        {
            get
            {
                return this.showAsTree.Value;
            }
            set
            {
                this.showAsTree.Value = value;
            }
        }

      public string Visible
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
