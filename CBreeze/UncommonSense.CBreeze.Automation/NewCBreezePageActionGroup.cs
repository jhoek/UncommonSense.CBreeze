using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionGroup", DefaultParameterSetName =ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageActionGroup))]
    [Alias("ActionGroup")]
    public class NewCBreezePageActionGroup : NewItemWithIDCmdlet<PageActionBase, int, PSObject>
    {
        protected override IEnumerable<PageActionBase> CreateItems()
        {
            var pageActionGroup = new PageActionGroup(ID, GetIndentation());

            pageActionGroup.Properties.CaptionML.Set("ENU", Caption);
            pageActionGroup.Properties.Description = Description;
            pageActionGroup.Properties.Enabled = Enabled;
            pageActionGroup.Properties.Image = Image;
            pageActionGroup.Properties.Name = Name;
            pageActionGroup.Properties.Visible = Visible;

            yield return pageActionGroup;

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", GetIndentation() + 1) };

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

        protected override void AddItemToInputObject(PageActionBase item, PSObject inputObject)
        {
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

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

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public string Caption
        {
            get; set;
        }

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock ChildActions
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public string Enabled
        {
            get; set;
        }

        [Parameter()]
        public string Image
        {
            get; set;
        }

        [Parameter()]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public string Visible
        {
            get; set;
        }

        [Parameter()]
        public Position? Position
        {
            get; set;
        }

        protected int GetIndentation() => GetParentIndentationLevel() + 1;

        protected int GetParentIndentationLevel()
        {
            switch (InputObject.BaseObject)
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