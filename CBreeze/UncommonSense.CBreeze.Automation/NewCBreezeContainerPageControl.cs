using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeContainerPageControl", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(ContainerPageControl))]
    [Alias("ContainerControl")]
    public class NewCBreezeContainerPageControl : NewItemWithIDCmdlet<PageControl, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControl item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case PageControls c:
                    AddItemToInputObject(item, c);
                    break;

                case IPage p:
                    AddItemToInputObject(item, p);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected void AddItemToInputObject(PageControl item, IPage page) => AddItemToInputObject(item, page.Controls);

        protected void AddItemToInputObject(PageControl item, PageControls pageControls) => pageControls.Add(item, Position);

        protected override IEnumerable<PageControl> CreateItems()
        {
            var containerPageControl = new ContainerPageControl(ID, 0, ContainerType.GetValueOrDefault(Core.ContainerType.ContentArea));
            containerPageControl.Properties.CaptionML.Set(CaptionML);
            containerPageControl.Properties.Description = Description;
            containerPageControl.Properties.Name = Name;
            containerPageControl.AutoCaption(AutoCaption);
            yield return containerPageControl;

            var variables = new List<PSVariable>() { new PSVariable("Indentation", 1) };
            var childControls = ChildControls?
                .InvokeWithContext(null, variables)
                .Select(o => o.BaseObject)
                .Cast<PageControl>()
                ?? Enumerable.Empty<PageControl>();

            foreach (var childControl in childControls)
            {
                yield return childControl;
            }
        }

        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock ChildControls { get; set; }

        [Parameter()] public ContainerType? ContainerType { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        public Position? Position { get; set; }
    }
}