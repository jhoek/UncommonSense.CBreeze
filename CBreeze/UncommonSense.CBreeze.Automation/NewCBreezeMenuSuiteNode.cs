using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeMenuSuiteNode")]
    public class NewCBreezeMenuSuiteNode : CmdletWithDynamicParams
    {
        protected DynamicParameter<string> caption = new DynamicParameter<string>("Caption", true);
        protected DynamicParameter<bool?> deleted = new DynamicParameter<bool?>("Deleted");
        protected DynamicParameter<MenuItemDepartmentCategory?> departmentCategory = new DynamicParameter<MenuItemDepartmentCategory?>("DepartmentCategory", true);
        protected DynamicParameter<bool?> enabled = new DynamicParameter<bool?>("Enabled");
        protected DynamicParameter<Guid?> firstChild = new DynamicParameter<Guid?>("FirstChild");
        protected DynamicParameter<int?> image = new DynamicParameter<int?>("Image", minRange: 0, maxRange: 15);
        protected DynamicParameter<bool?> isDepartmentPage = new DynamicParameter<bool?>("IsDepartmentPage");
        protected DynamicParameter<bool?> isShortcut = new DynamicParameter<bool?>("IsShortcut");
        protected DynamicParameter<Guid?> memberOfMenu = new DynamicParameter<Guid?>("MemberOfMenu");
        protected DynamicParameter<string> name = new DynamicParameter<string>("Name");
        protected DynamicParameter<Guid?> nextNodeID = new DynamicParameter<Guid?>("NextNodeID");
        protected DynamicParameter<Guid?> parentNodeID = new DynamicParameter<Guid?>("ParentNodeID");
        protected DynamicParameter<MenuItemRunObjectType?> runObjectType = new DynamicParameter<MenuItemRunObjectType?>("RunObjectType", true);
        protected DynamicParameter<int?> runObjectID = new DynamicParameter<int?>("RunObjectID", true, minRange: 1, maxRange: int.MaxValue);
        protected DynamicParameter<bool?> visible = new DynamicParameter<bool?>("Visible");

        [Parameter(Mandatory = true, Position = 0)]
        public MenuSuiteNodeType Type
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateNode(Guid.NewGuid()));
        }

        protected MenuSuiteNode CreateNode(Guid guid)
        {
            switch (Type)
            {
                case MenuSuiteNodeType.Root:
                    var rootNode = new RootNode(guid);
                    rootNode.Properties.FirstChild = firstChild.Value;
                    return rootNode;

                case MenuSuiteNodeType.Delta:
                    var deltaNode = new DeltaNode(guid);
                    deltaNode.Properties.Deleted = deleted.Value;
                    deltaNode.Properties.NextNodeID = nextNodeID.Value;
                    return deltaNode;

                case MenuSuiteNodeType.Menu:
                    var menuNode = new MenuNode(guid);
                    menuNode.Properties.CaptionML.Set("ENU", caption.Value);
                    menuNode.Properties.Enabled = enabled.Value ?? true;
                    menuNode.Properties.FirstChild = firstChild.Value;
                    menuNode.Properties.Image = image.Value;
                    menuNode.Properties.IsShortcut = isShortcut.Value ?? false;
                    menuNode.Properties.MemberOfMenu = memberOfMenu.Value ?? menuNode.ID;
                    menuNode.Properties.Name = name.Value ?? caption.Value;
                    menuNode.Properties.NextNodeID = nextNodeID.Value ?? Guid.Empty;
                    menuNode.Properties.ParentNodeID = parentNodeID.Value ?? Guid.Empty;
                    menuNode.Properties.Visible = visible.Value ?? true;
                    return menuNode;

                case MenuSuiteNodeType.MenuGroup:
                    var groupNode = new GroupNode(guid);
                    groupNode.Properties.CaptionML.Set("ENU", caption.Value);
                    groupNode.Properties.FirstChild = firstChild.Value;
                    groupNode.Properties.IsDepartmentPage = isDepartmentPage.Value;
                    groupNode.Properties.MemberOfMenu = memberOfMenu.Value;
                    groupNode.Properties.Name = name.Value;
                    groupNode.Properties.NextNodeID = nextNodeID.Value;
                    groupNode.Properties.ParentNodeID = parentNodeID.Value;
                    groupNode.Properties.Visible = visible.Value ?? true;
                    return groupNode;

                case MenuSuiteNodeType.MenuItem:
                    var itemNode = new ItemNode(guid);
                    itemNode.Properties.CaptionML.Set("ENU", caption.Value);
                    itemNode.Properties.Deleted = deleted.Value;
                    itemNode.Properties.DepartmentCategory = departmentCategory.Value;
                    itemNode.Properties.MemberOfMenu = memberOfMenu.Value;
                    itemNode.Properties.Name = name.Value;
                    itemNode.Properties.NextNodeID = nextNodeID.Value;
                    itemNode.Properties.ParentNodeID = parentNodeID.Value;
                    itemNode.Properties.RunObjectType = runObjectType.Value;
                    itemNode.Properties.RunObjectID = runObjectID.Value;
                    itemNode.Properties.Visible = visible.Value;
                    return itemNode;

                default:
                    throw new ArgumentOutOfRangeException("Type");
            }
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case MenuSuiteNodeType.Root:
                        yield return firstChild.RuntimeDefinedParameter;
                        break;

                    case MenuSuiteNodeType.Delta:
                        yield return deleted.RuntimeDefinedParameter;
                        yield return nextNodeID.RuntimeDefinedParameter;
                        break;

                    case MenuSuiteNodeType.Menu:
                        yield return caption.RuntimeDefinedParameter;
                        yield return enabled.RuntimeDefinedParameter;
                        yield return firstChild.RuntimeDefinedParameter;
                        yield return image.RuntimeDefinedParameter;
                        yield return isShortcut.RuntimeDefinedParameter;
                        yield return memberOfMenu.RuntimeDefinedParameter;
                        yield return name.RuntimeDefinedParameter;
                        yield return nextNodeID.RuntimeDefinedParameter;
                        yield return parentNodeID.RuntimeDefinedParameter;
                        yield return visible.RuntimeDefinedParameter;
                        break;

                    case MenuSuiteNodeType.MenuGroup:
                        yield return caption.RuntimeDefinedParameter;
                        yield return firstChild.RuntimeDefinedParameter;
                        yield return isDepartmentPage.RuntimeDefinedParameter;
                        yield return memberOfMenu.RuntimeDefinedParameter;
                        yield return name.RuntimeDefinedParameter;
                        yield return nextNodeID.RuntimeDefinedParameter;
                        yield return parentNodeID.RuntimeDefinedParameter;
                        yield return visible.RuntimeDefinedParameter;
                        break;

                    case MenuSuiteNodeType.MenuItem:
                        yield return caption.RuntimeDefinedParameter;
                        yield return deleted.RuntimeDefinedParameter;
                        yield return departmentCategory.RuntimeDefinedParameter;
                        yield return memberOfMenu.RuntimeDefinedParameter;
                        yield return name.RuntimeDefinedParameter;
                        yield return nextNodeID.RuntimeDefinedParameter;
                        yield return parentNodeID.RuntimeDefinedParameter;
                        yield return runObjectType.RuntimeDefinedParameter;
                        yield return runObjectID.RuntimeDefinedParameter;
                        yield return visible.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
