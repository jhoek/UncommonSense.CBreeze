﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Extension;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Table.Field;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageControlPart", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageControlPart))]
    [Alias("PartControl", "Add-CBreezePageControlPart")]
    public class NewCBreezePageControlPart : NewItemWithIDCmdlet<PageControlBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControlBase item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case IPage p:
                    p.Controls.Add(item, Position);
                    break;

                case PageControlContainer c:
                    c.AddChildPageControl(item, Position.GetValueOrDefault(Core.Property.Enumeration.Position.LastWithinContainer));
                    break;

                case PageControlGroup g:
                    g.AddChildPageControl(item, Position.GetValueOrDefault(Core.Property.Enumeration.Position.LastWithinContainer));
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
            var partPageControl = new PageControlPart(ID, GetIndentation());
#if NAV2015
            partPageControl.Properties.AccessByPermission.Set(AccessByPermission);
#endif
#if NAV2017
            partPageControl.Properties.ApplicationArea.Set(ApplicationArea);
#endif
            partPageControl.Properties.CaptionML.Set(CaptionML);
            partPageControl.Properties.Description = Description;
            partPageControl.Properties.Editable = Editable;
            partPageControl.Properties.Enabled = Enabled;
            partPageControl.Properties.Name = Name;
            partPageControl.Properties.PartType = PartType;

            if (ChartPartID != null)
            {
                partPageControl.Properties.PartType = PageControlPartType.Chart;
                partPageControl.Properties.ChartPartID = ChartPartID;
            }
            else if (PagePartID != null)
            {
                // If PartType has been assigned a value explicitly, overwrite
                // that value with "Page". If previously, PartType was null,
                // leave the value as is.
                if (partPageControl.Properties.PartType.HasValue)
                    partPageControl.Properties.PartType = PageControlPartType.Page;
                partPageControl.Properties.PagePartID = PagePartID;
            }
            else if (SystemPartID != null)
            {
                partPageControl.Properties.PartType = PageControlPartType.System;
                partPageControl.Properties.SystemPartID = SystemPartID;
            }

            partPageControl.Properties.ProviderID = ProviderID;
            partPageControl.Properties.ShowFilter = NullableBooleanFromSwitch(nameof(ShowFilter));
            partPageControl.Properties.SubPageView.Key = SubPageViewKey;
            partPageControl.Properties.SubPageView.Order = SubPageViewOrder;
            partPageControl.Properties.ToolTipML.Set(ToolTipML);
#if NAV2015
            partPageControl.Properties.UpdatePropagation = UpdatePropagation;
#endif
            partPageControl.Properties.Visible = Visible;
            partPageControl.AutoCaption(AutoCaption);

            var subObjects = SubObjects?.Invoke().Select(o => o.BaseObject) ?? Enumerable.Empty<object>();
            partPageControl.Properties.SubPageLink.AddRange(subObjects.OfType<RunObjectLinkLine>());
            partPageControl.Properties.SubPageView.TableFilter.AddRange(subObjects.OfType<TableFilterLine>());

            yield return partPageControl;
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("ControlIndentation", 0)
                : GetParentIndentation() + 1;
        }

        protected int GetParentIndentation()
        {
            return InputObject.BaseObject is PageControlBase
                ? (InputObject.BaseObject as PageControlBase).IndentationLevel.GetValueOrDefault(0)
                : 0;
        }

#if NAV2015
        [Parameter()] public AccessByPermission AccessByPermission { get; set; }
#endif
#if NAV2017
        [Parameter()] public string[] ApplicationArea { get; set; }
#endif
        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string ChartPartID { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public PageControlPartType? PartType { get; set; }
        [Parameter()] public Position? Position { get; set; }
        [Parameter()] public int? PagePartID { get; set; }
        [Parameter()] public int? ProviderID { get; set; }
        [Parameter()] public SwitchParameter ShowFilter { get; set; }
        [Parameter()] public ScriptBlock SubObjects { get; set; }
        [Parameter()] public string SubPageViewKey { get; set; }
        [Parameter()] public Order? SubPageViewOrder { get; set; }
        [Parameter()] public SystemPartID? SystemPartID { get; set; }
        [Parameter()] public Hashtable ToolTipML { get; set; }
#if NAV2015
        [Parameter()] public UpdatePropagation? UpdatePropagation { get; set; }
#endif
        [Parameter()] public string Visible { get; set; }
    }
}