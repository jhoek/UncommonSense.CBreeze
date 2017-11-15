using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionContainer", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageActionContainer))]
    [Alias("ActionContainer", "Add-CBreezePageActionContainer")]
    public class NewCBreezePageActionContainer : NewItemWithIDCmdlet<PageActionBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageActionBase item, PSObject inputObject)
        {
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            switch (InputObject.BaseObject)
            {
                case IPage p:
                    p.AddPageActionAtPosition(item, position);
                    break;

                case ActionList a:
                    a.AddPageActionAtPosition(item, position);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<PageActionBase> CreateItems()
        {
            var pageActionContainer = new PageActionContainer(0, ID, ContainerType.GetValueOrDefault(Core.PageActionContainerType.ActionItems));
            pageActionContainer.Properties.Description = Description;
            pageActionContainer.Properties.Name = Name;
            pageActionContainer.Properties.ToolTipML.Set(ToolTipML);

            yield return pageActionContainer;

            if (ChildActions != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", 1) };
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

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock ChildActions
        {
            get; set;
        }

        [Parameter()]
        public PageActionContainerType? ContainerType
        {
            get; set;
        }

        [Parameter()]
        public string Description
        {
            get; set;
        }

        [Parameter()]
        public string Name
        {
            get; set;
        }

        [Parameter()]
        public Position? Position
        {
            get; set;
        }

        [Parameter()]
        public Hashtable ToolTipML { get; set; }
    }
}