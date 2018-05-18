using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Extension;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageControlContainer", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageControlContainer))]
    [Alias("ContainerControl", "Add-CBreezePageControlContainer")]
    public class NewCBreezePageControlContainer : NewItemWithIDCmdlet<PageControlBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControlBase item, PSObject inputObject)
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

        protected void AddItemToInputObject(PageControlBase item, IPage page) => AddItemToInputObject(item, page.Controls);

        protected void AddItemToInputObject(PageControlBase item, PageControls pageControls) => pageControls.Add(item, Position);

        protected override IEnumerable<PageControlBase> CreateItems()
        {
            var containerPageControl = new PageControlContainer(ID, 0, ContainerType.GetValueOrDefault(PageControlContainerType.ContentArea));
            containerPageControl.Properties.CaptionML.Set(CaptionML);
            containerPageControl.Properties.Description = Description;
            containerPageControl.Properties.Name = Name;
            containerPageControl.AutoCaption(AutoCaption);
            yield return containerPageControl;

            var variables = new List<PSVariable>() { new PSVariable("ControlIndentation", 1) };
            var subObjects = SubObjects?
                .InvokeWithContext(null, variables)
                .Select(o => o.BaseObject)
                .Cast<PageControlBase>()
                ?? Enumerable.Empty<PageControlBase>();

            foreach (var childControl in subObjects)
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
        public ScriptBlock SubObjects { get; set; }

        [Parameter()] public PageControlContainerType? ContainerType { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        public Position? Position { get; set; }
    }
}