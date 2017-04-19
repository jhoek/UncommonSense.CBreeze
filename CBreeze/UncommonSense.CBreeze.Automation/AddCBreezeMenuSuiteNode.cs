using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeMenuSuiteNode")]
    public class AddCBreezeMenuSuiteNode : NewCBreezeMenuSuiteNode
    {
        protected DynamicParameter<MenuSuiteNode> insertAfterNode = new DynamicParameter<MenuSuiteNode>("InsertAfterNode");
        protected DynamicParameter<MenuSuite> menuSuite = new DynamicParameter<MenuSuite>("MenuSuite", true, true);
        protected DynamicParameter<SwitchParameter> passthru = new DynamicParameter<SwitchParameter>("PassThru");

        protected override void ProcessRecord()
        {
            var guid = Guid.NewGuid();

            if (!menuSuite.Value.Nodes.Any())
            {
                var deltaNode = menuSuite.Value.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = guid;
            }

            var node =
                (insertAfterNode.Value == null) ?
                menuSuite.Value.Nodes.Add(CreateNode(guid)) :
                menuSuite.Value.Nodes.Insert(insertAfterNode.Value.Index + 1, CreateNode(guid));

            if (passthru.Value)
                WriteObject(node);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                yield return menuSuite.RuntimeDefinedParameter;

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
