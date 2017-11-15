using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePartPageControl", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PartPageControl))]
    [Alias("PartControl", "Add-CBreezePartPageControl")]
    public class NewCBreezePartPageControl : NewItemWithIDCmdlet<PageControlBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControlBase item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case IPage p:
                    p.Controls.Add(item, Position);
                    break;

                case ContainerPageControl c:
                    c.AddChildPageControl(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                case GroupPageControl g:
                    g.AddChildPageControl(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                case PageControls c:
                    c.Add(item, Position);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected override IEnumerable<PageControlBase> CreateItems()
        {
            var partPageControl = new PartPageControl(ID, GetIndentation());
            partPageControl.Properties.AccessByPermission.Set(AccessByPermission);
            partPageControl.Properties.CaptionML.Set(CaptionML);
            partPageControl.Properties.Description = Description;
            partPageControl.Properties.Editable = Editable;
            partPageControl.Properties.Enabled = Enabled;
            partPageControl.Properties.Name = Name;

            if (ChartPartID != null)
            {
                partPageControl.Properties.PartType = PartType.Chart;
                partPageControl.Properties.ChartPartID = ChartPartID;
            }
            else if (PagePartID != null)
            {
                partPageControl.Properties.PartType = PartType.Page;
                partPageControl.Properties.PagePartID = PagePartID;
            }
            else if (SystemPartID != null)
            {
                partPageControl.Properties.PartType = PartType.System;
                partPageControl.Properties.SystemPartID = SystemPartID;
            }

            partPageControl.Properties.ProviderID = ProviderID;
            partPageControl.Properties.ShowFilter = NullableBooleanFromSwitch(nameof(ShowFilter));
            partPageControl.Properties.SubPageView.Key = SubPageViewKey;
            partPageControl.Properties.SubPageView.Order = SubPageViewOrder;
#if NAV2015
            partPageControl.Properties.UpdatePropagation = UpdatePropagation;
#endif
            partPageControl.Properties.Visible = Visible;
            partPageControl.AutoCaption(AutoCaption);

            yield return partPageControl;
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("Indentation", 0)
                : GetParentIndentation() + 1;
        }

        protected int GetParentIndentation()
        {
            return InputObject.BaseObject is PageControlBase
                ? (InputObject.BaseObject as PageControlBase).IndentationLevel.GetValueOrDefault(0)
                : 0;
        }

        [Parameter()] public AccessByPermission AccessByPermission { get; set; }
        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string ChartPartID { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public Position? Position { get; set; }
        [Parameter()] public int? PagePartID { get; set; }
        [Parameter()] public int? ProviderID { get; set; }
        [Parameter()] public SwitchParameter ShowFilter { get; set; }
        [Parameter()] public string SubPageViewKey { get; set; }
        [Parameter()] public Order? SubPageViewOrder { get; set; }
        [Parameter()] public SystemPartID? SystemPartID { get; set; }
#if NAV2015
        [Parameter()] public UpdatePropagation? UpdatePropagation { get; set; }
#endif
        [Parameter()] public string Visible { get; set; }
    }
}