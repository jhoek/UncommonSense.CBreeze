﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionGroup", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageActionGroup))]
    [Alias("ActionGroup", "Add-CBreezePageActionGroup")]
    public class NewCBreezePageActionGroup : NewItemWithIDCmdlet<PageActionBase, int, PSObject>
    {
        [Parameter()] public Hashtable CaptionML { get; set; } 

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock ChildActions { get; set; } 

        [Parameter()] public PageActionContainerType? ContainerType { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public string Image { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public Position? Position { get; set; }
#if NAV2016
        [Parameter()] public Hashtable ToolTipML { get; set; }
#endif
        [Parameter()] public string Visible { get; set; }

        protected override void AddItemToInputObject(PageActionBase item, PSObject inputObject)
        {
            var position = Position.GetValueOrDefault(Core.Property.Enumeration.Position.LastWithinContainer);

            switch (InputObject.BaseObject)
            {
                case PageActionContainer c:
                    c.AddChildPageAction(item, position);
                    break;

                case PageActionGroup g:
                    g.AddChildPageAction(item, position);
                    break;

                case ActionList a:
                    a.AddPageActionAtPosition(item, position);
                    break;

                case IPage p:
                    p.AddPageActionAtPosition(item, position);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<PageActionBase> CreateItems()
        {
            var pageActionGroup = new PageActionGroup(ID, GetIndentation());

            pageActionGroup.Properties.CaptionML.Set(CaptionML);
            pageActionGroup.Properties.ActionContainerType = ContainerType;
            pageActionGroup.Properties.Description = Description;
            pageActionGroup.Properties.Enabled = Enabled;
            pageActionGroup.Properties.Image = Image;
            pageActionGroup.Properties.Name = Name;
#if NAV2016
            pageActionGroup.Properties.ToolTipML.Set(ToolTipML);
#endif
            pageActionGroup.Properties.Visible = Visible;

            yield return pageActionGroup;

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("ActionIndentation", GetIndentation() + 1) };

                var childActions = ChildActions
                    .InvokeWithContext(null, variables)
                    .Select(o => o.BaseObject)
                    .Cast<PageActionBase>();

                foreach (var childAction in childActions)
                {
                    yield return childAction;
                }
            }
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("ActionIndentation", 0)
                : GetParentIndentationLevel() + 1;
        }

        protected int GetParentIndentationLevel()
        {
            switch (InputObject?.BaseObject)
            {
                case PageActionContainer c:
                    return c.IndentationLevel.GetValueOrDefault(0);

                case PageActionGroup g:
                    return g.IndentationLevel.GetValueOrDefault(0);

                default:
                    return 0;
            }
        }
    }
}